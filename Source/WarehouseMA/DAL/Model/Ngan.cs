using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Ngan
    {
        private string maTang;
        private string maNgan;
        private float dungTichKhaDung;
        private float dungTichDaDung;

        public Ngan(string maNgan, string maTang, float dungTichDaDung, float dungTichKhaDung)
        {
            this.maNgan = maNgan;
            this.maTang = maTang;
            this.dungTichDaDung = dungTichDaDung;
            this.dungTichKhaDung = dungTichKhaDung;
        }

        public Ngan(string maNgan)
        {
            this.maNgan = maNgan;
            this.maTang = "maTang";
            this.dungTichDaDung = 0;
            this.dungTichKhaDung = 0;
        }

        public string MaTang
        {
            get { return maTang; }
            set { maTang = value; }
        }

        // Getter và Setter cho MaNgan
        public string MaNgan
        {
            get { return maNgan; }
            set { maNgan = value; }
        }

        // Getter và Setter cho DungTichKhaDung
        public float DungTichKhaDung
        {
            get { return dungTichKhaDung; }
            set { dungTichKhaDung = value; }
        }

        // Getter và Setter cho DungTichDaDung
        public float DungTichDaDung
        {
            get { return dungTichDaDung; }
            set { dungTichDaDung = value; }
        }
    }

    
}
