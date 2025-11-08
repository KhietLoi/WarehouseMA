using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMA.DAL; // Thêm namespace cho DAL

namespace WarehouseMA.BLL
{
    public class KiemTraDangNhapBLL
    {
        // Phương thức gọi DAL để kiểm tra đăng nhập
        public static bool KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            // Gọi DAL để kiểm tra thông tin đăng nhập
            return KiemTraThongTinDangNhapDAL.KiemTraThongTinDangNhap(tenDangNhap, matKhau);
        }
    }
}
