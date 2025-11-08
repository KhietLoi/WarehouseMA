using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public  class KhoNoiBo
    {
        private string chucNang;
        private string maKho;

        public KhoNoiBo ( string chucNang, string maKho)
        {
            this.maKho = maKho;
            this.chucNang = chucNang;   
        }

        public string getMaKho()
        {
            return maKho;
        }

        public string getChucNang()
        {
            return chucNang;
        }

        public void setMaKho(string maKho)
        {
            this.maKho = maKho;
        }

        public void setChucNang(string chucNang)
        {
            this.chucNang= chucNang;
        }
    }
}
