using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMA.DAL;
using System.Net.Mail;
using DAL.Model;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Exceptions;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Event;
using iText.Kernel.Font;
using iText.Layout.Properties;
using iText.IO.Font;
using iText.Commons.Actions;
using iText.IO.Font.Constants;
using iText.Kernel.Pdf.Xobject;
namespace WarehouseMA.BLL
{
    public class QuanLyKhoBLL
    {
        
        private QuanLyKhoDAL khoDAL = new QuanLyKhoDAL();

        public DataTable LayDuLieuKhoNoiBo()
        {
            return khoDAL.LayDuLieuKhoNoiBo();
        }

        public DataTable LayDuLieuKhoChoThue()
        {
            return khoDAL.LayDuLieuKhoChoThue();
        }

        public DataTable LayDuLieuKeNoiBo()
        {
            return khoDAL.LayDuLieuKeNoiBo();
        }

        public DataTable LayDuLieuKeChoThue()
        {
            return khoDAL.LayDuLieuKeChoThue();
        }

        public DataTable LayDuLieuTang()
        {
            return khoDAL.LayDuLieuTang();
        }

        public DataTable LayDuLieuNgan()
        {
            return khoDAL.LayDuLieuNgan();
        }

        public DataTable LayDuLieuHangHoaNoiBo()
        {
            return khoDAL.LayDuLieuHangHoaNoiBo();
        }

        public DataTable LayDuLieuThung()
        {
            return khoDAL.LayDuLieuThung();
        }

        public string NapDuLieuVaoKhoNoiBo(string maNhanVien, string maKho, string chucNang)
        {

            return khoDAL.NapDuLieuVaoKhoNoiBo(maNhanVien, maKho, chucNang);
        }

        public string NapDuLieuVaoKhoChoThue(string maNhanVien, string maKho, float dungTichKhaDung, float dungTichDaDung)
        {

            return khoDAL.NapDuLieuVaoKhoChoThue(maNhanVien, maKho,dungTichKhaDung,dungTichDaDung );
        }

        public string NapDuLieuVaoKeNoiBo(string maKho)
        {

            return khoDAL.NapDuLieuVaoKeNoiBo(maKho);
        }

        public string NapDuLieuVaoHangHoaNoiBo(string maKe, string donViTinh, string moTaHangHoa, int soLuong)
        {

            return khoDAL.NapDuLieuVaoHangHoaNoiBo(maKe,  donViTinh,  moTaHangHoa, soLuong);
        }

        public string NapDuLieuVaoKeChoThue(string maKho, float dungTichKhaDung)
        {

            return khoDAL.NapDuLieuVaoKeChoThue(maKho, dungTichKhaDung);
        }

        public string NapDuLieuVaoTang(string maKe, float dungTichKhaDung)
        {

            return khoDAL.NapDuLieuVaoTang(maKe, dungTichKhaDung);
        }

        public string NapDuLieuVaoNgan(string maTang, float dungTichKhaDung)
        {

            return khoDAL.NapDuLieuVaoNgan(maTang, dungTichKhaDung);
        }

        public string NapDuLieuVaoThung(string moTa, float dungTich, DateTime ngayNhap, string temSo, string maNgan, string maYC, string trangThai, string maNV , DateTime ngayHH)
        {

            return khoDAL.NapDuLieuVaoThung(moTa, dungTich, ngayNhap, temSo, maNgan, maYC, trangThai, maNV, ngayHH);
        }

        public string XoaDuLieuKhoNoiBo(string maKho, string chucNang)
        {
            KhoNoiBo b = new KhoNoiBo(chucNang, maKho);
            
            return khoDAL.XoaDuLieuKhoNoiBo(b);

        }

        public string XoaDuLieuKhoChoThue(string maKho,float dungTichKhaDung, float dungTichDaDung)
        {
            KhoChoThue b = new KhoChoThue(maKho, dungTichKhaDung, dungTichDaDung);
       
            return khoDAL.XoaDuLieuKhoChoThue(b);
        }

        public string XoaDuLieuKeNoiBo(string maKho, string make)
        {
            KeNoiBo b = new KeNoiBo(maKho, make);
            
            return khoDAL.XoaDuLieuKeNoiBo(b);
        }

        public string XoaDuLieuHangHoaNoiBo(string maHH)
        {
            HangHoaNoiBo b = new HangHoaNoiBo(maHH);
           
            return khoDAL.XoaDuLieuHangHoaNoiBo(b);
        }

        public string XoaDuLieuKeChoThue(string maKe)
        {
            KeChoThue b = new KeChoThue(maKe);

            return khoDAL.XoaDuLieuKeChoThue(b);
        }

        public string XoaDuLieuTang(string maTang)
        {
            Tang b = new Tang(maTang);
            
            return khoDAL.XoaDuLieuTang(b);
        }

        public string XoaDuLieuNgan(string maNgan)
        {
            Ngan b = new Ngan(maNgan);
         
            return khoDAL.XoaDuLieuNgan(b);
        }


        public string XoaDuLieuThung(string maThung, string maNgan, float dungTich)
        {
            Thung b = new Thung(maThung,maNgan, dungTich);

            return khoDAL.XoaDuLieuThung(b);
        }

        public string capNhatKhoNoiBo(DataTable dt)
        {

            return khoDAL.capNhatKhoNoiBo(dt);
        }

        public string capNhatKeNoiBo(DataTable dt)
        {
            
            return khoDAL.capNhatKeNoiBo(dt);
        }

        public string capNhatHangHoaNoiBo(DataTable dt)
        {

            return khoDAL.capNhatHangHoaNoiBo(dt);
        }

        public string capNhatKhoChoThue(DataTable dt)
        {
            return khoDAL.capNhatKhoChoThue(dt);
        }


        public string capNhatKeChoThue(DataTable dt)
        {
           
            return khoDAL.capNhatKeChoThue(dt);
        }


        public string capNhatTang(DataTable dt)
        {
            
            return khoDAL.capNhatTang(dt);
        }


        public string capNhatNgan(DataTable dt)
        {
           
            return khoDAL.capNhatNgan(dt);
        }


        public string capNhatThung(DataTable dt)
        {

            return khoDAL.capNhatThung(dt);
        }

        public List<string> KiemTraHetHan()
        {
            return khoDAL.KiemTraHetHan();
        }

        public List<string> KiemTraSoluong()
        {
            return khoDAL.KiemTraSoLuong();
        }

        public string inDanhSach(string danhSach, string filePath)
        {
            return khoDAL.inDanhSach(danhSach, filePath);
        }

        //public void GuiEmailThongBaoHetHan(string maYeuCau)
        //{
        //    try
        //    {
        //        var thongTinYC = YCKHDAL.LayThongTinYC(maYeuCau);
        //        if (string.IsNullOrEmpty(thongTinYC.Email))
        //        {
        //            Console.WriteLine("Không tìm thấy thông tin người nhận cho yêu cầu này.");
        //            return;
        //        }

        //        var client = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587)
        //        {
        //            Credentials = new System.Net.NetworkCredential("letiendat2004.it@gmail.com", "ywan znrs wagl dpyt"),
        //            EnableSsl = true
        //        };

        //        var toAddress = new System.Net.Mail.MailAddress(thongTinYC.Email);

        //        // Định dạng chủ đề và nội dung email
        //        string chuDe = $"[# {maYeuCau}] Đăng ký gửi đồ";
        //        string noiDung = $@"
        //            Xin chào {thongTinYC.TenKhachHang},
        //            Dịch vụ Warehouse MA thông báo tiếp nhận yêu cầu #{maYeuCau}.
        //                    Thông tin cụ thể như sau:
        //                    - Ngày đăng ký: {thongTinYC.NgayDangKy:yyyy-MM-dd hh:mm:ss}
        //                    - Số lượng thùng S: {thongTinYC.SoLuongThungS}
        //                    - Số lượng thùng M: {thongTinYC.SoLuongThungM}
        //                    - Số lượng thùng L: {thongTinYC.SoLuongThungL}
        //                    - Tình trạng xử lý: Đang xử lý
        //                    - Ngày hết hạn: {thongTinYC.NgayHetHan:yyyy-MM-dd hh:mm:ss}

        //            Đây là Email được gửi tự động từ Hệ thống. 
        //            Quý khách không cần phải hồi đáp cho Email này.
        //            Quý khách có thể liên hệ với chúng tôi theo thông tin sau:
        //            Bộ phận Dịch vụ WarehouseMA
        //            Email: support@warehousema.com 
        //            Tell: 123-456-7890
        //            ";

        //        // Cấu hình SmtpClient cho email
        //        var thuDienTu = new System.Net.Mail.MailMessage
        //        {
        //            From = new System.Net.Mail.MailAddress("letiendat2004.it@gmail.com"),
        //            Subject = chuDe,
        //            Body = noiDung
        //        };
        //        thuDienTu.To.Add(toAddress);

        //        client.Send(thuDienTu);
        //        Console.WriteLine("Đã gửi email thành công đến " + thongTinYC.Email);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Gửi email thất bại: " + ex.Message);
        //    }
        //}
    }
}
