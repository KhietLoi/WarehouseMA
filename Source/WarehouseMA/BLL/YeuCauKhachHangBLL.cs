using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMA.DAL;
using System.Net.Mail;
using System.Diagnostics;
using OfficeOpenXml;
using System.IO;
namespace WarehouseMA.BLL
{
    public class YeuCauKhachHangBLL
    {
        private YeuCauKhachHangDAL YCKHDAL = new YeuCauKhachHangDAL();


        public DataTable LayDuLieuChuaXuLy()
        {
            return YCKHDAL.LayDuLieuTuDatabase();
        }
        //Lấy dữ liệu đang xử lí:
        public DataTable LayDuLieuDangXuLy()
        {
            return YCKHDAL.LayDuLieuTuDatabase_dangxuli();
        }
        //Lấy dữ liệu đã hoàn thành:
        public DataTable LayDuLieuDaNhapHang()
        {
            return YCKHDAL.LayDuLieuTuDatabase_danhaphang();
        }
        //Lấy dữ liệu đã từ chối:
        public DataTable LayDuLieuTuChoi()
        {
            return YCKHDAL.LayDuLieuTuDatabase_tuchoi();
        }
        //Lấy dữ liệu đã rút hàng:
        public DataTable LayDuLieuDaRutHang()
        {
            return YCKHDAL.LayDuLieuTuDatabase_daruthang();
        }
        //Lấy tất cả dữ liệu:
        public DataTable LayDuLieu()
        {
            return YCKHDAL.LayDuLieuTuDatabase_TatCa();
        }
        /**Tìm kiếm
         *  1. Chưa duyệt
         *  2. Đang xử lí
         *  3. Hoàn thành
         *  4. Từ chối
         *  5. Tất cả
         **/
        //Tìm kiếm yêu cầu chưa =duyệt:
        public DataTable TimKiem_chuaduyet(string tuKhoa)
        {
            return YCKHDAL.TimKiemChuaDuyet(tuKhoa);
        }
        //Tìm kiếm yêu cầu đang xử lí:
        public DataTable TimKiem_dangxuli(string tuKhoa)
        {
            return YCKHDAL.TimKiemDangXuLy(tuKhoa);
        }
        //Tìm kiếm yêu cầu đã nhập hàng:
        public DataTable TimKiem_danhaphang(string tuKhoa)
        {
            return YCKHDAL.TimKiemDaNhapHang(tuKhoa);
        }
        //Tìm kiếm yêu cầu đã rút hàng:
        public DataTable TimKiem_darutphang(string tuKhoa)
        {
            return YCKHDAL.TimKiemDaRutHang(tuKhoa);
        }
        //Tìm kiếm yêu cầu từ chối:
        public DataTable TimKiem_tuchoi(string tuKhoa)
        {
            return YCKHDAL.TimKiemTuChoi(tuKhoa);
        }
        //Tìm kiếm tất cả yêu cầu:
        public DataTable TimKiem_tatca(string tuKhoa)
        {
            return YCKHDAL.TimKiemTatCa(tuKhoa);
        }


        public bool CapNhatTrangThaiYeuCau(string maYeuCauHienTai, string trangthaimoi)
        {
            try
            {
                // Gọi phương thức DAL để cập nhật trạng thái yêu cầu
                return YCKHDAL.CapNhatTrangThai(maYeuCauHienTai, trangthaimoi);
            }
            catch (Exception ex)
            {
                // Thêm xử lý nghiệp vụ nếu cần
                throw new Exception("Lỗi khi xử lý trong BLL: " + ex.Message);
            }
        }
        public void GuiEmailThongBao(string maYeuCau)
        {
            try
            {
                var thongTinYC = YCKHDAL.LayThongTinYC(maYeuCau);
                if (string.IsNullOrEmpty(thongTinYC.Email))
                {
                    Console.WriteLine("Không tìm thấy thông tin người nhận cho yêu cầu này.");
                    return;
                }

                var client = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new System.Net.NetworkCredential("letiendat2004.it@gmail.com", "ywan znrs wagl dpyt"),
                    EnableSsl = true
                };

                var toAddress = new System.Net.Mail.MailAddress(thongTinYC.Email);

                // Định dạng chủ đề và nội dung email
                string chuDe = $"[# {maYeuCau}] Đăng ký gửi đồ";
                string noiDung = $@"
Xin chào {thongTinYC.TenKhachHang},
Dịch vụ Warehouse MA thông báo tiếp nhận yêu cầu #{maYeuCau}.
        Thông tin cụ thể như sau:
        - Ngày đăng ký: {thongTinYC.NgayDangKy:dd-MM-yyyy HH:mm:ss}
        - Số lượng thùng S: {thongTinYC.SoLuongThungS}
        - Số lượng thùng M: {thongTinYC.SoLuongThungM}
        - Số lượng thùng L: {thongTinYC.SoLuongThungL}
        - Tình trạng xử lý: Đang xử lý
        - Ngày hết hạn: {thongTinYC.NgayHetHan:dd-MM-yyyy HH:mm:ss}

Đây là Email được gửi tự động từ Hệ thống. 
Quý khách không cần phải hồi đáp cho Email này.
Quý khách có thể liên hệ với chúng tôi theo thông tin sau:
Bộ phận Dịch vụ WarehouseMA
Email: support@warehousema.com 
Tell: 123-456-7890
";

                // Cấu hình SmtpClient cho email
                var thuDienTu = new System.Net.Mail.MailMessage
                {
                    From = new System.Net.Mail.MailAddress("letiendat2004.it@gmail.com"),
                    Subject = chuDe,
                    Body = noiDung
                };
                thuDienTu.To.Add(toAddress);

                client.Send(thuDienTu);
                Console.WriteLine("Đã gửi email thành công đến " + thongTinYC.Email);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Gửi email thất bại: " + ex.Message);
            }
        }
        //Hàm tính tiền từ yêu cầu:
        //Tham chiếu đến từng phần từ cho TinhTien 
        public decimal TinhTheTich(string maYeuCau)
        {
            var thongTinYC = YCKHDAL.LayThongTinYC(maYeuCau);
            // Thể tích của các loại thùng
            int theTichThungS = 20; // Lít
            int theTichThungM = 30; // Lít
            int theTichThungL = 60; // Lít

            // Tổng thể tích hàng hóa
            int tongTheTich =
                (thongTinYC.SoLuongThungS * theTichThungS) +
                (thongTinYC.SoLuongThungM * theTichThungM) +
                (thongTinYC.SoLuongThungL * theTichThungL);
            Debug.WriteLine($"Tổng thể tích: {tongTheTich} lít");
            return tongTheTich;
        }
        public decimal TinhTien(string maYeuCau)
        {
            try
            {
                //Khai báo biến thông tin yêu cầu
                var thongTinYC = YCKHDAL.LayThongTinYC(maYeuCau);

                decimal giaLuuTru = 100; // VNĐ mỗi lít mỗi giờ

                decimal tongTheTich = TinhTheTich(maYeuCau);
                Debug.WriteLine($"Tổng thể tích: {tongTheTich} lít");
                // Tính thời gian lưu trữ (theo giờ)
                TimeSpan thoiGianLuuTru = thongTinYC.NgayHetHan - thongTinYC.NgayDangKy;
                if (thoiGianLuuTru.TotalHours < 0)
                {
                    throw new Exception("Thời gian dự kiến lấy hàng không hợp lệ.");
                }
                //Làm tròn giờ(chỉ lấy phần nguyên):
                decimal soGioLuuTru = Math.Floor((decimal)thoiGianLuuTru.TotalHours);
                Debug.WriteLine($"Tổng thời gian lưu trữ: {thoiGianLuuTru.TotalHours} giờ");
                string ketQua = $"{thoiGianLuuTru.Hours} giờ {thoiGianLuuTru.Minutes} phút {thoiGianLuuTru.Seconds} giây";
                Console.WriteLine($"Tổng thời gian lưu trữ: {ketQua}");
                //Tính tổng tiền 
                decimal tongTien = tongTheTich * soGioLuuTru * giaLuuTru;
                Debug.WriteLine($"Tổng tiền: {tongTien} VNĐ");

                //27-11-2024

                //Tình tổng  tiên:
                // Cập nhật vào cột GiaThanhToan
                YCKHDAL.CapNhatGiaThanhToan(maYeuCau, tongTien);
                return tongTien;
            }
            catch (Exception ex)
            {
                {

                    throw new Exception("Lỗi khi tính tiền: " + ex.Message);
                }
            }
        }

        //Lấy thông tin khách hàng cần thiết:



        public (string Email, string TenKhachHang, DateTime NgayDangKy, int SoLuongThungS, int SoLuongThungM, int SoLuongThungL, DateTime NgayHetHan, int dungtich)
            LayThongTinYC(string maYeuCau)
        {
            return YCKHDAL.LayThongTinYC(maYeuCau);
        }
        //in excel
        public List<Dictionary<string, object>> GetDataByTrangThai(string trangThaiChon)
        {
            return YCKHDAL.GetDataByTrangThai(trangThaiChon); // Gọi phương thức DAL để lấy dữ liệu
        }

        // Phương thức xuất báo cáo ra Excel
        public void InToExcel(string trangThaiChon)
        {
            try
            {
                // Thiết lập LicenseContext trước khi sử dụng EPPlus
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.Commercial; // Hoặc LicenseContext.NonCommercial nếu dùng phiên bản miễn phí

                // Lấy dữ liệu theo trạng thái từ DAL
                var dataToExport = GetDataByTrangThai(trangThaiChon);

                // Tạo một gói Excel mới
                using (var package = new OfficeOpenXml.ExcelPackage())
                {
                    // Tạo một worksheet mới
                    var worksheet = package.Workbook.Worksheets.Add("YeuCau");

                    // Thiết lập tiêu đề các cột
                    worksheet.Cells[1, 1].Value = "Mã YC";
                    worksheet.Cells[1, 2].Value = "Trang Thai Xu Ly";
                    worksheet.Cells[1, 3].Value = "Ngày Yêu Cầu";
                    worksheet.Cells[1, 4].Value = "Số Lượng Thùng S";
                    worksheet.Cells[1, 5].Value = "Số Lượng Thùng M";
                    worksheet.Cells[1, 6].Value = "Số Lượng Thùng L";
                    worksheet.Cells[1, 7].Value = "Dung Tích";
                    worksheet.Cells[1, 8].Value = "Ngày Hết Hạn";
                    worksheet.Cells[1, 9].Value = "Vận Chuyển";
                    worksheet.Cells[1, 10].Value = "CCCD";

                    // Điền dữ liệu vào các dòng
                    int row = 2; // Bắt đầu từ dòng 2 vì dòng 1 là tiêu đề
                    foreach (var item in dataToExport)
                    {
                        worksheet.Cells[row, 1].Value = item["MaYC"];
                        worksheet.Cells[row, 2].Value = item["TrangThaiXuLy"];
                        worksheet.Cells[row, 3].Value = item["NgayYeuCau"];
                        worksheet.Cells[row, 4].Value = item["SoLuongThungS"];
                        worksheet.Cells[row, 5].Value = item["SoLuongThungM"];
                        worksheet.Cells[row, 6].Value = item["SoLuongThungL"];
                        worksheet.Cells[row, 7].Value = item["DungTich"];
                        worksheet.Cells[row, 8].Value = item["NgayHetHan"];
                        worksheet.Cells[row, 9].Value = item["VanChuyen"];
                        worksheet.Cells[row, 10].Value = item["CCCD"];
                        row++;
                    }

                    // Lưu file Excel
                    //var fileInfo = new System.IO.FileInfo(@"C:\path_to_save\YeuCau_" + trangThaiChon + ".xlsx");
                    // lưu ở document
                    string filePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "InYeuCau_" + trangThaiChon + ".xlsx");
                    package.SaveAs(filePath);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        // xuất pdf 
        public string GetTrangThaiYeuCau(string maYeuCau)
        {
            return YCKHDAL.GetTrangThaiYeuCau(maYeuCau);
        }
        public void XuatPhieuNhapToPDF(string maYeuCau)
        {
            // Lấy đường dẫn thư mục Documents của người dùng
            string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Tạo đường dẫn file PDF, ví dụ như "C:\Users\<user>\Documents\PhieuNhap_<maYeuCau>.pdf"
            string filePath = Path.Combine(documentsFolder, "PhieuNhap_" + maYeuCau + ".pdf");

            // Gọi DAL để xuất phiếu nhập PDF
            YCKHDAL.XuatPhieuNhapToPDF(maYeuCau, filePath);
        }
    }








}
