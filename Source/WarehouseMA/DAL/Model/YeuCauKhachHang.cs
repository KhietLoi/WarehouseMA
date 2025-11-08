using System;

namespace DAL.Model
{
    public class YeuCauKhachHang
    {
        // Private fields
        private string maYC;
        private string trangThaiXuLy;
        private DateTime ngayYeuCau;
        private int soLuongThungS;
        private int soLuongThungM;
        private int soLuongThungL;
        private float dungTich;
        private DateTime ngayHetHan;
        private bool vanChuyen;
        private string cccd;

        // Public properties with get and set accessors
        public string MaYC
        {
            get { return maYC; }
            set { maYC = value; }
        }

        public string TrangThaiXuLy
        {
            get { return trangThaiXuLy; }
            set { trangThaiXuLy = value; }
        }

        public DateTime NgayYeuCau
        {
            get { return ngayYeuCau; }
            set { ngayYeuCau = value; }
        }

        public int SoLuongThungS
        {
            get { return soLuongThungS; }
            set { soLuongThungS = value; }
        }

        public int SoLuongThungM
        {
            get { return soLuongThungM; }
            set { soLuongThungM = value; }
        }

        public int SoLuongThungL
        {
            get { return soLuongThungL; }
            set { soLuongThungL = value; }
        }

        public float DungTich
        {
            get { return dungTich; }
            set { dungTich = value; }
        }

        public DateTime NgayHetHan
        {
            get { return ngayHetHan; }
            set { ngayHetHan = value; }
        }

        public bool VanChuyen
        {
            get { return vanChuyen; }
            set { vanChuyen = value; }
        }

        public string CCCD
        {
            get { return cccd; }
            set { cccd = value; }
        }
    }
}
