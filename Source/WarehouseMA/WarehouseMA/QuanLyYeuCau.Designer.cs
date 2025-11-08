using System.Windows.Forms;

namespace WarehouseMA
{
    partial class QuanLyYeuCau
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnIn = new ReaLTaiizor.Controls.CyberButton();
            this.btnXuatPhieuNhap = new ReaLTaiizor.Controls.CyberButton();
            this.gbYeuCauChuaXuLy = new System.Windows.Forms.GroupBox();
            this.btnLamMoi = new ReaLTaiizor.Controls.CyberButton();
            this.boxTimKiemYeuCauChuaXuLy = new ReaLTaiizor.Controls.DungeonTextBox();
            this.dgvYeuCauChuaXuLy = new System.Windows.Forms.DataGridView();
            this.btnDuyet = new ReaLTaiizor.Controls.CyberButton();
            this.btnTimKiemYeuCauChuaXuLy = new ReaLTaiizor.Controls.CyberButton();
            this.cbLoaiDanhSach = new ReaLTaiizor.Controls.DungeonComboBox();
            this.pnTieuDeQuanLyYeuCau = new System.Windows.Forms.Panel();
            this.txtTieuDeQuanLyYeuCau = new System.Windows.Forms.Label();
            this.btnXem = new ReaLTaiizor.Controls.CyberButton();
            this.boxTimKiemYeuCau = new ReaLTaiizor.Controls.DungeonTextBox();
            this.gbDanhSachYeuCau = new System.Windows.Forms.GroupBox();
            this.dgvDanhSachYeuCau = new System.Windows.Forms.DataGridView();
            this.btnTimKiemYeuCau = new ReaLTaiizor.Controls.CyberButton();
            this.gbYeuCauChuaXuLy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYeuCauChuaXuLy)).BeginInit();
            this.pnTieuDeQuanLyYeuCau.SuspendLayout();
            this.gbDanhSachYeuCau.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachYeuCau)).BeginInit();
            this.SuspendLayout();
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
            this.btnIn.Location = new System.Drawing.Point(782, 74);
            this.btnIn.Name = "btnIn";
            this.btnIn.PenWidth = 15;
            this.btnIn.Rounding = true;
            this.btnIn.RoundingInt = 70;
            this.btnIn.Size = new System.Drawing.Size(73, 29);
            this.btnIn.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnIn.TabIndex = 5;
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
            // btnXuatPhieuNhap
            // 
            this.btnXuatPhieuNhap.Alpha = 20;
            this.btnXuatPhieuNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXuatPhieuNhap.BackColor = System.Drawing.Color.Transparent;
            this.btnXuatPhieuNhap.Background = true;
            this.btnXuatPhieuNhap.Background_WidthPen = 3F;
            this.btnXuatPhieuNhap.BackgroundPen = true;
            this.btnXuatPhieuNhap.ColorBackground = System.Drawing.Color.White;
            this.btnXuatPhieuNhap.ColorBackground_1 = System.Drawing.Color.White;
            this.btnXuatPhieuNhap.ColorBackground_2 = System.Drawing.Color.White;
            this.btnXuatPhieuNhap.ColorBackground_Pen = System.Drawing.Color.Black;
            this.btnXuatPhieuNhap.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnXuatPhieuNhap.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnXuatPhieuNhap.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnXuatPhieuNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatPhieuNhap.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnXuatPhieuNhap.Effect_1 = true;
            this.btnXuatPhieuNhap.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnXuatPhieuNhap.Effect_1_Transparency = 25;
            this.btnXuatPhieuNhap.Effect_2 = true;
            this.btnXuatPhieuNhap.Effect_2_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(57)))));
            this.btnXuatPhieuNhap.Effect_2_Transparency = 125;
            this.btnXuatPhieuNhap.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatPhieuNhap.ForeColor = System.Drawing.Color.Black;
            this.btnXuatPhieuNhap.Lighting = false;
            this.btnXuatPhieuNhap.LinearGradient_Background = false;
            this.btnXuatPhieuNhap.LinearGradientPen = false;
            this.btnXuatPhieuNhap.Location = new System.Drawing.Point(633, 74);
            this.btnXuatPhieuNhap.Name = "btnXuatPhieuNhap";
            this.btnXuatPhieuNhap.PenWidth = 15;
            this.btnXuatPhieuNhap.Rounding = true;
            this.btnXuatPhieuNhap.RoundingInt = 70;
            this.btnXuatPhieuNhap.Size = new System.Drawing.Size(143, 29);
            this.btnXuatPhieuNhap.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnXuatPhieuNhap.TabIndex = 4;
            this.btnXuatPhieuNhap.Tag = "Cyber";
            this.btnXuatPhieuNhap.TextButton = "Xuất phiếu nhập";
            this.btnXuatPhieuNhap.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnXuatPhieuNhap.Timer_Effect_1 = 5;
            this.btnXuatPhieuNhap.Timer_RGB = 300;
            this.btnXuatPhieuNhap.Click += new System.EventHandler(this.btnXuatPhieuNhap_Click);
            this.btnXuatPhieuNhap.Enter += new System.EventHandler(this.btnXuatPhieuNhap_Enter);
            this.btnXuatPhieuNhap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnXuatPhieuNhap_KeyDown);
            this.btnXuatPhieuNhap.Leave += new System.EventHandler(this.btnXuatPhieuNhap_Leave);
            // 
            // gbYeuCauChuaXuLy
            // 
            this.gbYeuCauChuaXuLy.Controls.Add(this.btnLamMoi);
            this.gbYeuCauChuaXuLy.Controls.Add(this.boxTimKiemYeuCauChuaXuLy);
            this.gbYeuCauChuaXuLy.Controls.Add(this.dgvYeuCauChuaXuLy);
            this.gbYeuCauChuaXuLy.Controls.Add(this.btnDuyet);
            this.gbYeuCauChuaXuLy.Controls.Add(this.btnTimKiemYeuCauChuaXuLy);
            this.gbYeuCauChuaXuLy.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.gbYeuCauChuaXuLy.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbYeuCauChuaXuLy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(66)))));
            this.gbYeuCauChuaXuLy.Location = new System.Drawing.Point(0, 52);
            this.gbYeuCauChuaXuLy.Name = "gbYeuCauChuaXuLy";
            this.gbYeuCauChuaXuLy.Size = new System.Drawing.Size(887, 268);
            this.gbYeuCauChuaXuLy.TabIndex = 1;
            this.gbYeuCauChuaXuLy.TabStop = false;
            this.gbYeuCauChuaXuLy.Text = "Yêu cầu chưa xử lý";
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
            this.btnLamMoi.Effect_1_ColorBackground = System.Drawing.Color.White;
            this.btnLamMoi.Effect_1_Transparency = 25;
            this.btnLamMoi.Effect_2 = true;
            this.btnLamMoi.Effect_2_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(57)))));
            this.btnLamMoi.Effect_2_Transparency = 125;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.Color.Black;
            this.btnLamMoi.Lighting = false;
            this.btnLamMoi.LinearGradient_Background = false;
            this.btnLamMoi.LinearGradientPen = false;
            this.btnLamMoi.Location = new System.Drawing.Point(674, 30);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.PenWidth = 15;
            this.btnLamMoi.Rounding = true;
            this.btnLamMoi.RoundingInt = 70;
            this.btnLamMoi.Size = new System.Drawing.Size(95, 29);
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
            // boxTimKiemYeuCauChuaXuLy
            // 
            this.boxTimKiemYeuCauChuaXuLy.BackColor = System.Drawing.Color.Transparent;
            this.boxTimKiemYeuCauChuaXuLy.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.boxTimKiemYeuCauChuaXuLy.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.boxTimKiemYeuCauChuaXuLy.EdgeColor = System.Drawing.Color.White;
            this.boxTimKiemYeuCauChuaXuLy.Font = new System.Drawing.Font("Tahoma", 11F);
            this.boxTimKiemYeuCauChuaXuLy.ForeColor = System.Drawing.Color.DimGray;
            this.boxTimKiemYeuCauChuaXuLy.Location = new System.Drawing.Point(25, 32);
            this.boxTimKiemYeuCauChuaXuLy.MaxLength = 32767;
            this.boxTimKiemYeuCauChuaXuLy.Multiline = false;
            this.boxTimKiemYeuCauChuaXuLy.Name = "boxTimKiemYeuCauChuaXuLy";
            this.boxTimKiemYeuCauChuaXuLy.ReadOnly = false;
            this.boxTimKiemYeuCauChuaXuLy.Size = new System.Drawing.Size(315, 28);
            this.boxTimKiemYeuCauChuaXuLy.TabIndex = 0;
            this.boxTimKiemYeuCauChuaXuLy.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.boxTimKiemYeuCauChuaXuLy.UseSystemPasswordChar = false;
            // 
            // dgvYeuCauChuaXuLy
            // 
            this.dgvYeuCauChuaXuLy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvYeuCauChuaXuLy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvYeuCauChuaXuLy.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvYeuCauChuaXuLy.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvYeuCauChuaXuLy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvYeuCauChuaXuLy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvYeuCauChuaXuLy.Location = new System.Drawing.Point(9, 68);
            this.dgvYeuCauChuaXuLy.Margin = new System.Windows.Forms.Padding(2);
            this.dgvYeuCauChuaXuLy.Name = "dgvYeuCauChuaXuLy";
            this.dgvYeuCauChuaXuLy.ReadOnly = true;
            this.dgvYeuCauChuaXuLy.RowHeadersWidth = 51;
            this.dgvYeuCauChuaXuLy.RowTemplate.Height = 30;
            this.dgvYeuCauChuaXuLy.Size = new System.Drawing.Size(872, 195);
            this.dgvYeuCauChuaXuLy.TabIndex = 4;
            this.dgvYeuCauChuaXuLy.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvYeuCauChuaXuLy_CellContentClick);
            // 
            // btnDuyet
            // 
            this.btnDuyet.Alpha = 20;
            this.btnDuyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDuyet.BackColor = System.Drawing.Color.Transparent;
            this.btnDuyet.Background = true;
            this.btnDuyet.Background_WidthPen = 3F;
            this.btnDuyet.BackgroundPen = true;
            this.btnDuyet.ColorBackground = System.Drawing.Color.White;
            this.btnDuyet.ColorBackground_1 = System.Drawing.Color.White;
            this.btnDuyet.ColorBackground_2 = System.Drawing.Color.White;
            this.btnDuyet.ColorBackground_Pen = System.Drawing.Color.Black;
            this.btnDuyet.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnDuyet.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnDuyet.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnDuyet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDuyet.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnDuyet.Effect_1 = true;
            this.btnDuyet.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnDuyet.Effect_1_Transparency = 25;
            this.btnDuyet.Effect_2 = true;
            this.btnDuyet.Effect_2_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(57)))));
            this.btnDuyet.Effect_2_Transparency = 125;
            this.btnDuyet.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDuyet.ForeColor = System.Drawing.Color.Black;
            this.btnDuyet.Lighting = false;
            this.btnDuyet.LinearGradient_Background = false;
            this.btnDuyet.LinearGradientPen = false;
            this.btnDuyet.Location = new System.Drawing.Point(782, 31);
            this.btnDuyet.Name = "btnDuyet";
            this.btnDuyet.PenWidth = 15;
            this.btnDuyet.Rounding = true;
            this.btnDuyet.RoundingInt = 70;
            this.btnDuyet.Size = new System.Drawing.Size(73, 28);
            this.btnDuyet.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnDuyet.TabIndex = 3;
            this.btnDuyet.Tag = "Cyber";
            this.btnDuyet.TextButton = "Duyệt";
            this.btnDuyet.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnDuyet.Timer_Effect_1 = 5;
            this.btnDuyet.Timer_RGB = 300;
            this.btnDuyet.Click += new System.EventHandler(this.btnDuyet_Click);
            this.btnDuyet.Enter += new System.EventHandler(this.btnDuyet_Enter);
            this.btnDuyet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnDuyet_KeyDown);
            this.btnDuyet.Leave += new System.EventHandler(this.btnDuyet_Leave);
            // 
            // btnTimKiemYeuCauChuaXuLy
            // 
            this.btnTimKiemYeuCauChuaXuLy.Alpha = 20;
            this.btnTimKiemYeuCauChuaXuLy.BackColor = System.Drawing.Color.Transparent;
            this.btnTimKiemYeuCauChuaXuLy.Background = true;
            this.btnTimKiemYeuCauChuaXuLy.Background_WidthPen = 3F;
            this.btnTimKiemYeuCauChuaXuLy.BackgroundPen = true;
            this.btnTimKiemYeuCauChuaXuLy.ColorBackground = System.Drawing.Color.White;
            this.btnTimKiemYeuCauChuaXuLy.ColorBackground_1 = System.Drawing.Color.White;
            this.btnTimKiemYeuCauChuaXuLy.ColorBackground_2 = System.Drawing.Color.White;
            this.btnTimKiemYeuCauChuaXuLy.ColorBackground_Pen = System.Drawing.Color.Black;
            this.btnTimKiemYeuCauChuaXuLy.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnTimKiemYeuCauChuaXuLy.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnTimKiemYeuCauChuaXuLy.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnTimKiemYeuCauChuaXuLy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiemYeuCauChuaXuLy.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnTimKiemYeuCauChuaXuLy.Effect_1 = true;
            this.btnTimKiemYeuCauChuaXuLy.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnTimKiemYeuCauChuaXuLy.Effect_1_Transparency = 25;
            this.btnTimKiemYeuCauChuaXuLy.Effect_2 = true;
            this.btnTimKiemYeuCauChuaXuLy.Effect_2_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(57)))));
            this.btnTimKiemYeuCauChuaXuLy.Effect_2_Transparency = 125;
            this.btnTimKiemYeuCauChuaXuLy.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiemYeuCauChuaXuLy.ForeColor = System.Drawing.Color.Black;
            this.btnTimKiemYeuCauChuaXuLy.Lighting = false;
            this.btnTimKiemYeuCauChuaXuLy.LinearGradient_Background = false;
            this.btnTimKiemYeuCauChuaXuLy.LinearGradientPen = false;
            this.btnTimKiemYeuCauChuaXuLy.Location = new System.Drawing.Point(351, 31);
            this.btnTimKiemYeuCauChuaXuLy.Name = "btnTimKiemYeuCauChuaXuLy";
            this.btnTimKiemYeuCauChuaXuLy.PenWidth = 15;
            this.btnTimKiemYeuCauChuaXuLy.Rounding = true;
            this.btnTimKiemYeuCauChuaXuLy.RoundingInt = 70;
            this.btnTimKiemYeuCauChuaXuLy.Size = new System.Drawing.Size(97, 31);
            this.btnTimKiemYeuCauChuaXuLy.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnTimKiemYeuCauChuaXuLy.TabIndex = 1;
            this.btnTimKiemYeuCauChuaXuLy.Tag = "Cyber";
            this.btnTimKiemYeuCauChuaXuLy.TextButton = "Tìm kiếm";
            this.btnTimKiemYeuCauChuaXuLy.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnTimKiemYeuCauChuaXuLy.Timer_Effect_1 = 5;
            this.btnTimKiemYeuCauChuaXuLy.Timer_RGB = 300;
            this.btnTimKiemYeuCauChuaXuLy.Click += new System.EventHandler(this.btnTimKiemYeuCauChuaXuLy_Click);
            this.btnTimKiemYeuCauChuaXuLy.Enter += new System.EventHandler(this.btnTimKiemYeuCauChuaXuLy_Enter);
            this.btnTimKiemYeuCauChuaXuLy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnTimKiemYeuCauChuaXuLy_KeyDown);
            this.btnTimKiemYeuCauChuaXuLy.Leave += new System.EventHandler(this.btnTimKiemYeuCauChuaXuLy_Leave);
            // 
            // cbLoaiDanhSach
            // 
            this.cbLoaiDanhSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.cbLoaiDanhSach.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(132)))), ((int)(((byte)(85)))));
            this.cbLoaiDanhSach.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(57)))));
            this.cbLoaiDanhSach.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(241)))), ((int)(((byte)(240)))));
            this.cbLoaiDanhSach.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.cbLoaiDanhSach.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(237)))), ((int)(((byte)(236)))));
            this.cbLoaiDanhSach.ColorF = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.cbLoaiDanhSach.ColorG = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(118)))));
            this.cbLoaiDanhSach.ColorH = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(222)))), ((int)(((byte)(220)))));
            this.cbLoaiDanhSach.ColorI = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.cbLoaiDanhSach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbLoaiDanhSach.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLoaiDanhSach.DropDownHeight = 100;
            this.cbLoaiDanhSach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoaiDanhSach.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbLoaiDanhSach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(97)))));
            this.cbLoaiDanhSach.FormattingEnabled = true;
            this.cbLoaiDanhSach.HoverSelectionColor = System.Drawing.Color.Empty;
            this.cbLoaiDanhSach.IntegralHeight = false;
            this.cbLoaiDanhSach.ItemHeight = 20;
            this.cbLoaiDanhSach.Location = new System.Drawing.Point(26, 34);
            this.cbLoaiDanhSach.Name = "cbLoaiDanhSach";
            this.cbLoaiDanhSach.Size = new System.Drawing.Size(314, 26);
            this.cbLoaiDanhSach.StartIndex = 0;
            this.cbLoaiDanhSach.TabIndex = 0;
            // 
            // pnTieuDeQuanLyYeuCau
            // 
            this.pnTieuDeQuanLyYeuCau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(229)))), ((int)(((byte)(184)))));
            this.pnTieuDeQuanLyYeuCau.Controls.Add(this.txtTieuDeQuanLyYeuCau);
            this.pnTieuDeQuanLyYeuCau.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTieuDeQuanLyYeuCau.Location = new System.Drawing.Point(0, 0);
            this.pnTieuDeQuanLyYeuCau.Name = "pnTieuDeQuanLyYeuCau";
            this.pnTieuDeQuanLyYeuCau.Size = new System.Drawing.Size(887, 48);
            this.pnTieuDeQuanLyYeuCau.TabIndex = 0;
            // 
            // txtTieuDeQuanLyYeuCau
            // 
            this.txtTieuDeQuanLyYeuCau.AutoSize = true;
            this.txtTieuDeQuanLyYeuCau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtTieuDeQuanLyYeuCau.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTieuDeQuanLyYeuCau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(66)))));
            this.txtTieuDeQuanLyYeuCau.Location = new System.Drawing.Point(307, 6);
            this.txtTieuDeQuanLyYeuCau.Name = "txtTieuDeQuanLyYeuCau";
            this.txtTieuDeQuanLyYeuCau.Size = new System.Drawing.Size(253, 37);
            this.txtTieuDeQuanLyYeuCau.TabIndex = 0;
            this.txtTieuDeQuanLyYeuCau.Text = "QUẢN LÝ YÊU CẦU";
            this.txtTieuDeQuanLyYeuCau.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnXem
            // 
            this.btnXem.Alpha = 20;
            this.btnXem.BackColor = System.Drawing.Color.Transparent;
            this.btnXem.Background = true;
            this.btnXem.Background_WidthPen = 3F;
            this.btnXem.BackgroundPen = true;
            this.btnXem.ColorBackground = System.Drawing.Color.White;
            this.btnXem.ColorBackground_1 = System.Drawing.Color.White;
            this.btnXem.ColorBackground_2 = System.Drawing.Color.White;
            this.btnXem.ColorBackground_Pen = System.Drawing.Color.Black;
            this.btnXem.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnXem.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnXem.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnXem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXem.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnXem.Effect_1 = true;
            this.btnXem.Effect_1_ColorBackground = System.Drawing.Color.White;
            this.btnXem.Effect_1_Transparency = 25;
            this.btnXem.Effect_2 = true;
            this.btnXem.Effect_2_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(57)))));
            this.btnXem.Effect_2_Transparency = 125;
            this.btnXem.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXem.ForeColor = System.Drawing.Color.Black;
            this.btnXem.Lighting = false;
            this.btnXem.LinearGradient_Background = false;
            this.btnXem.LinearGradientPen = false;
            this.btnXem.Location = new System.Drawing.Point(360, 33);
            this.btnXem.Name = "btnXem";
            this.btnXem.PenWidth = 15;
            this.btnXem.Rounding = true;
            this.btnXem.RoundingInt = 70;
            this.btnXem.Size = new System.Drawing.Size(97, 28);
            this.btnXem.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnXem.TabIndex = 1;
            this.btnXem.Tag = "Cyber";
            this.btnXem.TextButton = "Xem";
            this.btnXem.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnXem.Timer_Effect_1 = 5;
            this.btnXem.Timer_RGB = 300;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            this.btnXem.Enter += new System.EventHandler(this.btnXem_Enter);
            this.btnXem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnXem_KeyDown);
            this.btnXem.Leave += new System.EventHandler(this.btnXem_Leave);
            // 
            // boxTimKiemYeuCau
            // 
            this.boxTimKiemYeuCau.BackColor = System.Drawing.Color.Transparent;
            this.boxTimKiemYeuCau.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.boxTimKiemYeuCau.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.boxTimKiemYeuCau.EdgeColor = System.Drawing.Color.White;
            this.boxTimKiemYeuCau.Font = new System.Drawing.Font("Tahoma", 11F);
            this.boxTimKiemYeuCau.ForeColor = System.Drawing.Color.DimGray;
            this.boxTimKiemYeuCau.Location = new System.Drawing.Point(25, 75);
            this.boxTimKiemYeuCau.MaxLength = 32767;
            this.boxTimKiemYeuCau.Multiline = false;
            this.boxTimKiemYeuCau.Name = "boxTimKiemYeuCau";
            this.boxTimKiemYeuCau.ReadOnly = false;
            this.boxTimKiemYeuCau.Size = new System.Drawing.Size(315, 28);
            this.boxTimKiemYeuCau.TabIndex = 2;
            this.boxTimKiemYeuCau.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.boxTimKiemYeuCau.UseSystemPasswordChar = false;
            // 
            // gbDanhSachYeuCau
            // 
            this.gbDanhSachYeuCau.Controls.Add(this.dgvDanhSachYeuCau);
            this.gbDanhSachYeuCau.Controls.Add(this.btnXem);
            this.gbDanhSachYeuCau.Controls.Add(this.boxTimKiemYeuCau);
            this.gbDanhSachYeuCau.Controls.Add(this.cbLoaiDanhSach);
            this.gbDanhSachYeuCau.Controls.Add(this.btnIn);
            this.gbDanhSachYeuCau.Controls.Add(this.btnXuatPhieuNhap);
            this.gbDanhSachYeuCau.Controls.Add(this.btnTimKiemYeuCau);
            this.gbDanhSachYeuCau.Cursor = System.Windows.Forms.Cursors.Default;
            this.gbDanhSachYeuCau.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDanhSachYeuCau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(66)))));
            this.gbDanhSachYeuCau.Location = new System.Drawing.Point(0, 326);
            this.gbDanhSachYeuCau.Name = "gbDanhSachYeuCau";
            this.gbDanhSachYeuCau.Size = new System.Drawing.Size(887, 317);
            this.gbDanhSachYeuCau.TabIndex = 2;
            this.gbDanhSachYeuCau.TabStop = false;
            this.gbDanhSachYeuCau.Text = "Danh sách yêu cầu";
            // 
            // dgvDanhSachYeuCau
            // 
            this.dgvDanhSachYeuCau.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDanhSachYeuCau.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSachYeuCau.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSachYeuCau.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDanhSachYeuCau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachYeuCau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvDanhSachYeuCau.Location = new System.Drawing.Point(9, 117);
            this.dgvDanhSachYeuCau.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDanhSachYeuCau.Name = "dgvDanhSachYeuCau";
            this.dgvDanhSachYeuCau.ReadOnly = true;
            this.dgvDanhSachYeuCau.RowHeadersWidth = 51;
            this.dgvDanhSachYeuCau.RowTemplate.Height = 30;
            this.dgvDanhSachYeuCau.Size = new System.Drawing.Size(872, 195);
            this.dgvDanhSachYeuCau.TabIndex = 6;
            this.dgvDanhSachYeuCau.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSachYeuCau_CellContentClick);
            // 
            // btnTimKiemYeuCau
            // 
            this.btnTimKiemYeuCau.Alpha = 20;
            this.btnTimKiemYeuCau.BackColor = System.Drawing.Color.Transparent;
            this.btnTimKiemYeuCau.Background = true;
            this.btnTimKiemYeuCau.Background_WidthPen = 3F;
            this.btnTimKiemYeuCau.BackgroundPen = true;
            this.btnTimKiemYeuCau.ColorBackground = System.Drawing.Color.White;
            this.btnTimKiemYeuCau.ColorBackground_1 = System.Drawing.Color.White;
            this.btnTimKiemYeuCau.ColorBackground_2 = System.Drawing.Color.White;
            this.btnTimKiemYeuCau.ColorBackground_Pen = System.Drawing.Color.Black;
            this.btnTimKiemYeuCau.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnTimKiemYeuCau.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnTimKiemYeuCau.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnTimKiemYeuCau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiemYeuCau.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnTimKiemYeuCau.Effect_1 = true;
            this.btnTimKiemYeuCau.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnTimKiemYeuCau.Effect_1_Transparency = 25;
            this.btnTimKiemYeuCau.Effect_2 = true;
            this.btnTimKiemYeuCau.Effect_2_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(57)))));
            this.btnTimKiemYeuCau.Effect_2_Transparency = 125;
            this.btnTimKiemYeuCau.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiemYeuCau.ForeColor = System.Drawing.Color.Black;
            this.btnTimKiemYeuCau.Lighting = false;
            this.btnTimKiemYeuCau.LinearGradient_Background = false;
            this.btnTimKiemYeuCau.LinearGradientPen = false;
            this.btnTimKiemYeuCau.Location = new System.Drawing.Point(360, 75);
            this.btnTimKiemYeuCau.Name = "btnTimKiemYeuCau";
            this.btnTimKiemYeuCau.PenWidth = 15;
            this.btnTimKiemYeuCau.Rounding = true;
            this.btnTimKiemYeuCau.RoundingInt = 70;
            this.btnTimKiemYeuCau.Size = new System.Drawing.Size(97, 28);
            this.btnTimKiemYeuCau.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnTimKiemYeuCau.TabIndex = 3;
            this.btnTimKiemYeuCau.Tag = "Cyber";
            this.btnTimKiemYeuCau.TextButton = "Tìm kiếm";
            this.btnTimKiemYeuCau.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnTimKiemYeuCau.Timer_Effect_1 = 5;
            this.btnTimKiemYeuCau.Timer_RGB = 300;
            this.btnTimKiemYeuCau.Click += new System.EventHandler(this.btnTimKiemYeuCau_Click);
            this.btnTimKiemYeuCau.Enter += new System.EventHandler(this.btnTimKiemYeuCau_Enter);
            this.btnTimKiemYeuCau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnTimKiemYeuCau_KeyDown);
            this.btnTimKiemYeuCau.Leave += new System.EventHandler(this.btnTimKiemYeuCau_Leave);
            // 
            // QuanLyYeuCau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(229)))), ((int)(((byte)(184)))));
            this.ClientSize = new System.Drawing.Size(887, 642);
            this.Controls.Add(this.gbYeuCauChuaXuLy);
            this.Controls.Add(this.pnTieuDeQuanLyYeuCau);
            this.Controls.Add(this.gbDanhSachYeuCau);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QuanLyYeuCau";
            this.Text = "Quản lý yêu cầu";
            this.Load += new System.EventHandler(this.QuanLyYeuCau_Load);
            this.Resize += new System.EventHandler(this.QuanLyYeuCau_Resize);
            this.gbYeuCauChuaXuLy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvYeuCauChuaXuLy)).EndInit();
            this.pnTieuDeQuanLyYeuCau.ResumeLayout(false);
            this.pnTieuDeQuanLyYeuCau.PerformLayout();
            this.gbDanhSachYeuCau.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachYeuCau)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ReaLTaiizor.Controls.CyberButton btnIn;
        private ReaLTaiizor.Controls.CyberButton btnXuatPhieuNhap;
        private GroupBox gbYeuCauChuaXuLy;
        private ReaLTaiizor.Controls.CyberButton btnLamMoi;
        private ReaLTaiizor.Controls.DungeonTextBox boxTimKiemYeuCauChuaXuLy;
        private DataGridView dgvYeuCauChuaXuLy;
        private ReaLTaiizor.Controls.CyberButton btnDuyet;
        private ReaLTaiizor.Controls.CyberButton btnTimKiemYeuCauChuaXuLy;
        private ReaLTaiizor.Controls.DungeonComboBox cbLoaiDanhSach;
        private Panel pnTieuDeQuanLyYeuCau;
        private Label txtTieuDeQuanLyYeuCau;
        private ReaLTaiizor.Controls.CyberButton btnXem;
        private ReaLTaiizor.Controls.DungeonTextBox boxTimKiemYeuCau;
        private GroupBox gbDanhSachYeuCau;
        private ReaLTaiizor.Controls.CyberButton btnTimKiemYeuCau;
        private DataGridView dgvDanhSachYeuCau;
    }
}
