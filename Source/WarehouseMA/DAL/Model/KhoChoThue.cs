using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class KhoChoThue
    {
        private string maKho;
        private float dungTichKhaDung;
        private float dungTichDaDung;

        public KhoChoThue(string maKho, float dungTichKhaDung, float dungTichDaDung)
        {
            this.maKho = maKho;
            this.dungTichKhaDung = dungTichKhaDung;
            this.dungTichDaDung = dungTichDaDung;
        }

        public string getMaKho()
        {
            return maKho;
        }

        public float getDungTichDaDung()
        {
            return dungTichDaDung;
        }

        public float getDungTichKhaDung()
        {
            return dungTichKhaDung;
        }

        public void setMaKho(string maKho)
        {
            this.maKho = maKho;
        }

        public void setDungTichKhaDung(float dungTichKhaDung)
        {
            this.dungTichKhaDung = dungTichKhaDung;
        }

        public void setDungTichDaDung(float dungTichDaDung)
        {
            this.dungTichDaDung = dungTichDaDung;
        }
    }
}
