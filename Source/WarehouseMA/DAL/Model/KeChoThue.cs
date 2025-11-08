using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class KeChoThue
    {
        private string maKho;
        private float dungTichKhaDung;
        private float dungTichDaDung;
        private string maKe;

        public KeChoThue (string maKho, float dungTichKhaDung, float dungTichDaDung, string maKe)
        {
            this.maKho = maKho;
            this.dungTichKhaDung = dungTichKhaDung;
            this.dungTichDaDung = dungTichDaDung;
            this.maKe = maKe;
        }

        public KeChoThue ( string maKe)
        {
            this.maKe = maKe;
            maKho = "";
            dungTichDaDung = 0;
            dungTichKhaDung = 0;
        }

        public string getMaKho()
        {
            return maKho;
        }

        public string getMaKe()
        {
            return maKe;
        }

        public void setMake(string maKe)
        {
            this.maKe = maKe;
        }

        public float getDungTichDaDung()
        {
            return dungTichDaDung;
        }

        public float getDungTichKhaDung()
        {
            return dungTichKhaDung;
        }

        public void setMaKho( string maKho)
        {
            this.maKho = maKho;
        }

        public void setDungTichKhaDung ( float dungTichKhaDung)
        {
            this.dungTichKhaDung = dungTichKhaDung;
        }

        public void setDungTichDaDung ( float dungTichDaDung)
        {
            this.dungTichDaDung = dungTichDaDung;
        }
    }

}
