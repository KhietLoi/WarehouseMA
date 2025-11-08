
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using System.IO;


namespace WarehouseMA
{
    public partial class QuanLyKiemKe : Form
    {
        QuanLyKiemKeBLL a = new QuanLyKiemKeBLL();
        public QuanLyKiemKe()
        {
            InitializeComponent();
        }


        private async void QuanLyKiemKe_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.Dock = DockStyle.Fill;
            AdjustLayout();
            
            await LoadDuLieuKiemKeNoiBo();
            await LoadDuLieuKiemKeChoThue();
            dgvDanhSachKiemKeNoiBo.ReadOnly = true;
            dgvDanhSachKiemKeChoThue.ReadOnly = true;
            dgvDanhSachKiemKeNoiBo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachKiemKeChoThue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void QuanLyKiemKe_Resize(object sender, EventArgs e)
        {
            AdjustLayout();
        }

        private void AdjustLayout()
        {
            int formHeight = this.ClientSize.Height;
            int panelHeight = formHeight / 11;
            int gbKiemKeChoThueHeight = 5 * formHeight / 11;
            int gbKiemKeNoiBoHeight = 5 * formHeight / 11;
            pnTieuDeQuanLyKiemKe.Height = panelHeight;
            gbKiemKeChoThue.Top = pnTieuDeQuanLyKiemKe.Bottom;
            gbKiemKeChoThue.Height = gbKiemKeChoThueHeight;
            gbKiemKeChoThue.Width = this.ClientSize.Width;
            gbKiemKeNoiBo.Top = gbKiemKeChoThue.Bottom;
            gbKiemKeNoiBo.Height = gbKiemKeNoiBoHeight;
            gbKiemKeNoiBo.Width = this.ClientSize.Width;
            txtTieuDeQuanLyKiemKe.Left = (this.ClientSize.Width - txtTieuDeQuanLyKiemKe.Width) / 2;
            txtTieuDeQuanLyKiemKe.Top = (pnTieuDeQuanLyKiemKe.Height - txtTieuDeQuanLyKiemKe.Height) / 2;
        }

        private void btnInChoThue_Click(object sender, EventArgs e)
        {
            string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(documentsFolder, "Kiểm kê cho thuê" + ".pdf");


            DataTable dt = new DataTable();
            foreach (DataGridViewColumn column in dgvDanhSachKiemKeChoThue.Columns)
            {
                dt.Columns.Add(column.HeaderText); // Tên cột của DataGridView
            }

            // Duyệt qua các dòng trong DataGridView và thêm vào DataTable
            foreach (DataGridViewRow row in dgvDanhSachKiemKeChoThue.Rows)
            {
                if (!row.IsNewRow) // Bỏ qua hàng mới (dòng trống)
                {
                    DataRow dataRow = dt.NewRow();
                    for (int i = 0; i < dgvDanhSachKiemKeChoThue.Columns.Count; i++)
                    {
                        dataRow[i] = row.Cells[i].Value; // Lấy giá trị từ các ô trong hàng
                    }
                    dt.Rows.Add(dataRow); // Thêm dòng vào DataTable
                }
            }

            MessageBox.Show(a.inDanhSachChoThue(filePath, dt));
        }

        private void btnInChoThue_Enter(object sender, EventArgs e)
        {
            btnInChoThue.ColorBackground = Color.FromArgb(250, 150, 77);
        }

        private void btnInChoThue_Leave(object sender, EventArgs e)
        {
            btnInChoThue.ColorBackground = Color.White;
        }

        private void btnInChoThue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnInChoThue_Click(sender, e);
            }
        }

        private void btnInNoiBo_Click(object sender, EventArgs e)
        {
            string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(documentsFolder, "Kiểm kê nội bộ" + ".pdf");

            DataTable dt = new DataTable();
            foreach (DataGridViewColumn column in dgvDanhSachKiemKeNoiBo.Columns)
            {
                dt.Columns.Add(column.HeaderText); // Tên cột của DataGridView
            }

            // Duyệt qua các dòng trong DataGridView và thêm vào DataTable
            foreach (DataGridViewRow row in dgvDanhSachKiemKeNoiBo.Rows)
            {
                if (!row.IsNewRow) // Bỏ qua hàng mới (dòng trống)
                {
                    DataRow dataRow = dt.NewRow();
                    for (int i = 0; i < dgvDanhSachKiemKeNoiBo.Columns.Count; i++)
                    {
                        dataRow[i] = row.Cells[i].Value; // Lấy giá trị từ các ô trong hàng
                    }
                    dt.Rows.Add(dataRow); // Thêm dòng vào DataTable
                }
            }
            MessageBox.Show(a.inDanhSachNoiBo(filePath, dt));
        }

        private void btnInNoiBo_Enter(object sender, EventArgs e)
        {
            btnInNoiBo.ColorBackground = Color.FromArgb(250, 150, 77);
        }

        private void btnInNoiBo_Leave(object sender, EventArgs e)
        {
            btnInNoiBo.ColorBackground = Color.White;
        }

        private void btnInNoiBo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnInNoiBo_Click(sender, e);
            }
        }

        private void btnTimKiemChoThue_Click(object sender, EventArgs e)
        {
            //            dgvDanhSachKiemKeChoThue.ClearSelection();

            //            string searchText = boxTimKiemChoThue.Text.Trim(); // Lấy nội dung từ TextBox
            //            if (string.IsNullOrWhiteSpace(searchText))
            //            {
            //                MessageBox.Show("Vui lòng nhập từ khóa cần tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                return;
            //            }

            //            bool isFound = false; // Để kiểm tra xem có tìm thấy không

            //            // Duyệt qua tất cả các hàng trong DataGridView
            //            foreach (DataGridViewRow row in dgvDanhSachKiemKeChoThue.Rows)
            //            {
            //                foreach (DataGridViewCell cell in row.Cells)
            //                {
            //                    if (cell.Value != null && cell.Value.ToString().ToLower().Contains(searchText.ToLower())
            //)
            //                    {
            //                        // Chọn hàng nếu tìm thấy
            //                        row.Selected = true;
            //                        dgvDanhSachKiemKeChoThue.FirstDisplayedScrollingRowIndex = row.Index; // Cuộn tới hàng được chọn
            //                        isFound = true;
            //                        break; // Thoát khỏi vòng lặp nếu tìm thấy
            //                    }
            //                }

            //                if (isFound) break;
            //            }

            //            if (!isFound)
            //            {
            //                MessageBox.Show("Không tìm thấy nội dung phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            DataTable dt = a.LayDuLieuKiemKeChoThue();   // lấy từ database ra để lên dgv

            var sortedData = dt.AsEnumerable()
    .OrderBy(row => row.Field<DateTime>("Ngày kiểm kê"))
    .ThenBy(row => row.Field<string>("Mã ngăn"))
    .CopyToDataTable();

            dgvDanhSachKiemKeChoThue.DataSource = sortedData;

            string keyword = boxTimKiemChoThue.Text.Trim().ToLower();




            // Kiểm tra nếu DataGridView có dữ liệu
            if (dgvDanhSachKiemKeChoThue.DataSource is DataTable originalTable)
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


                dgvDanhSachKiemKeChoThue.DataSource = filteredTable;
                // Gán bảng đã lọc cho DataGridView
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnTimKiemChoThue_Enter(object sender, EventArgs e)
        {
            btnTimKiemChoThue.ColorBackground = Color.FromArgb(250, 150, 77);
        }

        private void btnTimKiemChoThue_Leave(object sender, EventArgs e)
        {
            btnTimKiemChoThue.ColorBackground = Color.White;
        }

        private void btnTimKiemChoThue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiemChoThue_Click(sender, e);
            }
        }

        private void btnTimKiemNoiBo_Click(object sender, EventArgs e)
        {
            //            dgvDanhSachKiemKeNoiBo.ClearSelection();

            //            string searchText = boxTimKiemNoiBo.Text.Trim(); // Lấy nội dung từ TextBox
            //            if (string.IsNullOrWhiteSpace(searchText))
            //            {
            //                MessageBox.Show("Vui lòng nhập từ khóa cần tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                return;
            //            }

            //            bool isFound = false; // Để kiểm tra xem có tìm thấy không

            //            // Duyệt qua tất cả các hàng trong DataGridView
            //            foreach (DataGridViewRow row in dgvDanhSachKiemKeNoiBo.Rows)
            //            {
            //                foreach (DataGridViewCell cell in row.Cells)
            //                {
            //                    if (cell.Value != null && cell.Value.ToString().ToLower().Contains(searchText.ToLower())
            //)
            //                    {
            //                        // Chọn hàng nếu tìm thấy
            //                        row.Selected = true;
            //                        dgvDanhSachKiemKeNoiBo.FirstDisplayedScrollingRowIndex = row.Index; // Cuộn tới hàng được chọn
            //                        isFound = true;
            //                        break; // Thoát khỏi vòng lặp nếu tìm thấy
            //                    }
            //                }

            //                if (isFound) break;
            //            }

            //            if (!isFound)
            //            {
            //                MessageBox.Show("Không tìm thấy nội dung phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            DataTable dt = a.LayDuLieuKiemKeNoiBo();   // lấy từ database ra để lên dgv

            var sortedData = dt.AsEnumerable()
    .OrderBy(row => row.Field<DateTime>("Ngày kiểm kê"))
    .ThenBy(row => row.Field<string>("Mã hàng hóa"))
    .CopyToDataTable();

            dgvDanhSachKiemKeNoiBo.DataSource = sortedData;

            string keyword = boxTimKiemNoiBo.Text.Trim().ToLower();




            // Kiểm tra nếu DataGridView có dữ liệu
            if (dgvDanhSachKiemKeNoiBo.DataSource is DataTable originalTable)
            {
                DataTable filteredTable = originalTable.Clone(); // Tạo một DataTable mới với cấu trúc giống bảng gốc

                foreach (DataRow row in originalTable.Rows)
                {
                    string rowContent = string.Join(" ", row.ItemArray).ToLower();
                    Console.WriteLine(rowContent);// Ghép giá trị của các cột thành chuỗi
                    if (rowContent.Contains(keyword)) // Kiểm tra từ khóa
                    {
                        filteredTable.ImportRow(row); // Thêm dòng khớp vào bảng mới
                    }
                }

                if (filteredTable.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                dgvDanhSachKiemKeNoiBo.DataSource = filteredTable;
                // Gán bảng đã lọc cho DataGridView
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTimKiemNoiBo_Enter(object sender, EventArgs e)
        {
            btnTimKiemNoiBo.ColorBackground = Color.FromArgb(250, 150, 77);
        }

        private void btnTimKiemNoiBo_Leave(object sender, EventArgs e)
        {
            btnTimKiemNoiBo.ColorBackground = Color.White;
        }

        private void btnTimKiemNoiBo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiemNoiBo_Click(sender, e);
            }
        }

        private async Task LoadDuLieuKiemKeNoiBo()
        {
            
            await a.LayDuLieuSheetNoiBo();
            DataTable dt = a.LayDuLieuKiemKeNoiBo();
            var sortedData = dt.AsEnumerable()
    .OrderBy(row => row.Field<DateTime>("Ngày kiểm kê"))
    .ThenBy(row => row.Field<string>("Mã hàng hóa"))
    .CopyToDataTable();

            dgvDanhSachKiemKeNoiBo.DataSource= sortedData;

            //dgvDanhSachKiemKeNoiBo.Sort(dgvDanhSachKiemKeNoiBo.Columns["Ngày kiểm kê"], ListSortDirection.Ascending);

            //DataTable dt_1 = new DataTable();

            //// Thêm các cột vào DataTable từ DataGridView
            //foreach (DataGridViewColumn column in dgvDanhSachKiemKeNoiBo.Columns)
            //{
            //    dt_1.Columns.Add(column.Name); // Dùng tên cột làm tên cột trong DataTable
            //}


            //foreach (DataGridViewRow row in dgvDanhSachKiemKeNoiBo.Rows)
            //{
            //    if (!row.IsNewRow) // Không lấy dòng mới
            //    {
            //        DataRow dataRow = dt_1.NewRow();
            //        for (int i = 0; i < dgvDanhSachKiemKeNoiBo.Columns.Count; i++)
            //        {
            //            dataRow[i] = row.Cells[i].Value; // Lấy giá trị của từng ô
            //        }
            //        dt_1.Rows.Add(dataRow); // Thêm dòng vào DataTable
            //    }
            //}

            //MessageBox.Show(a.capNhatKiemKeNoiBo(dt_1));

        }

        private async Task LoadDuLieuKiemKeChoThue()
        {

            await a.LayDuLieuSheetChoThue(); // lấy từ sheet nạp vô database
            DataTable dt = a.LayDuLieuKiemKeChoThue();   // lấy từ database ra để lên dgv

            var sortedData = dt.AsEnumerable()
    .OrderBy(row => row.Field<DateTime>("Ngày kiểm kê"))
    .ThenBy(row => row.Field<string>("Mã ngăn"))
    .CopyToDataTable();

            dgvDanhSachKiemKeChoThue.DataSource = sortedData;
            //dgvDanhSachKiemKeChoThue.Sort(dgvDanhSachKiemKeChoThue.Columns["Ngày kiểm kê"], ListSortDirection.Ascending);



        }

        private async void btnLamMoiKiemKeChoThue_Click(object sender, EventArgs e)
        {
            await LoadDuLieuKiemKeChoThue();
        }

        private void btnLamMoiKiemKeChoThue_Enter(object sender, EventArgs e)
        {
            btnLamMoiKiemKeChoThue.ColorBackground = Color.FromArgb(250, 150, 77);
        }

        private void btnLamMoiKiemKeChoThue_Leave(object sender, EventArgs e)
        {
            btnLamMoiKiemKeChoThue.ColorBackground = Color.White;
        }

        private void btnLamMoiKiemKeChoThue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLamMoiKiemKeChoThue_Click(sender, e);
            }
        }

        private  async void btnLamMoiKiemKeNoiBo_Click(object sender, EventArgs e)
        {
             await LoadDuLieuKiemKeNoiBo();
        }

        private void btnLamMoiKiemKeNoiBo_Enter(object sender, EventArgs e)
        {
            btnLamMoiKiemKeNoiBo.ColorBackground = Color.FromArgb(250, 150, 77);
        }

        private void btnLamMoiKiemKeNoiBo_Leave(object sender, EventArgs e)
        {
            btnLamMoiKiemKeNoiBo.ColorBackground = Color.White;
        }

        private void btnLamMoiKiemKeNoiBo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLamMoiKiemKeNoiBo_Click(sender, e);
            }
        }
    }
}
