using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using WarehouseMA.BLL;

using System.IO;

using Mysqlx.Notice;



//using DrawingRectangle = System.Drawing.Rectangle;
//using PdfRectangle = iTextSharp.text.Rectangle;
//using iTextFont = iTextSharp.text.Font;
//using DrawingFont = System.Drawing.Font;

using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Exceptions;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Event;
using iText.Kernel.Font;
using iText.Layout.Properties;
using iText.IO.Font;
using iText.Commons.Actions;
using iText.IO.Font.Constants;
using iText.Kernel.Pdf.Xobject;
using System.Diagnostics;





namespace WarehouseMA
{


    public partial class QuanLyKho : Form
    {



        QuanLyKhoBLL a = new QuanLyKhoBLL();

        public QuanLyKho()
        {
            InitializeComponent();

        }

        private void QuanLyKho_Load(object sender, EventArgs e)
        {

            dgvDanhSach.AllowUserToAddRows = false;
            cbKho.Items.AddRange(new object[] { "Kho Nội Bộ", "Kho Cho Thuê" });

            //btnXoa.Enabled = false; // Vô hiệu hóa nút
            //btnSua.Enabled = false;  // Kích hoạt lại nút
            btnLuu.Enabled = false;
            dgvDanhSach.ReadOnly = true;
            this.ControlBox = false;
            this.Dock = DockStyle.Fill;

            cbKho.SelectedIndex = 0;
            UpdateListBasedOnWarehouse();

        }

        private void cbKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateListBasedOnWarehouse();
        }

        private void UpdateListBasedOnWarehouse()
        {
            string selectedWarehouse = cbKho.SelectedItem.ToString();
            cbDanhSach.Items.Clear();

            // Nếu chọn "Kho Nội Bộ", chỉ hiển thị "Danh sách Kho" và "Danh sách Kệ"
            if (selectedWarehouse == "Kho Nội Bộ")
            {
                cbDanhSach.Items.AddRange(new object[] { "Danh sách kho nội bộ", "Danh sách kệ nội bộ", "Danh sách hàng hóa nội bộ" });
            }
            // Nếu chọn "Kho Cho Thuê", hiển thị tất cả các danh sách
            else if (selectedWarehouse == "Kho Cho Thuê")
            {
                cbDanhSach.Items.AddRange(new object[] { "Danh sách kho cho thuê", "Danh sách kệ cho thuê", "Danh sách tầng", "Danh sách ngăn", "Danh sách thùng" });
            }
            cbDanhSach.SelectedIndex = 0;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            //btnXoa.Enabled = false; // Vô hiệu hóa nút
            //btnSua.Enabled = false;  
            //btnLuu.Enabled = false;
            //cbDanhSach.Enabled = true;// Kích hoạt danh sách
            //cbKho.Enabled = true;
            //btnThem.Enabled = true;
            LoadDataForSelectedList();
            string selectedList = cbDanhSach.SelectedItem.ToString();
            if (selectedList == "Danh sách thùng")
            {
                KiemTraHetHan();
            }

            if (selectedList == "Danh sách hàng hóa nội bộ")
            {
                KiemTraSoluong();
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

        public void LoadDataForSelectedList()
        {
            if (dgvDanhSach != null)
            {
                dgvDanhSach.Columns.Clear();
            }

            string selectedList = cbDanhSach.SelectedItem.ToString();
            switch (selectedList)
            {
                case "Danh sách kho nội bộ":
                    dgvDanhSach.DataSource = GetDSKhoNoiBo();
                    dgvDanhSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    break;
                case "Danh sách kệ nội bộ":
                    dgvDanhSach.DataSource = GetDSKeNoiBo();
                    dgvDanhSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    break;
                case "Danh sách hàng hóa nội bộ":
                    dgvDanhSach.DataSource = GetDSHangHoaNoiBo();
                    dgvDanhSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    KiemTraSoluong();
                    break;
                case "Danh sách kho cho thuê":
                    dgvDanhSach.DataSource = GetDSKhoChoThue();
                    dgvDanhSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    break;
                case "Danh sách kệ cho thuê":
                    dgvDanhSach.DataSource = GetDSKeChoThue();
                    dgvDanhSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    break;
                case "Danh sách tầng":
                    dgvDanhSach.DataSource = GetDSTang();
                    dgvDanhSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    break;
                case "Danh sách ngăn":
                    dgvDanhSach.DataSource = GetDSNgan();
                    dgvDanhSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    break;
                case "Danh sách thùng":
                    dgvDanhSach.DataSource = GetDSThung();
                    dgvDanhSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    KiemTraHetHan();
                    break;
            }
        }

        // Các danh sách xem trong quản lý kho 
        private DataTable GetDSKhoNoiBo()
        {


            var dt = a.LayDuLieuKhoNoiBo();
            return dt;

        }

        private DataTable GetDSKeNoiBo()
        {

            var dt = a.LayDuLieuKeNoiBo();
            return dt;
        }

        private DataTable GetDSHangHoaNoiBo()
        {

            var dt = a.LayDuLieuHangHoaNoiBo();
            return dt;
        }


        private DataTable GetDSKhoChoThue()
        {

            var dt = a.LayDuLieuKhoChoThue();
            return dt;
        }

        private DataTable GetDSKeChoThue()
        {

            var dt = a.LayDuLieuKeChoThue();
            return dt;
        }

        private DataTable GetDSTang()
        {

            var dt = a.LayDuLieuTang();
            return dt;
        }

        private DataTable GetDSNgan()
        {

            var dt = a.LayDuLieuNgan();
            return dt;
        }

        private DataTable GetDSThung()
        {

            var dt = a.LayDuLieuThung();
            return dt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string luaChon = cbDanhSach.SelectedItem.ToString();

            if (String.IsNullOrEmpty(luaChon))
            {
                Console.WriteLine("vui lòng chọn loại thông tin muốn thêm");
                return;
            }

            if (luaChon == "Danh sách kho nội bộ")
            {
                ThemKhoNoiBo a = new ThemKhoNoiBo();
                a.Owner = this;
                a.ShowDialog();

            }

            else if (luaChon == "Danh sách kho cho thuê")
            {
                ThemKhoChoThue a = new ThemKhoChoThue();
                a.Owner = this;
                a.ShowDialog();

            }


            else if (luaChon == "Danh sách kệ nội bộ")
            {
                ThemKeNoiBo a = new ThemKeNoiBo();
                a.Owner = this;
                a.ShowDialog();

            }

            else if (luaChon == "Danh sách hàng hóa nội bộ")
            {
                ThemHangHoaNoiBo a = new ThemHangHoaNoiBo();
                a.Owner = this;
                a.ShowDialog();

            }


            else if (luaChon == "Danh sách kệ cho thuê")
            {
                ThemKeChoThue a = new ThemKeChoThue();
                a.Owner = this;
                a.ShowDialog();

            }


            else if (luaChon == "Danh sách tầng")
            {
                ThemTang a = new ThemTang();
                a.Owner = this;
                a.ShowDialog();

            }


            else if (luaChon == "Danh sách ngăn")
            {
                ThemNgan a = new ThemNgan();
                a.Owner = this;
                a.ShowDialog();

            }

            else if (luaChon == "Danh sách thùng")
            {
                ThemThung a = new ThemThung();
                a.Owner = this;
                a.ShowDialog();

            }



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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string luaChon = cbDanhSach.SelectedItem.ToString();

            if (dgvDanhSach.SelectedCells.Count == 1 || dgvDanhSach.SelectedRows.Count == 1)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //Hành động xóa
                if (result == DialogResult.Yes)
                {
                    if (luaChon == "Danh sách kho nội bộ")
                    {
                        string maKho = dgvDanhSach.CurrentRow.Cells["Mã kho"].Value?.ToString();
                        string chucNang = dgvDanhSach.CurrentRow.Cells["Chức năng"].Value?.ToString();

                        MessageBox.Show(a.XoaDuLieuKhoNoiBo(maKho, chucNang));
                    }

                    if (luaChon == "Danh sách kho cho thuê")
                    {
                        float dungTichKhaDung = float.Parse(dgvDanhSach.CurrentRow.Cells["Dung tích khả dụng"].Value?.ToString());
                        float dungTichDaDung = float.Parse(dgvDanhSach.CurrentRow.Cells["Dung tích đã dùng"].Value?.ToString());
                        string maKho = dgvDanhSach.CurrentRow.Cells["Mã kho"].Value?.ToString();


                        MessageBox.Show(a.XoaDuLieuKhoChoThue(maKho, dungTichKhaDung, dungTichDaDung));
                    }

                    if (luaChon == "Danh sách kệ nội bộ")
                    {
                        string maKho = dgvDanhSach.CurrentRow.Cells["Mã kho"].Value?.ToString();
                        string maKe = dgvDanhSach.CurrentRow.Cells["Mã kệ"].Value?.ToString();

                        MessageBox.Show(a.XoaDuLieuKeNoiBo(maKho, maKe));
                    }

                    if (luaChon == "Danh sách hàng hóa nội bộ")
                    {
                        string maHangHoa = dgvDanhSach.CurrentRow.Cells["Mã hàng hóa"].Value?.ToString();

                        MessageBox.Show(a.XoaDuLieuHangHoaNoiBo(maHangHoa));
                    }

                    if (luaChon == "Danh sách kệ cho thuê")
                    {
                        string maKe = dgvDanhSach.CurrentRow.Cells["Mã kệ"].Value?.ToString();

                        MessageBox.Show(a.XoaDuLieuKeChoThue(maKe));
                    }


                    if (luaChon == "Danh sách tầng")
                    {
                        string maTang = dgvDanhSach.CurrentRow.Cells["Mã tầng"].Value?.ToString();

                        MessageBox.Show(a.XoaDuLieuTang(maTang));
                    }

                    if (luaChon == "Danh sách ngăn")
                    {
                        string maNgan = dgvDanhSach.CurrentRow.Cells["Mã ngăn"].Value?.ToString();

                        MessageBox.Show(a.XoaDuLieuNgan(maNgan));
                    }

                    if (luaChon == "Danh sách thùng")
                    {
                        string maThung = dgvDanhSach.CurrentRow.Cells["Mã thùng"].Value?.ToString();
                        string dungTich = dgvDanhSach.CurrentRow.Cells["Dung tích"].Value?.ToString();
                        string maNgan = dgvDanhSach.CurrentRow.Cells["Mã ngăn"].Value?.ToString();

                        MessageBox.Show(a.XoaDuLieuThung(maThung, maNgan, float.Parse(dungTich)));
                    }
                    LoadDataForSelectedList();
                }

            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnXoa_Enter(object sender, EventArgs e)
        {
            btnXoa.ColorBackground = Color.FromArgb(250, 150, 77);
        }

        private void btnXoa_Leave(object sender, EventArgs e)
        {
            btnXoa.ColorBackground = Color.White;
        }

        private void btnXoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnXoa_Click(sender, e);
            }
        }

        //private bool kiemTraDong()
        //{
        //    foreach (DataGridViewCell cell in dgvDanhSach.CurrentCell.OwningRow.Cells)
        //    {
        //        if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
        //        {
        //            return false; // Có ít nhất một ô  trống
        //        }
        //    }
        //    return true;
        //}





        private void btnSua_Click(object sender, EventArgs e)
        {
            string luaChon = cbDanhSach.SelectedItem.ToString();
            if (luaChon != "Danh sách thùng" && luaChon != "Danh sách kho nội bộ" && luaChon != "Danh sách hàng hóa nội bộ")
            {
                MessageBox.Show("Không được sửa danh sách này");
                return;
            }


            cbDanhSach.Enabled = false;// Vô hiệu hóa nút danh sách
            cbKho.Enabled = false;



            btnLuu.Enabled = true;

            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnIn.Enabled = false;
            btnXem.Enabled = false;

            //int selectedRowIndex = dgvDanhSach.SelectedCells[0].RowIndex;

            //foreach (DataGridViewCell cell in dgvDanhSach.Rows[selectedRowIndex].Cells)
            //{
            //    cell.ReadOnly = false; // Bỏ readonly cho từng ô
            //}
            dgvDanhSach.ReadOnly = false;
            if (luaChon == "Danh sách kho nội bộ")
            {
                dgvDanhSach.Columns[0].ReadOnly = true;
            }
            else if (luaChon == "Danh sách hàng hóa nội bộ")
            {
                dgvDanhSach.Columns[0].ReadOnly = true;
                dgvDanhSach.Columns[1].ReadOnly = true;
            }
            else if (luaChon == "Danh sách thùng")
            {
                dgvDanhSach.Columns[0].ReadOnly = true;
                dgvDanhSach.Columns[1].ReadOnly = true;
                dgvDanhSach.Columns[2].ReadOnly = true;
                dgvDanhSach.Columns[3].ReadOnly = true;
                dgvDanhSach.Columns[4].ReadOnly = true;
                dgvDanhSach.Columns[5].ReadOnly = true;
                dgvDanhSach.Columns[6].ReadOnly = true;
                dgvDanhSach.Columns[7].ReadOnly = true;
            }
            //else if (luaChon == "Danh sách kho cho thuê")
            //{
            //    dgvDanhSach.Columns[0].ReadOnly = true;

            //}
            //else if (luaChon == "Danh sách kệ cho thuê")
            //{
            //    dgvDanhSach.Columns[0].ReadOnly = true;
            //    dgvDanhSach.Columns[1].ReadOnly = true;
            //}
            //else if (luaChon == "Danh sách tầng")
            //{
            //    dgvDanhSach.Columns[0].ReadOnly = true;
            //    dgvDanhSach.Columns[1].ReadOnly = true;
            //}
            //else if (luaChon == "Danh sách ngăn")
            //{
            //    dgvDanhSach.Columns[0].ReadOnly = true;
            //    dgvDanhSach.Columns[3].ReadOnly = true;
            //}

           
        }

        private void btnSua_Enter(object sender, EventArgs e)
        {
            btnSua.ColorBackground = Color.FromArgb(250, 150, 77);
        }

        private void btnSua_Leave(object sender, EventArgs e)
        {
            btnSua.ColorBackground = Color.White;
        }

        private void btnSua_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSua_Click(sender, e);
            }
        }


        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadDataForSelectedList();
            string keyword = boxTimKiem.Text.Trim().ToLower();
            //if (string.IsNullOrEmpty(keyword) == true)
            //{
            //    MessageBox.Show("Vui lòng nhập thông tin tìm kiếm");
            //    return;
            //}



            // Kiểm tra nếu DataGridView có dữ liệu
            if (dgvDanhSach.DataSource is DataTable originalTable)
            {
                DataTable filteredTable = originalTable.Clone(); // Tạo một DataTable mới với cấu trúc giống bảng gốc

                foreach (DataRow row in originalTable.Rows)
                {
                    string rowContent = string.Join(" ", row.ItemArray).ToLower(); // Ghép giá trị của các cột thành chuỗi
                    if (rowContent.Contains(keyword)) // Kiểm tra từ khóa
                    {
                        filteredTable.ImportRow(row); // Thêm dòng khớp vào bảng mới
                    }
                }

                if (filteredTable.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dgvDanhSach.DataSource = filteredTable; // Gán bảng đã lọc cho DataGridView
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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



        //private void btnIn_Click(object sender, EventArgs e)
        //{
        //    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn in không?", "Xác nhận in", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    if (result == DialogResult.Yes)
        //    {
        //        try
        //        {
        //            // Tạo một file PDF
        //            Document document = new Document();
        //            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        //            string pdfFilePath = System.IO.Path.Combine(desktopPath, "outputKho.pdf");
        //            PdfWriter.GetInstance(document, new System.IO.FileStream(pdfFilePath, System.IO.FileMode.Create));

        //            // Mở file PDF để ghi dữ liệu
        //            document.Open();

        //            // Tạo tiêu đề cho file PDF
        //            document.Add(new Paragraph("Dữ liệu từ DataGridView"));
        //            document.Add(new Paragraph("\n"));

        //            // Tạo bảng trong PDF
        //            PdfPTable table = new PdfPTable(dgvDanhSach.Columns.Count); // Đếm số cột từ DataGridView

        //            // Thêm tiêu đề cột vào bảng PDF
        //            foreach (DataGridViewColumn column in dgvDanhSach.Columns)
        //            {
        //                table.AddCell(new Phrase(column.HeaderText));
        //            }

        //            // Thêm dữ liệu từ DataGridView vào bảng PDF
        //            foreach (DataGridViewRow row in dgvDanhSach.Rows)
        //            {
        //                if (!row.IsNewRow) // Không lấy dòng mới (nếu có)
        //                {
        //                    foreach (DataGridViewCell cell in row.Cells)
        //                    {
        //                        table.AddCell(new Phrase(cell.Value?.ToString() ?? ""));
        //                    }
        //                }
        //            }

        //            // Thêm bảng vào tài liệu PDF
        //            document.Add(table);

        //            // Đóng tài liệu PDF
        //            document.Close();

        //            MessageBox.Show("File PDF đã được lưu thành công tại: " + pdfFilePath, "In thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}

        private void btnIn_Click(object sender, EventArgs e)
        {
            string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            string luaChon = cbDanhSach.SelectedItem.ToString().Trim();
            string filePath = Path.Combine(documentsFolder, luaChon + ".pdf");
            MessageBox.Show(a.inDanhSach(luaChon, filePath));
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



        private void QuanLyKho_Resize(object sender, EventArgs e)
        {
            AdjustLayout();
        }

        private void AdjustLayout()
        {
            int formHeight = this.ClientSize.Height;
            int formWidth = this.ClientSize.Width;
            int pnTieuDeQuanLyKhoHeight = formHeight / 11;
            int gbThaoTacQLKHeight = 3 * formHeight / 22;
            int gbCongCuHeight = 3 * formHeight / 22;
            int dgvDanhSachHeight = 7 * formHeight / 11;

            // Khoảng cách giữa lề phải của các group box và form
            int rightMargin = 10;

            // Thiết lập chiều cao cho các thành phần
            pnTieuDeQuanLyKho.Height = pnTieuDeQuanLyKhoHeight;
            gbThaoTacQLK.Top = pnTieuDeQuanLyKho.Bottom;
            gbThaoTacQLK.Height = gbThaoTacQLKHeight;

            // Điều chỉnh chiều rộng và vị trí của gbThaoTacQLK
            gbThaoTacQLK.Width = formWidth - rightMargin;
            gbThaoTacQLK.Left = (formWidth - gbThaoTacQLK.Width) / 2;

            // Thiết lập vị trí và kích thước cho gbCongCu
            gbCongCu.Top = gbThaoTacQLK.Bottom;
            gbCongCu.Height = gbCongCuHeight;
            gbCongCu.Width = formWidth - rightMargin;
            gbCongCu.Left = (formWidth - gbCongCu.Width) / 2;

            // Thiết lập vị trí và kích thước cho dgvDanhSach
            dgvDanhSach.Top = gbCongCu.Bottom;
            dgvDanhSach.Height = dgvDanhSachHeight;
            dgvDanhSach.Width = formWidth - rightMargin;
            dgvDanhSach.Left = (formWidth - dgvDanhSach.Width) / 2;

            // Căn giữa txtTieuDeQuanLyKho trong pnTieuDeQuanLyKho
            txtTieuDeQuanLyKho.Left = (formWidth - txtTieuDeQuanLyKho.Width) / 2;
            txtTieuDeQuanLyKho.Top = (pnTieuDeQuanLyKho.Height - txtTieuDeQuanLyKho.Height) / 2;

            // Đặt vị trí Top của các điều khiển trong gbThaoTacQLK để căn giữa theo chiều dọc
            txtThongTinKho.Top = (gbThaoTacQLK.Height - txtThongTinKho.Height) / 2;
            cbKho.Top = (gbThaoTacQLK.Height - cbKho.Height) / 2;
            txtDanhSach.Top = (gbThaoTacQLK.Height - txtDanhSach.Height) / 2;
            cbDanhSach.Top = (gbThaoTacQLK.Height - cbDanhSach.Height) / 2;
            btnXem.Top = (gbThaoTacQLK.Height - btnXem.Height) / 2;

            // Đặt vị trí Top của các điều khiển trong gbCongCu để căn giữa theo chiều dọc
            boxTimKiem.Top = (gbCongCu.Height - boxTimKiem.Height) / 2;
            btnTimKiem.Top = (gbCongCu.Height - btnTimKiem.Height) / 2;
            btnThem.Top = (gbCongCu.Height - btnThem.Height) / 2;
            btnXoa.Top = (gbCongCu.Height - btnXoa.Height) / 2;
            btnSua.Top = (gbCongCu.Height - btnSua.Height) / 2;
            btnLuu.Top = (gbCongCu.Height - btnLuu.Height) / 2;
            btnIn.Top = (gbCongCu.Height - btnIn.Height) / 2;

            int gbThaoTacQLKWidth = gbThaoTacQLK.Width;
            int lbDanhSachWidth = txtDanhSach.Width;
            int centerGroupBox = (gbThaoTacQLKWidth - lbDanhSachWidth) / 2;
            int btnXemWidth = btnXem.Width;
            int spacing = 10;

            // Căn chỉnh vị trí ngang của lbDanhSach và các control khác trong gbThaoTacQLK
            txtDanhSach.Left = centerGroupBox;
            cbKho.Width = txtDanhSach.Left - cbKho.Left - spacing;
            cbDanhSach.Left = txtDanhSach.Right + spacing;
            btnXem.Left = gbThaoTacQLK.Width - btnXemWidth - spacing;
            cbDanhSach.Width = btnXem.Left - cbDanhSach.Left - spacing;
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gbThaoTacQLK_Enter(object sender, EventArgs e)
        {

        }

        private void pnTieuDeQuanLyKho_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gbCongCu_Enter(object sender, EventArgs e)
        {

        }


        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //// Kiểm tra nếu ô được nhấn nằm trong dữ liệu (không phải tiêu đề)
            //if (kiemTraNutSua == false)
            //{
            //    if (e.RowIndex >= 0)
            //    {
            //        btnXoa.Enabled = true; // Kích hoạt lại nút
            //        btnSua.Enabled = true;  // Kích hoạt lại nút
            //        cbDanhSach.Enabled = false;// Vô hiệu hóa nút danh sách
            //        cbKho.Enabled = false;

            //    }
            //    else
            //    {
            //        btnXoa.Enabled = false; // Vô hiệu hóa nút
            //        btnSua.Enabled = false;
            //        btnLuu.Enabled = false;
            //    }
            //}    

        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            string luaChon = cbDanhSach.SelectedItem.ToString();
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnIn.Enabled = true;

            btnXem.Enabled = true;
            dgvDanhSach.ReadOnly = true;
            cbDanhSach.Enabled = true;
            cbKho.Enabled = true;

            DataTable dt = new DataTable();

            // Thêm các cột vào DataTable từ DataGridView
            foreach (DataGridViewColumn column in dgvDanhSach.Columns)
            {
                dt.Columns.Add(column.Name); // Dùng tên cột làm tên cột trong DataTable
            }

            foreach (DataGridViewRow row in dgvDanhSach.Rows)
            {
                if (!row.IsNewRow && row != null) // Không lấy dòng mới và dòng trống
                {
                    DataRow dataRow = dt.NewRow();
                    for (int i = 0; i < dgvDanhSach.Columns.Count; i++)
                    {
                        dataRow[i] = row.Cells[i].Value; // Lấy giá trị của từng ô
                    }
                    dt.Rows.Add(dataRow); // Thêm dòng vào DataTable
                }
            }

            if (luaChon == "Danh sách kho nội bộ")
            {
                MessageBox.Show(a.capNhatKhoNoiBo(dt));
            }
            else if (luaChon == "Danh sách hàng hóa nội bộ")
            {
                MessageBox.Show(a.capNhatHangHoaNoiBo(dt));

            }
            else if (luaChon == "Danh sách thùng")
            {
                MessageBox.Show(a.capNhatThung(dt));

            }

            //else if (luaChon == "Danh sách kho cho thuê")
            //{
            //    MessageBox.Show(a.capNhatKhoChoThue(dt));
            //}
            //else if (luaChon == "Danh sách kệ cho thuê")
            //{
            //    MessageBox.Show(a.capNhatKeChoThue(dt));
            //}
            //else if (luaChon == "Danh sách tầng")
            //{
            //    MessageBox.Show(a.capNhatTang(dt));
            //}
            //else if (luaChon == "Danh sách ngăn")
            //{
            //    MessageBox.Show(a.capNhatNgan(dt));
            //}

           
                //foreach (DataColumn column in dt.Columns)
                //{
                //    Console.WriteLine($"Cột: {column.ColumnName}, Loại dữ liệu: {column.DataType}");
                //}
            
            LoadDataForSelectedList();

        }

        private void btnLuu_Enter(object sender, EventArgs e)
        {
            btnLuu.ColorBackground = Color.FromArgb(250, 150, 77);
        }

        private void btnLuu_Leave(object sender, EventArgs e)
        {
            btnLuu.ColorBackground = Color.White;
        }

        private void btnLuu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLuu_Click(sender, e);
            }
        }

        private void KiemTraHetHan()
        {
            List<string> maYC = a.KiemTraHetHan();

            foreach (DataGridViewRow row in dgvDanhSach.Rows)
            {
                // Lấy giá trị của cột "Mã Yêu Cầu" (giả định tên cột là "MaYC")
                string maYeuCau = row.Cells["Mã thùng"].Value?.ToString();

                // Kiểm tra nếu giá trị trùng với danh sách maYC
                if (maYC.Contains(maYeuCau))
                {
                    // Tô đỏ toàn bộ dòng
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    // Nếu không trùng, trả về màu mặc định (nếu cần)
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void KiemTraSoluong()
        {
            List<string> maYC = a.KiemTraSoluong();

            foreach (DataGridViewRow row in dgvDanhSach.Rows)
            {
                // Lấy giá trị của cột "Mã Yêu Cầu" (giả định tên cột là "MaYC")
                string maHH = row.Cells["Mã hàng hóa"].Value?.ToString();

                // Kiểm tra nếu giá trị trùng với danh sách maYC
                if (maYC.Contains(maHH))
                {
                    // Tô đỏ toàn bộ dòng
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    // Nếu không trùng, trả về màu mặc định (nếu cần)
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }




        private void cbDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataForSelectedList();
        }

        private void QuanLyKho_Activated(object sender, EventArgs e)
        {
            LoadDataForSelectedList();
        }

        private void gbCongCu_Enter_1(object sender, EventArgs e)
        {

        }


    }
}