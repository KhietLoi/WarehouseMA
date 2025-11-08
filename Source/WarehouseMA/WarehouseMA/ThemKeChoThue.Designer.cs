namespace WarehouseMA
{
    partial class ThemKeChoThue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThemKeChoThue));
            this.lbMaKho = new System.Windows.Forms.Label();
            this.lbDungTichKhaDung = new System.Windows.Forms.Label();
            this.tieuDeThemKeChoThue = new System.Windows.Forms.Panel();
            this.txtThemKeChoThue = new System.Windows.Forms.Label();
            this.pbLogoPhanMemChu = new System.Windows.Forms.PictureBox();
            this.txtDungTichKhaDung = new ReaLTaiizor.Controls.DungeonTextBox();
            this.txtMaKho = new ReaLTaiizor.Controls.DungeonTextBox();
            this.btnHuy = new ReaLTaiizor.Controls.CyberButton();
            this.btnThem = new ReaLTaiizor.Controls.CyberButton();
            this.txtTieuDeThemKeChoThue = new System.Windows.Forms.Label();
            this.btnDongMoForm = new ReaLTaiizor.Controls.MetroControlBox();
            this.tieuDeThemKeChoThue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoPhanMemChu)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMaKho
            // 
            this.lbMaKho.AutoSize = true;
            this.lbMaKho.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaKho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(66)))));
            this.lbMaKho.Location = new System.Drawing.Point(47, 130);
            this.lbMaKho.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbMaKho.Name = "lbMaKho";
            this.lbMaKho.Size = new System.Drawing.Size(82, 25);
            this.lbMaKho.TabIndex = 1;
            this.lbMaKho.Text = "Mã kho:";
            // 
            // lbDungTichKhaDung
            // 
            this.lbDungTichKhaDung.AutoSize = true;
            this.lbDungTichKhaDung.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDungTichKhaDung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(66)))));
            this.lbDungTichKhaDung.Location = new System.Drawing.Point(47, 202);
            this.lbDungTichKhaDung.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDungTichKhaDung.Name = "lbDungTichKhaDung";
            this.lbDungTichKhaDung.Size = new System.Drawing.Size(186, 25);
            this.lbDungTichKhaDung.TabIndex = 3;
            this.lbDungTichKhaDung.Text = "Dung tích khả dụng:";
            // 
            // tieuDeThemKeChoThue
            // 
            this.tieuDeThemKeChoThue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(178)))), ((int)(((byte)(88)))));
            this.tieuDeThemKeChoThue.Controls.Add(this.btnDongMoForm);
            this.tieuDeThemKeChoThue.Controls.Add(this.txtThemKeChoThue);
            this.tieuDeThemKeChoThue.Controls.Add(this.pbLogoPhanMemChu);
            this.tieuDeThemKeChoThue.Dock = System.Windows.Forms.DockStyle.Top;
            this.tieuDeThemKeChoThue.Location = new System.Drawing.Point(0, 0);
            this.tieuDeThemKeChoThue.Name = "tieuDeThemKeChoThue";
            this.tieuDeThemKeChoThue.Size = new System.Drawing.Size(586, 31);
            this.tieuDeThemKeChoThue.TabIndex = 0;
            this.tieuDeThemKeChoThue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tieuDeThemKeChoThue_MouseDown);
            this.tieuDeThemKeChoThue.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tieuDeThemKeChoThue_MouseMove);
            this.tieuDeThemKeChoThue.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tieuDeThemKeChoThue_MouseUp);
            // 
            // txtThemKeChoThue
            // 
            this.txtThemKeChoThue.AutoSize = true;
            this.txtThemKeChoThue.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThemKeChoThue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(66)))));
            this.txtThemKeChoThue.Location = new System.Drawing.Point(114, 5);
            this.txtThemKeChoThue.Name = "txtThemKeChoThue";
            this.txtThemKeChoThue.Size = new System.Drawing.Size(140, 21);
            this.txtThemKeChoThue.TabIndex = 0;
            this.txtThemKeChoThue.Text = "Thêm kệ cho thuê";
            // 
            // pbLogoPhanMemChu
            // 
            this.pbLogoPhanMemChu.Image = ((System.Drawing.Image)(resources.GetObject("pbLogoPhanMemChu.Image")));
            this.pbLogoPhanMemChu.Location = new System.Drawing.Point(3, 1);
            this.pbLogoPhanMemChu.Name = "pbLogoPhanMemChu";
            this.pbLogoPhanMemChu.Size = new System.Drawing.Size(105, 29);
            this.pbLogoPhanMemChu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogoPhanMemChu.TabIndex = 16;
            this.pbLogoPhanMemChu.TabStop = false;
            // 
            // txtDungTichKhaDung
            // 
            this.txtDungTichKhaDung.BackColor = System.Drawing.Color.Transparent;
            this.txtDungTichKhaDung.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtDungTichKhaDung.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDungTichKhaDung.EdgeColor = System.Drawing.Color.White;
            this.txtDungTichKhaDung.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDungTichKhaDung.ForeColor = System.Drawing.Color.DimGray;
            this.txtDungTichKhaDung.Location = new System.Drawing.Point(249, 202);
            this.txtDungTichKhaDung.MaxLength = 32767;
            this.txtDungTichKhaDung.Multiline = false;
            this.txtDungTichKhaDung.Name = "txtDungTichKhaDung";
            this.txtDungTichKhaDung.ReadOnly = false;
            this.txtDungTichKhaDung.Size = new System.Drawing.Size(271, 28);
            this.txtDungTichKhaDung.TabIndex = 4;
            this.txtDungTichKhaDung.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDungTichKhaDung.UseSystemPasswordChar = false;
            // 
            // txtMaKho
            // 
            this.txtMaKho.BackColor = System.Drawing.Color.Transparent;
            this.txtMaKho.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtMaKho.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaKho.EdgeColor = System.Drawing.Color.White;
            this.txtMaKho.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaKho.ForeColor = System.Drawing.Color.DimGray;
            this.txtMaKho.Location = new System.Drawing.Point(249, 130);
            this.txtMaKho.MaxLength = 32767;
            this.txtMaKho.Multiline = false;
            this.txtMaKho.Name = "txtMaKho";
            this.txtMaKho.ReadOnly = false;
            this.txtMaKho.Size = new System.Drawing.Size(271, 28);
            this.txtMaKho.TabIndex = 2;
            this.txtMaKho.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMaKho.UseSystemPasswordChar = false;
            // 
            // btnHuy
            // 
            this.btnHuy.Alpha = 20;
            this.btnHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuy.BackColor = System.Drawing.Color.Transparent;
            this.btnHuy.Background = true;
            this.btnHuy.Background_WidthPen = 3F;
            this.btnHuy.BackgroundPen = true;
            this.btnHuy.ColorBackground = System.Drawing.Color.White;
            this.btnHuy.ColorBackground_1 = System.Drawing.Color.White;
            this.btnHuy.ColorBackground_2 = System.Drawing.Color.White;
            this.btnHuy.ColorBackground_Pen = System.Drawing.Color.Black;
            this.btnHuy.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnHuy.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnHuy.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnHuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuy.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnHuy.Effect_1 = true;
            this.btnHuy.Effect_1_ColorBackground = System.Drawing.Color.White;
            this.btnHuy.Effect_1_Transparency = 25;
            this.btnHuy.Effect_2 = true;
            this.btnHuy.Effect_2_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(57)))));
            this.btnHuy.Effect_2_Transparency = 125;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.Color.Black;
            this.btnHuy.Lighting = false;
            this.btnHuy.LinearGradient_Background = false;
            this.btnHuy.LinearGradientPen = false;
            this.btnHuy.Location = new System.Drawing.Point(193, 267);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.PenWidth = 15;
            this.btnHuy.Rounding = true;
            this.btnHuy.RoundingInt = 70;
            this.btnHuy.Size = new System.Drawing.Size(80, 48);
            this.btnHuy.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnHuy.TabIndex = 5;
            this.btnHuy.Tag = "Cyber";
            this.btnHuy.TextButton = "Hủy";
            this.btnHuy.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnHuy.Timer_Effect_1 = 5;
            this.btnHuy.Timer_RGB = 300;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            this.btnHuy.Enter += new System.EventHandler(this.btnHuy_Enter);
            this.btnHuy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnHuy_KeyDown);
            this.btnHuy.Leave += new System.EventHandler(this.btnHuy_Leave);
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
            this.btnThem.Effect_1_ColorBackground = System.Drawing.Color.White;
            this.btnThem.Effect_1_Transparency = 25;
            this.btnThem.Effect_2 = true;
            this.btnThem.Effect_2_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(57)))));
            this.btnThem.Effect_2_Transparency = 125;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.Black;
            this.btnThem.Lighting = false;
            this.btnThem.LinearGradient_Background = false;
            this.btnThem.LinearGradientPen = false;
            this.btnThem.Location = new System.Drawing.Point(313, 267);
            this.btnThem.Name = "btnThem";
            this.btnThem.PenWidth = 15;
            this.btnThem.Rounding = true;
            this.btnThem.RoundingInt = 70;
            this.btnThem.Size = new System.Drawing.Size(80, 48);
            this.btnThem.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnThem.TabIndex = 6;
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
            // txtTieuDeThemKeChoThue
            // 
            this.txtTieuDeThemKeChoThue.AutoSize = true;
            this.txtTieuDeThemKeChoThue.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTieuDeThemKeChoThue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(66)))));
            this.txtTieuDeThemKeChoThue.Location = new System.Drawing.Point(155, 60);
            this.txtTieuDeThemKeChoThue.Name = "txtTieuDeThemKeChoThue";
            this.txtTieuDeThemKeChoThue.Size = new System.Drawing.Size(276, 37);
            this.txtTieuDeThemKeChoThue.TabIndex = 7;
            this.txtTieuDeThemKeChoThue.Text = "THÊM KỆ CHO THUÊ";
            this.txtTieuDeThemKeChoThue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDongMoForm
            // 
            this.btnDongMoForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDongMoForm.CloseHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnDongMoForm.CloseHoverForeColor = System.Drawing.Color.White;
            this.btnDongMoForm.CloseNormalForeColor = System.Drawing.Color.Gray;
            this.btnDongMoForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDongMoForm.DefaultLocation = ReaLTaiizor.Enum.Metro.LocationType.Normal;
            this.btnDongMoForm.DisabledForeColor = System.Drawing.Color.DimGray;
            this.btnDongMoForm.IsDerivedStyle = true;
            this.btnDongMoForm.Location = new System.Drawing.Point(483, 3);
            this.btnDongMoForm.MaximizeBox = false;
            this.btnDongMoForm.MaximizeHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnDongMoForm.MaximizeHoverForeColor = System.Drawing.Color.Gray;
            this.btnDongMoForm.MaximizeNormalForeColor = System.Drawing.Color.Gray;
            this.btnDongMoForm.MinimizeBox = true;
            this.btnDongMoForm.MinimizeHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnDongMoForm.MinimizeHoverForeColor = System.Drawing.Color.Gray;
            this.btnDongMoForm.MinimizeNormalForeColor = System.Drawing.Color.Gray;
            this.btnDongMoForm.Name = "btnDongMoForm";
            this.btnDongMoForm.Size = new System.Drawing.Size(100, 25);
            this.btnDongMoForm.Style = ReaLTaiizor.Enum.Metro.Style.Light;
            this.btnDongMoForm.StyleManager = null;
            this.btnDongMoForm.TabIndex = 17;
            this.btnDongMoForm.Text = "metroControlBox1";
            this.btnDongMoForm.ThemeAuthor = "Taiizor";
            this.btnDongMoForm.ThemeName = "MetroLight";
            // 
            // ThemKeChoThue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(229)))), ((int)(((byte)(184)))));
            this.ClientSize = new System.Drawing.Size(586, 351);
            this.Controls.Add(this.txtTieuDeThemKeChoThue);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtDungTichKhaDung);
            this.Controls.Add(this.txtMaKho);
            this.Controls.Add(this.tieuDeThemKeChoThue);
            this.Controls.Add(this.lbDungTichKhaDung);
            this.Controls.Add(this.lbMaKho);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ThemKeChoThue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ThemKeChoThue";
            this.tieuDeThemKeChoThue.ResumeLayout(false);
            this.tieuDeThemKeChoThue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoPhanMemChu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMaKho;
        private System.Windows.Forms.Label lbDungTichKhaDung;
        private System.Windows.Forms.Panel tieuDeThemKeChoThue;
        private System.Windows.Forms.Label txtThemKeChoThue;
        private System.Windows.Forms.PictureBox pbLogoPhanMemChu;
        private ReaLTaiizor.Controls.DungeonTextBox txtDungTichKhaDung;
        private ReaLTaiizor.Controls.DungeonTextBox txtMaKho;
        private ReaLTaiizor.Controls.CyberButton btnHuy;
        private ReaLTaiizor.Controls.CyberButton btnThem;
        private System.Windows.Forms.Label txtTieuDeThemKeChoThue;
        private ReaLTaiizor.Controls.MetroControlBox btnDongMoForm;
    }
}