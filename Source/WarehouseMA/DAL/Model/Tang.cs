using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Tang
    {
        private string maTang;
        private string maKe;
        private float dungTichKhaDung;
        private float dungTichDaDung;
        public Tang(string maTang, string maKe, float dungTichKhaDung, float dungTichDaDung)
        {
            this.maTang = maTang;
            this.maKe = maKe;
            this.dungTichKhaDung = dungTichKhaDung;
            this.dungTichDaDung = dungTichDaDung;
        }

        public Tang(string maTang)
        {
            this.maTang = maTang;
            this.maKe = "maKe";
            this.dungTichKhaDung = 0;
            this.dungTichDaDung = 0;
        }

        // Getter và Setter cho MaTang
        public string MaTang
        {
            get { return maTang; }
            set { maTang = value; }
        }

        // Getter và Setter cho MaKe
        public string MaKe
        {
            get { return maKe; }
            set { maKe = value; }
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
