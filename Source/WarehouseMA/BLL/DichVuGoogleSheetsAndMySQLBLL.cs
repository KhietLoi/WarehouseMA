using System;
using System.Collections.Generic;
using System.Timers;
using WarehouseMA.DAL;

namespace WarehouseMA.BLL
{
    public class DichVuGoogleSheetsAndMySQLBLL
    {
        private Timer timerLayDuLieu;
        private Timer timerSuaForm;

        private Timer timerXuLyDonHang; // Timer cho xử lý đơn hàng
        private DichVuGoogleSheetsAndMYSQLADL dal; // DAL class

        public DichVuGoogleSheetsAndMySQLBLL()
        {
            dal = new DichVuGoogleSheetsAndMYSQLADL();

            dal.KhoiTaoGoogleSheets();
            // Timer 2 phút cho LayDuLieuSheet
            timerLayDuLieu = new Timer(1 * 6 * 10000); //  2 phút // để tạm 1p
            timerLayDuLieu.Elapsed += TimerLayDuLieu_Elapsed;

            // Timer 1 phút cho XuLiFormSua
            timerSuaForm = new Timer(1 * 60 * 1000); // 1 phút
            timerSuaForm.Elapsed += TimerSuaForm_Elapsed;

            // Timer 1 phút cho xử lý đơn hàng
            timerXuLyDonHang = new Timer(1 * 60 * 1000); // 1 phút
            timerXuLyDonHang.Elapsed += TimerXuLyDonHang_Elapsed;
        }

        // Bắt đầu các timer
        public void StartTimers()
        {
            timerLayDuLieu.Start();
            timerSuaForm.Start();
            timerXuLyDonHang.Start();  // Bắt đầu timer xử lý đơn hàng
            Console.WriteLine("Timers started!");
        }

        // Dừng các timer
        public void StopTimers()
        {
            timerLayDuLieu.Stop();
            timerSuaForm.Stop();
            timerXuLyDonHang.Stop();  // Dừng timer xử lý đơn hàng
            Console.WriteLine("Timers stopped!");
        }

        // Sự kiện: Timer LayDuLieuSheet
        private void TimerLayDuLieu_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                dal.LayDuLieuSheet();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi chạy LayDuLieuSheet: " + ex.Message);
            }
        }

        // Sự kiện: Timer XuLiFormSua
        private void TimerSuaForm_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                dal.XuLiFormSua();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi chạy XuLiFormSua: " + ex.Message);
            }
        }

        //Sự kiện xử lí đơn hàng: 1 phút:
        private void TimerXuLyDonHang_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                dal.XuLyDonHang(); // Xử lý đơn hàng
                Console.WriteLine("Đã xử lý đơn hàng.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi chạy XuLyDonHang: " + ex.Message);
            }
        }
    }
}
