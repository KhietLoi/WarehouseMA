using BLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WarehouseMA.BLL;
using WarehouseMA.DAL;


namespace WarehouseMA
{
    public partial class QuanLyYeuCau : Form
    {
        private YeuCauKhachHangBLL YeuCauKHBLL = new YeuCauKhachHangBLL();
        private YeuCauKhachHangDAL YeuCauKHDAL = new YeuCauKhachHangDAL();
        // Get UTF-8 and UTF-16 encoders.
     /*   Encoding utf8 = Encoding.UTF8;
        Encoding utf16 = Encoding.Unicode;*/

        public QuanLyYeuCau()
        {
            InitializeComponent();
            KhoiTaoLoadTuDong(); // Khởi tạo chức năng tải tự động

        }
        private void KhoiTaoLoadTuDong()
        {
            // Khởi tạo với chu kỳ 2 phút (120000ms)
            LoadTuDongBLL loadTuDong = new LoadTuDongBLL(120000);
            loadTuDong.OnDataReloaded += XuLyDuLieuMoi;

            // Bắt đầu tải tự động
            loadTuDong.Start();
        }
        private void XuLyDuLieuMoi(DataTable dt)
        {
            // Cập nhật giao diện trên luồng chính (UI thread)
            if (InvokeRequired)
            {
                Invoke(new Action(() => XuLyDuLieuMoi(dt)));
                return;
            }

            // Ví dụ: Gán dữ liệu vào DataGridView
            dgvYeuCauChuaXuLy.DataSource = dt;
        }


        //Hàm khi load form 
        private void QuanLyYeuCau_Load(object sender, EventArgs e)
        {

            this.ControlBox = false;
            this.Dock = DockStyle.Fill;
            AdjustLayout();
            //LayDuLieuTuDatabase(); // Gọi lấy dữ liệu khi load form
            LoadDuLieu();
            // Xóa các mục hiện có trong ComboBox (nếu có)
            cbLoaiDanhSach.Items.Clear();

            //Sửa ở đây 27-11-2024
            // Thêm các tùy chọn trạng thái vào ComboBox
            cbLoaiDanhSach.Items.Add("Chọn loại danh sách");
            cbLoaiDanhSach.Items.Add("Chưa duyệt");
            cbLoaiDanhSach.Items.Add("Đang xử lý");
            cbLoaiDanhSach.Items.Add("Đã nhập hàng"); //đổi trạng thái
            cbLoaiDanhSach.Items.Add("Từ chối");
            cbLoaiDanhSach.Items.Add("Tất cả");
            cbLoaiDanhSach.Items.Add("Đã rút hàng");

            // Đặt mục mặc định là "Chọn loại danh sách"
            cbLoaiDanhSach.SelectedIndex = 0;
        }

        private void QuanLyYeuCau_Resize(object sender, EventArgs e)
        {
            AdjustLayout();
        }
        private void AdjustLayout()
        {
            int formHeight = this.ClientSize.Height;
            int panelHeight = formHeight / 11;
            int gbYeuCauChuaXuLyHeight = 4 * formHeight / 11;
            //int gbDanhSachYeuCauHeight = 6 * formHeight / 11;
            int gbDanhSachYeuCauHeight = formHeight - panelHeight - gbYeuCauChuaXuLyHeight;
            pnTieuDeQuanLyYeuCau.Height = panelHeight;
            gbYeuCauChuaXuLy.Top = pnTieuDeQuanLyYeuCau.Bottom;
            gbYeuCauChuaXuLy.Height = gbYeuCauChuaXuLyHeight;
            gbYeuCauChuaXuLy.Width = this.ClientSize.Width;
            gbDanhSachYeuCau.Top = gbYeuCauChuaXuLy.Bottom + 3;
            gbDanhSachYeuCau.Height = gbDanhSachYeuCauHeight;
            gbDanhSachYeuCau.Width = this.ClientSize.Width;
            txtTieuDeQuanLyYeuCau.Left = (this.ClientSize.Width - txtTieuDeQuanLyYeuCau.Width) / 2;
            txtTieuDeQuanLyYeuCau.Top = (pnTieuDeQuanLyYeuCau.Height - txtTieuDeQuanLyYeuCau.Height) / 2;
        }
        private void LoadDuLieu()

        {
            try
            {
                // Lấy dữ liệu từ BLL
                var dt = YeuCauKHBLL.LayDuLieuChuaXuLy();

                // Gán dữ liệu vào DataGridView
                dgvYeuCauChuaXuLy.DataSource = dt;

                // Đổi tên các cột cho dễ đọc
                dgvYeuCauChuaXuLy.Columns["MaYC"].HeaderText = "Mã Yêu Cầu";
                dgvYeuCauChuaXuLy.Columns["TrangThaiXuLy"].HeaderText = "Trạng thái";
                dgvYeuCauChuaXuLy.Columns["NgayYeuCau"].HeaderText = "Ngày yêu cầu";
                dgvYeuCauChuaXuLy.Columns["SoLuongThungS"].HeaderText = "Số lượng thùng S";
                dgvYeuCauChuaXuLy.Columns["SoLuongThungM"].HeaderText = "Số lượng thùng M";
                dgvYeuCauChuaXuLy.Columns["SoLuongThungL"].HeaderText = "Số lượng thùng L";
                dgvYeuCauChuaXuLy.Columns["DungTich"].HeaderText = "Tổng dung tích";
                dgvYeuCauChuaXuLy.Columns["NgayHetHan"].HeaderText = "Ngày lấy hàng";
                dgvYeuCauChuaXuLy.Columns["CCCD"].HeaderText = "CCCD";
                dgvYeuCauChuaXuLy.Columns["VanChuyen"].HeaderText = "Vận chuyển";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }


        // Gọi lại phương thức lấy dữ liệu khi nhấn nút Làm mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadDuLieu();
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

        private void pnTieuDeQuanLyYeuCau_Paint(object sender, EventArgs e)
        {
        }

        private void gbYeuCauChuaXuLy_Enter(object sender, EventArgs e)
        {

        }

        private void pnTieuDeQuanLyYeuCau_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtTieuDeQuanLyYeuCau_Click(object sender, EventArgs e)
        {

        }

        //Xử lí việc xác nhận đơn hàng:
        public string maYeuCauHienTai = ""; // Biến lưu mã yêu cầu dạng YCxxxx


        private void dgvYeuCauChuaXuLy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow hang = dgvYeuCauChuaXuLy.Rows[e.RowIndex];
                maYeuCauHienTai = hang.Cells["MaYC"].Value.ToString(); // Giả sử cột "Mã Yêu Cầu" chứa mã yêu cầu
                //MessageBox.Show("Mã yêu cầu đã chọn: " + maYeuCauHienTai);
            }
        }


        private void btnDuyet_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có yêu cầu nào được chọn không
            if (string.IsNullOrEmpty(maYeuCauHienTai))
            {
                MessageBox.Show("Vui lòng chọn một yêu cầu trước khi duyệt.");
                return;
            }

            // Đưa vào try catch để bắt lỗi
            try
            {
                // Cập nhật trạng thái yêu cầu
                YeuCauKHBLL.CapNhatTrangThaiYeuCau(maYeuCauHienTai, "Đang xử lý");
                MessageBox.Show("Trạng thái yêu cầu đã được cập nhật");

                // Lấy thông tin yêu cầu và tiền
                decimal tongTien = YeuCauKHBLL.TinhTien(maYeuCauHienTai);
                KetQuaDuyet ketquaDuyet = new KetQuaDuyet();

                // Lấy thông tin chi tiết yêu cầu
                var thongTinYC = YeuCauKHBLL.LayThongTinYC(maYeuCauHienTai);
                decimal TongTheTich = YeuCauKHBLL.TinhTheTich(maYeuCauHienTai);
                /* int soluongthungS = thongTinYC.SoLuongThungS;
                 int soluongthungM = thongTinYC.SoLuongThungM;
                 int soluongthungL = thongTinYC.SoLuongThungL;*/
                // Tính thời gian lưu trữ giữa ngày hết hạn và ngày đăng ký
                TimeSpan thoiGianLuuTru = thongTinYC.NgayHetHan - thongTinYC.NgayDangKy;

                // Tính tổng số giờ thực tế (bao gồm phần ngày)
                decimal tongSoGioLuuTru = (decimal)thoiGianLuuTru.TotalHours;

                // Làm tròn xuống phần nguyên để lấy số giờ
                int hours = (int)Math.Floor(tongSoGioLuuTru);

                // Tính phần phút
                int minutes = (int)((tongSoGioLuuTru - hours) * 60);

                // Tính phần giây
                int seconds = (int)((tongSoGioLuuTru - hours - (decimal)minutes / 60) * 3600);

                // Chuẩn bị chuỗi thời gian lưu trữ theo định dạng giờ, phút, giây
                string thoiGianLuuTruText = $"{hours} giờ {minutes} phút {seconds} giây";

                // Hiển thị kết quả tổng thời gian lưu trữ
                Console.WriteLine($"Tổng thời gian lưu trữ: {thoiGianLuuTruText}");

                // Tìm kho phù hợp dựa trên thể tích yêu cầu
                string ketQuaTimKiem = "";
                int tongDungTichYeuCau = (int)TongTheTich; // Giả sử tổng thể tích yêu cầu là thể tích cần tìm kho
                TimKiem timKiem = new TimKiem(); // Khởi tạo đối tượng tìm kiếm kho
                string ketQuaTimKho = timKiem.TimVaGhiNhanNhieuGoiY(tongDungTichYeuCau); // Lấy kết quả tìm kho phù hợp

                // Cập nhật kết quả tìm kho vào thông tin kết quả duyệt
                ketQuaTimKiem += "\nWarehouse Promt thông báo:\n " + ketQuaTimKho;
                // Chuyển đổi NgayDangKy thành chuỗi với định dạng dd/MM/yyyy
                string ngayDangKyFormatted = thongTinYC.NgayDangKy.ToString("dd/MM/yyyy");
                // Truyền thông tin sang form kết quả
                ketquaDuyet.ShowKetQua(
                    maYeuCau: maYeuCauHienTai,
                    tenKhachHang: thongTinYC.TenKhachHang,
                    thoiGianLuuTru: thoiGianLuuTruText,
                    tongTheTich: TongTheTich,
                    tongTien: tongTien,
                    thoiGianDangKy: ngayDangKyFormatted,
                    ketQuaTimKiem: ketQuaTimKiem // Truyền kết quả tìm kiếm vào
                );

                // Hiển thị form kết quả
                ketquaDuyet.ShowDialog(); // Hiển thị form kết quả dưới dạng modal

                // Làm mới lại dữ liệu sau khi duyệt
                LoadDuLieu();

                // Gửi email thông báo cho khách hàng
                YeuCauKHBLL.GuiEmailThongBao(maYeuCauHienTai);
                maYeuCauHienTai = "";
            }
            //catch (Exception ex)
            //{
            //    // Xử lý lỗi nếu có
            //    MessageBox.Show("Lỗi trong quá trình duyệt: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            catch (Exception ex)
{
                // Hiển thị thông tin lỗi chi tiết hơn
                string chiTietLoi = $"Lỗi trong quá trình duyệt: {ex.Message}\n" +
                                    $"Nguồn: {ex.Source}\n" +
                                    $"Vị trí lỗi: {ex.StackTrace}";

                // Hiển thị thông báo lỗi chi tiết ra hộp thoại
                MessageBox.Show(chiTietLoi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
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

        private void btnTimKiemYeuCauChuaXuLy_Click(object sender, EventArgs e)
        {
            string tuKhoa = boxTimKiemYeuCauChuaXuLy.Text.Trim();
            //Kiểm tra từ khóa có trống không
            if (string.IsNullOrEmpty(tuKhoa))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Lấy dữ liệu từ BLL
            var dt = YeuCauKHBLL.TimKiem_chuaduyet(tuKhoa);
            // Gán dữ liệu vào DataGridView
            dgvYeuCauChuaXuLy.DataSource = dt;
            // Đổi tên các cột cho dễ đọc
            // Đổi tên các cột cho dễ đọc
            dgvYeuCauChuaXuLy.Columns["MaYC"].HeaderText = "Mã Yêu Cầu";
            dgvYeuCauChuaXuLy.Columns["TrangThaiXuLy"].HeaderText = "Trạng thái";
            dgvYeuCauChuaXuLy.Columns["NgayYeuCau"].HeaderText = "Ngày yêu cầu";
            dgvYeuCauChuaXuLy.Columns["SoLuongThungS"].HeaderText = "Số lượng thùng S";
            dgvYeuCauChuaXuLy.Columns["SoLuongThungM"].HeaderText = "Số lượng thùng M";
            dgvYeuCauChuaXuLy.Columns["SoLuongThungL"].HeaderText = "Số lượng thùng L";
            dgvYeuCauChuaXuLy.Columns["DungTich"].HeaderText = "Tổng dung tích";
            dgvYeuCauChuaXuLy.Columns["NgayHetHan"].HeaderText = "Ngày lấy hàng";
            dgvYeuCauChuaXuLy.Columns["CCCD"].HeaderText = "CCCD";
            dgvYeuCauChuaXuLy.Columns["VanChuyen"].HeaderText = "Vận chuyển";

        }

        private void btnTimKiemYeuCauChuaXuLy_Enter(object sender, EventArgs e)
        {
            btnTimKiemYeuCauChuaXuLy.ColorBackground = Color.FromArgb(250, 150, 77);
        }

        private void btnTimKiemYeuCauChuaXuLy_Leave(object sender, EventArgs e)
        {
            btnTimKiemYeuCauChuaXuLy.ColorBackground = Color.White;
        }

        private void btnTimKiemYeuCauChuaXuLy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiemYeuCauChuaXuLy_Click(sender, e);
            }
        }

        private void cbLoaiDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            string trangThai = cbLoaiDanhSach.SelectedItem.ToString();
            if (trangThai == "Chưa duyệt")
            {
                // Lấy dữ liệu từ BLL
                var dt = YeuCauKHBLL.LayDuLieuChuaXuLy();

                // Gán dữ liệu vào DataGridView
                dgvDanhSachYeuCau.DataSource = dt;

                // Đổi tên các cột cho dễ đọc
                dgvDanhSachYeuCau.Columns["MaYC"].HeaderText = "Mã Yêu Cầu";
                dgvDanhSachYeuCau.Columns["TrangThaiXuLy"].HeaderText = "Trạng thái";
                dgvDanhSachYeuCau.Columns["NgayYeuCau"].HeaderText = "Ngày yêu cầu";
                dgvDanhSachYeuCau.Columns["SoLuongThungS"].HeaderText = "Số lượng thùng S";
                dgvDanhSachYeuCau.Columns["SoLuongThungM"].HeaderText = "Số lượng thùng M";
                dgvDanhSachYeuCau.Columns["SoLuongThungL"].HeaderText = "Số lượng thùng L";
                dgvDanhSachYeuCau.Columns["DungTich"].HeaderText = "Tổng dung tích";
                dgvDanhSachYeuCau.Columns["NgayHetHan"].HeaderText = "Ngày lấy hàng";
                dgvDanhSachYeuCau.Columns["CCCD"].HeaderText = "CCCD";
                dgvDanhSachYeuCau.Columns["VanChuyen"].HeaderText = "Vận chuyển";

            }
            else if (trangThai == "Đang xử lý")
            {
                // Lấy dữ liệu từ BLL
                var dt = YeuCauKHBLL.LayDuLieuDangXuLy();

                // Gán dữ liệu vào DataGridView
                dgvDanhSachYeuCau.DataSource = dt;

                // Đổi tên các cột cho dễ đọc
                dgvDanhSachYeuCau.Columns["MaYC"].HeaderText = "Mã Yêu Cầu";
                dgvDanhSachYeuCau.Columns["TrangThaiXuLy"].HeaderText = "Trạng thái";
                dgvDanhSachYeuCau.Columns["NgayYeuCau"].HeaderText = "Ngày yêu cầu";
                dgvDanhSachYeuCau.Columns["SoLuongThungS"].HeaderText = "Số lượng thùng S";
                dgvDanhSachYeuCau.Columns["SoLuongThungM"].HeaderText = "Số lượng thùng M";
                dgvDanhSachYeuCau.Columns["SoLuongThungL"].HeaderText = "Số lượng thùng L";
                dgvDanhSachYeuCau.Columns["DungTich"].HeaderText = "Tổng dung tích";
                dgvDanhSachYeuCau.Columns["NgayHetHan"].HeaderText = "Ngày lấy hàng";
                dgvDanhSachYeuCau.Columns["CCCD"].HeaderText = "CCCD";
                dgvDanhSachYeuCau.Columns["VanChuyen"].HeaderText = "Vận chuyển";

            }
            else if (trangThai == "Đã nhập hàng")

            {

                // Lấy dữ liệu từ BLL
                var dt = YeuCauKHBLL.LayDuLieuDaNhapHang();

                // Gán dữ liệu vào DataGridView
                dgvDanhSachYeuCau.DataSource = dt;

                dgvDanhSachYeuCau.Columns["MaYC"].HeaderText = "Mã Yêu Cầu";
                dgvDanhSachYeuCau.Columns["TrangThaiXuLy"].HeaderText = "Trạng thái";
                dgvDanhSachYeuCau.Columns["NgayYeuCau"].HeaderText = "Ngày yêu cầu";
                dgvDanhSachYeuCau.Columns["SoLuongThungS"].HeaderText = "Số lượng thùng S";
                dgvDanhSachYeuCau.Columns["SoLuongThungM"].HeaderText = "Số lượng thùng M";
                dgvDanhSachYeuCau.Columns["SoLuongThungL"].HeaderText = "Số lượng thùng L";
                dgvDanhSachYeuCau.Columns["DungTich"].HeaderText = "Tổng dung tích";
                dgvDanhSachYeuCau.Columns["NgayHetHan"].HeaderText = "Ngày lấy hàng";
                dgvDanhSachYeuCau.Columns["CCCD"].HeaderText = "CCCD";
                dgvDanhSachYeuCau.Columns["VanChuyen"].HeaderText = "Vận chuyển";

            }
            else if (trangThai == "Từ chối")
            {
                var dt = YeuCauKHBLL.LayDuLieuTuChoi();

                // Gán dữ liệu vào DataGridView
                dgvDanhSachYeuCau.DataSource = dt;

                dgvDanhSachYeuCau.Columns["MaYC"].HeaderText = "Mã Yêu Cầu";
                dgvDanhSachYeuCau.Columns["TrangThaiXuLy"].HeaderText = "Trạng thái";
                dgvDanhSachYeuCau.Columns["NgayYeuCau"].HeaderText = "Ngày yêu cầu";
                dgvDanhSachYeuCau.Columns["SoLuongThungS"].HeaderText = "Số lượng thùng S";
                dgvDanhSachYeuCau.Columns["SoLuongThungM"].HeaderText = "Số lượng thùng M";
                dgvDanhSachYeuCau.Columns["SoLuongThungL"].HeaderText = "Số lượng thùng L";
                dgvDanhSachYeuCau.Columns["DungTich"].HeaderText = "Tổng dung tích";
                dgvDanhSachYeuCau.Columns["NgayHetHan"].HeaderText = "Ngày lấy hàng";
                dgvDanhSachYeuCau.Columns["CCCD"].HeaderText = "CCCD";
                dgvDanhSachYeuCau.Columns["VanChuyen"].HeaderText = "Vận chuyển";
            }
            else if (trangThai == "Đã rút hàng")
            {
                var dt = YeuCauKHBLL.LayDuLieuDaRutHang();
                // Gán dữ liệu vào DataGridView
                dgvDanhSachYeuCau.DataSource = dt;
                dgvDanhSachYeuCau.Columns["MaYC"].HeaderText = "Mã Yêu Cầu";
                dgvDanhSachYeuCau.Columns["TrangThaiXuLy"].HeaderText = "Trạng thái";
                dgvDanhSachYeuCau.Columns["NgayYeuCau"].HeaderText = "Ngày yêu cầu";
                dgvDanhSachYeuCau.Columns["SoLuongThungS"].HeaderText = "Số lượng thùng S";
                dgvDanhSachYeuCau.Columns["SoLuongThungM"].HeaderText = "Số lượng thùng M";
                dgvDanhSachYeuCau.Columns["SoLuongThungL"].HeaderText = "Số lượng thùng L";
                dgvDanhSachYeuCau.Columns["DungTich"].HeaderText = "Tổng dung tích";
                dgvDanhSachYeuCau.Columns["NgayHetHan"].HeaderText = "Ngày lấy hàng";
                dgvDanhSachYeuCau.Columns["CCCD"].HeaderText = "CCCD";
                dgvDanhSachYeuCau.Columns["VanChuyen"].HeaderText = "Vận chuyển";
            }
            else
            {
                // Lấy dữ liệu từ BLL
                var dt = YeuCauKHBLL.LayDuLieu();

                // Gán dữ liệu vào DataGridView
                dgvDanhSachYeuCau.DataSource = dt;

                // Đổi tên các cột cho dễ đọc
                dgvDanhSachYeuCau.Columns["MaYC"].HeaderText = "Mã Yêu Cầu";
                dgvDanhSachYeuCau.Columns["TrangThaiXuLy"].HeaderText = "Trạng thái";
                dgvDanhSachYeuCau.Columns["NgayYeuCau"].HeaderText = "Ngày yêu cầu";
                dgvDanhSachYeuCau.Columns["SoLuongThungS"].HeaderText = "Số lượng thùng S";
                dgvDanhSachYeuCau.Columns["SoLuongThungM"].HeaderText = "Số lượng thùng M";
                dgvDanhSachYeuCau.Columns["SoLuongThungL"].HeaderText = "Số lượng thùng L";
                dgvDanhSachYeuCau.Columns["DungTich"].HeaderText = "Tổng dung tích";
                dgvDanhSachYeuCau.Columns["NgayHetHan"].HeaderText = "Ngày lấy hàng";
                dgvDanhSachYeuCau.Columns["CCCD"].HeaderText = "CCCD";
                dgvDanhSachYeuCau.Columns["VanChuyen"].HeaderText = "Vận chuyển";


            }
        }

        private void btnXem_Enter(object sender, EventArgs e)
        {
            btnXem.ColorBackground = Color.FromArgb(250, 150, 77);
        }

        private void btnXem_Leave(object sender, EventArgs e)
        {
            btnXem.ColorBackground = Color.White;
        }

        private void btnXem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnXem_Click(sender, e);
            }
        }

        private void SetupDataGridView()
        {
            dgvDanhSachYeuCau.Columns["MaYC"].HeaderText = "Mã Yêu Cầu";
            dgvDanhSachYeuCau.Columns["TrangThaiXuLy"].HeaderText = "Trạng thái";
            dgvDanhSachYeuCau.Columns["NgayYeuCau"].HeaderText = "Ngày yêu cầu";
            dgvDanhSachYeuCau.Columns["SoLuongThungS"].HeaderText = "Số lượng thùng S";
            dgvDanhSachYeuCau.Columns["SoLuongThungM"].HeaderText = "Số lượng thùng M";
            dgvDanhSachYeuCau.Columns["SoLuongThungL"].HeaderText = "Số lượng thùng L";
            dgvDanhSachYeuCau.Columns["DungTich"].HeaderText = "Tổng dung tích";
            dgvDanhSachYeuCau.Columns["NgayHetHan"].HeaderText = "Ngày lấy hàng";
            dgvDanhSachYeuCau.Columns["CCCD"].HeaderText = "CCCD";
            dgvDanhSachYeuCau.Columns["VanChuyen"].HeaderText = "Vận chuyển";
        }


        private void btnTimKiemYeuCau_Click(object sender, EventArgs e)
        {
            string trangThai = cbLoaiDanhSach.SelectedItem.ToString(); ;
            string tuKhoa = boxTimKiemYeuCau.Text;

            if (string.IsNullOrEmpty(tuKhoa))
            {
                MessageBox.Show("Vui lòng nhập vào nội dung tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(trangThai))
            {
                MessageBox.Show("Vui lòng chọn loại danh sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Gửi yêu cầu tìm kiếm đến BLL
            if (trangThai == "Chưa duyệt")
            {
                // Lấy dữ liệu từ BLL
                var dt = YeuCauKHBLL.TimKiem_chuaduyet(tuKhoa);
                // Gán dữ liệu vào DataGridView
                dgvDanhSachYeuCau.DataSource = dt;
                // Đổi tên các cột cho dễ đọc
                SetupDataGridView();
            }
            else if (trangThai == "Đang xử lý")
            {
                var dt = YeuCauKHBLL.TimKiem_dangxuli(tuKhoa);
                //Gán dữ liệu vào DataGridView
                dgvDanhSachYeuCau.DataSource = dt;

                SetupDataGridView();
            }
            else if (trangThai == "Đã rút hàng")
            {
                var dt = YeuCauKHBLL.TimKiem_darutphang(tuKhoa);
                //Gán dữ liệu vào DataGridView
                dgvDanhSachYeuCau.DataSource = dt;

                SetupDataGridView();
            }
            else if (trangThai == "Từ chối")
            {
                var dt = YeuCauKHBLL.TimKiem_tuchoi(tuKhoa);
                //Gán dữ liệu vào DataGridView
                dgvDanhSachYeuCau.DataSource = dt;
                SetupDataGridView();
            }
            else if (trangThai == "Đã nhập hàng")
            {
                var dt = YeuCauKHBLL.TimKiem_danhaphang(tuKhoa);
                dgvDanhSachYeuCau.DataSource = dt;
                SetupDataGridView();
            }
            else //Tìm kiếm cho tất cả:
            {
                var dt = YeuCauKHBLL.TimKiem_tatca(tuKhoa);
                dgvDanhSachYeuCau.DataSource = dt;

                SetupDataGridView();
            }
        }

        private void btnTimKiemYeuCau_Enter(object sender, EventArgs e)
        {
            btnTimKiemYeuCau.ColorBackground = Color.FromArgb(250, 150, 77);
        }

        private void btnTimKiemYeuCau_Leave(object sender, EventArgs e)
        {
            btnTimKiemYeuCau.ColorBackground = Color.White;
        }

        private void btnTimKiemYeuCau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiemYeuCau_Click(sender, e);
            }
        }

        private void btnXuatPhieuNhap_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra trạng thái yêu cầu từ DAL
                string trangThai = YeuCauKHBLL.GetTrangThaiYeuCau(maYeuCauHienTaiPN);

                // Nếu trạng thái không phải "Hoàn thành", thông báo lỗi
                if (trangThai != "Đã nhập hàng")
                {
                    MessageBox.Show("Yêu cầu chưa được nhập hàng, không thể xuất phiếu nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tiến hành xuất phiếu nhập nếu trạng thái là "Hoàn thành"
                YeuCauKHBLL.XuatPhieuNhapToPDF(maYeuCauHienTaiPN);

                MessageBox.Show("Phiếu nhập đã được xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("Có lỗi xảy ra khi xuất phiếu nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatPhieuNhap_Enter(object sender, EventArgs e)
        {
            btnXuatPhieuNhap.ColorBackground = Color.FromArgb(250, 150, 77);
        }

        private void btnXuatPhieuNhap_Leave(object sender, EventArgs e)
        {
            btnXuatPhieuNhap.ColorBackground = Color.White;
        }

        private void btnXuatPhieuNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnXuatPhieuNhap_Click(sender, e);
            }
        }

        public string maYeuCauHienTaiPN = "";
        private void dgvDanhSachYeuCau_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow hang = dgvDanhSachYeuCau.Rows[e.RowIndex];
                maYeuCauHienTaiPN = hang.Cells["MaYC"].Value.ToString(); // Giả sử cột "Mã Yêu Cầu" chứa mã yêu cầu
                //MessageBox.Show("Mã yêu cầu đã chọn: " + maYeuCauHienTai);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy trạng thái được chọn từ ComboBox
                string trangThaiChon = cbLoaiDanhSach.SelectedItem.ToString();

                // Gọi phương thức BLL để xuất báo cáo
                YeuCauKHBLL.InToExcel(trangThaiChon);

                // Thông báo thành công
                MessageBox.Show("Báo cáo đã được xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("Có lỗi xảy ra khi xuất báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
