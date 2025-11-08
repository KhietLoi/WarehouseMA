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
    public partial class ThemNgan : Form
    {
        public ThemNgan()
        {
            InitializeComponent();
        }

        private bool dangKeo = false;
        private Point diemBatDau = new Point(0, 0);

        private void tieuDeThemNgan_MouseDown(object sender, MouseEventArgs e)
        {
            dangKeo = true;
            diemBatDau = new Point(e.X, e.Y);
        }

        private void tieuDeThemNgan_MouseMove(object sender, MouseEventArgs e)
        {
            if (dangKeo)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - diemBatDau.X, p.Y - diemBatDau.Y);
            }
        }

        private void tieuDeThemNgan_MouseUp(object sender, MouseEventArgs e)
        {
            dangKeo = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maTang = txtMaTang.Text.Trim();
            string dungTichKhaDung = txtDungTichKhaDung.Text.Trim();

            if (String.IsNullOrEmpty(maTang) || String.IsNullOrEmpty(dungTichKhaDung))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }

            if (float.TryParse(dungTichKhaDung, out float result))
            {
                if (result <= 0)
                {
                    MessageBox.Show("Dung tích khả dụng phải lớn hơn 0");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Dung tích khả dụng không hợp lệ");
                return;
            }

          

            QuanLyKhoBLL a = new QuanLyKhoBLL();
            string thongBao = a.NapDuLieuVaoNgan(maTang, float.Parse(dungTichKhaDung));
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
