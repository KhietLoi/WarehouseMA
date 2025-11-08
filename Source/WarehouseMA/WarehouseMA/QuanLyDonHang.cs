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
    public partial class QuanLyDonHang : Form
    {
        private QuanLyDonHangBLL donHangBLL;
        Timer timerCapNhat;
        public QuanLyDonHang()
        {
            InitializeComponent();
            donHangBLL = new QuanLyDonHangBLL();
        }

        private void QuanLyDonHang_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.Dock = DockStyle.Fill;
            AdjustLayout();
          
            CapNhatDuLieu();
            timerCapNhat = new Timer();
            timerCapNhat.Interval = 2 * 60 * 1000; // 2 phút
            timerCapNhat.Tick += TimerCapNhatDuLieu_Tick;
            timerCapNhat.Start();
            donHangBLL.XuLyDonHang();
            CapNhatDuLieu();

        }
        private void CapNhatDuLieu()
        {
            DataTable data = donHangBLL.LayDuLieuYeuCauKhachHang();
            if (data != null && data.Rows.Count > 0)
            {
                dgvYeuCauXuatHang.DataSource = data;
                dgvYeuCauXuatHang.Columns[0].HeaderText = "Thời Gian Nhập";
                dgvYeuCauXuatHang.Columns[1].HeaderText = "Email";
                dgvYeuCauXuatHang.Columns[2].HeaderText = "Mã Yêu Cầu";
                dgvYeuCauXuatHang.Columns[3].HeaderText = "Tem Số";
                dgvYeuCauXuatHang.Columns[4].HeaderText = "CCCD Khách Hàng";
                //dgvYeuCauXuatHang.AutoResizeColumns();
                //dgvYeuCauXuatHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            else
            {
                dgvYeuCauXuatHang.DataSource = null;
                //MessageBox.Show("Không có dữ liệu để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        private void TimerCapNhatDuLieu_Tick(object sender, EventArgs e)
        {
            CapNhatDuLieu();
        }

        private void QuanLyDonHang_Resize(object sender, EventArgs e)
        {
            AdjustLayout();
        }

        private void AdjustLayout()
        {
            int formHeight = this.ClientSize.Height;
            int panelHeight = formHeight / 11;
            int gbYeuCauHeight = 5 * formHeight / 11;
            int gbDanhSachHeight = 5 * formHeight / 11;
            pnTieuDeQuanLyDonHang.Height = panelHeight;
            gbYeuCauXuatHang.Top = pnTieuDeQuanLyDonHang.Bottom;
            gbYeuCauXuatHang.Height = gbYeuCauHeight;
            gbYeuCauXuatHang.Width = this.ClientSize.Width;
            gbDanhSachDonHang.Top = gbYeuCauXuatHang.Bottom;
            gbDanhSachDonHang.Height = gbDanhSachHeight;
            gbDanhSachDonHang.Width = this.ClientSize.Width;
            txtTieuDeQuanLyDonHang.Left = (this.ClientSize.Width - txtTieuDeQuanLyDonHang.Width) / 2;
            txtTieuDeQuanLyDonHang.Top = (pnTieuDeQuanLyDonHang.Height - txtTieuDeQuanLyDonHang.Height) / 2;
        }

        private void pnTieuDeQuanLyDonHang_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbLoaiDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvYeuCauXuatHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = boxTimKiem.Text;
            if (string.IsNullOrEmpty(tuKhoa))
            {
                MessageBox.Show("Vui lòng nhập vào nội dung tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Gửi yêu cầu tìm kiếm 
            var dt = donHangBLL.TimKiemdonhang(tuKhoa);
            // Gán dữ liệu vào DataGridView
            dgvDanhSachDonHang.DataSource = dt;
        }

        private void btnTimKiem_Enter(object sender, EventArgs e)
        {
            btnTimKiem.ColorBackground = Color.FromArgb(250, 150, 77);
        }

        private void btnTimKiem_Leave(object sender, EventArgs e)
        {
            btnTimKiem.ColorBackground = Color.White;
        }

        private void btnTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {
                dgvDanhSachDonHang.DataSource = null;
                //Lấy dữ liệu mới từ cơ sở dữ liệu:
                DataTable dataTable = donHangBLL.LayDanhSachDonHang();
                dgvDanhSachDonHang.DataSource = dataTable;
                // Đổi tên các cột cho dễ đọc
                dgvDanhSachDonHang.Columns["MaDH"].HeaderText = "Mã đơn hàng";
                dgvDanhSachDonHang.Columns["NgayXuatKho"].HeaderText = "Ngày xuất kho";
                dgvDanhSachDonHang.Columns["GiaTien"].HeaderText = "Giá tiền gia hạn";
                dgvDanhSachDonHang.Columns["PhiPhuThu"].HeaderText = "Phí phụ thu";
                dgvDanhSachDonHang.Columns["ThanhTien"].HeaderText = "Tiền cần thanh toán";
                dgvDanhSachDonHang.Columns["MaNV"].HeaderText = "Mã nhân viên(Phụ trách)";
                dgvDanhSachDonHang.Columns["MaYC"].HeaderText = "Mã yêu cầu";
                dgvDanhSachDonHang.Columns["TemSo"].HeaderText = "Tem số";
                dgvDanhSachDonHang.Columns["CCCD"].HeaderText = "CCCD";

            }
            catch (Exception ex)
            {
                {
                    Console.WriteLine("Lỗi kết nối mạng: " + ex.Message);
                }


            }
        }

        private void btnLamMoi_Enter(object sender, EventArgs e)
        {
            btnLamMoi.ColorBackground = Color.FromArgb(250, 150, 77);
        }

        private void btnLamMoi_Leave(object sender, EventArgs e)
        {
            btnLamMoi.ColorBackground = Color.White;
        }

        private void btnLamMoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLamMoi_Click(sender, e);
            }
        }

        public string maDH = "";

        private void dgvDanhSachDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow hang = dgvDanhSachDonHang.Rows[e.RowIndex];
                maDH = hang.Cells["MaDH"].Value.ToString(); // Thay đổi từ "MaYC" sang "MaDH"

                // MessageBox.Show("Mã đơn hàng đã chọn: " + maYeuCauHienTaiDN);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {

            try
            {
                // Kiểm tra trạng thái yêu cầu từ DAL
                string checkMaDH = donHangBLL.GetTrangThaiYeuCau(maDH);

                // Nếu trạng thái không phải "Hoàn thành", thông báo lỗi
                if (checkMaDH == "" || checkMaDH == null)
                {
                    MessageBox.Show("Vui lòng chọn Mã Đơn Hàng để in", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tiến hành xuất phiếu nhập nếu trạng thái là "Hoàn thành"
                donHangBLL.XuatPhieuNhapToPDF(maDH);

                MessageBox.Show("Phiếu nhập đã được xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("Có lỗi xảy ra khi xuất phiếu nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIn_Enter(object sender, EventArgs e)
        {
            btnIn.ColorBackground = Color.FromArgb(250, 150, 77);
        }

        private void btnIn_Leave(object sender, EventArgs e)
        {
            btnIn.ColorBackground = Color.White;
        }

        private void btnIn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnIn_Click(sender, e);
            }
        }
    }
}
