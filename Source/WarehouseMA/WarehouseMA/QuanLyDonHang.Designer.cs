using System.Windows.Forms;

namespace WarehouseMA
{
    partial class QuanLyDonHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbDanhSachDonHang = new System.Windows.Forms.GroupBox();
            this.boxTimKiem = new ReaLTaiizor.Controls.DungeonTextBox();
            this.btnLamMoi = new ReaLTaiizor.Controls.CyberButton();
            this.btnIn = new ReaLTaiizor.Controls.CyberButton();
            this.btnTimKiem = new ReaLTaiizor.Controls.CyberButton();
            this.dgvYeuCauXuatHang = new System.Windows.Forms.DataGridView();
            this.gbYeuCauXuatHang = new System.Windows.Forms.GroupBox();
            this.txtTieuDeQuanLyDonHang = new System.Windows.Forms.Label();
            this.pnTieuDeQuanLyDonHang = new System.Windows.Forms.Panel();
            this.dgvDanhSachDonHang = new System.Windows.Forms.DataGridView();
            this.gbDanhSachDonHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYeuCauXuatHang)).BeginInit();
            this.gbYeuCauXuatHang.SuspendLayout();
            this.pnTieuDeQuanLyDonHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachDonHang)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDanhSachDonHang
            // 
            this.gbDanhSachDonHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDanhSachDonHang.Controls.Add(this.dgvDanhSachDonHang);
            this.gbDanhSachDonHang.Controls.Add(this.boxTimKiem);
            this.gbDanhSachDonHang.Controls.Add(this.btnLamMoi);
            this.gbDanhSachDonHang.Controls.Add(this.btnIn);
            this.gbDanhSachDonHang.Controls.Add(this.btnTimKiem);
            this.gbDanhSachDonHang.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDanhSachDonHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(66)))));
            this.gbDanhSachDonHang.Location = new System.Drawing.Point(0, 294);
            this.gbDanhSachDonHang.Name = "gbDanhSachDonHang";
            this.gbDanhSachDonHang.Size = new System.Drawing.Size(887, 292);
            this.gbDanhSachDonHang.TabIndex = 2;
            this.gbDanhSachDonHang.TabStop = false;
            this.gbDanhSachDonHang.Text = "Danh sách đơn hàng";
            // 
            // boxTimKiem
            // 
            this.boxTimKiem.BackColor = System.Drawing.Color.Transparent;
            this.boxTimKiem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.boxTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.boxTimKiem.EdgeColor = System.Drawing.Color.White;
            this.boxTimKiem.Font = new System.Drawing.Font("Tahoma", 11F);
            this.boxTimKiem.ForeColor = System.Drawing.Color.DimGray;
            this.boxTimKiem.Location = new System.Drawing.Point(32, 43);
            this.boxTimKiem.MaxLength = 32767;
            this.boxTimKiem.Multiline = false;
            this.boxTimKiem.Name = "boxTimKiem";
            this.boxTimKiem.ReadOnly = false;
            this.boxTimKiem.Size = new System.Drawing.Size(315, 28);
            this.boxTimKiem.TabIndex = 0;
            this.boxTimKiem.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.boxTimKiem.UseSystemPasswordChar = false;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Alpha = 20;
            this.btnLamMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLamMoi.BackColor = System.Drawing.Color.Transparent;
            this.btnLamMoi.Background = true;
            this.btnLamMoi.Background_WidthPen = 3F;
            this.btnLamMoi.BackgroundPen = true;
            this.btnLamMoi.ColorBackground = System.Drawing.Color.White;
            this.btnLamMoi.ColorBackground_1 = System.Drawing.Color.White;
            this.btnLamMoi.ColorBackground_2 = System.Drawing.Color.White;
            this.btnLamMoi.ColorBackground_Pen = System.Drawing.Color.Black;
            this.btnLamMoi.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnLamMoi.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnLamMoi.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnLamMoi.Effect_1 = true;
            this.btnLamMoi.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnLamMoi.Effect_1_Transparency = 25;
            this.btnLamMoi.Effect_2 = true;
            this.btnLamMoi.Effect_2_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(57)))));
            this.btnLamMoi.Effect_2_Transparency = 125;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.Color.Black;
            this.btnLamMoi.Lighting = false;
            this.btnLamMoi.LinearGradient_Background = false;
            this.btnLamMoi.LinearGradientPen = false;
            this.btnLamMoi.Location = new System.Drawing.Point(697, 44);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.PenWidth = 15;
            this.btnLamMoi.Rounding = true;
            this.btnLamMoi.RoundingInt = 70;
            this.btnLamMoi.Size = new System.Drawing.Size(89, 30);
            this.btnLamMoi.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnLamMoi.TabIndex = 2;
            this.btnLamMoi.Tag = "Cyber";
            this.btnLamMoi.TextButton = "Làm mới";
            this.btnLamMoi.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnLamMoi.Timer_Effect_1 = 5;
            this.btnLamMoi.Timer_RGB = 300;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            this.btnLamMoi.Enter += new System.EventHandler(this.btnLamMoi_Enter);
            this.btnLamMoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnLamMoi_KeyDown);
            this.btnLamMoi.Leave += new System.EventHandler(this.btnLamMoi_Leave);
            // 
            // btnIn
            // 
            this.btnIn.Alpha = 20;
            this.btnIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIn.BackColor = System.Drawing.Color.Transparent;
            this.btnIn.Background = true;
            this.btnIn.Background_WidthPen = 3F;
            this.btnIn.BackgroundPen = true;
            this.btnIn.ColorBackground = System.Drawing.Color.White;
            this.btnIn.ColorBackground_1 = System.Drawing.Color.White;
            this.btnIn.ColorBackground_2 = System.Drawing.Color.White;
            this.btnIn.ColorBackground_Pen = System.Drawing.Color.Black;
            this.btnIn.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnIn.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnIn.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIn.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnIn.Effect_1 = true;
            this.btnIn.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnIn.Effect_1_Transparency = 25;
            this.btnIn.Effect_2 = true;
            this.btnIn.Effect_2_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(57)))));
            this.btnIn.Effect_2_Transparency = 125;
            this.btnIn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.ForeColor = System.Drawing.Color.Black;
            this.btnIn.Lighting = false;
            this.btnIn.LinearGradient_Background = false;
            this.btnIn.LinearGradientPen = false;
            this.btnIn.Location = new System.Drawing.Point(793, 44);
            this.btnIn.Name = "btnIn";
            this.btnIn.PenWidth = 15;
            this.btnIn.Rounding = true;
            this.btnIn.RoundingInt = 70;
            this.btnIn.Size = new System.Drawing.Size(63, 30);
            this.btnIn.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnIn.TabIndex = 3;
            this.btnIn.Tag = "Cyber";
            this.btnIn.TextButton = "In";
            this.btnIn.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnIn.Timer_Effect_1 = 5;
            this.btnIn.Timer_RGB = 300;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            this.btnIn.Enter += new System.EventHandler(this.btnIn_Enter);
            this.btnIn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnIn_KeyDown);
            this.btnIn.Leave += new System.EventHandler(this.btnIn_Leave);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Alpha = 20;
            this.btnTimKiem.BackColor = System.Drawing.Color.Transparent;
            this.btnTimKiem.Background = true;
            this.btnTimKiem.Background_WidthPen = 3F;
            this.btnTimKiem.BackgroundPen = true;
            this.btnTimKiem.ColorBackground = System.Drawing.Color.White;
            this.btnTimKiem.ColorBackground_1 = System.Drawing.Color.White;
            this.btnTimKiem.ColorBackground_2 = System.Drawing.Color.White;
            this.btnTimKiem.ColorBackground_Pen = System.Drawing.Color.Black;
            this.btnTimKiem.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnTimKiem.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnTimKiem.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnTimKiem.Effect_1 = true;
            this.btnTimKiem.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnTimKiem.Effect_1_Transparency = 25;
            this.btnTimKiem.Effect_2 = true;
            this.btnTimKiem.Effect_2_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(57)))));
            this.btnTimKiem.Effect_2_Transparency = 125;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.Black;
            this.btnTimKiem.Lighting = false;
            this.btnTimKiem.LinearGradient_Background = false;
            this.btnTimKiem.LinearGradientPen = false;
            this.btnTimKiem.Location = new System.Drawing.Point(353, 41);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.PenWidth = 15;
            this.btnTimKiem.Rounding = true;
            this.btnTimKiem.RoundingInt = 70;
            this.btnTimKiem.Size = new System.Drawing.Size(93, 30);
            this.btnTimKiem.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnTimKiem.TabIndex = 1;
            this.btnTimKiem.Tag = "Cyber";
            this.btnTimKiem.TextButton = "Tìm kiếm";
            this.btnTimKiem.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnTimKiem.Timer_Effect_1 = 5;
            this.btnTimKiem.Timer_RGB = 300;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            this.btnTimKiem.Enter += new System.EventHandler(this.btnTimKiem_Enter);
            this.btnTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnTimKiem_KeyDown);
            this.btnTimKiem.Leave += new System.EventHandler(this.btnTimKiem_Leave);
            // 
            // dgvYeuCauXuatHang
            // 
            this.dgvYeuCauXuatHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvYeuCauXuatHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvYeuCauXuatHang.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvYeuCauXuatHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvYeuCauXuatHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvYeuCauXuatHang.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvYeuCauXuatHang.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvYeuCauXuatHang.Location = new System.Drawing.Point(9, 42);
            this.dgvYeuCauXuatHang.Margin = new System.Windows.Forms.Padding(2);
            this.dgvYeuCauXuatHang.Name = "dgvYeuCauXuatHang";
            this.dgvYeuCauXuatHang.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvYeuCauXuatHang.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvYeuCauXuatHang.RowHeadersWidth = 51;
            this.dgvYeuCauXuatHang.RowTemplate.Height = 30;
            this.dgvYeuCauXuatHang.Size = new System.Drawing.Size(872, 195);
            this.dgvYeuCauXuatHang.TabIndex = 0;
            this.dgvYeuCauXuatHang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvYeuCauXuatHang_CellContentClick);
            // 
            // gbYeuCauXuatHang
            // 
            this.gbYeuCauXuatHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbYeuCauXuatHang.Controls.Add(this.dgvYeuCauXuatHang);
            this.gbYeuCauXuatHang.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbYeuCauXuatHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(66)))));
            this.gbYeuCauXuatHang.Location = new System.Drawing.Point(0, 46);
            this.gbYeuCauXuatHang.Name = "gbYeuCauXuatHang";
            this.gbYeuCauXuatHang.Size = new System.Drawing.Size(887, 242);
            this.gbYeuCauXuatHang.TabIndex = 1;
            this.gbYeuCauXuatHang.TabStop = false;
            this.gbYeuCauXuatHang.Text = "Yêu cầu xuất hàng";
            // 
            // txtTieuDeQuanLyDonHang
            // 
            this.txtTieuDeQuanLyDonHang.AutoSize = true;
            this.txtTieuDeQuanLyDonHang.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTieuDeQuanLyDonHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(66)))));
            this.txtTieuDeQuanLyDonHang.Location = new System.Drawing.Point(307, 6);
            this.txtTieuDeQuanLyDonHang.Name = "txtTieuDeQuanLyDonHang";
            this.txtTieuDeQuanLyDonHang.Size = new System.Drawing.Size(289, 37);
            this.txtTieuDeQuanLyDonHang.TabIndex = 0;
            this.txtTieuDeQuanLyDonHang.Text = "QUẢN LÝ ĐƠN HÀNG";
            this.txtTieuDeQuanLyDonHang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnTieuDeQuanLyDonHang
            // 
            this.pnTieuDeQuanLyDonHang.Controls.Add(this.txtTieuDeQuanLyDonHang);
            this.pnTieuDeQuanLyDonHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTieuDeQuanLyDonHang.Location = new System.Drawing.Point(0, 0);
            this.pnTieuDeQuanLyDonHang.Name = "pnTieuDeQuanLyDonHang";
            this.pnTieuDeQuanLyDonHang.Size = new System.Drawing.Size(887, 48);
            this.pnTieuDeQuanLyDonHang.TabIndex = 0;
            // 
            // dgvDanhSachDonHang
            // 
            this.dgvDanhSachDonHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDanhSachDonHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSachDonHang.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSachDonHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDanhSachDonHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachDonHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvDanhSachDonHang.Location = new System.Drawing.Point(10, 92);
            this.dgvDanhSachDonHang.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDanhSachDonHang.Name = "dgvDanhSachDonHang";
            this.dgvDanhSachDonHang.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSachDonHang.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDanhSachDonHang.RowHeadersWidth = 51;
            this.dgvDanhSachDonHang.RowTemplate.Height = 30;
            this.dgvDanhSachDonHang.Size = new System.Drawing.Size(872, 195);
            this.dgvDanhSachDonHang.TabIndex = 4;
            this.dgvDanhSachDonHang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSachDonHang_CellClick);
            // 
            // QuanLyDonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(229)))), ((int)(((byte)(184)))));
            this.ClientSize = new System.Drawing.Size(887, 586);
            this.Controls.Add(this.gbDanhSachDonHang);
            this.Controls.Add(this.gbYeuCauXuatHang);
            this.Controls.Add(this.pnTieuDeQuanLyDonHang);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "QuanLyDonHang";
            this.Text = "QuanLyDonHang";
            this.Load += new System.EventHandler(this.QuanLyDonHang_Load);
            this.Resize += new System.EventHandler(this.QuanLyDonHang_Resize);
            this.gbDanhSachDonHang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvYeuCauXuatHang)).EndInit();
            this.gbYeuCauXuatHang.ResumeLayout(false);
            this.pnTieuDeQuanLyDonHang.ResumeLayout(false);
            this.pnTieuDeQuanLyDonHang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachDonHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDanhSachDonHang;
        private ReaLTaiizor.Controls.DungeonTextBox boxTimKiem;
        private ReaLTaiizor.Controls.CyberButton btnLamMoi;
        private ReaLTaiizor.Controls.CyberButton btnIn;
        private ReaLTaiizor.Controls.CyberButton btnTimKiem;
        private System.Windows.Forms.DataGridView dgvYeuCauXuatHang;
        private System.Windows.Forms.GroupBox gbYeuCauXuatHang;
        private System.Windows.Forms.Label txtTieuDeQuanLyDonHang;
        private System.Windows.Forms.Panel pnTieuDeQuanLyDonHang;
        private DataGridView dgvDanhSachDonHang;
    }
}
