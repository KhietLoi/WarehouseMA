using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using iText.Layout;
using iText.Layout.Properties;
using iText.Kernel.Pdf.Canvas.Draw;
using System.Net.Mail;
using System.Net;

namespace WarehouseMA.DAL
{
    public class QuanLyDonHangDAL
    {
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

        public DataTable LayDuLieuSheetYCKH()
        {
            try
            {
                // Đọc dữ liệu từ Google Sheets
                var phamVi = "Dữ liệu chung!A1:E";
                var yeuCau = dichVuSheets.Spreadsheets.Values.Get("1rjeLYWplaCnfIyrLphyVykEPIJaodOzdhES0L8JMnNg", phamVi);
                var phanHoi = yeuCau.Execute();
                IList<IList<object>> giaTri = phanHoi.Values;

                if (giaTri == null || giaTri.Count == 0)
                {
                    Console.WriteLine("Không có dữ liệu trong Google Sheets.");
                    return null;
                }

                // Tạo DataTable để chứa dữ liệu
                DataTable table = new DataTable();

                // Thêm cột vào DataTable từ hàng đầu tiên (tiêu đề)
                var tieuDe = giaTri[0];
                foreach (var tieuDeCot in tieuDe)
                {
                    table.Columns.Add(tieuDeCot.ToString());
                }

                // Duyệt qua từng hàng dữ liệu và thêm vào DataTable
                for (int i = 1; i < giaTri.Count; i++) // Bắt đầu từ dòng thứ 2 (dữ liệu)
                {
                    var hang = giaTri[i];

                    if (hang[1].ToString() == "Form NV")
                    {
                        continue;
                    }


                    DataRow row = table.NewRow();

                    // Gán giá trị vào các cột
                    row[0] = TryParseDateTime(hang[0]?.ToString(), out DateTime thoiGianNhap) ? thoiGianNhap : (object)DBNull.Value;
                    row[1] = hang[1]?.ToString(); // Email
                    row[2] = hang[2]?.ToString(); // Mã yêu cầu
                    row[3] = hang[3]?.ToString(); // Tem số
                    row[4] = hang[4]?.ToString().TrimStart('\''); // CCCD

                    table.Rows.Add(row);
                }
                //Console.WriteLine(table.ToString());
                return table; // Trả về DataTable
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return null;
            }
        }


        // Hàm chuyển đổi tg
        public bool TryParseDateTime(string dateString, out DateTime dateTime)
        {
            string[] dateTimeFormats = { "dd/MM/yyyy HH:mm:ss", "dd/MM/yyyy H:mm:ss", "dd/MM/yyyy HH:mm", "dd/MM/yyyy H:mm" };
            return DateTime.TryParseExact(dateString, dateTimeFormats, null, System.Globalization.DateTimeStyles.None, out dateTime);
        }

        //VERSION 2:
        public void XuLiFormNV()
        {
            try
            {
                var phamVi1 = "Dữ liệu chung!A1:F";
                var yeuCau1 = dichVuSheets.Spreadsheets.Values.Get("1rjeLYWplaCnfIyrLphyVykEPIJaodOzdhES0L8JMnNg", phamVi1);
                var phanHoi1 = yeuCau1.Execute();
                IList<IList<object>> giaTri1 = phanHoi1.Values;

                if (giaTri1 == null || giaTri1.Count == 0)
                {
                    Console.WriteLine("Không có dữ liệu trong Google Sheets.");
                    return;
                }

                var phamVi2 = "Dữ liệu chung!A1:L";
                var yeuCau2 = dichVuSheets.Spreadsheets.Values.Get("1rjeLYWplaCnfIyrLphyVykEPIJaodOzdhES0L8JMnNg", phamVi2);
                var phanHoi2 = yeuCau2.Execute();
                IList<IList<object>> giaTri2 = phanHoi2.Values;

                if (giaTri2 == null || giaTri2.Count == 0)
                {
                    Console.WriteLine("Không có dữ liệu trong Google Sheets.");
                    return;
                }

                List<int> hangXoa = new List<int>();

                for (int i = 1; i < giaTri1.Count; i++)
                {
                    var hang1 = giaTri1[i];
                    while (hang1.Count < 6)
                    {
                        hang1.Add(""); // Thêm chuỗi rỗng nếu thiếu
                    }

                    string email1 = hang1[1].ToString();
                    // thêm sửa tg

                    TryParseDateTime(hang1[0].ToString(), out DateTime thoiGianNhap1);

                    hang1[5] = "";  // Dòng này làm gì? Có cần không?
                    string cccd1 = hang1[4].ToString();
                    string maYC1 = hang1[2].ToString();
                    // Kiểm tra MaYC có hợp lệ và hoàn thành không
                    if (!KiemTraMaYCHopLe(maYC1))
                    {
                        Console.WriteLine($"MaYC '{maYC1}' không hợp lệ hoặc chưa hoàn thành, bỏ qua hàng này.");
                        hangXoa.Add(i);
                        continue; // Bỏ qua hàng này và tiếp tục
                    }
                    if (!KiemTraCCCDHopLe(cccd1))
                    {
                        Console.WriteLine("CCCD không hợp lệ: " + cccd1);
                        hangXoa.Add(i);
                        break;
                    }

                    if (email1 != "Form NV") // Chỉ xử lý khi email1 không phải "Form NV"
                    {
                        for (int j = i + 1; j < giaTri2.Count; j++)
                        {
                            var hang2 = giaTri2[j];
                            string email2 = hang2[1].ToString();
                            string maYC = hang2[2].ToString();
                            if (email2 == "Form NV" && hang1[2].ToString() == hang2[2].ToString()) // Kiểm tra mã YC
                            {
                                TryParseDateTime(hang2[0].ToString(), out DateTime thoiGianNhap2);


                                // Thêm logic kiểm tra ở đây:
                                // Kiểm tra MaYC có hợp lệ và hoàn thành không
                                if (!KiemTraMaYCHopLe(maYC))
                                {
                                    Console.WriteLine($"MaYC '{maYC}' không hợp lệ hoặc chưa hoàn thành, bỏ qua hàng này.");
                                    hangXoa.Add(j);
                                    continue; // Bỏ qua hàng này và tiếp tục
                                }
                                //Kiểm tra CCCD
                                string cccd = hang2[4]?.ToString();
                                if (!KiemTraCCCDHopLe(cccd))
                                {
                                    Console.WriteLine("CCCD không hợp lệ: " + cccd);
                                    hangXoa.Add(j);
                                    break;
                                }
                                //Kiểm tra MaNV hợp lệ:
                                string maNV = hang2[5]?.ToString();
                                if (!KiemTraMaNVHopLe(maNV))
                                {
                                    Console.WriteLine("MaNV không hợp lệ, bỏ qua hàng này.");
                                    hangXoa.Add(j);
                                    break;
                                }


                                hang1[0] = "\'" + thoiGianNhap2.ToString("yyyy-MM-dd HH:mm:ss");
                                hang1[1] = hang2[1]; // chuyển thành form nv
                                hang1[2] = hang2[2]; // mã YC
                                hang1[3] = hang2[3]; // danh sách tem số
                                hang1[4] = hang2[4]; // cccd
                                hang1[5] = hang2[5]; // mã NV

                                // Cập nhật dữ liệu cho giaTri1
                                CapNhatFormNV(giaTri1, phamVi1);

                                // Thêm vào danh sách các hàng đã xóa
                                hangXoa.Add(j);
                                // Gọi stored procedure để tạo mã đơn hàng dựa trên mã YC
                                string maDonHang = string.Empty;
                                float giaTien = 0;
                                float phiPhuThu = 0;
                                float thanhTien = 0;
                                List<string> dsTemso = hang2[3].ToString().Split('_').ToList();
                                Console.WriteLine(maNV + "," + dsTemso.Count);
                                foreach (string tem in dsTemso)
                                {
                                    try
                                    {
                                        // Gọi hàm và lấy kết quả
                                        var (giatien1, phiphuthu1) = TinhGiaTien(maYC, tem, thoiGianNhap2);

                                        // Hiển thị kết quả
                                        Console.WriteLine($"Tem số: {tem}");
                                        Console.WriteLine($"  Giá tiền: {giatien1}");
                                        Console.WriteLine($"  Phí phụ thu: {phiphuthu1}");
                                        giaTien += (float)giatien1;
                                        phiPhuThu += (float)phiphuthu1;
                                    }
                                    catch (Exception ex)
                                    {
                                        // Xử lý lỗi nếu cần
                                        Console.WriteLine($"Lỗi khi xử lý tem số {tem}: {ex.Message}");
                                    }
                                }
                                thanhTien = giaTien + phiPhuThu;
                                Console.WriteLine("Tổng kết:");
                                Console.WriteLine($"  Tổng giá tiền: {giaTien:F2}");
                                Console.WriteLine($"  Tổng phí phụ thu: {phiPhuThu:F2}");
                                Console.WriteLine($"  Thành tiền: {thanhTien:F2}");

                                try
                                {
                                    // Kết nối đến cơ sở dữ liệu MySQL
                                    using (var connection = new MySqlConnection(ketNoi))
                                    {
                                        connection.Open();

                                        // Câu lệnh gọi stored procedure
                                        string procedureQuery = "CALL XuatMaDonHang(@MaYC, @ExportCode)";
                                        using (var command = new MySqlCommand(procedureQuery, connection))
                                        {
                                            // Thêm tham số đầu vào (MaYC)
                                            command.Parameters.AddWithValue("@MaYC", hang2[2]);

                                            // Thêm tham số đầu ra (ExportCode)
                                            MySqlParameter exportCodeParam = new MySqlParameter("@ExportCode", MySqlDbType.VarChar, 255)
                                            {
                                                Direction = ParameterDirection.Output
                                            };
                                            command.Parameters.Add(exportCodeParam);

                                            // Thực thi câu lệnh stored procedure
                                            command.ExecuteNonQuery();

                                            // Lấy mã đơn hàng từ tham số đầu ra
                                            maDonHang = exportCodeParam.Value.ToString();
                                            Console.WriteLine("Mã đơn hàng được tạo: " + maDonHang);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Lỗi khi gọi stored procedure để tạo mã đơn hàng: " + ex.Message);
                                }

                                // Thêm vào bảng "Đơn hàng"
                                try
                                {
                                    // Kết nối đến cơ sở dữ liệu MySQL
                                    using (var connection = new MySqlConnection(ketNoi))
                                    {
                                        connection.Open();

                                        // Câu lệnh SQL để thêm dữ liệu vào bảng "Đơn hàng"
                                        string query = "INSERT INTO DonHang (MaDH, NgayXuatKho,GiaTien,PhiPhuThu,ThanhTien,MaNV, MaYC, TemSo, CCCD)" +
                                                       "VALUES (@MaDonHang, @ThoiGianXuatHang,@giaTien,@phiPhuThu,@thanhTien,@MaNV,@MaYC, @TemSo, @CCCD)";

                                        using (var command = new MySqlCommand(query, connection))
                                        {
                                            // Thêm tham số vào câu lệnh SQL
                                            command.Parameters.AddWithValue("@MaDonHang", maDonHang); // Thêm mã đơn hàng đã tạo
                                            TryParseDateTime(hang2[0].ToString().TrimStart('\''), out DateTime ngayXuatHang);
                                            command.Parameters.AddWithValue("@ThoiGianXuatHang", ngayXuatHang);
                                            command.Parameters.AddWithValue("@giaTien", giaTien);
                                            command.Parameters.AddWithValue("@phiPhuThu", phiPhuThu);
                                            command.Parameters.AddWithValue("@thanhTien", thanhTien);
                                            command.Parameters.AddWithValue("@MaYC", hang2[2]);
                                            command.Parameters.AddWithValue("@TemSo", hang2[3]);
                                            command.Parameters.AddWithValue("@CCCD", hang2[4]);
                                            command.Parameters.AddWithValue("@MaNV", hang2[5]);

                                            // Thực thi câu lệnh SQL 
                                            int rowsAffected = command.ExecuteNonQuery();
                                            // Gọi hàm để cập nhật trạng thái cho thùng
                                            CapNhatTrangThaiThung(hang2[2].ToString(), hang2[3].ToString());
                                            //27-11-2024:Cập nhật trạng thái yêu cầu  với điều kiện đơn hàng đã xuất hết

                                            // Kiểm tra nếu không còn hàng nào với MaYC và trạng thái = 1
                                            if (!KiemTraConHangTrongThung(hang2[2].ToString()))
                                            {
                                                CapNhatTrangThaiYeuCau(hang2[2].ToString()); //Dựa vào mã yêu cầu
                                            }


                                            // Gọi hàm GetMaNganFromThung để lấy danh sách mã ngăn
                                            //List<string> maNganList = GetMaNganFromThung(hang2[2].ToString(), hang2[3].ToString());
                                            /*  for (var temso in ) #mai làm*/

                                            //Sau khi cập nhật trạng thái thúng tôi muốn nó cập nhật các vấn đề liên quan

                                            if (rowsAffected > 0)
                                            {
                                                Console.WriteLine("Thêm hàng vào bảng 'Đơn hàng' thành công.");
                                                // gửi mail
                                                GuiEmailThongBao(maYC, dsTemso);
                                                try
                                                {
                                                    // Xóa hàng trong Google Sheets sau khi thêm vào cơ sở dữ liệu thành công
                                                    //XoaHangFormNV(j);
                                                    hangXoa.Add(j - 1); //SỬA XÓA HÀNG Ở ĐÂY
                                                    Console.WriteLine("Hàng đã được xóa khỏi Google Sheets.");
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.WriteLine("Lỗi khi xóa hàng trong Google Sheets: " + ex.Message);
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Không có dữ liệu được thêm vào bảng 'Đơn hàng'.");
                                            }
                                        }
                                    }

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Lỗi khi thêm hàng vào bảng 'Đơn hàng': " + ex.Message);
                                }
                                Console.WriteLine("Xử lý form xong và thêm vào Đơn hàng");

                            }
                        }
                    }
                }

                // Xóa các hàng bị xóa từ dưới lên để tránh lỗi chỉ số
                foreach (var i in hangXoa.OrderByDescending(x => x))
                {
                    XoaHangFormNV(i);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
        }
        // gửi mail
        public (string Email, string TenKhachHang, DateTime NgayDangKy, DateTime NgayHetHan, DateTime NgayXuatKho,
        string MaDonHang, float GiaTien, float PhiPhuThu, float ThanhTien, string MaNV, string CCCD,
        int TongSoThung, int SoThungDaRut, DateTime NgayGiaHan)
LayThongTinYC(string maYeuCau)
        {
            // Khai báo các biến lưu kết quả
            string emailNguoiNhan = "";
            string tenKhachHang = "";
            DateTime ngayDangKy = DateTime.MinValue;
            DateTime ngayHetHan = DateTime.MinValue;
            DateTime ngayXuatKho = DateTime.MinValue;
            string maDonHang = "";
            float giaTien = 0.0f;
            float phiPhuThu = 0.0f;
            float thanhTien = 0.0f;
            string maNV = "";
            string cccd = "";
            int tongSoThung = 0;
            int soThungDaRut = 0;
            DateTime ngayGiaHan = DateTime.MinValue;

            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();

                    // Truy vấn tổng hợp thông tin
                    string truyVan = @"
            SELECT 
                dh.MaDH,
                dh.NgayXuatKho,
                dh.GiaTien,
                dh.PhiPhuThu,
                dh.ThanhTien,
                dh.MaNV,
                kh.TenKH,
                kh.Email,
                yc.NgayYeuCau,
                yc.NgayHetHan,
                kh.CCCD,
                (SELECT COUNT(*) FROM Thung WHERE MaYC = dh.MaYC) AS TongSoThung,
                (SELECT COUNT(*) FROM Thung WHERE MaYC = dh.MaYC AND TrangThai = '0') AS SoThungDaRut,
                GROUP_CONCAT(DISTINCT th.NgayGiaHan SEPARATOR ', ') AS NgayGiaHan
            FROM YeuCauKhachHang yc
            JOIN KhachHang kh ON yc.CCCD = kh.CCCD
            JOIN DonHang dh ON yc.MaYC = dh.MaYC
            LEFT JOIN Thung th ON th.MaYC = yc.MaYC
            WHERE yc.MaYC = @maYeuCau
            GROUP BY dh.MaDH, yc.MaYC";

                    using (MySqlCommand cmd = new MySqlCommand(truyVan, conn))
                    {
                        cmd.Parameters.AddWithValue("@maYeuCau", maYeuCau);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Lấy thông tin từ truy vấn
                                try
                                {
                                    emailNguoiNhan = reader["Email"].ToString();
                                    tenKhachHang = reader["TenKH"].ToString();
                                    cccd = reader["CCCD"].ToString();
                                    ngayDangKy = reader.GetDateTime(reader.GetOrdinal("NgayYeuCau"));
                                    ngayHetHan = reader.GetDateTime(reader.GetOrdinal("NgayHetHan"));
                                    ngayXuatKho = reader.GetDateTime(reader.GetOrdinal("NgayXuatKho"));
                                    maDonHang = reader["MaDH"].ToString();
                                    giaTien = reader.GetFloat(reader.GetOrdinal("GiaTien"));
                                    phiPhuThu = reader.GetFloat(reader.GetOrdinal("PhiPhuThu"));
                                    thanhTien = reader.GetFloat(reader.GetOrdinal("ThanhTien"));
                                    maNV = reader["MaNV"].ToString();
                                    tongSoThung = reader.GetInt32(reader.GetOrdinal("TongSoThung"));
                                    soThungDaRut = reader.GetInt32(reader.GetOrdinal("SoThungDaRut"));
                                    ngayGiaHan = reader.GetDateTime(reader.GetOrdinal("NgayGiaHan"));
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Lỗi khi đọc dữ liệu từ cơ sở dữ liệu: " + ex.Message);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Không tìm thấy dữ liệu cho yêu cầu: " + maYeuCau);
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Lỗi khi kết nối cơ sở dữ liệu: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi không xác định: " + ex.Message);
                }
            }

            // Trả về kết quả
            return (emailNguoiNhan, tenKhachHang, ngayDangKy, ngayHetHan, ngayXuatKho, maDonHang, giaTien, phiPhuThu, thanhTien, maNV, cccd, tongSoThung, soThungDaRut, ngayGiaHan);
        }

        public void GuiEmailThongBao(string maYC, List<string> dsTemso)
        {
            try
            {
                // Lấy thông tin khách hàng từ mã yêu cầu
                var thongTinYC = LayThongTinYC(maYC);

                // Kiểm tra nếu thông tin yêu cầu không hợp lệ
                if (thongTinYC.Email == null)
                {
                    Console.WriteLine($"Không thể gửi email vì thông tin yêu cầu không hợp lệ cho Mã YC: {maYC}");
                    return;
                }

                // Thiết lập thông tin email
                string smtpServer = "smtp.gmail.com";
                int smtpPort = 587;
                string emailGui = "letiendat2004.it@gmail.com";
                string matKhau = "ywan znrs wagl dpyt";

                using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
                {
                    smtpClient.Credentials = new NetworkCredential(emailGui, matKhau);
                    smtpClient.EnableSsl = true;

                    // Nội dung email
                    string chuDe = $"[# {maYC}] Thông báo hoàn tất xuất hàng";
                    string noiDung = $@"
Xin chào {thongTinYC.TenKhachHang},
Dịch vụ Warehouse MA thông báo đã hoàn tất yêu cầu xuất hàng theo mã yêu cầu #{maYC}.

Thông tin cụ thể như sau:
    - Mã đơn hàng: {thongTinYC.MaDonHang}
    - Nhân viên phụ trách xuất hàng: {thongTinYC.MaNV}
    - Ngày đăng ký: {thongTinYC.NgayDangKy:dd-MM-yyyy HH:mm:ss}
    - Ngày hết hạn ban đầu: {thongTinYC.NgayHetHan:dd-MM-yyyy HH:mm:ss}
    - Ngày hết hạn đã gia hạn: {thongTinYC.NgayGiaHan:dd-MM-yyyy HH:mm:ss}
    - Ngày xuất kho: {thongTinYC.NgayXuatKho:dd-MM-yyyy HH:mm:ss}
    - Giá tiền: {thongTinYC.GiaTien}
    - Phí phụ thu: {thongTinYC.PhiPhuThu}
    - Thanh tiền: {thongTinYC.ThanhTien}
    - Tình trạng xử lý: Đã xuất hàng thành công

Chi tiết thùng xuất kho:
    - Tem: {string.Join(", ", dsTemso)}
    - Số thùng đã rút:{thongTinYC.SoThungDaRut} / tổng số thùng:{thongTinYC.TongSoThung}

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
                    Console.WriteLine($"Đã gửi email thông báo hoàn tất xuất hàng tới: {thongTinYC.Email}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi gửi email: " + ex.Message);
            }
        }








        //27-11-2024 : Kiểm tra trong bảng thùng MaYc có còn thùng nào ko?
        private bool KiemTraConHangTrongThung(string maYC)
        {
            try
            {
                using (var connection = new MySqlConnection(ketNoi))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM Thung WHERE MaYC = @MaYC AND TrangThai = 1";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaYC", maYC);

                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0; // Trả về true nếu vẫn còn hàng, ngược lại trả về false
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi kiểm tra hàng trong thùng: " + ex.Message);
                return false;
            }
        }
        //27-11-2024: HÀM CẬP NHẬT TRẠNG THÁI YÊU CẦU KHI RÚT HẾT:
        private void CapNhatTrangThaiYeuCau(string maYC)
        {
            try
            {
                using (var connection = new MySqlConnection(ketNoi))
                {
                    connection.Open();

                    string query = "UPDATE YeuCauKhachHang SET  TrangThaiXuLy = 'Đã rút hàng' WHERE MaYC = @MaYC";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaYC", maYC);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"Cập nhật trạng thái 'Đã rút hàng' cho MaYC {maYC} thành công.");
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy yêu cầu với MaYC {maYC} để cập nhật.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật trạng thái yêu cầu: " + ex.Message);
            }
        }

        //Xử lí tính tiền
        private (decimal GiaTien, decimal PhiPhuThu) TinhGiaTien(string maYC, string temSo, DateTime ngayXuatKho)
        {
            decimal giaTien = 0;
            decimal phiPhuThu = 0;

            try
            {
                // Chuỗi kết nối đến MySQL

                using (MySqlConnection conn = new MySqlConnection(ketNoi))
                {
                    conn.Open();

                    string query = @"
                SELECT t.TemSo, t.DungTich, t.NgayNhapKho, t.NgayGiaHan, y.NgayHetHan AS ngayhethanyc
                FROM Thung t
                JOIN YeuCauKhachHang y ON t.MaYC = y.MaYC
                WHERE t.MaYC = @MaYC AND t.TemSo = @temSo";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaYC", maYC);
                        cmd.Parameters.AddWithValue("@temSo", temSo);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Lấy các thuộc tính từ cơ sở dữ liệu
                                decimal dungTichThung = Convert.ToDecimal(reader["DungTich"]);
                                DateTime ngayNhapKho = Convert.ToDateTime(reader["NgayNhapKho"]);
                                DateTime ngayGiaHan = Convert.ToDateTime(reader["NgayGiaHan"]);
                                DateTime ngayHetHan = Convert.ToDateTime(reader["ngayhethanyc"]);

                                Console.WriteLine($"Dung tích thùng: {dungTichThung}");
                                Console.WriteLine($"Ngày nhập kho: {ngayNhapKho}");
                                Console.WriteLine($"Ngày gia hạn thùng: {ngayGiaHan}");
                                Console.WriteLine($"Ngày hết hạn (từ yêu cầu khách hàng): {ngayHetHan}");
                                Console.WriteLine($"Ngày xuất kho: {ngayXuatKho}");

                                // Kiểm tra logic của ngày
                                if (ngayNhapKho > ngayHetHan || ngayNhapKho > ngayGiaHan)
                                {
                                    throw new InvalidOperationException("Dữ liệu ngày không hợp lệ.");
                                }

                                // Tính toán các giá trị X, Y, Z và thời gian gia hạn
                                int x = (int)(ngayXuatKho - ngayNhapKho).TotalHours;
                                int y = (int)(ngayGiaHan - ngayNhapKho).TotalHours;
                                int z = (int)(ngayGiaHan - ngayHetHan).TotalHours;
                                int giaHan = (int)(ngayXuatKho - ngayGiaHan).TotalHours;

                                Console.WriteLine($"Thời gian từ nhập kho đến xuất kho (X): {x} giờ");
                                Console.WriteLine($"Thời gian từ nhập kho đến hết hạn thùng (Y): {y} giờ");
                                Console.WriteLine($"Thời gian từ hết hạn yêu cầu đến hết hạn thùng (Z): {z} giờ");
                                Console.WriteLine($"Thời gian gia hạn thêm (nếu có): {giaHan} giờ");

                                // Tính toán dựa trên điều kiện
                                if (ngayHetHan == ngayGiaHan) // Đúng hạn
                                {
                                    Console.WriteLine("Trường hợp: Hàng xuất đúng hạn.");
                                    if (x > y) // Xuất hàng trễ
                                    {
                                        phiPhuThu = dungTichThung * 10 * (x - y);
                                        Console.WriteLine($"Hàng xuất trễ, phụ thu: {phiPhuThu}");
                                        giaTien = 0;
                                    }
                                    else // Xuất hàng sớm hoặc đúng hạn
                                    {
                                        phiPhuThu = 0;
                                        giaTien = 0;
                                        Console.WriteLine("Hàng xuất đúng hạn hoặc sớm, không tính phí.");
                                    }
                                }
                                else if (ngayHetHan < ngayGiaHan) // Đã gia hạn
                                {
                                    Console.WriteLine("Trường hợp: Hàng đã được gia hạn.");
                                    if (x > y) // Gia hạn nhưng vẫn xuất trễ
                                    {
                                        giaTien = dungTichThung * 100 * z;
                                        phiPhuThu = dungTichThung * 10 * giaHan;
                                        Console.WriteLine($"Gia hạn nhưng xuất trễ, giá tiền: {giaTien}, phụ thu: {phiPhuThu}");
                                    }
                                    else if (x == y) // Lấy hàng đúng thời điểm gia hạn
                                    {
                                        giaTien = dungTichThung * 100 * z;
                                        phiPhuThu = 0;
                                        Console.WriteLine($"Lấy hàng đúng thời điểm gia hạn, giá tiền: {giaTien}");
                                    }
                                    else // Xuất hàng sớm hơn thời điểm gia hạn
                                    {
                                        phiPhuThu = 0;
                                        giaTien = dungTichThung * 100 * z;
                                        Console.WriteLine($"Lấy hàng sớm hơn thời điểm gia hạn, giá tiền: {giaTien}");
                                    }
                                }
                            }
                            else
                            {
                                throw new InvalidOperationException("Không tìm thấy dữ liệu phù hợp.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log lỗi và xử lý ngoại lệ
                Console.WriteLine($"Lỗi khi tính giá tiền: {ex.Message}");
                throw;
            }

            Console.WriteLine($"Kết quả: Giá tiền = {giaTien}, Phí phụ thu = {phiPhuThu}");
            return (giaTien, phiPhuThu);
        }





        //Viết hàm cập nhật trạng thái thùng với tem số và mã yêu cầu tương ứng:
        public void CapNhatTrangThaiThung(string maYC, string temSo)
        {
            try
            {
                // Tách tem số từ chuỗi "1_2" thành mảng các giá trị riêng biệt
                var danhSachTemSo = temSo.Split('_').ToList();

                // Kết nối tới cơ sở dữ liệu MySQL
                using (var connection = new MySqlConnection(ketNoi))
                {
                    connection.Open();

                    // Duyệt qua danh sách tem số và cập nhật trạng thái của từng thùng
                    foreach (var tem in danhSachTemSo)
                    {
                        // Câu lệnh SQL để cập nhật trạng thái của từng thùng
                        string query = "UPDATE Thung SET TrangThai = 0 WHERE MaYC = @MaYC AND TemSo = @TemSo";

                        using (var command = new MySqlCommand(query, connection))
                        {
                            // Thêm tham số vào câu lệnh SQL
                            command.Parameters.AddWithValue("@MaYC", maYC);
                            command.Parameters.AddWithValue("@TemSo", tem);

                            // Thực thi câu lệnh SQL
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                Console.WriteLine($"Cập nhật trạng thái thùng với tem số {tem} thành công.");
                                //Thục hiện truy vấn tra mã ngăn:
                                string maNgan = LayMaNgan(connection, tem, maYC);
                                float dungTich = LayDungTich(connection, maYC, tem);
                                Console.WriteLine("Ma Ngan la: " + maNgan);
                                //Tiến hành logic tìm kiếm 
                                if (!string.IsNullOrEmpty(maNgan))
                                {

                                    // Cập nhật dung tích ngăn
                                    CapNhatDungTichNgan_XuatHang(connection, maNgan, dungTich);
                                    Console.WriteLine("Cap nhat dung tich ngan thanh cong");
                                    string maTang = LayMaTang(connection, maNgan);
                                    if (!string.IsNullOrEmpty(maTang))
                                    {
                                        CapNhatDungTichTang_XuatHang(connection, maTang, dungTich);

                                        string maKe = LayMaKe(connection, maTang);
                                        if (!string.IsNullOrEmpty(maKe))
                                        {
                                            CapNhatDungTichKe_XuatHang(connection, maKe, dungTich);

                                            string maKho = LayMaKho(connection, maKe);
                                            if (!string.IsNullOrEmpty(maKho))
                                            {
                                                CapNhatDungTichKho_XuatHang(connection, maKho, dungTich);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Không tìm thấy thùng với tem số {tem} và mã YC {maYC}.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật trạng thái thùng: " + ex.Message);
            }
        }
        //Các hàm cập nhật dung tích khi xuất hàng:
        //Hàm lấy dung tích:
        public float LayDungTich(MySqlConnection conn, string maYC, string temSo)
        {
            try
            {
                // Câu lệnh SQL để lấy dung tích
                string query = "SELECT DungTich FROM Thung WHERE MaYC = @MaYC AND TemSo = @TemSo";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaYC", maYC);
                    cmd.Parameters.AddWithValue("@TemSo", temSo);

                    // Thực thi câu lệnh SQL và đọc kết quả
                    object result = cmd.ExecuteScalar();

                    if (result != null && float.TryParse(result.ToString(), out float dungTich))
                    {
                        return dungTich; // Trả về dung tích tìm được
                    }
                    else
                    {
                        Console.WriteLine($"Không tìm thấy dung tích cho MaYC: {maYC}, TemSo: {temSo}.");
                        return 0; // Trả về giá trị mặc định nếu không tìm thấy
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy dung tích: " + ex.Message);
                return 0; // Trả về giá trị mặc định nếu xảy ra lỗi
            }
        }

        //Hàm lấy mã ngăn:
        public string LayMaNgan(MySqlConnection conn, string temSo, string MaYC)
        {
            string maNgan = "";
            string query = "SELECT MaNgan FROM Thung WHERE TemSo = @TemSo and MaYC = @MaYC";
            using (var command = new MySqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@TemSo", temSo);
                command.Parameters.AddWithValue("@MaYC", MaYC);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        maNgan = reader.GetString("MaNgan");
                    }
                }
            }
            return maNgan;
        }

        //1.NGĂN:
        public void CapNhatDungTichNgan_XuatHang(MySqlConnection conn, string maNgan, float dungTichThung)
        {
            using (var cmd = new MySqlCommand("CapNhatDungTichNgan_XuatHang", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_MaNgan", maNgan);
                cmd.Parameters.AddWithValue("p_DungTich", dungTichThung);
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Cập nhật dung tích ngăn '{maNgan}' thành công.");
            }
        }

        //2.Tầng:
        // Hàm gọi procedure cập nhật dung tích của Tầng
        public void CapNhatDungTichTang_XuatHang(MySqlConnection conn, string maTang, float dungTichThung)
        {
            using (var cmd = new MySqlCommand("CapNhatDungTichTang_XuatHang", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_MaTang", maTang);
                cmd.Parameters.AddWithValue("p_DungTich", dungTichThung);
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Cập nhật dung tích tầng '{maTang}' thành công.");
            }
        }

        // Hàm gọi procedure cập nhật dung tích của Kệ
        public void CapNhatDungTichKe_XuatHang(MySqlConnection conn, string maKe, float dungTichThung)
        {
            using (var cmd = new MySqlCommand("CapNhatDungTichKe_XuatHang", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_MaKe", maKe);
                cmd.Parameters.AddWithValue("p_DungTich", dungTichThung);
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Cập nhật dung tích kệ '{maKe}' thành công.");
            }
        }
        // Hàm gọi procedure cập nhật dung tích của Kho
        public void CapNhatDungTichKho_XuatHang(MySqlConnection conn, string maKho, float dungTichThung)
        {
            using (var cmd = new MySqlCommand("CapNhatDungTichKho_XuatHang", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_MaKho", maKho);
                cmd.Parameters.AddWithValue("p_DungTich", dungTichThung);
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Cập nhật dung tích kho '{maKho}' thành công.");
            }
        }
        //Lấy thông tin cần thiết:
        private string LayMaTang(MySqlConnection conn, string maNgan)
        {
            string query = "SELECT MaTang FROM Ngan WHERE MaNgan = @MaNgan";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaNgan", maNgan);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader["MaTang"].ToString();
                    }
                }
            }
            Console.WriteLine($"Không tìm thấy MaTang cho MaNgan '{maNgan}'");
            return null;
        }
        private string LayMaKe(MySqlConnection conn, string maTang)
        {
            string query = "SELECT MaKe FROM Tang WHERE MaTang = @MaTang";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaTang", maTang);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader["MaKe"].ToString();
                    }
                }
            }
            Console.WriteLine($"Không tìm thấy MaKe cho MaTang '{maTang}'");
            return null;
        }
        private string LayMaKho(MySqlConnection conn, string maKe)
        {
            string query = "SELECT MaKho FROM KeChoThue WHERE MaKe = @MaKe";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaKe", maKe);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader["MaKho"].ToString();
                    }
                }
            }
            Console.WriteLine($"Không tìm thấy MaKho cho MaKe '{maKe}'");
            return null;
        }
        //Thêm các hàm kiểm tra ràng buộc về CCCD và MaNV
        public bool KiemTraCCCDHopLe(string cccd)
        {
            try
            {
                using (var conn = new MySqlConnection(ketNoi))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM KhachHang WHERE CCCD = @CCCD";
                    using (var command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@CCCD", cccd);
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi kiểm tra CCCD: " + ex.Message);
                return false;
            }
        }
        //Kiểm tra mã nhân viên:
        bool KiemTraMaNVHopLe(string maNV)
        {
            try
            {
                using (var conn = new MySqlConnection(ketNoi))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM NhanVienKho WHERE MaNV = @MaNV";
                    using (var command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@MaNV", maNV);
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi kiểm tra MaNV: " + ex.Message);
                return false;
            }
        }
        //Hàm kiểm tra mã yêu cầu:
        private bool KiemTraMaYCHopLe(string maYC)
        {
            try
            {
                using (var connection = new MySqlConnection(ketNoi))
                {
                    connection.Open();
                    string query = "SELECT TrangThaiXuLy FROM YeuCauKhachHang WHERE MaYC = @MaYC";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaYC", maYC);
                        var result = command.ExecuteScalar();

                        // Nếu kết quả không có hoặc không phải "đã nhập hàng", trả về false
                        if (result == null || result.ToString().ToLower() != "đã nhập hàng")
                        {
                            Console.WriteLine($"MaYC '{maYC}' không hợp lệ hoặc chưa nhập hàng.");
                            return false;
                        }
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi kiểm tra MaYC '{maYC}': {ex.Message}");
                return false;
            }
        }

        //Hàm tạo mã đơn hàng từ Procedure:
        public string XuatMaDonHang(string maYC)
        {
            string orderCode = string.Empty;

            using (var connection = new MySqlConnection(ketNoi)) // ketNoi là chuỗi kết nối MySQL của bạn
            {
                try
                {
                    connection.Open();

                    // Tạo câu lệnh gọi thủ tục
                    using (var cmd = new MySqlCommand("CreateOrderCode", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số cho thủ tục
                        cmd.Parameters.AddWithValue("@maYC", maYC);

                        // Đọc kết quả trả về từ thủ tục
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                orderCode = reader.GetString(0); // Lấy mã đơn hàng từ kết quả trả về
                            }
                        }
                    }

                    Console.WriteLine("Mã đơn hàng đã được tạo: " + orderCode);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi gọi thủ tục tạo mã đơn hàng: " + ex.Message);
                }
            }

            return orderCode;
        }




        public void CapNhatFormNV(IList<IList<object>> updatedData, string range)
        {
            try
            {
                // Tạo đối tượng BatchUpdateValuesRequest
                var batchUpdateRequest = new BatchUpdateValuesRequest
                {
                    ValueInputOption = "RAW", // Có thể thay bằng "USER_ENTERED" tùy theo cách nhập dữ liệu
                    Data = new List<ValueRange>
            {
                new ValueRange
                {
                    Range = range, // Vùng cần cập nhật (ví dụ: "QLK!A2:K")
                    Values = updatedData // Dữ liệu cần cập nhật
                }
            }
                };

                // Gửi yêu cầu cập nhật tới Google Sheets
                var request = dichVuSheets.Spreadsheets.Values.BatchUpdate(batchUpdateRequest, "1rjeLYWplaCnfIyrLphyVykEPIJaodOzdhES0L8JMnNg");

                // Thực thi yêu cầu
                request.Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cập nhật Google Sheets thất bại: " + ex.Message);
            }
        }

        public void XoaHangFormNV(int rowIndex)
        {
            try
            {
                // Kiểm tra chỉ số hàng (rowIndex) trước khi xóa
                Console.WriteLine($"Xóa hàng tại chỉ số: {rowIndex}");

                // Tạo một yêu cầu BatchUpdate để xóa hàng
                var deleteRequest = new Google.Apis.Sheets.v4.Data.Request
                {
                    DeleteDimension = new Google.Apis.Sheets.v4.Data.DeleteDimensionRequest
                    {
                        Range = new Google.Apis.Sheets.v4.Data.DimensionRange
                        {
                            SheetId = 146375061, // Thay sheet ID cho phù hợp
                            Dimension = "ROWS",
                            StartIndex = rowIndex,  // Xác định dòng cần xóa
                            EndIndex = rowIndex + 1  // Xóa chỉ một dòng
                        }
                    }
                };

                // Tạo BatchUpdateRequest và thêm yêu cầu xóa hàng
                var batchUpdateRequest = new Google.Apis.Sheets.v4.Data.BatchUpdateSpreadsheetRequest
                {
                    Requests = new List<Google.Apis.Sheets.v4.Data.Request> { deleteRequest }
                };

                // Gửi yêu cầu xóa hàng đến Google Sheets
                var response = dichVuSheets.Spreadsheets.BatchUpdate(batchUpdateRequest, "1rjeLYWplaCnfIyrLphyVykEPIJaodOzdhES0L8JMnNg").Execute();

                // In thông báo khi xóa thành công
                Console.WriteLine("Đã xóa hàng thành công trong Google Sheets.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa hàng trong Google Sheets: " + ex.Message);
            }
        }

        //Lấy dưx liệu từ bảng đơn hàng hiện trên datagridview:
        public DataTable LayDonHang()
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ketNoi))
                {
                    conn.Open();

                    string query = "SELECT * FROM DonHang";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        adapter.Fill(dataTable);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return dataTable;
        }


        //IN:

        //Lấy dưx liệu từ bảng đơn hàng hiện trên datagridview:

        // lấy yêu cầu kiểm tra 
        public string GetTrangThaiYeuCau(string maDH)
        {
            return maDH;
        }
        // xuất pdf
        //sưa 27-11-2024
        public void XuatPhieuNhapToPDF(string maDH, string filePath)
        {
            try
            {
                //Cập nhật ngày 27/11/2024
                string truyVan = @"
                            SELECT 
                                dh.*, 
                                kh.TenKH, 
                                kh.DiaChi, 
                                kh.SoDienThoai, 
                                kh.Email, 
                                yc.NgayHetHan, 
                                yc.MaYC, 
                                yc.GiaThanhToan,
                                (SELECT COUNT(*) FROM Thung WHERE MaYC = dh.MaYC) AS TongSoThung,
                                (SELECT COUNT(*) FROM Thung WHERE MaYC = dh.MaYC AND TrangThai = '0') AS SoThungDaRut,
                                GROUP_CONCAT(DISTINCT th.NgayGiaHan SEPARATOR ', ') AS NgayGiaHan
                            FROM YeuCauKhachHang yc
                            JOIN KhachHang kh ON yc.CCCD = kh.CCCD
                            JOIN DonHang dh ON yc.MaYC = dh.MaYC
                            LEFT JOIN Thung th ON th.MaYC = yc.MaYC -- Kết nối để lấy thông tin ngày gia hạn từ bảng Thung
                            WHERE dh.MaDH = @maDH
                            GROUP BY dh.MaDH, yc.MaYC";

                using (MySqlConnection conn = new MySqlConnection(ketNoi))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(truyVan, conn))
                    {
                        cmd.Parameters.AddWithValue("@maDH", maDH);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // Nếu tìm thấy yêu cầu
                            {
                                // Đường dẫn font Arial Unicode và font đậm
                                string fontPathRegular = @"C:\Windows\Fonts\arial.ttf"; // Font thường
                                string fontPathBold = @"C:\Windows\Fonts\arialbd.ttf"; // Font đậm
                                PdfFont fontRegular = PdfFontFactory.CreateFont(fontPathRegular, PdfEncodings.IDENTITY_H);
                                PdfFont fontBold = PdfFontFactory.CreateFont(fontPathBold, PdfEncodings.IDENTITY_H);

                                // Tạo file PDF
                                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                                {
                                    PdfWriter writer = new PdfWriter(fs);
                                    PdfDocument pdf = new PdfDocument(writer);
                                    Document document = new Document(pdf, PageSize.A4);

                                    // Set margins (top, bottom, left, right)
                                    document.SetMargins(36, 36, 36, 36); // Adjust these values as necessary

                                    // Tiêu đề chính
                                    document.Add(
                                        new Paragraph("PHIẾU XUẤT HÀNG")
                                            .SetTextAlignment(TextAlignment.CENTER)
                                            .SetFont(fontBold)
                                            .SetFontSize(22)
                                    );

                                    // Thông tin công ty
                                    document.Add(
                                        new Paragraph("WarehouseMA - QUẢN LÝ KHO")
                                            .SetTextAlignment(TextAlignment.CENTER)
                                            .SetFont(fontRegular)
                                            .SetFontSize(12)
                                    );
                                    LineSeparator ls = new LineSeparator(new SolidLine());
                                    document.Add(ls);

                                    //Chỉnh định dạng 27/11/2024:
                                    // Kiểm tra và định dạng ngày giờ
                                    string ngayGiaHanChuoi = reader["NgayGiaHan"].ToString();
                                    string ngayGiaHanDinhDang = string.Empty;

                                    if (!string.IsNullOrEmpty(ngayGiaHanChuoi))
                                    {
                                        // Nếu có nhiều ngày gia hạn (chuỗi được ghép từ GROUP_CONCAT)
                                        var ngayGiaHanList = ngayGiaHanChuoi.Split(',').Select(ngay =>
                                        {
                                            if (DateTime.TryParse(ngay.Trim(), out DateTime ngayGiaHan))
                                            {
                                                return ngayGiaHan.ToString("dd/MM/yyyy HH:mm:ss"); // Định dạng ngày giờ thành dd/MM/yyyy HH:mm:ss
                                            }
                                            return ngay; // Trả lại chuỗi gốc nếu không thể parse
                                        });

                                        ngayGiaHanDinhDang = string.Join(", ", ngayGiaHanList);
                                    }

                                    document.Add(new Paragraph("\n"));

                                    // Thông tin khách hàng (được thay thế bằng các Paragraph)
                                    document.Add(new Paragraph("Tên Khách Hàng: ")
                                        .SetFont(fontBold).Add(new Text(reader["TenKH"].ToString()).SetFont(fontRegular)));
                                    document.Add(new Paragraph("Địa Chỉ: ")
                                        .SetFont(fontBold).Add(new Text(reader["DiaChi"].ToString()).SetFont(fontRegular)));
                                    document.Add(new Paragraph("Số Điện Thoại: ")
                                        .SetFont(fontBold).Add(new Text(reader["SoDienThoai"].ToString()).SetFont(fontRegular)));
                                    document.Add(new Paragraph("Email: ")
                                        .SetFont(fontBold).Add(new Text(reader["Email"].ToString()).SetFont(fontRegular)));
                                    document.Add(new Paragraph("Căn Cước Công Dân: ")
                                       .SetFont(fontBold).Add(new Text(reader["CCCD"].ToString()).SetFont(fontRegular)));
                                    document.Add(new Paragraph("WarehouseMA xin chân thành cảm ơn bạn đã lựa chọn tin tưởng gửi hàng hóa của mình ở chúng tôi.Sau đây là thông tin chi tiết về hàng hóa của bạn:")
                                     .SetFont(fontRegular)
                                    .SetFontSize(13));


                                    // Thông tin phiếu gửi
                                    document.Add(new Paragraph("Mã Yêu Cầu: ")
                                        .SetFont(fontBold).Add(new Text(reader["MaYC"].ToString()).SetFont(fontRegular)));

                                    document.Add(new Paragraph("Mã Đơn Hàng: ")
                                       .SetFont(fontBold).Add(new Text(reader["MaDH"].ToString()).SetFont(fontRegular)));
                                    //document.Add(new Paragraph("Ngày Gửi: ")
                                    //    .SetFont(fontBold).Add(new Text(Convert.ToDateTime(reader["NgayYeuCau"]).ToString("dd/MM/yyyy HH:mm:ss")).SetFont(fontRegular)));
                                    document.Add(new Paragraph("Ngày Dự Kiến Lấy Hàng ban đầu (Hạn dự kiến): ")
                                        .SetFont(fontBold).Add(new Text(Convert.ToDateTime(reader["NgayHetHan"]).ToString("dd/MM/yyyy HH:mm:ss")).SetFont(fontRegular)));
                                    document.Add(new Paragraph()
                                            .Add(new Text("Ngày dự kiến lấy hàng đã gia hạn: ").SetFont(fontBold))
                                            .Add(new Text(ngayGiaHanDinhDang).SetFont(fontRegular)));


                                    document.Add(new Paragraph("Ngày Xuất Kho thực tế: ")
                                        .SetFont(fontBold).Add(new Text(Convert.ToDateTime(reader["NgayXuatKho"]).ToString("dd/MM/yyyy HH:mm:ss")).SetFont(fontRegular)));
                                    document.Add(new Paragraph("Giá Tiền đã thanh toán ban đầu: ")
                                       .SetFont(fontBold).Add(new Text(reader["GiaThanhToan"].ToString() + " VND").SetFont(fontRegular)));
                                    document.Add(new Paragraph("Giá Tiền thanh toán nếu gia hạn: ")
                                        .SetFont(fontBold).Add(new Text(reader["GiaTien"].ToString() + " VND").SetFont(fontRegular)));
                                    document.Add(new Paragraph("Phí Phụ Thu(Trễ hạn): ")
                                        .SetFont(fontBold).Add(new Text(reader["PhiPhuThu"].ToString() + " VND").SetFont(fontRegular)));
                                    document.Add(new Paragraph("Thành Tiền: ")
                                        .SetFont(fontBold).Add(new Text(reader["ThanhTien"].ToString() + " VND").SetFont(fontRegular)));
                                    document.Add(new Paragraph("Tình Trạng Thùng: ")
                                    .SetFont(fontBold)
                                    .Add(new Text($"{reader["SoThungDaRut"]}/{reader["TongSoThung"]}").SetFont(fontRegular)));
                                    if (Convert.ToInt32(reader["SoThungDaRut"]) == Convert.ToInt32(reader["TongSoThung"]))
                                    {
                                        document.Add(new Paragraph("Số thùng yêu cầu của quý khách đã được xuất hoàn toàn!")
                                             .SetFont(fontBold));
                                    }
                                    document.Add(new Paragraph("Mã Nhân Viên: ")
                                        .SetFont(fontBold).Add(new Text(reader["MaNV"].ToString()).SetFont(fontRegular)));
                                    document.Add(new Paragraph("Tem Số: ")
                                        .SetFont(fontBold).Add(new Text(reader["TemSo"].ToString()).SetFont(fontRegular)));


                                    document.Add(new Paragraph("\n"));


                                    /*      document.Add(new Paragraph("\n"));*/
                                    // Đoạn văn bản thêm ở cuối
                                    document.Add(new Paragraph("Mọi vấn đề khó khăn về gửi nhận hàng hóa, quý khách vui lòng liên hệ số hotline 038 995 0228 để được tư vấn chi tiết.")
                                        .SetFont(fontRegular)
                                        .SetFontSize(13)
                                        .SetTextAlignment(TextAlignment.LEFT));

                                    // Header và Footer
                                    string headerContent = $"Mã Đơn Hàng: {maDH} | An toàn - hiệu quả - nhanh chóng";
                                    string footerNote = "WarehouseMA";

                                    int totalPages = pdf.GetNumberOfPages();
                                    for (int i = 1; i <= totalPages; i++)
                                    {
                                        PdfPage page = pdf.GetPage(i);
                                        PdfCanvas canvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdf);

                                        // Header
                                        canvas.BeginText();
                                        canvas.SetFontAndSize(fontRegular, 10);
                                        canvas.MoveText(34, page.GetPageSize().GetTop() - 20); // Vị trí Header
                                        canvas.ShowText(headerContent);
                                        canvas.EndText();

                                        // Footer
                                        canvas.BeginText();
                                        canvas.SetFontAndSize(fontRegular, 10);
                                        canvas.MoveText(34, 20); // Vị trí Footer bên trái
                                        canvas.ShowText(footerNote);

                                        // Hiển thị số trang ở Footer bên phải
                                        canvas.MoveText(page.GetPageSize().GetWidth() - 100, 0); // Điều chỉnh vị trí số trang
                                        canvas.ShowText($"Trang {i}/{totalPages}");

                                        canvas.EndText();
                                    }


                                    document.Close();
                                }

                                Console.WriteLine("Phiếu gửi đã được xuất thành công!");
                            }
                            else
                            {
                                Console.WriteLine("Không tìm thấy mã yêu cầu.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
        }



        //Tìm kiêm đơn hàng:
        public DataTable TimKiemDonHang(string tuKhoa)
        {
            DataTable dt = new DataTable();
            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                tuKhoa = ""; // Hoặc thiết lập giá trị mặc định
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ketNoi))
                {
                    conn.Open();

                    string query = @"
            SELECT
                MaDH,
                DATE_FORMAT(NgayXuatKho, '%d/%m/%Y') AS NgayXuatKho,
                GiaTien,
                PhiPhuThu,
                ThanhTien,
                MaNV,
                MaYC,
                TemSo,
                CCCD
            FROM DonHang
            WHERE (
                LOWER(MaDH) LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
                OR LOWER(MaNV) LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
                OR LOWER(MaYC) LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
                OR LOWER(CCCD) LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
                OR DATE_FORMAT(NgayXuatKho, '%d/%m/%Y') LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
                OR GiaTien LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
                OR PhiPhuThu LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
                OR ThanhTien LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
                OR LOWER(TemSo) LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
            )
            ";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@tuKhoa", "%" + tuKhoa + "%");

                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log lỗi hoặc hiển thị thông báo
                Console.WriteLine("Lỗi: " + ex.Message);
            }

            return dt;
        }


    }

}
