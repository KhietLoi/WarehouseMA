using ReaLTaiizor.Controls;
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
    public partial class ThemHangHoaNoiBo : Form
    {
        public ThemHangHoaNoiBo()
        {
            InitializeComponent();
        }

        private bool dangKeo = false;
        private Point diemBatDau = new Point(0, 0);

        private void tieuDeThemHangHoaNoiBo_MouseDown(object sender, MouseEventArgs e)
        {
            dangKeo = true;
            diemBatDau = new Point(e.X, e.Y);
        }

        private void tieuDeThemHangHoaNoiBo_MouseMove(object sender, MouseEventArgs e)
        {
            if (dangKeo)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - diemBatDau.X, p.Y - diemBatDau.Y);
            }
        }

        private void tieuDeThemHangHoaNoiBo_MouseUp(object sender, MouseEventArgs e)
        {
            dangKeo = false;
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            string maKe = txtMaKe.Text.Trim();
            string soLuong = txtSoLuong.Text.Trim();
            string donViTinh = txtDonViTinh.Text.Trim();
            string moTa = txtMoTa.Text.Trim();  
            if (String.IsNullOrEmpty(maKe) || String.IsNullOrEmpty(soLuong) || String.IsNullOrEmpty(donViTinh)|| String.IsNullOrEmpty(moTa))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }

            if (int.TryParse(soLuong, out int result))
            {
                if ( result <= 0)
                {
                    MessageBox.Show("Dung tích khả dụng phải lớn hơn 0");
                    return;
                }    
            }
            else
            {
                MessageBox.Show("Số lượng không hợp lệ");
                return;
            }

           

            QuanLyKhoBLL a = new QuanLyKhoBLL();
            string thongBao = a.NapDuLieuVaoHangHoaNoiBo(maKe, donViTinh, moTa, int.Parse(soLuong));
            MessageBox.Show(thongBao);

            QuanLyKho qlKho = (QuanLyKho)this.Owner;

            qlKho.LoadDataForSelectedList();
        }

        private void btnDuyet_Enter(object sender, EventArgs e)
        {
            btnDuyet.ColorBackground = Color.FromArgb(250, 150, 77);
        }

        private void btnDuyet_Leave(object sender, EventArgs e)
        {
            btnDuyet.ColorBackground = Color.White;
        }

        private void btnDuyet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDuyet_Click(sender, e);
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
