using System.Windows.Forms;

namespace WarehouseMA
{
    partial class QuanLyKho
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox gbThaoTacQLK;
        private System.Windows.Forms.Label txtThongTinKho;
        private System.Windows.Forms.GroupBox gbCongCu;
        private System.Windows.Forms.DataGridView dgvDanhSach;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbThaoTacQLK = new System.Windows.Forms.GroupBox();
            this.btnXem = new ReaLTaiizor.Controls.CyberButton();
            this.cbDanhSach = new ReaLTaiizor.Controls.DungeonComboBox();
            this.cbKho = new ReaLTaiizor.Controls.DungeonComboBox();
            this.txtDanhSach = new System.Windows.Forms.Label();
            this.txtThongTinKho = new System.Windows.Forms.Label();
            this.gbCongCu = new System.Windows.Forms.GroupBox();
            this.btnIn = new ReaLTaiizor.Controls.CyberButton();
            this.btnLuu = new ReaLTaiizor.Controls.CyberButton();
            this.btnSua = new ReaLTaiizor.Controls.CyberButton();
            this.btnXoa = new ReaLTaiizor.Controls.CyberButton();
            this.btnThem = new ReaLTaiizor.Controls.CyberButton();
            this.btnTimKiem = new ReaLTaiizor.Controls.CyberButton();
            this.boxTimKiem = new ReaLTaiizor.Controls.DungeonTextBox();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.pnTieuDeQuanLyKho = new System.Windows.Forms.Panel();
            this.txtTieuDeQuanLyKho = new System.Windows.Forms.Label();
            this.gbThaoTacQLK.SuspendLayout();
            this.gbCongCu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.pnTieuDeQuanLyKho.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbThaoTacQLK
            // 
            this.gbThaoTacQLK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbThaoTacQLK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(229)))), ((int)(((byte)(184)))));
            this.gbThaoTacQLK.Controls.Add(this.btnXem);
            this.gbThaoTacQLK.Controls.Add(this.cbDanhSach);
            this.gbThaoTacQLK.Controls.Add(this.cbKho);
            this.gbThaoTacQLK.Controls.Add(this.txtDanhSach);
            this.gbThaoTacQLK.Controls.Add(this.txtThongTinKho);
            this.gbThaoTacQLK.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbThaoTacQLK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(66)))));
            this.gbThaoTacQLK.Location = new System.Drawing.Point(9, 67);
            this.gbThaoTacQLK.Margin = new System.Windows.Forms.Padding(2);
            this.gbThaoTacQLK.Name = "gbThaoTacQLK";
            this.gbThaoTacQLK.Padding = new System.Windows.Forms.Padding(2);
            this.gbThaoTacQLK.Size = new System.Drawing.Size(888, 102);
            this.gbThaoTacQLK.TabIndex = 1;
            this.gbThaoTacQLK.TabStop = false;
            this.gbThaoTacQLK.Text = "Thao tác";
            // 
            // btnXem
            // 
            this.btnXem.Alpha = 20;
            this.btnXem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnXem.Location = new System.Drawing.Point(808, 42);
            this.btnXem.Name = "btnXem";
            this.btnXem.PenWidth = 15;
            this.btnXem.Rounding = true;
            this.btnXem.RoundingInt = 70;
            this.btnXem.Size = new System.Drawing.Size(80, 29);
            this.btnXem.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnXem.TabIndex = 4;
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
            // cbDanhSach
            // 
            this.cbDanhSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.cbDanhSach.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(132)))), ((int)(((byte)(85)))));
            this.cbDanhSach.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(57)))));
            this.cbDanhSach.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(241)))), ((int)(((byte)(240)))));
            this.cbDanhSach.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.cbDanhSach.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(237)))), ((int)(((byte)(236)))));
            this.cbDanhSach.ColorF = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.cbDanhSach.ColorG = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(118)))));
            this.cbDanhSach.ColorH = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(222)))), ((int)(((byte)(220)))));
            this.cbDanhSach.ColorI = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.cbDanhSach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbDanhSach.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDanhSach.DropDownHeight = 100;
            this.cbDanhSach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDanhSach.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbDanhSach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(97)))));
            this.cbDanhSach.FormattingEnabled = true;
            this.cbDanhSach.HoverSelectionColor = System.Drawing.Color.Empty;
            this.cbDanhSach.IntegralHeight = false;
            this.cbDanhSach.ItemHeight = 20;
            this.cbDanhSach.Location = new System.Drawing.Point(509, 45);
            this.cbDanhSach.Name = "cbDanhSach";
            this.cbDanhSach.Size = new System.Drawing.Size(288, 26);
            this.cbDanhSach.StartIndex = 0;
            this.cbDanhSach.TabIndex = 3;
            this.cbDanhSach.SelectedIndexChanged += new System.EventHandler(this.cbDanhSach_SelectedIndexChanged);
            // 
            // cbKho
            // 
            this.cbKho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.cbKho.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(132)))), ((int)(((byte)(85)))));
            this.cbKho.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(57)))));
            this.cbKho.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(241)))), ((int)(((byte)(240)))));
            this.cbKho.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.cbKho.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(237)))), ((int)(((byte)(236)))));
            this.cbKho.ColorF = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.cbKho.ColorG = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(118)))));
            this.cbKho.ColorH = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(222)))), ((int)(((byte)(220)))));
            this.cbKho.ColorI = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.cbKho.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbKho.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbKho.DropDownHeight = 100;
            this.cbKho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKho.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbKho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(97)))));
            this.cbKho.FormattingEnabled = true;
            this.cbKho.HoverSelectionColor = System.Drawing.Color.Empty;
            this.cbKho.IntegralHeight = false;
            this.cbKho.ItemHeight = 20;
            this.cbKho.Location = new System.Drawing.Point(61, 45);
            this.cbKho.Name = "cbKho";
            this.cbKho.Size = new System.Drawing.Size(298, 26);
            this.cbKho.StartIndex = 0;
            this.cbKho.TabIndex = 1;
            this.cbKho.SelectedIndexChanged += new System.EventHandler(this.cbKho_SelectedIndexChanged);
            // 
            // txtDanhSach
            // 
            this.txtDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDanhSach.AutoSize = true;
            this.txtDanhSach.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDanhSach.ForeColor = System.Drawing.Color.Black;
            this.txtDanhSach.Location = new System.Drawing.Point(420, 47);
            this.txtDanhSach.Name = "txtDanhSach";
            this.txtDanhSach.Size = new System.Drawing.Size(83, 21);
            this.txtDanhSach.TabIndex = 2;
            this.txtDanhSach.Text = "Danh sách";
            // 
            // txtThongTinKho
            // 
            this.txtThongTinKho.AutoSize = true;
            this.txtThongTinKho.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThongTinKho.ForeColor = System.Drawing.Color.Black;
            this.txtThongTinKho.Location = new System.Drawing.Point(18, 47);
            this.txtThongTinKho.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtThongTinKho.Name = "txtThongTinKho";
            this.txtThongTinKho.Size = new System.Drawing.Size(39, 21);
            this.txtThongTinKho.TabIndex = 0;
            this.txtThongTinKho.Text = "Kho";
            // 
            // gbCongCu
            // 
            this.gbCongCu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCongCu.Controls.Add(this.btnIn);
            this.gbCongCu.Controls.Add(this.btnLuu);
            this.gbCongCu.Controls.Add(this.btnSua);
            this.gbCongCu.Controls.Add(this.btnXoa);
            this.gbCongCu.Controls.Add(this.btnThem);
            this.gbCongCu.Controls.Add(this.btnTimKiem);
            this.gbCongCu.Controls.Add(this.boxTimKiem);
            this.gbCongCu.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCongCu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(66)))));
            this.gbCongCu.Location = new System.Drawing.Point(9, 173);
            this.gbCongCu.Margin = new System.Windows.Forms.Padding(2);
            this.gbCongCu.Name = "gbCongCu";
            this.gbCongCu.Padding = new System.Windows.Forms.Padding(2);
            this.gbCongCu.Size = new System.Drawing.Size(888, 89);
            this.gbCongCu.TabIndex = 2;
            this.gbCongCu.TabStop = false;
            this.gbCongCu.Text = "Công cụ";
            this.gbCongCu.Enter += new System.EventHandler(this.gbCongCu_Enter_1);
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
            this.btnIn.Location = new System.Drawing.Point(803, 56);
            this.btnIn.Name = "btnIn";
            this.btnIn.PenWidth = 15;
            this.btnIn.Rounding = true;
            this.btnIn.RoundingInt = 70;
            this.btnIn.Size = new System.Drawing.Size(80, 28);
            this.btnIn.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnIn.TabIndex = 6;
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
            // btnLuu
            // 
            this.btnLuu.Alpha = 20;
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.BackColor = System.Drawing.Color.Transparent;
            this.btnLuu.Background = true;
            this.btnLuu.Background_WidthPen = 3F;
            this.btnLuu.BackgroundPen = true;
            this.btnLuu.ColorBackground = System.Drawing.Color.White;
            this.btnLuu.ColorBackground_1 = System.Drawing.Color.White;
            this.btnLuu.ColorBackground_2 = System.Drawing.Color.White;
            this.btnLuu.ColorBackground_Pen = System.Drawing.Color.Black;
            this.btnLuu.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnLuu.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnLuu.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnLuu.Effect_1 = true;
            this.btnLuu.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnLuu.Effect_1_Transparency = 25;
            this.btnLuu.Effect_2 = true;
            this.btnLuu.Effect_2_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(57)))));
            this.btnLuu.Effect_2_Transparency = 125;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.Black;
            this.btnLuu.Lighting = false;
            this.btnLuu.LinearGradient_Background = false;
            this.btnLuu.LinearGradientPen = false;
            this.btnLuu.Location = new System.Drawing.Point(717, 56);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.PenWidth = 15;
            this.btnLuu.Rounding = true;
            this.btnLuu.RoundingInt = 70;
            this.btnLuu.Size = new System.Drawing.Size(80, 28);
            this.btnLuu.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnLuu.TabIndex = 5;
            this.btnLuu.Tag = "Cyber";
            this.btnLuu.TextButton = "Lưu";
            this.btnLuu.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnLuu.Timer_Effect_1 = 5;
            this.btnLuu.Timer_RGB = 300;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            this.btnLuu.Enter += new System.EventHandler(this.btnLuu_Enter);
            this.btnLuu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnLuu_KeyDown);
            this.btnLuu.Leave += new System.EventHandler(this.btnLuu_Leave);
            // 
            // btnSua
            // 
            this.btnSua.Alpha = 20;
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua.BackColor = System.Drawing.Color.Transparent;
            this.btnSua.Background = true;
            this.btnSua.Background_WidthPen = 3F;
            this.btnSua.BackgroundPen = true;
            this.btnSua.ColorBackground = System.Drawing.Color.White;
            this.btnSua.ColorBackground_1 = System.Drawing.Color.White;
            this.btnSua.ColorBackground_2 = System.Drawing.Color.White;
            this.btnSua.ColorBackground_Pen = System.Drawing.Color.Black;
            this.btnSua.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnSua.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnSua.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnSua.Effect_1 = true;
            this.btnSua.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnSua.Effect_1_Transparency = 25;
            this.btnSua.Effect_2 = true;
            this.btnSua.Effect_2_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(57)))));
            this.btnSua.Effect_2_Transparency = 125;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.Black;
            this.btnSua.Lighting = false;
            this.btnSua.LinearGradient_Background = false;
            this.btnSua.LinearGradientPen = false;
            this.btnSua.Location = new System.Drawing.Point(631, 56);
            this.btnSua.Name = "btnSua";
            this.btnSua.PenWidth = 15;
            this.btnSua.Rounding = true;
            this.btnSua.RoundingInt = 70;
            this.btnSua.Size = new System.Drawing.Size(80, 28);
            this.btnSua.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnSua.TabIndex = 4;
            this.btnSua.Tag = "Cyber";
            this.btnSua.TextButton = "Sửa";
            this.btnSua.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnSua.Timer_Effect_1 = 5;
            this.btnSua.Timer_RGB = 300;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            this.btnSua.Enter += new System.EventHandler(this.btnSua_Enter);
            this.btnSua.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSua_KeyDown);
            this.btnSua.Leave += new System.EventHandler(this.btnSua_Leave);
            // 
            // btnXoa
            // 
            this.btnXoa.Alpha = 20;
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.BackColor = System.Drawing.Color.Transparent;
            this.btnXoa.Background = true;
            this.btnXoa.Background_WidthPen = 3F;
            this.btnXoa.BackgroundPen = true;
            this.btnXoa.ColorBackground = System.Drawing.Color.White;
            this.btnXoa.ColorBackground_1 = System.Drawing.Color.White;
            this.btnXoa.ColorBackground_2 = System.Drawing.Color.White;
            this.btnXoa.ColorBackground_Pen = System.Drawing.Color.Black;
            this.btnXoa.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnXoa.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnXoa.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnXoa.Effect_1 = true;
            this.btnXoa.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnXoa.Effect_1_Transparency = 25;
            this.btnXoa.Effect_2 = true;
            this.btnXoa.Effect_2_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(57)))));
            this.btnXoa.Effect_2_Transparency = 125;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.Black;
            this.btnXoa.Lighting = false;
            this.btnXoa.LinearGradient_Background = false;
            this.btnXoa.LinearGradientPen = false;
            this.btnXoa.Location = new System.Drawing.Point(545, 56);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.PenWidth = 15;
            this.btnXoa.Rounding = true;
            this.btnXoa.RoundingInt = 70;
            this.btnXoa.Size = new System.Drawing.Size(80, 28);
            this.btnXoa.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Tag = "Cyber";
            this.btnXoa.TextButton = "Xóa";
            this.btnXoa.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnXoa.Timer_Effect_1 = 5;
            this.btnXoa.Timer_RGB = 300;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnXoa.Enter += new System.EventHandler(this.btnXoa_Enter);
            this.btnXoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnXoa_KeyDown);
            this.btnXoa.Leave += new System.EventHandler(this.btnXoa_Leave);
            // 
            // btnThem
            // 
            this.btnThem.Alpha = 20;
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.BackColor = System.Drawing.Color.Transparent;
            this.btnThem.Background = true;
            this.btnThem.Background_WidthPen = 3F;
            this.btnThem.BackgroundPen = true;
            this.btnThem.ColorBackground = System.Drawing.Color.White;
            this.btnThem.ColorBackground_1 = System.Drawing.Color.White;
            this.btnThem.ColorBackground_2 = System.Drawing.Color.White;
            this.btnThem.ColorBackground_Pen = System.Drawing.Color.Black;
            this.btnThem.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnThem.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnThem.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnThem.Effect_1 = true;
            this.btnThem.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnThem.Effect_1_Transparency = 25;
            this.btnThem.Effect_2 = true;
            this.btnThem.Effect_2_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(57)))));
            this.btnThem.Effect_2_Transparency = 125;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.Black;
            this.btnThem.Lighting = false;
            this.btnThem.LinearGradient_Background = false;
            this.btnThem.LinearGradientPen = false;
            this.btnThem.Location = new System.Drawing.Point(459, 56);
            this.btnThem.Name = "btnThem";
            this.btnThem.PenWidth = 15;
            this.btnThem.Rounding = true;
            this.btnThem.RoundingInt = 70;
            this.btnThem.Size = new System.Drawing.Size(80, 28);
            this.btnThem.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnThem.TabIndex = 2;
            this.btnThem.Tag = "Cyber";
            this.btnThem.TextButton = "Thêm";
            this.btnThem.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnThem.Timer_Effect_1 = 5;
            this.btnThem.Timer_RGB = 300;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnThem.Enter += new System.EventHandler(this.btnThem_Enter);
            this.btnThem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnThem_KeyDown);
            this.btnThem.Leave += new System.EventHandler(this.btnThem_Leave);
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
            this.btnTimKiem.Location = new System.Drawing.Point(334, 56);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.PenWidth = 15;
            this.btnTimKiem.Rounding = true;
            this.btnTimKiem.RoundingInt = 70;
            this.btnTimKiem.Size = new System.Drawing.Size(100, 28);
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
            // boxTimKiem
            // 
            this.boxTimKiem.BackColor = System.Drawing.Color.Transparent;
            this.boxTimKiem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.boxTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.boxTimKiem.EdgeColor = System.Drawing.Color.White;
            this.boxTimKiem.Font = new System.Drawing.Font("Tahoma", 11F);
            this.boxTimKiem.ForeColor = System.Drawing.Color.DimGray;
            this.boxTimKiem.Location = new System.Drawing.Point(13, 56);
            this.boxTimKiem.MaxLength = 32767;
            this.boxTimKiem.Multiline = false;
            this.boxTimKiem.Name = "boxTimKiem";
            this.boxTimKiem.ReadOnly = false;
            this.boxTimKiem.Size = new System.Drawing.Size(315, 28);
            this.boxTimKiem.TabIndex = 0;
            this.boxTimKiem.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.boxTimKiem.UseSystemPasswordChar = false;
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDanhSach.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDanhSach.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDanhSach.Location = new System.Drawing.Point(9, 266);
            this.dgvDanhSach.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDanhSach.Name = "dgvDanhSach";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSach.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDanhSach.RowHeadersWidth = 51;
            this.dgvDanhSach.RowTemplate.Height = 30;
            this.dgvDanhSach.Size = new System.Drawing.Size(888, 369);
            this.dgvDanhSach.TabIndex = 3;
            this.dgvDanhSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            // 
            // pnTieuDeQuanLyKho
            // 
            this.pnTieuDeQuanLyKho.Controls.Add(this.txtTieuDeQuanLyKho);
            this.pnTieuDeQuanLyKho.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTieuDeQuanLyKho.Location = new System.Drawing.Point(0, 0);
            this.pnTieuDeQuanLyKho.Name = "pnTieuDeQuanLyKho";
            this.pnTieuDeQuanLyKho.Size = new System.Drawing.Size(906, 64);
            this.pnTieuDeQuanLyKho.TabIndex = 0;
            // 
            // txtTieuDeQuanLyKho
            // 
            this.txtTieuDeQuanLyKho.AutoSize = true;
            this.txtTieuDeQuanLyKho.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTieuDeQuanLyKho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(66)))));
            this.txtTieuDeQuanLyKho.Location = new System.Drawing.Point(361, 15);
            this.txtTieuDeQuanLyKho.Name = "txtTieuDeQuanLyKho";
            this.txtTieuDeQuanLyKho.Size = new System.Drawing.Size(199, 37);
            this.txtTieuDeQuanLyKho.TabIndex = 0;
            this.txtTieuDeQuanLyKho.Text = "QUẢN LÝ KHO";
            this.txtTieuDeQuanLyKho.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QuanLyKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(229)))), ((int)(((byte)(184)))));
            this.ClientSize = new System.Drawing.Size(906, 656);
            this.Controls.Add(this.pnTieuDeQuanLyKho);
            this.Controls.Add(this.dgvDanhSach);
            this.Controls.Add(this.gbCongCu);
            this.Controls.Add(this.gbThaoTacQLK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "QuanLyKho";
            this.Text = "QuanLyKho";
            this.Activated += new System.EventHandler(this.QuanLyKho_Activated);
            this.Load += new System.EventHandler(this.QuanLyKho_Load);
            this.Resize += new System.EventHandler(this.QuanLyKho_Resize);
            this.gbThaoTacQLK.ResumeLayout(false);
            this.gbThaoTacQLK.PerformLayout();
            this.gbCongCu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.pnTieuDeQuanLyKho.ResumeLayout(false);
            this.pnTieuDeQuanLyKho.PerformLayout();
            this.ResumeLayout(false);

        }

        private Panel pnTieuDeQuanLyKho;
        private Label txtTieuDeQuanLyKho;
        private Label txtDanhSach;
        private ReaLTaiizor.Controls.DungeonComboBox cbKho;
        private ReaLTaiizor.Controls.DungeonComboBox cbDanhSach;
        private ReaLTaiizor.Controls.DungeonTextBox boxTimKiem;
        private ReaLTaiizor.Controls.CyberButton btnTimKiem;
        private ReaLTaiizor.Controls.CyberButton btnThem;
        private ReaLTaiizor.Controls.CyberButton btnXoa;
        private ReaLTaiizor.Controls.CyberButton btnSua;
        private ReaLTaiizor.Controls.CyberButton btnLuu;
        private ReaLTaiizor.Controls.CyberButton btnIn;
        private ReaLTaiizor.Controls.CyberButton btnXem;
    }
}
