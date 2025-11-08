using System;
using System.Data;
using System.Timers;
using WarehouseMA.DAL;

namespace BLL
{
    public class LoadTuDongBLL : IDisposable
    {
        private readonly Timer timer; // Timer để chạy định kỳ
        private readonly YeuCauKhachHangDAL yeuCauDAL; // Lớp Data Access Layer
        public event Action<DataTable> OnDataReloaded; // Sự kiện khi dữ liệu được tải lại
        private bool disposed = false; // Để đảm bảo Dispose chỉ chạy một lần

        public LoadTuDongBLL(int intervalInMilliseconds)
        {
            // Khởi tạo Timer và lớp DAL
            timer = new Timer(intervalInMilliseconds);
            timer.Elapsed += TimerElapsed;
            yeuCauDAL = new YeuCauKhachHangDAL();
        }

        public void Start()
        {
            timer.Start(); // Bắt đầu timer
        }

        public void Stop()
        {
            timer.Stop(); // Dừng timer
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                // Gọi hàm lấy dữ liệu từ DAL
                DataTable dt = yeuCauDAL.LayDuLieuTuDatabase();
                // Kích hoạt sự kiện để thông báo rằng dữ liệu đã được tải lại
                OnDataReloaded?.Invoke(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        // Triển khai IDisposable.Dispose()
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // Ngăn GC gọi lại phương thức hủy
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Giải phóng tài nguyên được quản lý
                    if (timer != null)
                    {
                        timer.Stop();
                        timer.Dispose();
                    }
                }
                // Giải phóng tài nguyên không được quản lý nếu có
                disposed = true;
            }
        }

        ~LoadTuDongBLL()
        {
            Dispose(false); // Gọi Dispose(false) từ hàm hủy
        }
    }
}
