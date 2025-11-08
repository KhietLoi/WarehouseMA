using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMA.DAL;
using System.Timers;
namespace WarehouseMA.BLL
{
    public class GiaHanBLL
    {
        private GiaHanDAL giaHanDAL = new GiaHanDAL();
        private Timer timerLayDuLieu;
        public GiaHanBLL()
        {
            giaHanDAL = new DAL.GiaHanDAL();
            giaHanDAL.KhoiTaoGoogleSheets();
            // timer lấy dữ liệu
            timerLayDuLieu = new Timer(1 * 3 * 10000); //  1p // test 30s trước
            timerLayDuLieu.Elapsed += TimerLayDuLieu_Elapsed;
        }
        public void StartTimers()
        {
            timerLayDuLieu.Start();

            Console.WriteLine("Timer lấy dữ liệu sheet gia hạn!");
        }
        private void TimerLayDuLieu_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                giaHanDAL.LayDuLieuSheet();
                Console.WriteLine("Đã chạy gia hạn");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi chạy LayDuLieuSheet gia hạn: " + ex.Message);
            }
        }



    }

}
