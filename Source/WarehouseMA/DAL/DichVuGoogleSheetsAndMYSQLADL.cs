using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Google.Apis.Http;
using Org.BouncyCastle.Utilities.Collections;

namespace WarehouseMA.DAL
{
    public class DichVuGoogleSheetsAndMYSQLADL
    {
        private SheetsService dichVuSheets;
        private string ketNoi = "server = sql5.freesqldatabase.com;Database = sql5742970; Uid = sql5742970;Pwd = BPHD48Fx7i; Charset = utf8mb4";
        // Get UTF-8 and UTF-16 encoders.
        Encoding utf8 = Encoding.UTF8;
        Encoding utf16 = Encoding.Unicode;
        public void KhoiTaoGoogleSheets()
        {
            try
            {
                string[] Scopes = { SheetsService.Scope.Spreadsheets };
                var clientSecrets = new ClientSecrets
                {
                    ClientId = "GOOGLE_CLIENT_ID",
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
                var phamVi = "QLK!A1:K";
                var yeuCau = dichVuSheets.Spreadsheets.Values.Get("16_vjiCW3xwZd1ZBV5VxFYzvJ1M4-hjTWVCb6OKXDJSs", phamVi);
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
                        if (!TryParseDateTime(hang[0].ToString(), out DateTime thoiGianNhap) ||
                            (DateTime.Now - thoiGianNhap).TotalMinutes < 1)
                        {
                            continue;
                        }

                        string tenKH = hang[2].ToString();
                        string cCCD = hang[3].ToString().TrimStart('\'');
                        /* string soDienThoai = hang[6].ToString();*/
                        string soDienThoai = hang[6].ToString().TrimStart('\'');

                        string email = hang[1].ToString();
                        string diaChi = hang[4].ToString();

                        // Kiểm tra hoặc thêm khách hàng vào database
                        AddOrUpdateKhachHang(conn, tenKH, soDienThoai, email, diaChi, cCCD);

                        // Thêm yêu cầu khách hàng
                        string trangThaiXL = "Chưa duyệt";
                        int soLuongThungS = int.Parse(hang[8].ToString().Split('_')[0]);
                        int soLuongThungM = int.Parse(hang[8].ToString().Split('_')[1]);
                        int soLuongThungL = int.Parse(hang[8].ToString().Split('_')[2]);
                        if (!TryParseDateTime(hang[9].ToString(), out DateTime ngayHetHanDateTime))
                        {
                            Console.WriteLine("Không thể chuyển đổi dấu thời gian: " + hang[9]);
                            continue;
                        }

                        string Goi_yeucauKH = @"CALL ThemMaYeuCauKhachHang(@TrangThaiXuLy, @NgayYeuCau, @SoLuongThungS, @SoLuongThungM, @SoLuongThungL, @DungTich, @NgayHetHan, @VanChuyen, @CCCD)";
                        using (MySqlCommand cmd = new MySqlCommand(Goi_yeucauKH, conn))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@TrangThaiXuLy", trangThaiXL);
                            cmd.Parameters.AddWithValue("@NgayYeuCau", thoiGianNhap);
                            cmd.Parameters.AddWithValue("@SoLuongThungS", soLuongThungS);
                            cmd.Parameters.AddWithValue("@SoLuongThungM", soLuongThungM);
                            cmd.Parameters.AddWithValue("@SoLuongThungL", soLuongThungL);
                            cmd.Parameters.AddWithValue("@DungTich", float.Parse(hang[7].ToString()));
                            cmd.Parameters.AddWithValue("@NgayHetHan", ngayHetHanDateTime);
                            cmd.Parameters.AddWithValue("@VanChuyen", hang[5].ToString() == "Có" ? 1 : 0);
                            cmd.Parameters.AddWithValue("@CCCD", cCCD);
                            cmd.ExecuteNonQuery();
                        }

                        rowsToDelete.Add(i);
                    }

                    XoaHangGoogleSheet(rowsToDelete);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
        }

        //Lấy dữ liệu từ sheet xác nhận yêu cầu của nhân viên:
        /* public void XuLyDonHang()
         {
             try
             {
                 // Đọc dữ liệu từ Google Sheets
                 var phamVi = "NV!A1:N";
                 var yeuCau = dichVuSheets.Spreadsheets.Values.Get("117BL-60p2O25_AF1riNMpdqCWByQfY1PfsGnD-STQFM", phamVi);
                 var phanHoi = yeuCau.Execute();
                 IList<IList<object>> giaTri = phanHoi.Values;

                 if (giaTri == null || giaTri.Count == 0)
                 {
                     Console.WriteLine("Không có dữ liệu trong Google Sheets.");
                     return;
                 }

                 // Duyệt từng hàng dữ liệu (bắt đầu từ hàng thứ 2 để bỏ qua tiêu đề)
                 List<int> rowsToDelete = new List<int>();  // Danh sách các hàng cần xóa sau khi xử lý
                 for (int i = 1; i < giaTri.Count; i++)
                 {
                     IList<object> hang = giaTri[i];
                     try
                     {
                         // Kết nối đến cơ sở dữ liệu
                         using (MySqlConnection conn = new MySqlConnection(ketNoi))
                         {
                             conn.Open();

                             // Lấy thông tin từ Google Sheets
                             //Xác nhận đơn
                             string TrangThaiNhap = hang[9]?.ToString().Trim().ToLower(); // "Đồng ý" hoặc "Từ chối".

                             // Kiểm tra trạng thái
                             if (TrangThaiNhap == "Đồng ý")
                             {
                                 // Trạng thái là "Đồng ý" -> Xử lý nhập kho
                                 string maYC = hang[1].ToString().Trim();

                                 TryParseDateTime(hang[0].ToString(), out DateTime ngayNhapKho);
                                 string[] mathung_array = hang[2]?.ToString().Split(','); // Phân tách nhau bằng dấu ,
                                 string[] dungtich_array = hang[3]?.ToString().Split('_');
                                 string[] moTaArray = hang[4]?.ToString().Trim().Split('_'); // Mô tả hàng hóa
                                 string[] temSoArray = hang[5]?.ToString().Trim().Split('_'); // Tem số
                                 string[] maNganArray = hang[6]?.ToString().Trim().Split(','); // Mã ngăn
                                 int dungTich = int.Parse(hang[3]?.ToString().Trim()); // Dung tích tổng
                                 int maxLength = Math.Min(moTaArray.Length, Math.Min(temSoArray.Length, maNganArray.Length));

                                 // Xác định trạng thái (1 = đồng ý, 0 = từ chối)
                                 int TrangThai = TrangThaiNhap == "Đồng ý" ? 1 : 0;
                                 string maNV = hang[8]?.ToString();

                                 for (int j = 0; j < maxLength; j++)
                                 {
                                     string chenThung = @"
                             INSERT INTO Thung (MaThung, MoTaHangHoa, DungTich, NgayNhapKho, TemSo, TrangThai, MaNgan, MaYC)
                             VALUES (@MaThung, @MoTaHangHoa, @DungTich, @NgayNhapKho, @TemSo, @TrangThai, @MaNgan, @MaYC)";

                                     using (MySqlCommand cmd = new MySqlCommand(chenThung, conn))
                                     {
                                         cmd.Parameters.AddWithValue("@MaThung", mathung_array[j]);
                                         cmd.Parameters.AddWithValue("@MoTaHangHoa", moTaArray[j].Trim());
                                         cmd.Parameters.AddWithValue("@DungTich", dungtich_array[j]);
                                         cmd.Parameters.AddWithValue("@NgayNhapKho", ngayNhapKho);
                                         cmd.Parameters.AddWithValue("@TemSo", temSoArray[j].Trim());
                                         cmd.Parameters.AddWithValue("@TrangThai", TrangThai); // Đồng ý = 1
                                         cmd.Parameters.AddWithValue("@MaNgan", maNganArray[j].Trim());
                                         cmd.Parameters.AddWithValue("@MaYC", maYC);

                                         cmd.ExecuteNonQuery();
                                     }
                                 }
                             }
                             else if (TrangThaiNhap == "Từ chối")
                             {
                                 string MaYC = hang[10].ToString().Trim();
                                 string maNV = hang[11].ToString().Trim();
                                 int TrangThai = TrangThaiNhap == "Đồng ý" ? 1 : 0;

                                 // Trạng thái là "Từ chối" -> Cập nhật trạng thái trong bảng YeuCauKhachHang
                                 string CapNhatTrangThai = @"
                         UPDATE YeuCauKhachHang
                         SET TrangThaiXuLy = 'Từ chối'
                         WHERE MaYC = @MaYC";

                                 using (MySqlCommand cmd = new MySqlCommand(CapNhatTrangThai, conn))
                                 {
                                     cmd.Parameters.AddWithValue("@MaYC", MaYC);
                                     cmd.Parameters.AddWithValue("@MaNV", maNV);
                                     cmd.ExecuteNonQuery();
                                 }
                             }
                         }

                         // Thêm chỉ số dòng vào danh sách cần xóa
                         rowsToDelete.Add(i);
                     }
                     catch (Exception ex)
                     {
                         Console.WriteLine($"Lỗi xử lý đơn hàng tại dòng {i + 1}: {ex.Message}");
                     }
                 }

                 // Gọi hàm XoaHangGoogleSheet để xóa các hàng đã xử lý
                 XoaHangGoogleSheet_XacNhan(rowsToDelete); // SheetId là id của sheet cần thao tác
             }
             catch (Exception ex)
             {
                 Console.WriteLine("Lỗi khi đọc dữ liệu từ Google Sheets: " + ex.Message);
             }
         }
 */
        public void XuLyDonHang()
        {
            try
            {
                Console.WriteLine("Bắt đầu xử lý đơn hàng...");
                // Đọc dữ liệu từ Google Sheets
                var phamVi = "NV!A1:N";
                var yeuCau = dichVuSheets.Spreadsheets.Values.Get("117BL-60p2O25_AF1riNMpdqCWByQfY1PfsGnD-STQFM", phamVi);
                var phanHoi = yeuCau.Execute();
                IList<IList<object>> giaTri = phanHoi.Values;

                if (giaTri == null || giaTri.Count == 0)
                {
                    Console.WriteLine("Không có dữ liệu trong Google Sheets.");
                    return;
                }
                //ktra
                Console.WriteLine($"Đã đọc được {giaTri.Count - 1} hàng dữ liệu từ Google Sheets (không tính tiêu đề).");
                // Duyệt từng hàng dữ liệu (bắt đầu từ hàng thứ 2 để bỏ qua tiêu đề)
                List<int> rowsToDelete = new List<int>();  // Danh sách các hàng cần xóa sau khi xử lý
                for (int i = 1; i < giaTri.Count; i++)
                {
                    IList<object> hang = giaTri[i];
                    try
                    {
                        Console.WriteLine($"Đang xử lý hàng {i + 1}...");
                        // Kết nối đến cơ sở dữ liệu
                        using (MySqlConnection conn = new MySqlConnection(ketNoi))
                        {
                            conn.Open();
                            Console.WriteLine("Kết nối cơ sở dữ liệu thành công.");

                            string TrangThaiNhap = hang[8]?.ToString().Trim(); // Trạng thái nhập kho ("Đồng ý" hoặc "Từ chối")

                            if (TrangThaiNhap == "Đồng ý")
                            {

                                XuLyDonDongY(conn, hang);
                                Console.WriteLine($"Trạng thái: {TrangThaiNhap}. Đang xử lý hàng đồng ý...");
                            }
                            else if (TrangThaiNhap == "Từ chối")
                            {
                                Console.WriteLine($"Trạng thái: {TrangThaiNhap}. Đang xử lý hàng từ chối...");
                                XuLyDonTuChoi(conn, hang);
                            }
                        }

                        // Thêm chỉ số dòng vào danh sách cần xóa
                        rowsToDelete.Add(i);
                        Console.WriteLine($"Xử lý thành công hàng {i + 1}.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi xử lý đơn hàng tại dòng {i + 1}: {ex.Message}");
                    }
                }

                // Xóa các hàng đã xử lý
                if (rowsToDelete.Count > 0)
                {
                    Console.WriteLine($"Đang xóa {rowsToDelete.Count} hàng đã xử lý khỏi Google Sheets...");
                    XoaHangGoogleSheet_XacNhan(rowsToDelete);
                    Console.WriteLine("Xóa thành công.");
                }
                else
                {
                    Console.WriteLine("Không có hàng nào cần xóa.");
                }

                Console.WriteLine("Hoàn tất xử lý đơn hàng.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi đọc dữ liệu từ Google Sheets: " + ex.Message);
            }
        }

        private void XuLyDonDongY(MySqlConnection conn, IList<object> hang)
        {
            string maYC = hang[1].ToString().Trim();

            // Kiểm tra MAYC
            if (!KiemTraMayc(conn, maYC))
            {
                Console.WriteLine($"MAYC '{maYC}' không hợp lệ hoặc không ở trạng thái 'Đang xử lý'.");
                return; // Dừng xử lý nếu MAYC không hợp lệ
            }
            TryParseDateTime(hang[0].ToString(), out DateTime ngayNhapKho);
            //string[] mathung_array = hang[2]?.ToString().Split(',');
            string[] dungtich_array = hang[2]?.ToString().Split('_');
            string[] moTaArray = hang[3]?.ToString().Trim().Split('_');
            string[] temSoArray = hang[4]?.ToString().Trim().Split('_');
            string[] maNganArray = hang[5]?.ToString().Trim().Split(',');
            string maNV = hang[7].ToString().Trim();
            int maxLength = Math.Min(moTaArray.Length, Math.Min(temSoArray.Length, maNganArray.Length));

            // Lấy Ngày Hết Hạn từ bảng YeuCauKhachHang
            DateTime? ngayHetHan = LayNgayHetHan(conn, maYC);
            Console.WriteLine(ngayHetHan.ToString());
            if (ngayHetHan == null)
            {
                Console.WriteLine($"Không tìm thấy NgayHetHan cho MAYC '{maYC}'. Sử dụng giá trị mặc định.");
                //ngayHetHan = ngayNhapKho.AddDays(30); // Giá trị mặc định nếu không có
            }
            // Tổng dung tích yêu cầu của tất cả các thùng
            int tongDungTich = 0;
            for (int j = 0; j < maxLength; j++)
            {
                tongDungTich += int.TryParse(dungtich_array[j], out int dt) ? dt : 0;
            }
            // Kiểm tra dung tích của tất cả các ngăn
            /*   foreach (var maNgan in maNganArray)
               {
                   int dungTichKhaDung = GetDungTichKhaDung(conn, maNgan.Trim());
                   if (dungTichKhaDung < tongDungTich || dungTichKhaDung == -1)
                   {
                       Console.WriteLine($"Dung tích khả dụng của ngăn '{maNgan.Trim()}' không đủ hoặc không tồn tại. Bỏ qua MAYC '{maYC}'.");
                       return; // Bỏ qua yêu cầu nếu dung tích không hợp lệ
                   }
               }*/
            for (int j = 0; j < maxLength; j++)
            {
                string maNgan = maNganArray[j].Trim();

                // Kiểm tra MaNgan tồn tại
                if (!KiemTraNgan(conn, maNgan))
                {
                    Console.WriteLine($"MaNgan '{maNgan}' không tồn tại. Bỏ qua hàng này.");
                    continue;
                }
                try
                {



                    // Gọi stored procedure để tạo mã thùng
                    string maThung;
                    using (MySqlCommand cmdGenerate = new MySqlCommand("CALL GenerateMaThung(@MaYC, @TemSo, @MaThungOut);", conn))
                    {
                        cmdGenerate.Parameters.AddWithValue("@MaYC", maYC);
                        cmdGenerate.Parameters.AddWithValue("@TemSo", temSoArray[j].Trim());
                        cmdGenerate.Parameters.Add("@MaThungOut", MySqlDbType.VarChar).Direction = ParameterDirection.Output;

                        cmdGenerate.ExecuteNonQuery();
                        maThung = cmdGenerate.Parameters["@MaThungOut"].Value.ToString();
                    }



                    string chenThung = @"
                INSERT INTO Thung (MaThung, MoTaHangHoa, DungTich, NgayNhapKho, TemSo, TrangThai, MaNgan, MaYC,MaNV,NgayGiaHan)
                VALUES (@MaThung, @MoTaHangHoa, @DungTich, @NgayNhapKho, @TemSo, @TrangThai, @MaNgan, @MaYC,@MaNV,@NgayGiaHan)";

                    using (MySqlCommand cmd = new MySqlCommand(chenThung, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaThung", maThung);
                        cmd.Parameters.AddWithValue("@MoTaHangHoa", moTaArray[j].Trim());
                        cmd.Parameters.AddWithValue("@DungTich", dungtich_array[j]);
                        cmd.Parameters.AddWithValue("@NgayNhapKho", ngayNhapKho);
                        cmd.Parameters.AddWithValue("@NgayGiaHan", ngayHetHan);
                        cmd.Parameters.AddWithValue("@TemSo", temSoArray[j].Trim());
                        cmd.Parameters.AddWithValue("@TrangThai", 1); // Đồng ý = 1
                        cmd.Parameters.AddWithValue("@MaNgan", maNganArray[j].Trim());
                        cmd.Parameters.AddWithValue("@MaYC", maYC);
                        cmd.Parameters.AddWithValue("@MaNV", maNV);

                        cmd.ExecuteNonQuery();
                    }
                    // Cập nhật trạng thái yêu cầu khách hàng thành 'Hoàn thành'
                    /*    CapNhatTrangThaiYeuCau(conn, maYC, "Hoàn thành");
                        Console.WriteLine($"Yêu cầu '{maYC}' đã hoàn thành.");*/

                    // Gọi stored procedure để cập nhật dung tích
                    int dungTichThung = int.TryParse(dungtich_array[j], out int dt) ? dt : 0;

                    // Cập nhật dung tích của bảng Ngan
                    CapNhatDungTichNgan(conn, maNgan, dungTichThung);

                    // Lấy mã tầng và cập nhật dung tích của tầng
                    string maTang = LayMaTang(conn, maNgan);
                    CapNhatDungTichTang(conn, maTang, dungTichThung);

                    // Lấy mã kệ và cập nhật dung tích của kệ
                    string maKe = LayMaKe(conn, maTang);
                    CapNhatDungTichKe(conn, maKe, dungTichThung, "Sẵn sàng");

                    // Lấy mã kho và cập nhật dung tích của kho
                    string maKho = LayMaKho(conn, maKe);
                    CapNhatDungTichKho(conn, maKho, dungTichThung);



                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi thêm thùng vào ngăn '{maNgan}': {ex.Message}");
                }

            }
            // Cập nhật trạng thái yêu cầu khách hàng thành 'Hoàn thành'
            CapNhatTrangThaiYeuCau(conn, maYC, "Đã nhập hàng");
            Console.WriteLine($"Yêu cầu '{maYC}' đã nhập hàng");
            // Console.WriteLine($"Thùng '{mathung_array[j]}' đã thêm vào ngăn '{maNgan}' và dung tích được cập nhật.");
        }
        //Code mới:
        private DateTime? LayNgayHetHan(MySqlConnection conn, string maYC)
        {
            try
            {
                string query = "SELECT NgayHetHan FROM YeuCauKhachHang WHERE MaYC = @MaYC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaYC", maYC);

                    object result = cmd.ExecuteScalar();
                    if (result != null && DateTime.TryParse(result.ToString(), out DateTime ngayHetHan))
                    {
                        return ngayHetHan; // Trả về NgayHetHan nếu tồn tại
                    }
                    else
                    {
                        Console.WriteLine($"Không tìm thấy NgayHetHan cho MaYC '{maYC}'.");
                        return null; // Không tìm thấy hoặc lỗi định dạng
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy NgayHetHan từ MaYC '{maYC}': {ex.Message}");
                return null; // Trả về null nếu có lỗi
            }
        }

        private void XuLyDonTuChoi(MySqlConnection conn, IList<object> hang)
        {
            string maYC = hang[9].ToString().Trim();
            if (!KiemTraMayc(conn, maYC))
            {
                Console.WriteLine($"MAYC '{maYC}' không hợp lệ hoặc không ở trạng thái 'Đang xử lý'.");
                return; // Dừng xử lý nếu MAYC không hợp lệ
            }
            string capNhatTrangThai = @"
            UPDATE YeuCauKhachHang
            SET TrangThaiXuLy = 'Từ chối'
            WHERE MaYC = @MaYC";

            using (MySqlCommand cmd = new MySqlCommand(capNhatTrangThai, conn))
            {
                cmd.Parameters.AddWithValue("@MaYC", maYC);
                cmd.ExecuteNonQuery();
            }
        }
        //Thêm logic khi khi xử lí đơn hàng
        /**
         * Kiểm tra MaYC có tồn tại trong bảng yckh chưa
         * Kiểm tra ngăn có hợp lệ ko:
         * ktra dung tich có hợp lí ko
         * Cập nhật trạng thái yêu cầu khi xử lí thành công
         * có các procedure để cập nhật dung tích vào kho
         **/
        private bool KiemTraMayc(MySqlConnection conn, string MAYC)
        {
            try
            {
                if (string.IsNullOrEmpty(MAYC))
                {
                    Console.WriteLine("MAYC không hợp lệ (trống hoặc null).");
                    return false;
                }

                // Kiểm tra MAYC trong bảng YeuCauKhachHang
                string queryCheck = "SELECT TrangThaiXuLy FROM YeuCauKhachHang WHERE MAYC = @MAYC";
                using (MySqlCommand cmd = new MySqlCommand(queryCheck, conn))
                {
                    cmd.Parameters.AddWithValue("@MAYC", MAYC);
                    var result = cmd.ExecuteScalar();

                    if (result == null)
                    {
                        Console.WriteLine($"MAYC '{MAYC}' không tồn tại trong bảng YeuCauKhachHang.");
                        return false;
                    }

                    string TrangThaiHienTai = result.ToString().Trim();
                    if (TrangThaiHienTai != "Đang xử lý")
                    {
                        Console.WriteLine($"MAYC '{MAYC}' không ở trạng thái 'Đang xử lý' (hiện tại: '{TrangThaiHienTai}').");
                        return false;
                    }

                    return true; // MAYC hợp lệ và trạng thái là "Đang xử lý"
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi kiểm tra MAYC '{MAYC}': {ex.Message}");
                return false;
            }
        }
        private bool KiemTraNgan(MySqlConnection conn, string mangan)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Ngan WHERE MaNgan = @MaNgan";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNgan", mangan);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0; // Trả về true nếu ngăn tồn tại
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi kiểm tra ngăn '{mangan}': {ex.Message}");
                return false;
            }
        }
        private int GetDungTichKhaDung(MySqlConnection conn, string maNgan)
        {
            try
            {
                string query = "SELECT DungTichKhaDung FROM Ngan WHERE MaNgan = @MaNgan";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNgan", maNgan);
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1; // Trả về -1 nếu không tìm thấy
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lấy dung tích khả dụng cho ngăn '{maNgan}': {ex.Message}");
                return -1;
            }
        }
        //Hàm gọi proc về cập nhật dung tích:
        private void CapNhatDungTichNgan(MySqlConnection conn, string maNgan, int dungTich)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("CapNhatDungTichNgan", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_MaNgan", maNgan);
                    cmd.Parameters.AddWithValue("@p_DungTich", dungTich);
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine($"Cập nhật dung tích ngăn {maNgan} thành công.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi gọi stored procedure CapNhatDungTichNgan: {ex.Message}");
                throw;
            }
        }
        private void CapNhatDungTichTang(MySqlConnection conn, string maTang, int dungTich)
        {
            try
            {

                using (MySqlCommand cmd = new MySqlCommand("CapNhatDungTichTang", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_MaTang", maTang);
                    cmd.Parameters.AddWithValue("@p_DungTich", dungTich);
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine($"Cập nhật dung tích tầng {maTang} thành công.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi gọi stored procedure CapNhatDungTichTang: {ex.Message}");
                throw;
            }
        }
        private void CapNhatDungTichKe(MySqlConnection conn, string maKe, int dungTich, string TrangThaiMoi)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("CapNhatDungTichKe", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_MaKe", maKe);
                    cmd.Parameters.AddWithValue("@p_DungTich", dungTich);
                    cmd.Parameters.AddWithValue("@p_TrangThai", TrangThaiMoi);

                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine($"Cập nhật dung tích kệ {maKe} thành công.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi gọi stored procedure CapNhatDungTichKe: {ex.Message}");
                throw;
            }
        }
        private void CapNhatDungTichKho(MySqlConnection conn, string maKho, int dungTich)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("CapNhatDungTichKho", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_MaKho", maKho);
                    cmd.Parameters.AddWithValue("@p_DungTich", dungTich);
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine($"Cập nhật dung tích kho {maKho} thành công.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi gọi stored procedure CapNhatDungTichKho: {ex.Message}");
                throw;
            }
        }


        //Các hàm lấy mã hỗ trợ:
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



        //Cập nhật trangthaixuly
        private void CapNhatTrangThaiYeuCau(MySqlConnection conn, string maYC, string trangThaiMoi)
        {
            try
            {
                string query = "UPDATE YeuCauKhachHang SET TrangThaiXuLy = @TrangThaiMoi WHERE MaYC = @MaYC";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TrangThaiMoi", trangThaiMoi);
                    cmd.Parameters.AddWithValue("@MaYC", maYC);
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine($"Cập nhật trạng thái yêu cầu '{maYC}' thành '{trangThaiMoi}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật trạng thái yêu cầu '{maYC}': {ex.Message}");
            }
        }


        public void XuLiFormSua()
        {

            try
            {
                var phamVi1 = "QLK!A1:K";
                var yeuCau1 = dichVuSheets.Spreadsheets.Values.Get("16_vjiCW3xwZd1ZBV5VxFYzvJ1M4-hjTWVCb6OKXDJSs", phamVi1);
                var phanHoi1 = yeuCau1.Execute();
                IList<IList<object>> giaTri1 = phanHoi1.Values;

                var phamVi2 = "QLK!A1:K";
                var yeuCau2 = dichVuSheets.Spreadsheets.Values.Get("16_vjiCW3xwZd1ZBV5VxFYzvJ1M4-hjTWVCb6OKXDJSs", phamVi2);
                var phanHoi2 = yeuCau2.Execute();
                IList<IList<object>> giaTri2 = phanHoi2.Values;

                if (giaTri1 == null || giaTri1.Count == 0 || giaTri2 == null || giaTri2.Count == 0)
                {
                    Console.WriteLine("Không có dữ liệu trong Google Sheets.");
                    return;
                }
                for (int i = 1; i < giaTri1.Count; i++)
                {
                    var hang1 = giaTri1[i];
                    string suaForm1 = hang1[10].ToString();
                    TryParseDateTime(hang1[0].ToString(), out DateTime thoiGianNhap1);


                    if (suaForm1 == "Không")
                    {
                        for (int j = i + 1; j < giaTri2.Count; j++)
                        {
                            var hang2 = giaTri2[j];
                            string suaForm2 = hang2[10].ToString();
                            TryParseDateTime(hang2[0].ToString(), out DateTime thoiGianNhap2);
                            if (suaForm2 == "Có")
                            {
                                if (hang1[3].ToString() == hang2[3].ToString()) //&& ((thoiGianNhap1 - thoiGianNhap2).TotalMinutes <= 10)) // kiểm tra cccd và tg <= 10 phút mới cho sửa
                                {

                                    hang1[2] = hang2[2];
                                    hang1[4] = hang2[4];
                                    hang1[5] = hang2[5];
                                    hang1[6] = hang2[6];
                                    hang1[7] = hang2[7];
                                    hang1[8] = hang2[8];
                                    hang1[9] = hang2[9];
                                    hang1[10] = "Không";
                                    CapNhatSuaForm(giaTri1, phamVi1);
                                    XoaHangSuaForm(j);
                                }
                            }
                            else
                            {
                                continue;
                            }

                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
        }
        public void CapNhatSuaForm(IList<IList<object>> updatedData, string range)
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
                var request = dichVuSheets.Spreadsheets.Values.BatchUpdate(batchUpdateRequest, "16_vjiCW3xwZd1ZBV5VxFYzvJ1M4-hjTWVCb6OKXDJSs");

                // Thực thi yêu cầu
                request.Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cập nhật Google Sheets thất bại: " + ex.Message);
            }
        }
        // xoa form sai
        public void XoaHangSuaForm(int rowIndex)
        {
            try
            {
                // Tạo một yêu cầu BatchUpdate để xóa hàng
                var deleteRequest = new Google.Apis.Sheets.v4.Data.Request
                {
                    DeleteDimension = new Google.Apis.Sheets.v4.Data.DeleteDimensionRequest
                    {
                        Range = new Google.Apis.Sheets.v4.Data.DimensionRange
                        {
                            SheetId = 2113057406, // Thay sheet ID cho phù hợp
                            Dimension = "ROWS",
                            StartIndex = rowIndex,
                            EndIndex = rowIndex + 1
                        }
                    }
                };

                // Tạo BatchUpdateRequest và thêm yêu cầu xóa hàng
                var batchUpdateRequest = new Google.Apis.Sheets.v4.Data.BatchUpdateSpreadsheetRequest
                {
                    Requests = new List<Google.Apis.Sheets.v4.Data.Request> { deleteRequest }
                };

                // Gửi yêu cầu
                dichVuSheets.Spreadsheets.BatchUpdate(batchUpdateRequest, "16_vjiCW3xwZd1ZBV5VxFYzvJ1M4-hjTWVCb6OKXDJSs").Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa hàng trong Google Sheets: " + ex.Message);
            }
        }
        // Hàm hỗ trợ thêm hoặc cập nhật khách hàng vào database
        public void AddOrUpdateKhachHang(MySqlConnection conn, string tenKH, string soDienThoai, string email, string diaChi, string cCCD)
        {
            MySqlCommand ktKhachHang = new MySqlCommand("SELECT COUNT(*) FROM KhachHang WHERE CCCD = @cCCD", conn);
            ktKhachHang.Parameters.AddWithValue("@cCCD", cCCD);
            int count = Convert.ToInt32(ktKhachHang.ExecuteScalar());

            if (count == 0)
            {
                string themKh = @"INSERT INTO KhachHang (TenKH, SoDienThoai, Email, DiaChi, CCCD) 
                          VALUES (@tenKH, @soDienThoai, @email, @diaChi, @cCCD)";
                using (MySqlCommand cmd = new MySqlCommand(themKh, conn))
                {
                    cmd.Parameters.AddWithValue("@tenKH", tenKH);
                    cmd.Parameters.AddWithValue("@soDienThoai", soDienThoai);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@diaChi", diaChi);
                    cmd.Parameters.AddWithValue("@cCCD", cCCD);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        // Xóa các hàng đã xử lý trong Google Sheets
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
                                    SheetId = 2113057406,
                                    /*SheetId = id,*/
                                    Dimension = "ROWS",
                                    StartIndex = rowIndex,
                                    EndIndex = rowIndex + 1
                                }
                            }
                        };
                        batchUpdateRequest.Requests.Add(deleteRequest);
                    }

                    var batchUpdate = dichVuSheets.Spreadsheets.BatchUpdate(batchUpdateRequest, "16_vjiCW3xwZd1ZBV5VxFYzvJ1M4-hjTWVCb6OKXDJSs");
                    batchUpdate.Execute();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi xóa hàng từ Google Sheets: " + ex.Message);
                }
            }
        }
        public void XoaHangGoogleSheet_XacNhan(List<int> rowsToDelete)
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
                                    SheetId = 981782711,
                                    /*SheetId = id,*/
                                    Dimension = "ROWS",
                                    StartIndex = rowIndex,
                                    EndIndex = rowIndex + 1
                                }
                            }
                        };
                        batchUpdateRequest.Requests.Add(deleteRequest);
                    }

                    var batchUpdate = dichVuSheets.Spreadsheets.BatchUpdate(batchUpdateRequest, "117BL-60p2O25_AF1riNMpdqCWByQfY1PfsGnD-STQFM");
                    batchUpdate.Execute();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi xóa hàng từ Google Sheets: " + ex.Message);
                }
            }
        }
        //Hàm chuyển đổi thời gian
        public bool TryParseDateTime(string dateString, out DateTime dateTime)
        {
            string[] dateTimeFormats = { "dd/MM/yyyy HH:mm:ss", "dd/MM/yyyy H:mm:ss", "dd/MM/yyyy HH:mm", "dd/MM/yyyy H:mm" };
            return DateTime.TryParseExact(dateString, dateTimeFormats, null, System.Globalization.DateTimeStyles.None, out dateTime);
        }




    }
}
