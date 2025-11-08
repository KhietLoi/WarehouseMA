using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class KhachHang
    {
        // Private fields
        private string tenKH;
        private string soDienThoai;
        private string email;
        private string diaChi;
        private string cccd;

        // Public properties with get and set accessors
        public string TenKH
        {
            get { return tenKH; }
            set { tenKH = value; }
        }

        public string SoDienThoai
        {
            get { return soDienThoai; }
            set { soDienThoai = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        public string CCCD
        {
            get { return cccd; }
            set { cccd = value; }
        }

    }
}