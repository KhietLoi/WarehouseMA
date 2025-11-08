using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WarehouseMA.DAL
{
    public class KiemTraThongTinDangNhapDAL
    {
        // Phương thức kiểm tra tên đăng nhập và mật khẩu
        public static bool KiemTraThongTinDangNhap(string tenDangNhap, string matKhau)
        {
            // Kiểm tra tên đăng nhập và mật khẩu (ở đây kiểm tra tên đăng nhập và mật khẩu cố định)
            if (tenDangNhap == "admin" && matKhau == "1234")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
