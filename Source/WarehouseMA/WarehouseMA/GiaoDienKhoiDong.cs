using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SystemColor = System.Drawing.Color;
using WarehouseMA.BLL;
using WarehouseMA.DAL;



namespace WarehouseMA
{
    // Timer để làm mới tự động sau 10 phút  // Timer để làm mới tự động sau 10 phút
    public partial class GiaoDienKhoiDong : Form

    {
        private DichVuGoogleSheetsAndMySQLBLL DichVuGGAndMYBLL;
        private GiaHanBLL giaHanBLL;
        TrangChu trangChu;
        QuanLyYeuCau quanLyYeuCau;
        QuanLyKho quanLyKho;
        QuanLyKiemKe quanLyKiemKe;
        QuanLyDonHang quanLyDonHang;
        public GiaoDienKhoiDong()
        {
            InitializeComponent();
            mdiProp();
            ThayDoiMauButton(btnTrangChu);
            DichVuGGAndMYBLL = new DichVuGoogleSheetsAndMySQLBLL();
            giaHanBLL = new GiaHanBLL();
            if (trangChu == null)
            {
                trangChu = new TrangChu();
                trangChu.FormClosed += TrangChu_FormClosed;
                trangChu.MdiParent = this;
                trangChu.Show();
            }
            else
            {
                trangChu.Activate();
            }
        }
        private void GiaoDienKhoiDong_Load(object sender, EventArgs e)
        {
            DichVuGGAndMYBLL.StartTimers();
            giaHanBLL.StartTimers();

        }

        private void mdiProp()
        {
            this.SetBevel(false);
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = SystemColor.FromArgb(232, 234, 237);
        }

        private bool dangKeo = false;
        private Point diemBatDau = new Point(0, 0);

        private void tieuDeApp_MouseDown(object sender, MouseEventArgs e)
        {
            dangKeo = true;
            diemBatDau = new Point(e.X, e.Y);
        }

        private void tieuDeApp_MouseMove(object sender, MouseEventArgs e)
        {
            if (dangKeo)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - diemBatDau.X, p.Y - diemBatDau.Y);
            }
        }

        private void tieuDeApp_MouseUp(object sender, MouseEventArgs e)
        {
            dangKeo = false;
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            ThayDoiMauButton((Button)sender);
            if (trangChu == null)
            {
                trangChu = new TrangChu();
                trangChu.FormClosed += TrangChu_FormClosed;
                trangChu.MdiParent = this;
                trangChu.Show();
            }
            else
            {
                trangChu.Activate();
            }
        }

        private void btnQuanLyYeuCau_Click(object sender, EventArgs e)
        {
            ThayDoiMauButton((Button)sender);
            if (quanLyYeuCau == null)
            {
                quanLyYeuCau = new QuanLyYeuCau();
                quanLyYeuCau.FormClosed += QuanLyYeuCau_FormClosed;
                quanLyYeuCau.MdiParent = this;
                quanLyYeuCau.Show();
            }
            else
            {
                quanLyYeuCau.Activate();
            }
        }

        private void btnQuanLyKho_Click(object sender, EventArgs e)
        {
            ThayDoiMauButton((Button)sender);
            if (quanLyKho == null)
            {
                quanLyKho = new QuanLyKho();
                quanLyKho.FormClosed += QuanLyKho_FormClosed;
                quanLyKho.MdiParent = this;
                quanLyKho.Show();
            }
            else
            {
                quanLyKho.Activate();
            }
        }

        private void btnQuanLyKiemKe_Click(object sender, EventArgs e)
        {
            ThayDoiMauButton((Button)sender);
            if (quanLyKiemKe == null)
            {
                quanLyKiemKe = new QuanLyKiemKe();
                quanLyKiemKe.FormClosed += QuanLyKiemKe_FormClosed;
                quanLyKiemKe.MdiParent = this;
                quanLyKiemKe.Show();
            }
            else
            {
                quanLyKiemKe.Activate();
            }
        }

        private void btnQuanLyDonHang_Click(object sender, EventArgs e)
        {
            ThayDoiMauButton((Button)sender);
            if (quanLyDonHang == null)
            {
                quanLyDonHang = new QuanLyDonHang();
                quanLyDonHang.FormClosed += QuanLyDonHang_FormClosed;
                quanLyDonHang.MdiParent = this;
                quanLyDonHang.Show();
            }
            else
            {
                quanLyDonHang.Activate();
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                DangNhap dangNhap = new DangNhap();
                dangNhap.Show();
            }
        }

        private Button buttonHienTai = null;

        private void ThayDoiMauButton(Button button)
        {
            if (buttonHienTai != null)
            {
                buttonHienTai.BackColor = SystemColor.Transparent;
            }
            button.BackColor = SystemColor.FromArgb(255, 229, 184);
            //button.BackColor = Color.Silver;
            buttonHienTai = button;
        }

        private void TrangChu_FormClosed(object sender, FormClosedEventArgs e)
        {
            trangChu = null;
        }

        private void QuanLyYeuCau_FormClosed(object sender, FormClosedEventArgs e)
        {
            quanLyYeuCau = null;
        }

        private void QuanLyKho_FormClosed(object sender, FormClosedEventArgs e)
        {
            quanLyKho = null;
        }

        private void QuanLyKiemKe_FormClosed(object sender, FormClosedEventArgs e)
        {
            quanLyKiemKe = null;
        }

        private void QuanLyDonHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            quanLyDonHang = null;
        }

        public void HienThiQuanLyKho()
        {
            ThayDoiMauButton(btnQuanLyKho);
            if (quanLyKho == null)
            {
                quanLyKho = new QuanLyKho();
                quanLyKho.FormClosed += QuanLyKho_FormClosed;
                quanLyKho.MdiParent = this;
                quanLyKho.Show();
            }
            else
            {
                quanLyKho.Activate();
            }
        }

        public void HienThiQuanLyYeuCau()
        {
            ThayDoiMauButton(btnQuanLyYeuCau);
            if (quanLyYeuCau == null)
            {
                quanLyYeuCau = new QuanLyYeuCau();
                quanLyYeuCau.FormClosed += QuanLyYeuCau_FormClosed;
                quanLyYeuCau.MdiParent = this;
                quanLyYeuCau.Show();
            }
            else
            {
                quanLyYeuCau.Activate();
            }
        }

        public void HienThiQuanLyDonHang()
        {
            ThayDoiMauButton(btnQuanLyDonHang);
            if (quanLyDonHang == null)
            {
                quanLyDonHang = new QuanLyDonHang();
                quanLyDonHang.FormClosed += QuanLyDonHang_FormClosed;
                quanLyDonHang.MdiParent = this;
                quanLyDonHang.Show();
            }
            else
            {
                quanLyDonHang.Activate();
            }
        }

        public void HienThiQuanLyKiemKe()
        {
            ThayDoiMauButton(btnQuanLyKiemKe);
            if (quanLyKiemKe == null)
            {
                quanLyKiemKe = new QuanLyKiemKe();
                quanLyKiemKe.FormClosed += QuanLyKiemKe_FormClosed;
                quanLyKiemKe.MdiParent = this;
                quanLyKiemKe.Show();
            }
            else
            {
                quanLyKiemKe.Activate();
            }
        }

        private void txtTenApp_Click(object sender, EventArgs e)
        {

        }
    }
}
