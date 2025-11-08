using DAL.Model;
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
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using OfficeOpenXml;
using System.Text.RegularExpressions;
using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using static Mysqlx.Datatypes.Scalar.Types;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout.Properties;


using iText.Layout;

using iText.Commons.Actions;
using iText.IO.Font.Constants;
using iText.Kernel.Pdf.Xobject;
using System.Collections;


namespace DAL
{
    public class QuanLyKiemKeDAL
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        
        private SheetsService dichVuSheets;
        private string diaChiSheet = "16_vjiCW3xwZd1ZBV5VxFYzvJ1M4-hjTWVCb6OKXDJSs";
        private string phamViNoiBo = "KKNB!C1:E";
        private string phamViChoThue = "KKCT!C1:E";
        private string ketNoi = "server = sql5.freesqldatabase.com;Database = sql5742970; Uid = sql5742970;Pwd = BPHD48Fx7i; Charset = utf8mb4";

        public QuanLyKiemKeDAL()
        {
            KhoiTaoGoogleSheets();
        }



        public void KhoiTaoGoogleSheets()
        {
            try
            {
                // mảng chứa các quyền mà ứng dụng muốn yêu cầu đc sài từ google
                // ứng dụng chỉ yêu cầu quyền truy cập vào Google Sheets.
                string[] Scopes = { SheetsService.Scope.Spreadsheets }; 

                var clientSecrets = new ClientSecrets   /////chứa thông tin định danh ứng dụng của bạn
                {
                    ClientId = "YOUR_GOOGLE_CLIENT_ID",  
                    ///  Mã định danh của ứng dụng được tạo trên Google Cloud Console.
                    ClientSecret = "YOUR_GOOGLE_CLIENT_SECRET"
                    ///Chuỗi bảo mật liên kết với ClientId. Nó cho phép Google nhận biết ứng dụng của bạn.
                };

                // Đây là phương thức của Google API Client Library
                // dùng để ủy quyền (authorization) ứng dụng truy cập các dịch vụ của Google (trong trường hợp này là Google Sheets).
                var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    clientSecrets,
                    Scopes,
                    "user", //// Đây là định danh người dùng, trong trường hợp ứng dụng
                            //// của bạn cho phép nhiều người dùng truy cập.
                            ///"user" biểu thị rằng thông tin xác thực được lưu sẽ áp dụng cho người dùng hiện tại.
                            /// Lưu ý là người sở hữu project trên gg cloud console phải chia sẻ quyền truy cập chỉnh sửa gg form
                 
                    CancellationToken.None,
                    //Đây là token dùng để hủy bỏ một tác vụ không đồng bộ. Ở đây, bạn không hủy bỏ, nên sử dụng CancellationToken.None.

                    new FileDataStore("MyAppsToken")  
                    // Lớp FileDataStore được dùng để lưu thông tin xác thực của người dùng (token) vào ổ đĩa dưới dạng file.
                  // "MyAppsToken" là tên thư mục mà token sẽ được lưu trữ(thường nằm ở thư mục ứng dụng trong máy tính của bạn).

                ).Result; //AuthorizeAsync là một phương thức bất đồng bộ (async). Sử dụng
                          //.Result để đợi cho đến khi phương thức hoàn tất và trả về kết quả đồng bộ.
                //Kết quả trả về là một đối tượng UserCredential, chứa thông tin đăng nhập đã được ủy quyền.



                dichVuSheets = new SheetsService(new BaseClientService.Initializer()  // khi đã có thông tin đăng nhập dc ủy quyền
                                                                                      // tiến hành yêu cầu cấp quyền dịch vụ gg sheets
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Google Sheets API .NET Quickstart",
                });
                Console.WriteLine("Khởi tạo dịch vụ gg sheet thành công");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi khởi tạo Google Sheets API: " + ex.Message);
            }
        }


        //public void LayDuLieuSheetNoiBo() // lấy dữ liệu từ gg sheet và bỏ vào database
        //{

        //    try
        //    {
        //        /////////////////
        //        List<int> rowsToDelete = new List<int>();

        //        // Đọc dữ liệu từ Google Sheets
        //        var yeuCau = dichVuSheets.Spreadsheets.Values.Get(diaChiSheet, phamViNoiBo);
        //        var phanHoi = yeuCau.Execute();
        //        IList<IList<object>> giaTri = phanHoi.Values;

        //        if (giaTri == null || giaTri.Count == 0)
        //        {
        //            Console.WriteLine("Không có dữ liệu trong Google Sheets.");
        //            return;
        //        }

        //        var tenCot = giaTri[0];
        //        int indexMaNV = tenCot.IndexOf("Mã nhân viên");
        //        int indexMaHH = tenCot.IndexOf("Mã hàng hóa");
        //        int indexNgayKK = tenCot.IndexOf("Ngày kiểm kê");
        //        int indexSoLuong = tenCot.IndexOf("Số lượng");

        //        // mỗi một dòng trong gg sheet là dữ liệu kiểm kê của một loại hàng hóa nội bộ nào đó


        //        using (MySqlConnection conn = new MySqlConnection(ketNoi))
        //        {
        //            conn.Open();
        //            for (int i = 1; i < giaTri.Count; i++)
        //            {
        //                var hang = giaTri[i];

        //                // kiểm tra ngày kiểm kê
        //                if (TryParseDateTime(hang[indexNgayKK].ToString(), out DateTime thoiGianNhap) == false)

        //                {
        //                    Console.WriteLine("Ngày nhập không hợp lệ tại dòng: " + (i + 1).ToString());
        //                    continue;
        //                }

        //                string maNV = Convert.ToString(hang[indexMaNV]).Trim() ;
        //                string maHH = Convert.ToString(hang[indexMaHH]).Trim();
        //                int soLuong = Int32.Parse(  Convert.ToString(hang[indexSoLuong]).Trim()  );
        //                DateTime ngayNhap = thoiGianNhap;

        //                // kiểm tra số lượng
        //                if (soLuong < 0)
        //                {
        //                    Console.WriteLine("Số lượng hàng hóa không hợp lệ tại dòng lệ tại dòng: " + (i + 1).ToString());
        //                    continue;
        //                }
        //                // kiểm tra mã nhân viên
        //                if (KiemTraMaNV(maNV, conn) == false)
        //                {
        //                    Console.WriteLine("Mã nhân viên không hợp lệ tại dòng lệ tại dòng: " + (i + 1).ToString());
        //                    continue;
        //                }

        //                // kiểm tra mã hàng hóa
        //                if (KiemTraMaHH(maHH, conn) == false)
        //                {
        //                    Console.WriteLine("Mã hàng hóa không hợp lệ tại dòng lệ tại dòng: " + (i+1).ToString());
        //                    continue;
        //                }

        //                // Nếu ok hết thì thêm vào dataabse
        //                int newMaKK = 0;
        //                string query = "insert into KiemKeNoiBo ( MaKK, MaNV,MaHangHoa,SoLuong, NgayKK) values" +
        //                    "  ( @MaKK, @MaNV, @MaHangHoa, @SoLuong, @NgayKK)";
        //                string query1 = "select count(*) from KiemKeNoiBo"; // tự tạo mã kiểm kê


        //                using (MySqlCommand cmd = new MySqlCommand(query1, conn))
        //                {
        //                    int count = Convert.ToInt32(cmd.ExecuteScalar());
        //                    newMaKK = count + 1;
        //                }

        //                using (MySqlCommand cmd = new MySqlCommand(query, conn))
        //                {
        //                    string maKK = "KKNB_" + newMaKK.ToString();
        //                    cmd.Parameters.AddWithValue("@MaNV", maNV);
        //                    cmd.Parameters.AddWithValue("@MaKK", maKK);
        //                    cmd.Parameters.AddWithValue("@SoLuong", soLuong);
        //                    cmd.Parameters.AddWithValue("@MaHangHoa", maHH);
        //                    cmd.Parameters.AddWithValue("@NgayKK", ngayNhap);
        //                    int row = cmd.ExecuteNonQuery();
        //                }

        //                Console.WriteLine("Thêm thành công hàng thứ: " + (i + 1).ToString());
        //                rowsToDelete.Add(i);
        //            }
        //            XoaHangGoogleSheetKiemKeNoiBo(rowsToDelete);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Lỗi: " + ex.Message);
        //    }
        //}



        public async Task LayDuLieuSheetNoiBo() // lấy dữ liệu từ gg sheet và bỏ vào database
        {
            try
            {
                //xoaDuLieuKiemKeChoThue();
                /////////////////
                List<int> rowsToDelete = new List<int>();

                // Đọc dữ liệu từ Google Sheets
                var yeuCau = dichVuSheets.Spreadsheets.Values.Get(diaChiSheet, phamViNoiBo);
                var phanHoi = yeuCau.Execute();
                IList<IList<object>> giaTri = phanHoi.Values;

                if (giaTri == null || giaTri.Count == 0)
                {
                    Console.WriteLine("Không có dữ liệu trong Google Sheets.");
                    return;
                }

                var tenCot = giaTri[0];
                int indexMaNV = tenCot.IndexOf("Mã nhân viên");
                int indexNgayKK = tenCot.IndexOf("Ngày kiểm kê");
                int indexTinhTrangKho = tenCot.IndexOf("Tình trạng kho");  // tình trạng kho là  link dẫn tới một file excel




                using (MySqlConnection conn = new MySqlConnection(ketNoi))
                {
                    conn.Open();
                    for (int i = 1; i < giaTri.Count; i++)
                    {
                        var hang = giaTri[i];

                        // kiểm tra ngày kiểm kê
                        if (TryParseDateTime(hang[indexNgayKK].ToString(), out DateTime thoiGianNhap) == false
                            )  
                        {
                            Console.WriteLine("Ngày nhập không hợp lệ tại dòng: " + (i + 1).ToString());
                            continue;
                        }

                        string maNV = Convert.ToString(hang[indexMaNV]).Trim();
                        DateTime ngayKiemKe = DateTime.Parse(thoiGianNhap.ToString("dd/MM/yyyy"));

                        //Console.WriteLine(maNV);///////////////////////////////////////////




                        //Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAA");///////////////////////////////////////////

                        // kiểm tra mã nhân viên
                        if (KiemTraMaNV(maNV, conn) == false)
                        {
                            Console.WriteLine("Mã nhân viên không hợp lệ tại dòng: " + (i + 1).ToString());
                            continue;
                        }
                        //Console.WriteLine("BBBBBBBBBBBBBBBBBBBBBBBAAAAAAAAAAAA");



                        //// tải file excel và kiểm tra
                        /// tách url của gg drive và url của file
                        Console.WriteLine((hang[indexTinhTrangKho]).ToString());
                        string url = ExtractFileId((hang[indexTinhTrangKho]).ToString());
                        if (url == null)
                        {
                            Console.WriteLine("link gg drive ko tồn tại");
                            return;
                        }
                        string fileURL = "https://drive.google.com/uc?export=download&id=" + url;

                        string fileName = $"KiemKeNB_{DateTime.Now:yyyyMMdd_HHmmss}_{Guid.NewGuid()}.xlsx";
                        string savePath = Path.Combine(desktopPath, fileName);

                        await DownloadExcelFileAsync(fileURL, savePath);
                        Console.WriteLine("Tệp Excel đã được tải về tại: " + savePath);



                        // thêm vào dataabse

                        readDuLieuExcelNoiBo(savePath, conn, maNV, ngayKiemKe);




                        Console.WriteLine("Thêm thành công");
                        rowsToDelete.Add(i);


                    }
                    XoaHangGoogleSheetKiemKeNoiBo(rowsToDelete);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
        }


        private void readDuLieuExcelNoiBo(string filePath, MySqlConnection conn, string maNV, DateTime ngayKK)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Cần cho EPPlus
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0]; // Lấy sheet đầu tiên
                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;


                for (int row = 2; row <= rowCount; row++) // Bỏ qua hàng tiêu đề
                {
                    string maHH = worksheet.Cells[row, 1].Text; // Cột 1
                    int soLuong = Int32.Parse(worksheet.Cells[row, 2].Text); // Cột 2

                    if (KiemTraTruocKhiThemDuLieuNoiBo(maHH, soLuong, conn) == false)
                    {
                        continue;
                    }

                    // Thêm vào cơ sở dữ liệu
                    string query = "INSERT INTO KiemKeNoiBo (MaKK, MaNV,NgayKK, MaHangHoa,SoLuong )" +
                        " VALUES (@MaKK, @MaNV,@NgayKK, @MaHangHoa,@SoLuong )";
                    string query1 = "select count(*) from KiemKeNoiBo"; // tự tạo mã kiểm kê
                    string newMaKK;


                    using (MySqlCommand cmd = new MySqlCommand(query1, conn))
                    {
                        int count = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                        newMaKK = "KKNB_" + count.ToString();
                    }
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKK", newMaKK);
                        cmd.Parameters.AddWithValue("@MaNV", maNV);
                        cmd.Parameters.AddWithValue("@NgayKK", ngayKK);
                        cmd.Parameters.AddWithValue("@MaHangHoa", maHH);
                        cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        private async Task<string> DownloadExcelFileAsync(string url, string savePath)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    using (var fs = new FileStream(savePath, FileMode.Create, FileAccess.Write))
                    {
                        await response.Content.CopyToAsync(fs);
                    }
                    return savePath;
                }
                throw new Exception("Tải tệp Excel thất bại.");
            }
        }


        private void readDuLieuExcelChoThue(string filePath, MySqlConnection conn, string maNV, DateTime ngayKK)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Cần cho EPPlus
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0]; // Lấy sheet đầu tiên
                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;


                for (int row = 2; row <= rowCount; row++) // Bỏ qua hàng tiêu đề
                {
                    string maNgan = worksheet.Cells[row, 1].Text; // Cột 1
                    float dungTich = float.Parse (worksheet.Cells[row, 2].Text); // Cột 2


                    // kiểm tra mã ngăn và dung tích
                    if (KiemTraTruocKhiThemDuLieuChoThue(maNgan,dungTich,conn) == false)
                    {
                        continue;
                    }    

                                                                     // Thêm vào cơ sở dữ liệu
                    string query = "INSERT INTO KiemKe (MaKK, MaNV,NgayKK, MaNgan,DungTichDaDung )" +
                        " VALUES (@MaKK, @MaNV,@NgayKK, @MaNgan,@DungTichDaDung )";
                    string query1 = "select count(*) from KiemKe"; // tự tạo mã kiểm kê
                    string newMaKK;

                   
                    using (MySqlCommand cmd = new MySqlCommand(query1, conn))
                    {
                        int count = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                        newMaKK = "KKCT_" + count.ToString();
                    }
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKK", newMaKK);
                        cmd.Parameters.AddWithValue("@MaNV", maNV);
                        cmd.Parameters.AddWithValue("@NgayKK", ngayKK);
                        cmd.Parameters.AddWithValue("@MaNgan", maNgan);
                        cmd.Parameters.AddWithValue("@DungTichDaDung", dungTich);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private  string ExtractFileId(string url)
        {
            // Biểu thức chính quy để tìm File ID trong URL Google Drive
            string pattern = @"(?:drive\.google\.com\/(?:.*?[\/]d\/|.*\?id=))([a-zA-Z0-9_-]+)";

            // Sử dụng Regex để tìm ID
            Match match = Regex.Match(url, pattern);

            if (match.Success)
            {
                // Trả về File ID
                return match.Groups[1].Value;
            }
            else
            {
                // Nếu không tìm thấy File ID, trả về null hoặc thông báo lỗi
                return null;
            }

            // Biểu thức chính quy để tìm File ID trong URL Google Drive
            //string pattern = @"(?:drive\.google\.com\/(?:.*?[\/]d\/|.*\?id=))([a-zA-Z0-9_-]+)";

            //// Sử dụng Regex để tìm ID
            //Match match = Regex.Match(url, pattern);

            //if (match.Success)
            //{
            //    // Trả về URL tải xuống
            //    string fileId = match.Groups[1].Value;
            //    return fileId;
            //}
            //else
            //{
            //    // Nếu không tìm thấy File ID, trả về null hoặc thông báo lỗi
            //    return null;
            //}
        }

        private void xoaDuLieuKiemKeChoThue()
        {
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    string query = "delete from KiemKe";

                    using (var cmd = new MySqlCommand(query, conn))
                    {                       
                        cmd.ExecuteNonQuery();
                    }
                }
                catch ( Exception e ) 
                {
                    Console.WriteLine( e.Message );
                }
                
            }
        }

        public async Task LayDuLieuSheetChoThue() // lấy dữ liệu từ gg sheet và bỏ vào database
        {

            try
            {
                //xoaDuLieuKiemKeChoThue();
                /////////////////
                List<int> rowsToDelete = new List<int>();

                // Đọc dữ liệu từ Google Sheets
                var yeuCau = dichVuSheets.Spreadsheets.Values.Get(diaChiSheet, phamViChoThue);
                var phanHoi = yeuCau.Execute();
                IList<IList<object>> giaTri = phanHoi.Values;

                if (giaTri == null || giaTri.Count == 0)
                {
                    Console.WriteLine("Không có dữ liệu trong Google Sheets.");
                    return;
                }

                var tenCot = giaTri[0];
                int indexMaNV = tenCot.IndexOf("Mã nhân viên");
                int indexNgayKK = tenCot.IndexOf("Ngày kiểm kê");
                int indexTinhTrangKho = tenCot.IndexOf("Tình trạng kho");  // tình trạng kho là  link dẫn tới một file excel




                using (MySqlConnection conn = new MySqlConnection(ketNoi))
                {
                    conn.Open();
                    for (int i = 1; i < giaTri.Count; i++)
                    {
                        var hang = giaTri[i];

                        // kiểm tra ngày kiểm kê
                        if (TryParseDateTime(hang[indexNgayKK].ToString(), out DateTime thoiGianNhap) == false 
                            )   // dữ liệu kiểm kê phải dc gửi trong cùng ngày quản lý yêu cầu
                        {
                            Console.WriteLine("Ngày nhập không hợp lệ tại dòng: " + (i + 1).ToString());
                            continue;
                        }

                        string maNV = Convert.ToString(hang[indexMaNV]).Trim();
                        DateTime ngayKiemKe = DateTime.Parse(thoiGianNhap.ToString("dd/MM/yyyy"));

                        //Console.WriteLine(maNV);///////////////////////////////////////////




                        //Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAA");///////////////////////////////////////////

                        // kiểm tra mã nhân viên
                        if (KiemTraMaNV(maNV, conn) == false)
                        {
                            Console.WriteLine("Mã nhân viên không hợp lệ tại dòng lệ tại dòng: " + (i + 1).ToString());
                            continue;
                        }
                        //Console.WriteLine("BBBBBBBBBBBBBBBBBBBBBBBAAAAAAAAAAAA");



                        //// tải file excel và kiểm tra
                        /// tách url của gg drive và url của file
                        Console.WriteLine((hang[indexTinhTrangKho]).ToString());
                        string url = ExtractFileId((hang[indexTinhTrangKho]).ToString());
                        if (url == null)
                        {
                            Console.WriteLine("link gg drive ko tồn tại");
                            return;
                        }
                        string fileURL = "https://drive.google.com/uc?export=download&id=" + url;

                        string fileName = $"KiemKeCT_{DateTime.Now:yyyyMMdd_HHmmss}_{Guid.NewGuid()}.xlsx";
                        string savePath = Path.Combine(desktopPath, fileName);

                        await DownloadExcelFileAsync(fileURL, savePath);
                        Console.WriteLine("Tệp Excel đã được tải về tại: " + savePath);



                        // thêm vào dataabse

                        readDuLieuExcelChoThue(savePath, conn, maNV, ngayKiemKe);




                        Console.WriteLine("Thêm thành công");
                        rowsToDelete.Add(i);


                    }
                    XoaHangGoogleSheetKiemKeChoThue(rowsToDelete);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
        }

        

        public void XoaHangGoogleSheetKiemKeNoiBo(List<int> rowsToDelete)
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
                                    SheetId = 1952076405, // id của bảng tính trong sheet
                                    Dimension = "ROWS",
                                    StartIndex = rowIndex,
                                    EndIndex = rowIndex + 1
                                }
                            }
                        };
                        batchUpdateRequest.Requests.Add(deleteRequest);
                    }

                    var batchUpdate = dichVuSheets.Spreadsheets.BatchUpdate(batchUpdateRequest, diaChiSheet);
                    batchUpdate.Execute();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi xóa hàng từ Google Sheets: " + ex.Message);
                }
            }
        }


        public void XoaHangGoogleSheetKiemKeChoThue(List<int> rowsToDelete)
        {
            if (rowsToDelete.Count > 0)
            {
                try
                {
                    //var request = dichVuSheets.Spreadsheets.Get(diaChiSheet);
                    //var response = request.Execute();

                    //foreach (var sheet in response.Sheets)
                    //{
                    //    var properties = sheet.Properties;
                    //    Console.WriteLine($"Sheet name: {properties.Title}, Sheet ID: {properties.SheetId}");

                    //}

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
                                    SheetId = 774965345,

                                    /*SheetId = id,*/
                                    Dimension = "ROWS",
                                    StartIndex = rowIndex,
                                    EndIndex = rowIndex + 1
                                }
                            }
                        };
                        batchUpdateRequest.Requests.Add(deleteRequest);
                    }

                    var batchUpdate = dichVuSheets.Spreadsheets.BatchUpdate(batchUpdateRequest, diaChiSheet);
                    batchUpdate.Execute();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi xóa hàng từ Google Sheets: " + ex.Message);
                }
            }
        }


        public bool TryParseDateTime(string dateString, out DateTime dateTime)
        {
            string[] dateTimeFormats = { "dd/MM/yyyy"};
            return DateTime.TryParseExact(dateString, dateTimeFormats, null, System.Globalization.DateTimeStyles.None, out dateTime);
        }


        private bool KiemTraMaNV ( string maNV, MySqlConnection conn)
        {
            string query = @"select count(*) from NhanVienKho where MaNV = @MaNV";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@MaNV", maNV);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count == 0)
                    {
                        return false;  // mã nhân viên ko tồn tại
                    }
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }   
            }
            
        }



        private bool KiemTraTruocKhiThemDuLieuNoiBo(string maHH,int SoLuong, MySqlConnection conn) // kiểm tra dữ liệu trên excel trước khi thêm vào bảng nội bộ
        {
            if (SoLuong <0)
            {
                return false;
            }    


            string query = "select count(*) from HangHoaNoiBo where MaHangHoa = @MaHangHoa";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@MaHangHoa", maHH);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count == 0)
                    {
                        return false;  // mã hàng hóa ko tồn tại
                    }
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }

            }
           
        }


        private bool KiemTraTruocKhiThemDuLieuChoThue(string maNgan, float dungTich, MySqlConnection conn) // kiểm tra dữ liệu trên excel trước khi thêm vào bảng nội bộ
        {
            if (dungTich < 0)
            {
                return false;
            }


            string query = "select count(*) from Ngan where MaNgan = @MaNgan";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@MaNgan", maNgan);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count == 0)
                    {
                        return false;  // mã hàng hóa ko tồn tại
                    }
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }

            }

        }






        public DataTable LayDuLieuKiemKeNoiBo()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    string query = @"
                    SELECT 
                        NgayKK as 'Ngày kiểm kê' ,MaHangHoa as 'Mã hàng hóa', SoLuong as 'Số lượng', MaNV as 'Mã nhân viên'
                    FROM KiemKeNoiBo
                    ";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi lấy dữ liệu: " + ex.Message);
                }
            }
            return dt;
        }

        public string capNhatKiemKeNoiBo(DataTable dt)
        {
            List<string> loi = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();

                    // Tắt khóa ngoại
                    using (MySqlCommand disableFKConstraintsCommand = new MySqlCommand("SET foreign_key_checks = 0;", conn))
                    {
                        disableFKConstraintsCommand.ExecuteNonQuery();
                    }

                    foreach (DataRow row in dt.Rows)
                    {
                        string maHH = row["Mã hàng hóa"].ToString();
                        string maNV = row["Mã nhân viên"].ToString();
                        string maKK = row["Mã kiểm kê"].ToString();

                        // Kiểm tra ngày kiểm kê
                        if (!DateTime.TryParse(row["Ngày kiểm kê"].ToString(), out DateTime ngay))
                        {
                            Console.WriteLine($"Ngày kiểm kê không hợp lệ cho Mã kiểm kê: {maKK}");
                            loi.Add(maKK);
                            continue;
                        }

                        // Kiểm tra số lượng
                        if (!int.TryParse(row["Số lượng"].ToString(), out int soLuong) || soLuong < 0)
                        {
                            Console.WriteLine($"Số lượng không hợp lệ cho Mã kiểm kê: {maKK}");
                            loi.Add(maKK);
                            continue;
                        }

                        // Kiểm tra sự tồn tại của mã hàng hóa
                        string kiemTraMaHH = "SELECT COUNT(*) FROM HangHoaNoiBo WHERE MaHangHoa = @MaHangHoa";
                        using (MySqlCommand cmd = new MySqlCommand(kiemTraMaHH, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaHangHoa", maHH);
                            object result = cmd.ExecuteScalar();
                            if (result == null || Convert.ToInt32(result) == 0)
                            {
                                Console.WriteLine($"Mã hàng hóa không tồn tại: {maHH}");
                                loi.Add(maKK);
                                continue;
                            }
                        }

                        // Kiểm tra sự tồn tại của mã nhân viên
                        string kiemTraMaNV = "SELECT COUNT(*) FROM NhanVienKho WHERE MaNV = @MaNV";
                        using (MySqlCommand cmd = new MySqlCommand(kiemTraMaNV, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaNV", maNV);
                            object result = cmd.ExecuteScalar();
                            if (result == null || Convert.ToInt32(result) == 0)
                            {
                                Console.WriteLine($"Mã nhân viên không tồn tại: {maNV}");
                                loi.Add(maKK);
                                continue;
                            }
                        }

                        // Cập nhật số lượng
                        string updateSoLuong = "UPDATE HangHoaNoiBo SET SoLuong = @SoLuong WHERE MaHangHoa = @MaHangHoa";
                        using (MySqlCommand cmd = new MySqlCommand(updateSoLuong, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaHangHoa", maHH);
                            cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Bật lại khóa ngoại
                    using (MySqlCommand enableFKConstraintsCommand = new MySqlCommand("SET foreign_key_checks = 1;", conn))
                    {
                        enableFKConstraintsCommand.ExecuteNonQuery();
                    }

                    // Xử lý kết quả
                    if (loi.Count > 0)
                    {
                        return $"Cập nhật dữ liệu kiểm kê nội bộ thành công. Các dòng bị lỗi: {string.Join(", ", loi)}";
                    }

                    return "Cập nhật dữ liệu kiểm kê nội bộ thành công!";
                }
                catch (Exception ex)
                {
                    return $"Lỗi khi cập nhật dữ liệu: {ex.Message}";
                }
            }
        }







        public DataTable LayDuLieuKiemKeChoThue()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    string query = @"
                    SELECT 
                        NgayKK as 'Ngày kiểm kê',MaNgan as 'Mã ngăn', DungTichDaDung as 'Dung tích đã dùng', MaNV as 'Mã nhân viên'
                    FROM KiemKe
                    ";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi lấy dữ liệu: " + ex.Message);
                }
            }
            return dt;
        }




        public string inDanhSachNoiBo(string path, DataTable dt)
        {
            try
            {


                if (dt.Rows.Count == 0)
                {
                    return "không có dữ liệu để in";
                }


                // Đường dẫn font Arial Unicode
                string fontPath = @"C:\Windows\Fonts\arial.ttf"; // Đường dẫn chính xác tới font
                PdfFont font = PdfFontFactory.CreateFont(fontPath, PdfEncodings.IDENTITY_H);

                // Tạo file PDF

                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {

                    PdfWriter writer = new PdfWriter(fs);
                    PdfDocument pdf = new PdfDocument(writer);
                    Document document = new Document(pdf);

                    // Sử dụng font hỗ trợ tiếng Việt
                    document.SetFont(font);

                    // Tiêu đề phiếu nhập
                    Text tieuDe = new Text("KIỂM KÊ NỘI BỘ").SetFont(font);
                    document.Add(new Paragraph().Add(tieuDe).SetFontSize(23).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                    document.Add(new Paragraph().Add("WarehouseMA - QUẢN LÝ KHO").SetFontSize(13).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));

                    document.Add(new Paragraph("\n")); // Thêm dòng trống

                    // Tạo bảng PDF với số cột bằng số cột trong DataTable
                    Table table = new Table(UnitValue.CreatePercentArray(dt.Columns.Count)).UseAllAvailableWidth();


                    // Thêm header từ DataTable
                    foreach (DataColumn column in dt.Columns) // 'dt' là DataTable chứa dữ liệu
                    {
                        Text boldText = new Text(column.ColumnName).SetFont(font);

                        // Tạo Paragraph
                        Paragraph paragraph = new Paragraph().Add(boldText).SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);

                        // Thêm vào bảng
                        table.AddHeaderCell(new Cell().Add(paragraph));
                    }

                    // Thêm dữ liệu từ DataTable
                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (var cellValue in row.ItemArray)
                        {
                            table.AddCell(new Cell().Add(new Paragraph(cellValue?.ToString() ?? "").SetFontSize(10)));
                        }
                    }

                    // Thêm bảng vào tài liệu
                    document.Add(table);
                    document.Add(new Paragraph("\n")); // Thêm dòng trống nếu cần
                    document.Add(new Paragraph("\n"));
                    document.Add(new Paragraph("\n"));
                    document.Add(new Paragraph("\n"));// Thêm dòng trống nếu cần



                    // Thêm chỗ ký tên xác nhận
                    document.Add(new Paragraph().Add("Tp. Hồ Chí Minh, ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString()).SetFontSize(13).SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT));
                    document.Add(new Paragraph().Add("Người kiểm duyệt").SetFontSize(13).SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT));



                    // Sau khi thêm các nội dung, thêm Header và Footer
                    string ngayYeuCau = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    string headerContent = $"Kiểm kê nội bộ | Ngày xuất báo cáo: {ngayYeuCau}";
                    string footerNote = "Phần mềm: WarehouseMA";



                    // Đánh số trang và thêm header/footer
                    int totalPages = pdf.GetNumberOfPages();
                    for (int i = 1; i <= totalPages; i++)
                    {
                        PdfPage page = pdf.GetPage(i);
                        PdfCanvas canvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdf);

                        // Header
                        canvas.BeginText();
                        canvas.SetFontAndSize(font, 10);
                        canvas.MoveText(34, page.GetPageSize().GetTop() - 20); // Vị trí Header (trên cùng)
                        canvas.ShowText(headerContent);
                        canvas.EndText();

                        // Footer
                        canvas.BeginText();
                        canvas.SetFontAndSize(font, 10);
                        canvas.MoveText(34, 20); // Vị trí Footer (dưới cùng)
                        canvas.ShowText(footerNote);
                        canvas.MoveText(400, 0); // Di chuyển qua phải để đánh số trang
                        canvas.ShowText($"Trang {i}/{totalPages}");
                        canvas.EndText();
                    }
                    document.Close();
                }

                return ("Xuất file thành công tới đường dẫn: " + path);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine($"Lỗi: {ex.Message}");

                return ("Lỗi khi xuất phiếu nhập: " + ex.Message + "\nStackTrace: " + ex.StackTrace);
            }
        }



        public string inDanhSachChoThue(string path, DataTable dt)
        {
            try
            {
                if (dt.Rows.Count == 0)
                {
                    return "không có dữ liệu để in";
                }


                // Đường dẫn font Arial Unicode
                string fontPath = @"C:\Windows\Fonts\arial.ttf"; // Đường dẫn chính xác tới font
                PdfFont font = PdfFontFactory.CreateFont(fontPath, PdfEncodings.IDENTITY_H);

                // Tạo file PDF

                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {

                    PdfWriter writer = new PdfWriter(fs);
                    PdfDocument pdf = new PdfDocument(writer);
                    Document document = new Document(pdf);

                    // Sử dụng font hỗ trợ tiếng Việt
                    document.SetFont(font);

                    // Tiêu đề phiếu nhập
                    Text tieuDe = new Text("KIỂM KÊ CHO THUÊ").SetFont(font);
                    document.Add(new Paragraph().Add(tieuDe).SetFontSize(23).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                    document.Add(new Paragraph().Add("WarehouseMA - QUẢN LÝ KHO").SetFontSize(13).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));

                    document.Add(new Paragraph("\n")); // Thêm dòng trống

                    // Tạo bảng PDF với số cột bằng số cột trong DataTable
                    Table table = new Table(UnitValue.CreatePercentArray(dt.Columns.Count)).UseAllAvailableWidth();


                    // Thêm header từ DataTable
                    foreach (DataColumn column in dt.Columns) // 'dt' là DataTable chứa dữ liệu
                    {
                        Text boldText = new Text(column.ColumnName).SetFont(font);

                        // Tạo Paragraph
                        Paragraph paragraph = new Paragraph().Add(boldText).SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);

                        // Thêm vào bảng
                        table.AddHeaderCell(new Cell().Add(paragraph));
                    }

                    // Thêm dữ liệu từ DataTable
                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (var cellValue in row.ItemArray)
                        {
                            table.AddCell(new Cell().Add(new Paragraph(cellValue?.ToString() ?? "").SetFontSize(10)));
                        }
                    }

                    // Thêm bảng vào tài liệu
                    document.Add(table);
                    document.Add(new Paragraph("\n"));
                    document.Add(new Paragraph("\n"));
                    document.Add(new Paragraph("\n"));
                    document.Add(new Paragraph("\n"));// Thêm dòng trống nếu cần



                    // Thêm chỗ ký tên xác nhận
                    document.Add(new Paragraph().Add("Tp. Hồ Chí Minh, ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString()).SetFontSize(13).SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT));
                    document.Add(new Paragraph().Add("Người kiểm duyệt").SetFontSize(13).SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT));



                    // Sau khi thêm các nội dung, thêm Header và Footer
                    string ngayYeuCau = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    string headerContent = $"Kiểm kê cho thuê | Ngày xuất báo cáo: {ngayYeuCau}";
                    string footerNote = "Phần mềm: WarehouseMA";



                    // Đánh số trang và thêm header/footer
                    int totalPages = pdf.GetNumberOfPages();
                    for (int i = 1; i <= totalPages; i++)
                    {
                        PdfPage page = pdf.GetPage(i);
                        PdfCanvas canvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdf);

                        // Header
                        canvas.BeginText();
                        canvas.SetFontAndSize(font, 10);
                        canvas.MoveText(34, page.GetPageSize().GetTop() - 20); // Vị trí Header (trên cùng)
                        canvas.ShowText(headerContent);
                        canvas.EndText();

                        // Footer
                        canvas.BeginText();
                        canvas.SetFontAndSize(font, 10);
                        canvas.MoveText(34, 20); // Vị trí Footer (dưới cùng)
                        canvas.ShowText(footerNote);
                        canvas.MoveText(400, 0); // Di chuyển qua phải để đánh số trang
                        canvas.ShowText($"Trang {i}/{totalPages}");
                        canvas.EndText();
                    }
                    document.Close();
                }

                return ("Xuất file thành công tới đường dẫn: " + path);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine($"Lỗi: {ex.Message}");

                return ("Lỗi khi xuất phiếu nhập: " + ex.Message + "\nStackTrace: " + ex.StackTrace);
            }
        }
    }
}



