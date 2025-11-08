using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class HangHoaNoiBo
    {
        private string maHH;
        private string moTa;
        private string maKe;
        private string donVi;
        private int soLuong;

        public HangHoaNoiBo ( string maHH, string maKe, string donVi, int soLuong, string moTa )
        {
            this.maHH = maHH;
            this.maKe = maKe;
            this.donVi = donVi;
            this.soLuong = soLuong;
            this.moTa = moTa;
        }

        public HangHoaNoiBo ( string maHH)
        {
            this.maHH = maHH;
            moTa = "";
            soLuong = 0;
            moTa = "";
            donVi = "";
        }

        public string MaHH
        {
            get { return maHH; }
            set { maHH = value; }
        }

        // Getter và Setter cho MoTa
        public string MoTa
        {
            get { return moTa; }
            set { moTa = value; }
        }

        // Getter và Setter cho MaKe
        public string MaKe
        {
            get { return maKe; }
            set { maKe = value; }
        }

        // Getter và Setter cho DonVi
        public string DonVi
        {
            get { return donVi; }
            set { donVi = value; }
        }

        // Getter và Setter cho SoLuong
        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }


    }
}
