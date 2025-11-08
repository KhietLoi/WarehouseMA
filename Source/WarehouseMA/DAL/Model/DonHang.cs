using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class DonHang
    {
        public string MaDH { get; set; }
        public DateTime? NgayXuatKho { get; set; }
        public float GiaTien { get; set; }
        public float PhiPhuThu { get; set; }
        public float ThanhTien { get; set; }
        public string MaNV { get; set; }
        public string MaYC { get; set; }
        public string TemSo { get; set; }
        public string CCCD { get; set; }


    }
}
