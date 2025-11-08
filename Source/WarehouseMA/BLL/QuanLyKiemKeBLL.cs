using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class QuanLyKiemKeBLL
    {
        private QuanLyKiemKeDAL a = new QuanLyKiemKeDAL();
        public DataTable LayDuLieuKiemKeNoiBo()  // lấy dữ liệu từ databse để hiện lên dgv
        {
           
            return a.LayDuLieuKiemKeNoiBo();
        }

        public async Task LayDuLieuSheetNoiBo()   // lấy dữ liệu từ gg sheet và nạp lên database
        {
           
            await a.LayDuLieuSheetNoiBo();
        }

        public DataTable LayDuLieuKiemKeChoThue()
        {
            
            return a.LayDuLieuKiemKeChoThue();
        }


        public  async Task LayDuLieuSheetChoThue()
        {
        
            await a.LayDuLieuSheetChoThue();
        }


        public string capNhatKiemKeNoiBo(DataTable dt)
        {
            return a.capNhatKiemKeNoiBo(dt);
        }

        public string inDanhSachNoiBo(string path, DataTable dt)
        {
            return a.inDanhSachNoiBo(path, dt);
        }

        public string inDanhSachChoThue(string path, DataTable dt)
        {
            return a.inDanhSachChoThue(path, dt);
        }


    }
}
