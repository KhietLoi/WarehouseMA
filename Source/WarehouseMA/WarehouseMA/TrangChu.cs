using System;
using System.Drawing;
using System.Windows.Forms;

namespace WarehouseMA
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.Dock = DockStyle.Fill;
            CenterControls();
        }

        private void TrangChu_Resize(object sender, EventArgs e)
        {
            CenterControls();
        }

        private void CenterControls()
        {
            int formHeight = this.ClientSize.Height;
            int pbLogoPhanMemHeight = 2 * formHeight / 11;
            int txtChaoMungHeight = 2 * formHeight / 11;
            int pnCenterHeight = 6 * formHeight / 11;

            pbLogoPhanMem.Left = (this.ClientSize.Width - pbLogoPhanMem.Width) / 2;
            pbLogoPhanMem.Height = pbLogoPhanMemHeight;

            txtChaoMung.Top = pbLogoPhanMem.Bottom;
            txtChaoMung.Left = (this.ClientSize.Width - txtChaoMung.Width) / 2;
            txtChaoMung.Height = txtChaoMungHeight;

            pnCenter.Top = txtChaoMung.Bottom;
            pnCenter.Height = pnCenterHeight;
            pnCenter.Width = this.ClientSize.Width;

            pnButtonPicture.Left = (pnCenter.Width - pnButtonPicture.Width) / 2;
            pnButtonPicture.Top = (pnCenter.Height - pnButtonPicture.Height) / 2;

            int combinedWidth = pbLogoNhom.Width + txtBanQuyen.Width + Padding.Left + Padding.Right;
            int horizontalOffset = (this.ClientSize.Width - combinedWidth) / 2;
            int verticalOffset = pnBanQuyenLogoNhom.Height - pbLogoNhom.Height - Padding.Bottom;
            int txtBanQuyenVerticalOffset = verticalOffset + pbLogoNhom.Height / 2 - txtBanQuyen.Height / 2;
            txtBanQuyen.Location = new Point(horizontalOffset, txtBanQuyenVerticalOffset);
            pbLogoNhom.Location = new Point(txtBanQuyen.Location.X + txtBanQuyen.Width, verticalOffset);
        }

        private void btnQuanLyKho_Click(object sender, EventArgs e)
        {
            GiaoDienKhoiDong mainForm = this.MdiParent as GiaoDienKhoiDong;
            if (mainForm != null)
            {
                mainForm.HienThiQuanLyKho();
            }
        }

        private void btnQuanLyYeuCau_Click(object sender, EventArgs e)
        {
            GiaoDienKhoiDong mainForm = this.MdiParent as GiaoDienKhoiDong;
            if (mainForm != null)
            {
                mainForm.HienThiQuanLyYeuCau();
            }
        }

        private void btnQuanLyDonHang_Click(object sender, EventArgs e)
        {
            GiaoDienKhoiDong mainForm = this.MdiParent as GiaoDienKhoiDong;
            if (mainForm != null)
            {
                mainForm.HienThiQuanLyDonHang();
            }
        }

        private void btnQuanLyKiemKe_Click(object sender, EventArgs e)
        {
            GiaoDienKhoiDong mainForm = this.MdiParent as GiaoDienKhoiDong;
            if (mainForm != null)
            {
                mainForm.HienThiQuanLyKiemKe();
            }
        }
    }
}
