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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            AdjustLayout();
        }

        private void AdjustLayout()
        {
            int combinedWidth = pbLogoNhom.Width + txtBanQuyen.Width + Padding.Left + Padding.Right;
            int horizontalOffset = (pnDangNhap.ClientSize.Width - combinedWidth) / 2;
            int verticalOffset = pnDangNhap.ClientSize.Height - pbLogoNhom.Height - Padding.Bottom;
            int txtBanQuyenVerticalOffset = verticalOffset + pbLogoNhom.Height / 2 - txtBanQuyen.Height / 2;
            txtBanQuyen.Location = new Point(horizontalOffset, txtBanQuyenVerticalOffset);
            pbLogoNhom.Location = new Point(txtBanQuyen.Location.X + txtBanQuyen.Width, verticalOffset);
        }

        private bool dangKeo = false;
        private Point diemBatDau = new Point(0, 0);

        private void tieuDeDangNhap_MouseDown(object sender, MouseEventArgs e)
        {
            dangKeo = true;
            diemBatDau = new Point(e.X, e.Y);
        }

        private void tieuDeDangNhap_MouseMove(object sender, MouseEventArgs e)
        {
            if (dangKeo)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - diemBatDau.X, p.Y - diemBatDau.Y);
            }
        }

        private void tieuDeDangNhap_MouseUp(object sender, MouseEventArgs e)
        {
            dangKeo = false;
        }

        private void checkBoxHienThiMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHienThiMatKhau.Checked == true)
            {
                boxMatKhau.UseSystemPasswordChar = false; // Show the password
            }
            else
            {
                boxMatKhau.UseSystemPasswordChar = true; // Hide the password
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = boxTenDangNhap.Text;
            string matKhau = boxMatKhau.Text;

            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrWhiteSpace(matKhau))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin tên đăng nhập và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Gọi BLL để kiểm tra đăng nhập
                bool ketQuaDangNhap = KiemTraDangNhapBLL.KiemTraDangNhap(tenDangNhap, matKhau);

                if (ketQuaDangNhap)
                {
                    MessageBox.Show("Đăng nhập thành công!");
                    this.Hide();
                    GiaoDienKhoiDong giaoDienKhoiDong = new GiaoDienKhoiDong();
                    giaoDienKhoiDong.Show();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDangNhap_Enter(object sender, EventArgs e)
        {
            btnDangNhap.ColorBackground = Color.FromArgb(250, 150, 77);
        }

        private void btnDangNhap_Leave(object sender, EventArgs e)
        {
            btnDangNhap.ColorBackground = Color.FromArgb(242, 178, 88);
        }

        private void btnDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
            }
        }

        private void DangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
            }
        }
    }
}