using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseMA.BLL;

namespace WarehouseMA
{
    public partial class ThemThung : Form
    {
        public ThemThung()
        {
            InitializeComponent();
        }

        private bool dangKeo = false;
        private Point diemBatDau = new Point(0, 0);

        private void tieuDeThemThung_MouseDown(object sender, MouseEventArgs e)
        {
            dangKeo = true;
            diemBatDau = new Point(e.X, e.Y);
        }

        private void tieuDeThemThung_MouseMove(object sender, MouseEventArgs e)
        {
            if (dangKeo)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - diemBatDau.X, p.Y - diemBatDau.Y);
            }
        }

        private void tieuDeThemThung_MouseUp(object sender, MouseEventArgs e)
        {
            dangKeo = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            dtpNgayNhap.CustomFormat = "dd/MM/yyyy"; // Hiển thị ngày/tháng/năm
            dtpNgayHetHan.CustomFormat = "dd/MM/yyyy"; // Hiển thị ngày/tháng/năm
            string maNgan = txtMaNgan.Text.Trim();
            string dungTich = txtDungTich.Text.Trim();
            string ngayNhap = dtpNgayNhap.Text.Trim();
            string ngayHH = dtpNgayHetHan.Text.Trim();
            string moTa = txtMoTa.Text.Trim();
            string temSo = txtTemSo.Text.Trim();
            string trangThai = txtTrangThai.Text.Trim();
            string maYC = txtMaYeuCau.Text.Trim();
            string maNV = txtMaNhanVien.Text.Trim();
           

            
            if (String.IsNullOrEmpty(maNV) || String.IsNullOrEmpty(maNgan) || String.IsNullOrEmpty(dungTich) || String.IsNullOrEmpty(ngayNhap) || String.IsNullOrEmpty(moTa) || String.IsNullOrEmpty(temSo) || String.IsNullOrEmpty(trangThai) || String.IsNullOrEmpty(maYC))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }

            if (float.TryParse(dungTich, out float result))
            {
                if (result <= 0)
                {
                    MessageBox.Show("Dung tích phải lớn hơn 0");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Dung tích không hợp lệ");
                return;
            }


            if (DateTime.Parse(ngayHH) < DateTime.Parse(ngayNhap))
            {
                MessageBox.Show("Ngày không hợp lệ.");
                return;
            }
       
           


            if (int.TryParse(temSo, out int TemSo))
            {
                if ( TemSo <=0)
                {
                    MessageBox.Show("Tem số không hợp lệ");
                    return;
                }    
            }
            else
            {
                MessageBox.Show("Tem số không hợp lệ");
                return;
            }

            if ( trangThai != "0" && trangThai != "1" && trangThai != "Đã lấy"&& trangThai != "Chưa lấy")
            {
                MessageBox.Show("Trạng thái không hợp lệ");
                return;
            }    




            QuanLyKhoBLL a = new QuanLyKhoBLL();
            string thongBao = a.NapDuLieuVaoThung(moTa, float.Parse(dungTich), DateTime.Parse(ngayNhap), temSo, maNgan, maYC, trangThai, maNV, DateTime.Parse(ngayHH));
            MessageBox.Show(thongBao);

            QuanLyKho qlKho = (QuanLyKho)this.Owner;

            qlKho.LoadDataForSelectedList();
        }

        private void btnThem_Enter(object sender, EventArgs e)
        {
            btnThem.ColorBackground = Color.FromArgb(250, 150, 77);
        }

        private void btnThem_Leave(object sender, EventArgs e)
        {
            btnThem.ColorBackground = Color.White;
        }

        private void btnThem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnThem_Click(sender, e);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Enter(object sender, EventArgs e)
        {
            btnHuy.ColorBackground = Color.FromArgb(250, 150, 77);
        }

        private void btnHuy_Leave(object sender, EventArgs e)
        {
            btnHuy.ColorBackground = Color.White;
        }

        private void btnHuy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnHuy_Click(sender, e);
            }
        }
    }
}
