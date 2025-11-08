using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Thung
    {
        private string maThung;
        private string moTa;
        private float dungTich;
        private DateTime ngayNhap;
        private string temSo;
        private bool trangThai;
        private string maNgan;
        private string maYC;
        private string maNV;

        public Thung (string maThung, string moTa, float dungTich, DateTime ngayNhap, string temSo, bool trangThai, string maNgan, string maYC, string maNV)
        {
            this.maThung = maThung;
            this.moTa = moTa;
            this.dungTich = dungTich;
            this.ngayNhap = ngayNhap;
            this.temSo = temSo;
            this.trangThai = trangThai;
            this.maNgan = maNgan;
            this.maYC = maYC;
            this.maNV = maNV;
        }

        public Thung(string maThung, string maNgan, float dungTich)
        {
            this.maThung = maThung;
            this.moTa = "moTa";
            this.dungTich = dungTich;
            this.ngayNhap = DateTime.Now.Date;
            this.temSo = "temSo";
            this.trangThai = false;
            this.maNgan = maNgan;
            this.maYC = "maYC";
            this.maNV = "maNV";
        }

        // Getter và Setter cho MaThung
        public string MaThung
        {
            get { return maThung; }
            set { maThung = value; }
        }

        // Getter và Setter cho MoTa
        public string MoTa
        {
            get { return moTa; }
            set { moTa = value; }
        }

        // Getter và Setter cho DungTich
        public float DungTich
        {
            get { return dungTich; }
            set { dungTich = value; }
        }

        // Getter và Setter cho NgayNhap
        public DateTime NgayNhap
        {
            get { return ngayNhap; }
            set { ngayNhap = value; }
        }

        // Getter và Setter cho TemSo
        public string TemSo
        {
            get { return temSo; }
            set { temSo = value; }
        }

        // Getter và Setter cho TrangThai
        public bool TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }

        // Getter và Setter cho MaNgan
        public string MaNgan
        {
            get { return maNgan; }
            set { maNgan = value; }
        }

        // Getter và Setter cho MaYC
        public string MaYC
        {
            get { return maYC; }
            set { maYC = value; }
        }

        // Getter và Setter cho MaNV
        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }
    }
}
