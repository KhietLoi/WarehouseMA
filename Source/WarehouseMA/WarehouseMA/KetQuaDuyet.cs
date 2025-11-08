using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarehouseMA
{
    public partial class KetQuaDuyet : Form
    {
        public KetQuaDuyet()
        {
            InitializeComponent();
        }

        private bool dangKeo = false;
        private Point diemBatDau = new Point(0, 0);

        private void tieuDeKetQuaDuyet_MouseDown(object sender, MouseEventArgs e)
        {
            dangKeo = true;
            diemBatDau = new Point(e.X, e.Y);
        }

        private void tieuDeKetQuaDuyet_MouseMove(object sender, MouseEventArgs e)
        {
            if (dangKeo)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - diemBatDau.X, p.Y - diemBatDau.Y);
            }
        }

        private void tieuDeKetQuaDuyet_MouseUp(object sender, MouseEventArgs e)
        {
            dangKeo = false;
        }

        // Hàm để hiển thị kết quả
        public void ShowKetQua(string maYeuCau, string tenKhachHang, string thoiGianLuuTru, decimal tongTien, decimal tongTheTich, string thoiGianDangKy, string ketQuaTimKiem)
        {
            lblXuatMaYeuCau.Text = maYeuCau;
            lblXuatTenKH.Text = tenKhachHang;
            lblXuatThoiGianLT.Text = $"{thoiGianLuuTru:F2}";
            lblXuatTongTheTich.Text = $"{tongTheTich} lít";
            lblXuatThoiGianDH.Text = thoiGianDangKy.ToString();
            //Kết quả duyệt vị trí:
            boxXuatViTri.Text = ketQuaTimKiem;

            lblXuatGiaDK.Text = $"{tongTien}VNĐ";

        }

        private void KetQuaDuyet_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtMaYC_Click(object sender, EventArgs e)
        {

        }

        private void txtXuatMaYC_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void boxXuatViTri_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDong_Enter(object sender, EventArgs e)
        {
            btnDong.ColorBackground = Color.FromArgb(250, 150, 77);
        }

        private void btnHuy_Leave(object sender, EventArgs e)
        {
            btnDong.ColorBackground = Color.White;
        }

        private void btnDong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDong_Click(sender, e);
            }
        }
    }
}
