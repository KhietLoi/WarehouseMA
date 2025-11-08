using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;
using WarehouseMA.DAL;

namespace WarehouseMA.BLL
{
    public class QuanLyDonHangBLL
    {
        private QuanLyDonHangDAL donHangDAL = new QuanLyDonHangDAL();
        private Timer timerLayYCKH;
        private Timer timerFormNV;
        public QuanLyDonHangBLL()
        {
            donHangDAL = new QuanLyDonHangDAL();
            donHangDAL.KhoiTaoGoogleSheets(); // Khởi tạo kết nối Google Sheets

            // Tạo Timer để lấy dữ liệu từ Google Sheets
            timerLayYCKH = new Timer(1 * 60 * 1000); // 2 phút
            timerLayYCKH.Elapsed += TimerLayYCKH_Elapsed;
            timerLayYCKH.Start(); // Bắt đầu đếm thời gian

            // Tạo Timer để xử lý form nhân viên
            timerFormNV = new Timer(1 * 60 * 1000); // 1 phút
            timerFormNV.Elapsed += TimerFormNV_Elapsed;
            timerFormNV.Start(); // Bắt đầu đếm thời gian
        }
        private void TimerLayYCKH_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                donHangDAL.LayDuLieuSheetYCKH();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy dữ liệu từ Google Sheets: " + ex.Message);
            }
        }

        private void TimerFormNV_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                donHangDAL.XuLiFormNV();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xử lý form nhân viên: " + ex.Message);
            }
        }

        public DataTable LayDuLieuYeuCauKhachHang()
        {
            return donHangDAL.LayDuLieuSheetYCKH();
        }

        public void XuLyDonHang()
        {
            donHangDAL.XuLiFormNV();
        }

        //Hiển thị lên datagrid
        public DataTable LayDanhSachDonHang()
        {
            return donHangDAL.LayDonHang();
        }



        //Lấy hàm IN
        public string GetTrangThaiYeuCau(string maDH)
        {
            return donHangDAL.GetTrangThaiYeuCau(maDH);
        }
        public void XuatPhieuNhapToPDF(string maYeuCau)
        {
            // Lấy đường dẫn thư mục Documents của người dùng
            string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Tạo đường dẫn file PDF, ví dụ như "C:\Users\<user>\Documents\PhieuNhap_<maYeuCau>.pdf"
            string filePath = Path.Combine(documentsFolder, "PhieuXuat_" + maYeuCau + ".pdf");

            // Gọi DAL để xuất phiếu nhập PDF
            donHangDAL.XuatPhieuNhapToPDF(maYeuCau, filePath);
        }
        //Hàm tìm kiếm đơn hàng
        public DataTable TimKiemdonhang(string tuKhoa)
        {
            return donHangDAL.TimKiemDonHang(tuKhoa);
        }



    }
}