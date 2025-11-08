using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class KeNoiBo
    {
        private string maKe;
        private string maKho;

        public KeNoiBo(string maKho, string maKe)
        {
            this.maKho = maKho;
            this.maKe = maKe;
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

        public void setMaKho ( string maKho)
        {
            this.maKho= maKho;  
        }
    }
}
