using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WarehouseMA.DAL
{
    public class GiaHanDAL
    {
        // sheet gia hạn
        private SheetsService dichVuSheets;
        private string ketNoi = "server = sql5.freesqldatabase.com;Database = sql5742970; Uid = sql5742970;Pwd = BPHD48Fx7i; Charset = utf8mb4";

        public void KhoiTaoGoogleSheets()
        {
            try
            {
                string[] Scopes = { SheetsService.Scope.Spreadsheets };
                var clientSecrets = new ClientSecrets
                {
                    ClientId = "YOUR_GOOGLE_CLIENT_ID",
                    ClientSecret = "GOOGLE_CLIENT_SECRET"
                };

                var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    clientSecrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore("MyAppsToken")
                ).Result;

                dichVuSheets = new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Google Sheets API .NET Quickstart",
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi khởi tạo Google Sheets API: " + ex.Message);
            }
        }

        //Sheet yêu cầu khách hàng:
        public void LayDuLieuSheet()
        {
            try
            {
                // Đọc dữ liệu từ Google Sheets
                var phamVi = "Gia hạn!A1:F";
                var yeuCau = dichVuSheets.Spreadsheets.Values.Get("12y_jPnAqZCq66V3qHd0vSltn4JWELiFjD6d0SFnZyN4", phamVi);
                var phanHoi = yeuCau.Execute();
                IList<IList<object>> giaTri = phanHoi.Values;

                if (giaTri == null || giaTri.Count == 0)
                {
                    Console.WriteLine("Không có dữ liệu trong Google Sheets.");
                    return;
                }

                using (MySqlConnection conn = new MySqlConnection(ketNoi))
                {
                    conn.Open();
                    List<int> rowsToDelete = new List<int>();
                    for (int i = 1; i < giaTri.Count; i++)
                    {
                        var hang = giaTri[i];
                        TryParseDateTime(hang[0].ToString(), out DateTime thoiGianNhap);
                        string email = hang[1].ToString();
                        string maYC = hang[2].ToString();
                        string cCCD = hang[3].ToString().TrimStart('\'');
                        string[] temSo = hang[4].ToString().TrimStart('\'').Split('_');
                        TryParseDateTime(hang[5].ToString(), out DateTime thoiGianGiaHanTiep);

                        if (!string.IsNullOrEmpty(maYC))
                        {
                            // Kiểm tra mã yêu cầu trong cơ sở dữ liệu
                            string lenh = "SELECT COUNT(*) FROM YeuCauKhachHang WHERE MaYC = @MaYC";
                            MySqlCommand cmdCheck = new MySqlCommand(lenh, conn);
                            cmdCheck.Parameters.AddWithValue("@MaYC", maYC);
                            int count = Convert.ToInt32(cmdCheck.ExecuteScalar());

                            if (count > 0)
                            {
                                // Tăng số lần gia hạn
                                string lenhUpdate = "UPDATE YeuCauKhachHang SET SolanGiaHan = SolanGiaHan + 1 WHERE MaYC = @MaYC AND TrangThaiXuLy = 'Đã nhập hàng' ";
                                MySqlCommand cmdUpdate = new MySqlCommand(lenhUpdate, conn);
                                cmdUpdate.Parameters.AddWithValue("@MaYC", maYC);
                                cmdUpdate.ExecuteNonQuery();
                                Console.WriteLine($"Đã tăng số lần gia hạn cho Mã YC: {maYC}");
                                rowsToDelete.Add(i);

                                // cập nhật thùng
                                string lenhThung = "SELECT COUNT(*) FROM Thung WHERE MaYC = @MaYC AND TrangThai = 1";
                                MySqlCommand cmdCheckThung = new MySqlCommand(lenhThung, conn);
                                cmdCheckThung.Parameters.AddWithValue("@MaYC", maYC);
                                int countThung = Convert.ToInt32(cmdCheckThung.ExecuteScalar());

                                if (countThung > 0)
                                {
                                    foreach (var tem in temSo)
                                    {
                                        // Kiểm tra từng tem số trong bảng Thung
                                        string lenhCheckTem = "SELECT COUNT(*) FROM Thung WHERE MaYC = @MaYC AND TemSo = @TemSo AND TrangThai = 1";
                                        MySqlCommand cmdCheckTem = new MySqlCommand(lenhCheckTem, conn);
                                        cmdCheckTem.Parameters.AddWithValue("@MaYC", maYC);
                                        cmdCheckTem.Parameters.AddWithValue("@TemSo", tem);
                                        int countTem = Convert.ToInt32(cmdCheckTem.ExecuteScalar());

                                        if (countTem > 0)
                                        {
                                            // Cập nhật trạng thái hoặc thông tin liên quan đến tem
                                            string lenhUpdateTem = "UPDATE Thung SET NgayGiaHan = @NgayGiaHanM  WHERE MaYC = @MaYC AND TemSo = @TemSo";
                                            MySqlCommand cmdUpdateTem = new MySqlCommand(lenhUpdateTem, conn);
                                            cmdUpdateTem.Parameters.AddWithValue("@MaYC", maYC);
                                            cmdUpdateTem.Parameters.AddWithValue("@TemSo", tem);
                                            cmdUpdateTem.Parameters.AddWithValue("@NgayGiaHanM", thoiGianGiaHanTiep);
                                            cmdUpdateTem.ExecuteNonQuery();
                                            Console.WriteLine($"Đã cập nhật thông tin cho tem: {tem}");
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Tem số {tem} không tồn tại trong bảng Thung hoặc trạng thái không hợp lệ.");
                                        }
                                    }
                                    // gửi mail gia hạn
                                    GuiEmailThongBao(maYC);
                                }
                                else
                                {
                                    Console.WriteLine($"Không có thùng nào liên quan đến Mã YC: {maYC} trong trạng thái hợp lệ.");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Mã YC: {maYC} không tồn tại trong cơ sở dữ liệu.");
                            }

                        }

                    }
                    XoaHangGoogleSheet(rowsToDelete);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi Gia Hạn DAL: " + ex.Message);
            }
        }
        public void XoaHangGoogleSheet(List<int> rowsToDelete)
        {
            if (rowsToDelete.Count > 0)
            {
                try
                {
                    var batchUpdateRequest = new BatchUpdateSpreadsheetRequest
                    {
                        Requests = new List<Request>()
                    };

                    rowsToDelete.Reverse();
                    foreach (var rowIndex in rowsToDelete)
                    {
                        var deleteRequest = new Request
                        {
                            DeleteDimension = new DeleteDimensionRequest
                            {
                                Range = new DimensionRange
                                {
                                    SheetId = 1557015368,
                                    /*SheetId = id,*/
                                    Dimension = "ROWS",
                                    StartIndex = rowIndex,
                                    EndIndex = rowIndex + 1
                                }
                            }
                        };
                        batchUpdateRequest.Requests.Add(deleteRequest);
                    }

                    var batchUpdate = dichVuSheets.Spreadsheets.BatchUpdate(batchUpdateRequest, "12y_jPnAqZCq66V3qHd0vSltn4JWELiFjD6d0SFnZyN4");
                    batchUpdate.Execute();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi xóa hàng từ Google Sheets Gia Hạn: " + ex.Message);
                }
            }
        }
        public bool TryParseDateTime(string dateString, out DateTime dateTime)
        {
            string[] dateTimeFormats = { "dd/MM/yyyy HH:mm:ss", "dd/MM/yyyy H:mm:ss", "dd/MM/yyyy HH:mm", "dd/MM/yyyy H:mm" };
            return DateTime.TryParseExact(dateString, dateTimeFormats, null, System.Globalization.DateTimeStyles.None, out dateTime);
        }
        // gửi mail
        public (string Email, string TenKhachHang, DateTime NgayDangKy,int soLanGiaHan, 
        DateTime NgayHetHan, int DungTich, List<(string Tem, string MoTa, DateTime? NgayGiaHan)> DanhSachThung) LayThongTinYC(string maYeuCau)
        {
            string emailNguoiNhan = "";
            string tenKhachHang = "";
            DateTime ngayDangKy = DateTime.MinValue;
            int dungtich = 0;
            DateTime ngayHetHan = DateTime.MinValue;
            int soLanGiaHan = 0;
            List<(string Tem, string MoTa, DateTime? NgayGiaHan)> danhSachThung = new List<(string Tem, string MoTa, DateTime? NgayGiaHan)>();

            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();

                    // Truy vấn thông tin khách hàng và yêu cầu
                    string queryYC = @"
                SELECT y.MaYC, y.TrangThaiXuLy, y.NgayYeuCau, y.SoLuongThungS, y.SoLuongThungM, y.SoLuongThungL, 
                       y.DungTich, y.NgayHetHan,y.SolanGiaHan ,k.TenKH, k.Email
                FROM YeuCauKhachHang y
                INNER JOIN KhachHang k ON y.CCCD = k.CCCD
                WHERE y.MaYC = @maYeuCau";

                    using (MySqlCommand cmd = new MySqlCommand(queryYC, conn))
                    {
                        cmd.Parameters.AddWithValue("@maYeuCau", maYeuCau);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                emailNguoiNhan = reader["Email"].ToString();
                                tenKhachHang = reader["TenKH"].ToString();
                                ngayDangKy = reader.GetDateTime(reader.GetOrdinal("NgayYeuCau"));
                                ngayHetHan = reader.GetDateTime(reader.GetOrdinal("NgayHetHan"));
                                dungtich = reader.GetInt32(reader.GetOrdinal("DungTich"));
                                soLanGiaHan = reader.GetInt32(reader.GetOrdinal("SolanGiaHan"));
                            }
                        }
                    }

                    // Truy vấn danh sách thùng liên quan đến mã yêu cầu
                    string queryThung = @"
                SELECT TemSo, MoTaHangHoa, NgayGiaHan
                FROM Thung
                WHERE MaYC = @maYeuCau AND TrangThai = 1";

                    using (MySqlCommand cmdThung = new MySqlCommand(queryThung, conn))
                    {
                        cmdThung.Parameters.AddWithValue("@maYeuCau", maYeuCau);

                        using (var readerThung = cmdThung.ExecuteReader())
                        {
                            while (readerThung.Read())
                            {
                                string tem = readerThung["TemSo"].ToString();
                                string moTa = readerThung["MoTaHangHoa"].ToString();
                                DateTime? ngayGiaHan = readerThung["NgayGiaHan"] == DBNull.Value
                                    ? (DateTime?)null
                                    : readerThung.GetDateTime(readerThung.GetOrdinal("NgayGiaHan"));

                                danhSachThung.Add((tem, moTa, ngayGiaHan));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi lấy thông tin yêu cầu: " + ex.Message);
                }
            }

            return (emailNguoiNhan, tenKhachHang, ngayDangKy, soLanGiaHan, ngayHetHan, dungtich, danhSachThung);
        }

        private void GuiEmailThongBao(string maYC)
        {
            try
            {
                // Lấy thông tin yêu cầu và danh sách thùng
                var thongTinYC = LayThongTinYC(maYC);

                // Kiểm tra nếu thông tin yêu cầu không hợp lệ
                if (thongTinYC.Email == null || thongTinYC.DanhSachThung.Count == 0)
                {
                    Console.WriteLine($"Không thể gửi email vì thông tin yêu cầu hoặc danh sách thùng rỗng cho Mã YC: {maYC}");
                    return;
                }

                string smtpServer = "smtp.gmail.com";
                int smtpPort = 587;
                string emailGui = "letiendat2004.it@gmail.com";
                string matKhau = "ywan znrs wagl dpyt";

                using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
                {
                    smtpClient.Credentials = new NetworkCredential(emailGui, matKhau);
                    smtpClient.EnableSsl = true;

                    // Chuẩn bị nội dung danh sách thùng
                    string noiDungThung = string.Join("\n", thongTinYC.DanhSachThung.Select(x =>
                        $"- Tem: {x.Tem}, Mô tả: {x.MoTa}, Ngày gia hạn: {x.NgayGiaHan:dd-MM-yyyy HH:mm:ss}"));

                    // Nội dung email
                    string chuDe = $"[# {maYC}] Gia hạn gửi đồ";
                    string noiDung = $@"
Xin chào {thongTinYC.TenKhachHang},

Dịch vụ Warehouse MA thông báo đã hoàn tất gia hạn đơn hàng theo mã yêu cầu #{maYC}.

Thông tin cụ thể như sau:
        - Ngày đăng ký: {thongTinYC.NgayDangKy:dd-MM-yyyy HH:mm:ss}
        - Ngày hết hạn: {thongTinYC.NgayHetHan:dd-MM-yyyy HH:mm:ss}
        - Số lần gia hạn: {thongTinYC.soLanGiaHan}
        - Tình trạng xử lý: Gia Hạn Thành Công
        - Ngày xử lý đơn gia hạn: {DateTime.Now:dd-MM-yyyy HH:mm:ss}

Chi tiết thùng gia hạn:
{noiDungThung}

Đây là Email được gửi tự động từ Hệ thống.
Quý khách không cần phải hồi đáp cho Email này.
Quý khách có thể liên hệ với chúng tôi theo thông tin sau:
Bộ phận Dịch vụ WarehouseMA
Email: support@warehousema.com
Tell: 123-456-7890
";

                    // Tạo và gửi email
                    MailMessage mailMessage = new MailMessage(emailGui, thongTinYC.Email, chuDe, noiDung);
                    smtpClient.Send(mailMessage);
                    Console.WriteLine($"Đã gửi email thông báo tới: {thongTinYC.Email}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi gửi email: {ex.Message}");
            }
        }

    }
}
