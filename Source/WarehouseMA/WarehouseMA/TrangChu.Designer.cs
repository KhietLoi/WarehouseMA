using System.Windows.Forms;

namespace WarehouseMA
{
    partial class TrangChu
    {
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrangChu));
            this.txtChaoMung = new System.Windows.Forms.Label();
            this.pbLogoPhanMem = new System.Windows.Forms.PictureBox();
            this.txtBanQuyen = new System.Windows.Forms.Label();
            this.pbLogoNhom = new System.Windows.Forms.PictureBox();
            this.btnQuanLyYeuCau = new System.Windows.Forms.Button();
            this.btnQuanLyDonHang = new System.Windows.Forms.Button();
            this.btnQuanLyKho = new System.Windows.Forms.Button();
            this.btnQuanLyKiemKe = new System.Windows.Forms.Button();
            this.pbRobotTrai = new System.Windows.Forms.PictureBox();
            this.pbRobotPhai = new System.Windows.Forms.PictureBox();
            this.pnCenter = new System.Windows.Forms.Panel();
            this.pnButtonPicture = new System.Windows.Forms.Panel();
            this.pnBanQuyenLogoNhom = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoPhanMem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoNhom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRobotTrai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRobotPhai)).BeginInit();
            this.pnCenter.SuspendLayout();
            this.pnButtonPicture.SuspendLayout();
            this.pnBanQuyenLogoNhom.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtChaoMung
            // 
            this.txtChaoMung.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtChaoMung.BackColor = System.Drawing.Color.Transparent;
            this.txtChaoMung.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChaoMung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(66)))));
            this.txtChaoMung.Location = new System.Drawing.Point(0, 135);
            this.txtChaoMung.Name = "txtChaoMung";
            this.txtChaoMung.Size = new System.Drawing.Size(1128, 74);
            this.txtChaoMung.TabIndex = 0;
            this.txtChaoMung.Text = "Chào mừng bạn đến với\r\nPhần mềm quản lý hàng hóa, vật tư, công cụ dụng cụ trong T" +
    "òa nhà";
            this.txtChaoMung.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbLogoPhanMem
            // 
            this.pbLogoPhanMem.BackColor = System.Drawing.Color.Transparent;
            this.pbLogoPhanMem.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbLogoPhanMem.Image = ((System.Drawing.Image)(resources.GetObject("pbLogoPhanMem.Image")));
            this.pbLogoPhanMem.Location = new System.Drawing.Point(0, 0);
            this.pbLogoPhanMem.Name = "pbLogoPhanMem";
            this.pbLogoPhanMem.Size = new System.Drawing.Size(1128, 134);
            this.pbLogoPhanMem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogoPhanMem.TabIndex = 1;
            this.pbLogoPhanMem.TabStop = false;
            // 
            // txtBanQuyen
            // 
            this.txtBanQuyen.AutoSize = true;
            this.txtBanQuyen.BackColor = System.Drawing.Color.Transparent;
            this.txtBanQuyen.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBanQuyen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(66)))));
            this.txtBanQuyen.Location = new System.Drawing.Point(382, 25);
            this.txtBanQuyen.Name = "txtBanQuyen";
            this.txtBanQuyen.Size = new System.Drawing.Size(265, 17);
            this.txtBanQuyen.TabIndex = 0;
            this.txtBanQuyen.Text = "Bản quyền phần mềm thuộc về The Buff Soft";
            // 
            // pbLogoNhom
            // 
            this.pbLogoNhom.BackColor = System.Drawing.Color.Transparent;
            this.pbLogoNhom.Image = ((System.Drawing.Image)(resources.GetObject("pbLogoNhom.Image")));
            this.pbLogoNhom.Location = new System.Drawing.Point(654, 5);
            this.pbLogoNhom.Name = "pbLogoNhom";
            this.pbLogoNhom.Size = new System.Drawing.Size(68, 58);
            this.pbLogoNhom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogoNhom.TabIndex = 14;
            this.pbLogoNhom.TabStop = false;
            // 
            // btnQuanLyYeuCau
            // 
            this.btnQuanLyYeuCau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(178)))), ((int)(((byte)(88)))));
            this.btnQuanLyYeuCau.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLyYeuCau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(66)))));
            this.btnQuanLyYeuCau.Image = ((System.Drawing.Image)(resources.GetObject("btnQuanLyYeuCau.Image")));
            this.btnQuanLyYeuCau.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnQuanLyYeuCau.Location = new System.Drawing.Point(263, 6);
            this.btnQuanLyYeuCau.Name = "btnQuanLyYeuCau";
            this.btnQuanLyYeuCau.Padding = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.btnQuanLyYeuCau.Size = new System.Drawing.Size(150, 150);
            this.btnQuanLyYeuCau.TabIndex = 1;
            this.btnQuanLyYeuCau.Text = "Quản lý yêu cầu";
            this.btnQuanLyYeuCau.UseVisualStyleBackColor = false;
            this.btnQuanLyYeuCau.Click += new System.EventHandler(this.btnQuanLyYeuCau_Click);
            // 
            // btnQuanLyDonHang
            // 
            this.btnQuanLyDonHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(178)))), ((int)(((byte)(88)))));
            this.btnQuanLyDonHang.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLyDonHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(66)))));
            this.btnQuanLyDonHang.Image = ((System.Drawing.Image)(resources.GetObject("btnQuanLyDonHang.Image")));
            this.btnQuanLyDonHang.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnQuanLyDonHang.Location = new System.Drawing.Point(445, 6);
            this.btnQuanLyDonHang.Name = "btnQuanLyDonHang";
            this.btnQuanLyDonHang.Padding = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.btnQuanLyDonHang.Size = new System.Drawing.Size(150, 150);
            this.btnQuanLyDonHang.TabIndex = 2;
            this.btnQuanLyDonHang.Text = "Quản lý đơn hàng";
            this.btnQuanLyDonHang.UseVisualStyleBackColor = false;
            this.btnQuanLyDonHang.Click += new System.EventHandler(this.btnQuanLyDonHang_Click);
            // 
            // btnQuanLyKho
            // 
            this.btnQuanLyKho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(178)))), ((int)(((byte)(88)))));
            this.btnQuanLyKho.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLyKho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(66)))));
            this.btnQuanLyKho.Image = ((System.Drawing.Image)(resources.GetObject("btnQuanLyKho.Image")));
            this.btnQuanLyKho.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnQuanLyKho.Location = new System.Drawing.Point(8, 6);
            this.btnQuanLyKho.Name = "btnQuanLyKho";
            this.btnQuanLyKho.Padding = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.btnQuanLyKho.Size = new System.Drawing.Size(150, 150);
            this.btnQuanLyKho.TabIndex = 0;
            this.btnQuanLyKho.Text = "Quản lý kho";
            this.btnQuanLyKho.UseVisualStyleBackColor = false;
            this.btnQuanLyKho.Click += new System.EventHandler(this.btnQuanLyKho_Click);
            // 
            // btnQuanLyKiemKe
            // 
            this.btnQuanLyKiemKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(178)))), ((int)(((byte)(88)))));
            this.btnQuanLyKiemKe.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLyKiemKe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(91)))), ((int)(((byte)(66)))));
            this.btnQuanLyKiemKe.Image = ((System.Drawing.Image)(resources.GetObject("btnQuanLyKiemKe.Image")));
            this.btnQuanLyKiemKe.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnQuanLyKiemKe.Location = new System.Drawing.Point(699, 6);
            this.btnQuanLyKiemKe.Name = "btnQuanLyKiemKe";
            this.btnQuanLyKiemKe.Padding = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.btnQuanLyKiemKe.Size = new System.Drawing.Size(150, 150);
            this.btnQuanLyKiemKe.TabIndex = 3;
            this.btnQuanLyKiemKe.Text = "Quản lý kiểm kê";
            this.btnQuanLyKiemKe.UseVisualStyleBackColor = false;
            this.btnQuanLyKiemKe.Click += new System.EventHandler(this.btnQuanLyKiemKe_Click);
            // 
            // pbRobotTrai
            // 
            this.pbRobotTrai.Image = ((System.Drawing.Image)(resources.GetObject("pbRobotTrai.Image")));
            this.pbRobotTrai.Location = new System.Drawing.Point(76, 128);
            this.pbRobotTrai.Name = "pbRobotTrai";
            this.pbRobotTrai.Size = new System.Drawing.Size(273, 147);
            this.pbRobotTrai.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbRobotTrai.TabIndex = 20;
            this.pbRobotTrai.TabStop = false;
            // 
            // pbRobotPhai
            // 
            this.pbRobotPhai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbRobotPhai.Image = ((System.Drawing.Image)(resources.GetObject("pbRobotPhai.Image")));
            this.pbRobotPhai.Location = new System.Drawing.Point(511, 129);
            this.pbRobotPhai.Name = "pbRobotPhai";
            this.pbRobotPhai.Size = new System.Drawing.Size(273, 147);
            this.pbRobotPhai.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbRobotPhai.TabIndex = 21;
            this.pbRobotPhai.TabStop = false;
            // 
            // pnCenter
            // 
            this.pnCenter.BackColor = System.Drawing.Color.Transparent;
            this.pnCenter.Controls.Add(this.pnButtonPicture);
            this.pnCenter.Location = new System.Drawing.Point(0, 212);
            this.pnCenter.Name = "pnCenter";
            this.pnCenter.Size = new System.Drawing.Size(1128, 381);
            this.pnCenter.TabIndex = 1;
            // 
            // pnButtonPicture
            // 
            this.pnButtonPicture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnButtonPicture.Controls.Add(this.btnQuanLyKiemKe);
            this.pnButtonPicture.Controls.Add(this.btnQuanLyKho);
            this.pnButtonPicture.Controls.Add(this.btnQuanLyDonHang);
            this.pnButtonPicture.Controls.Add(this.btnQuanLyYeuCau);
            this.pnButtonPicture.Controls.Add(this.pbRobotTrai);
            this.pnButtonPicture.Controls.Add(this.pbRobotPhai);
            this.pnButtonPicture.Location = new System.Drawing.Point(137, 40);
            this.pnButtonPicture.Name = "pnButtonPicture";
            this.pnButtonPicture.Size = new System.Drawing.Size(857, 286);
            this.pnButtonPicture.TabIndex = 0;
            // 
            // pnBanQuyenLogoNhom
            // 
            this.pnBanQuyenLogoNhom.Controls.Add(this.txtBanQuyen);
            this.pnBanQuyenLogoNhom.Controls.Add(this.pbLogoNhom);
            this.pnBanQuyenLogoNhom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBanQuyenLogoNhom.Location = new System.Drawing.Point(0, 594);
            this.pnBanQuyenLogoNhom.Name = "pnBanQuyenLogoNhom";
            this.pnBanQuyenLogoNhom.Size = new System.Drawing.Size(1128, 74);
            this.pnBanQuyenLogoNhom.TabIndex = 2;
            // 
            // TrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(229)))), ((int)(((byte)(184)))));
            this.ClientSize = new System.Drawing.Size(1128, 668);
            this.Controls.Add(this.pnBanQuyenLogoNhom);
            this.Controls.Add(this.pnCenter);
            this.Controls.Add(this.txtChaoMung);
            this.Controls.Add(this.pbLogoPhanMem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TrangChu";
            this.Text = "TrangChu";
            this.Load += new System.EventHandler(this.TrangChu_Load);
            this.Resize += new System.EventHandler(this.TrangChu_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoPhanMem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoNhom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRobotTrai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRobotPhai)).EndInit();
            this.pnCenter.ResumeLayout(false);
            this.pnButtonPicture.ResumeLayout(false);
            this.pnBanQuyenLogoNhom.ResumeLayout(false);
            this.pnBanQuyenLogoNhom.PerformLayout();
            this.ResumeLayout(false);

        }


        // endregion
        private System.Windows.Forms.Label txtChaoMung;
        private System.Windows.Forms.PictureBox pbLogoPhanMem;
        private Label txtBanQuyen;
        private PictureBox pbLogoNhom;
        private Button btnQuanLyYeuCau;
        private Button btnQuanLyDonHang;
        private Button btnQuanLyKho;
        private Button btnQuanLyKiemKe;
        private PictureBox pbRobotTrai;
        private PictureBox pbRobotPhai;
        private Panel pnCenter;
        private Panel pnBanQuyenLogoNhom;
        private Panel pnButtonPicture;
    }
}
