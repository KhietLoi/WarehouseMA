using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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
using iText.Kernel.Geom;
using iText.Kernel.Pdf.Canvas.Draw;


namespace WarehouseMA.DAL
{
    public class YeuCauKhachHangDAL
    {
        private string ketNoi = "server=sql5.freesqldatabase.com;Database=sql5742970;Uid=sql5742970;Pwd=BPHD48Fx7i;Charset=utf8mb4";
        /*        public DataTable LayDuLieuTuDatabase()
                {
                    DataTable dt = new DataTable();
                    using (MySqlConnection conn = new MySqlConnection(ketNoi))
                    {
                        try
                        {
                            conn.Open();
                            string query = @"
                            SELECT 
                                MaYC, 
                                TrangThaiXuLy, 
                                NgayYeuCau, 
                                SoLuongThungS, 
                                SoLuongThungM, 
                                SoLuongThungL, 
                                DungTich, 
                                NgayHetHan, 
                                CCCD, 
                                CASE 
                                    WHEN VanChuyen = 1 THEN 'Có' 
                                    ELSE 'Không' 
                                END AS VanChuyen
                            FROM YeuCauKhachHang 
                            WHERE TrangThaiXuLy = 'Chưa duyệt'";

                            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                            adapter.Fill(dt);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Lỗi khi lấy dữ liệu: " + ex.Message);
                        }
                    }
                    return dt;
                }*/
        public DataTable LayDuLieuTuDatabase()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    string query = @"
            SELECT 
                MaYC, 
                TrangThaiXuLy, 
                DATE_FORMAT(NgayYeuCau, '%d/%m/%Y') AS NgayYeuCau, 
                SoLuongThungS, 
                SoLuongThungM, 
                SoLuongThungL, 
                DungTich, 
                DATE_FORMAT(NgayHetHan, '%d/%m/%Y') AS NgayHetHan, 
                CCCD, 
                CASE 
                    WHEN VanChuyen = 1 THEN 'Có' 
                    ELSE 'Không' 
                END AS VanChuyen
            FROM YeuCauKhachHang 
            WHERE TrangThaiXuLy = 'Chưa duyệt'";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi lấy dữ liệu: " + ex.Message);
                }
            }
            return dt;
        }


        public bool CapNhatTrangThai(string maYeuCauHienTai, string trangthaimoi)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ketNoi))
                {
                    conn.Open();
                    string query = "UPDATE YeuCauKhachHang SET TrangThaiXuLy = @trangthaimoi WHERE MaYC = @maYeuCauHienTai";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@trangthaimoi", trangthaimoi);
                        cmd.Parameters.AddWithValue("maYeuCauHienTai", maYeuCauHienTai);
                        cmd.ExecuteNonQuery();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Trả về true nếu có ít nhất một dòng được cập nhật
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật trạng thái: " + ex.Message);
            }
        }
        // gửi mail
        public (string Email, string TenKhachHang, DateTime NgayDangKy, int SoLuongThungS, int SoLuongThungM, int SoLuongThungL, DateTime NgayHetHan, int dungtich) LayThongTinYC(string maYeuCau)
        {
            string emailNguoiNhan = "";
            string tenKhachHang = "";
            DateTime ngayDangKy = DateTime.MinValue;
            int soLuongThungS = 0;
            int soLuongThungM = 0;
            int soLuongThungL = 0;
            int dungtich = 0;
            DateTime ngayHetHan = DateTime.MinValue;

            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT y.MaYC, y.TrangThaiXuLy, y.NgayYeuCau, y.SoLuongThungS, y.SoLuongThungM, y.SoLuongThungL, 
                                    y.DungTich, y.NgayHetHan, y.VanChuyen, k.TenKH, k.Email 
                                    FROM YeuCauKhachHang y
                                    INNER JOIN KhachHang k ON y.CCCD = k.CCCD
                                    WHERE y.MaYC = @maYeuCau AND y.TrangThaiXuLy = 'Đang xử lý'";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maYeuCau", maYeuCau);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                emailNguoiNhan = reader["Email"].ToString();
                                tenKhachHang = reader["TenKH"].ToString();
                                ngayDangKy = reader.GetDateTime(reader.GetOrdinal("NgayYeuCau"));
                                soLuongThungS = reader.GetInt32(reader.GetOrdinal("SoLuongThungS"));
                                soLuongThungM = reader.GetInt32(reader.GetOrdinal("SoLuongThungM"));
                                soLuongThungL = reader.GetInt32(reader.GetOrdinal("SoLuongThungL"));
                                ngayHetHan = reader.GetDateTime(reader.GetOrdinal("NgayHetHan"));
                                dungtich = reader.GetInt32(reader.GetOrdinal("DungTich"));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi lấy thông tin yêu cầu: " + ex.Message);
                }
            }

            return (emailNguoiNhan, tenKhachHang, ngayDangKy, soLuongThungS, soLuongThungM, soLuongThungL, ngayHetHan, dungtich);
        }

        /**Các hàm lấy dữ liệu theo yêu cầu
         * 1. Hàm tìm kiếm theo yêu cầu đang xử lí
         * 2. Hàm tìm kiếm theo yêu cầu đã hoãn thành
         * 3. Yêu cầu tìm kiếm theo yêu cầu đã từ chối 
         * 4. Yêu cầu tìm kiếm theo tất cả yêu cầu
         **/

        public DataTable LayDuLieuTuDatabase_dangxuli()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    string query = @"
                    SELECT 
                        MaYC, 
                        TrangThaiXuLy, 
                        DATE_FORMAT(NgayYeuCau, '%d/%m/%Y') AS NgayYeuCau,
                        SoLuongThungS, 
                        SoLuongThungM, 
                        SoLuongThungL, 
                        DungTich, 
                       	 DATE_FORMAT(NgayHetHan, '%d/%m/%Y') AS NgayHetHan, 
                        CCCD, 
                        CASE 
                            WHEN VanChuyen = 1 THEN 'Có' 
                            ELSE 'Không' 
                        END AS VanChuyen
                    FROM YeuCauKhachHang 
                    WHERE TrangThaiXuLy ='Đang xử lý'";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi lấy dữ liệu: " + ex.Message);
                }
            }
            return dt;
        }
        public DataTable LayDuLieuTuDatabase_tuchoi()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    string query = @"
                    SELECT 
                        MaYC, 
                        TrangThaiXuLy, 
                        DATE_FORMAT(NgayYeuCau, '%d/%m/%Y') AS NgayYeuCau, 
                        SoLuongThungS, 
                        SoLuongThungM, 
                        SoLuongThungL, 
                        DungTich, 
                        DATE_FORMAT(NgayHetHan, '%d/%m/%Y') AS NgayHetHan, 
                        CCCD, 
                        CASE 
                            WHEN VanChuyen = 1 THEN 'Có' 
                            ELSE 'Không' 
                        END AS VanChuyen
                    FROM YeuCauKhachHang 
                    WHERE TrangThaiXuLy ='Từ chối'";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi lấy dữ liệu: " + ex.Message);
                }
            }
            return dt;
        }
        public DataTable LayDuLieuTuDatabase_danhaphang()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                conn.Open();
                string query = @"
                    SELECT 
                        MaYC, 
                        TrangThaiXuLy, 
                        DATE_FORMAT(NgayYeuCau, '%d/%m/%Y') AS NgayYeuCau,  
                        SoLuongThungS, 
                        SoLuongThungM, 
                        SoLuongThungL, 
                        DungTich, 
                        DATE_FORMAT(NgayHetHan, '%d/%m/%Y') AS NgayHetHan,  
                        CCCD, 
                        CASE 
                            WHEN VanChuyen = 1 THEN 'Có' 
                            ELSE 'Không' 
                        END AS VanChuyen
                    FROM YeuCauKhachHang 
                    WHERE TrangThaiXuLy = 'Đã nhập hàng'";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }


            return dt;
        }
        public DataTable LayDuLieuTuDatabase_daruthang()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                conn.Open();
                string query = @"
                    SELECT 
                        MaYC, 
                        TrangThaiXuLy, 
                        DATE_FORMAT(NgayYeuCau, '%d/%m/%Y') AS NgayYeuCau,  
                        SoLuongThungS, 
                        SoLuongThungM, 
                        SoLuongThungL, 
                        DungTich, 
                        DATE_FORMAT(NgayHetHan, '%d/%m/%Y') AS NgayHetHan,  
                        CCCD, 
                        CASE 
                            WHEN VanChuyen = 1 THEN 'Có' 
                            ELSE 'Không' 
                        END AS VanChuyen
                    FROM YeuCauKhachHang 
                    WHERE TrangThaiXuLy = 'Đã rút hàng'";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }


            return dt;
        }
        public DataTable LayDuLieuTuDatabase_TatCa()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    string query = @"
                    SELECT 
                        MaYC, 
                        TrangThaiXuLy, 
                        DATE_FORMAT(NgayYeuCau, '%d/%m/%Y') AS NgayYeuCau,  
                        SoLuongThungS, 
                        SoLuongThungM, 
                        SoLuongThungL, 
                        DungTich, 
                        DATE_FORMAT(NgayHetHan, '%d/%m/%Y') AS NgayHetHan,
                        CCCD, 
                        CASE 
                            WHEN VanChuyen = 1 THEN 'Có' 
                            ELSE 'Không' 
                        END AS VanChuyen
                    FROM YeuCauKhachHang ";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi lấy dữ liệu: " + ex.Message);
                }
            }
            return dt;

        }
        /**
         * Chức năng tìm kiếm:
        **/
        public DataTable TimKiemChuaDuyet(string tuKhoa)
        {
            DataTable dt = new DataTable();

            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                tuKhoa = ""; // Hoặc thiết lập giá trị mặc định
            }

            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                conn.Open();

                string query = @"
       SELECT
    MaYC,
    TrangThaiXuLy,
    DATE_FORMAT(NgayYeuCau, '%d/%m/%Y') AS NgayYeuCau,
    SoLuongThungS,
    SoLuongThungM,
    SoLuongThungL,
    DungTich,
    DATE_FORMAT(NgayHetHan, '%d/%m/%Y') AS NgayHetHan,
    CCCD,
    CASE
        WHEN VanChuyen = 1 THEN 'Có'
        ELSE 'Không'
    END AS VanChuyen
FROM YeuCauKhachHang
WHERE TrangThaiXuLy = 'Chưa duyệt'
AND (
    LOWER(MaYC) LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR LOWER(TrangThaiXuLy) LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR LOWER(CCCD) LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR DATE_FORMAT(NgayYeuCau, '%d/%m/%Y') LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR SoLuongThungS LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR SoLuongThungL LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR SoLuongThungM LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR DungTich LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR DATE_FORMAT(NgayHetHan, '%d/%m/%Y') LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
)
";


                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tuKhoa", "%" + tuKhoa + "%");

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }

            return dt;
        }
        //Tìm kiếm theo  từng trạng thái khác:

        //Tìm kiếm đang xử lí
        public DataTable TimKiemDangXuLy(string tuKhoa)
        {
            DataTable dt = new DataTable();
            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                tuKhoa = ""; // Hoặc thiết lập giá trị mặc định
            }
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                conn.Open();


                string query = @"
  SELECT
    MaYC,
    TrangThaiXuLy,
    DATE_FORMAT(NgayYeuCau, '%d/%m/%Y') AS NgayYeuCau,
    SoLuongThungS,
    SoLuongThungM,
    SoLuongThungL,
    DungTich,
    DATE_FORMAT(NgayHetHan, '%d/%m/%Y') AS NgayHetHan,
    CCCD,
    CASE
        WHEN VanChuyen = 1 THEN 'Có'
        ELSE 'Không'
    END AS VanChuyen
FROM YeuCauKhachHang
WHERE TrangThaiXuLy = 'Đang xử lý'
AND (
    LOWER(MaYC) LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR LOWER(TrangThaiXuLy) LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR LOWER(CCCD) LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR DATE_FORMAT(NgayYeuCau, '%d/%m/%Y') LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR SoLuongThungS LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR SoLuongThungL LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR SoLuongThungM LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR DungTich LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR DATE_FORMAT(NgayHetHan, '%d/%m/%Y') LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
)
";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tuKhoa", "%" + tuKhoa + "%");

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }

            return dt;
        }
        //Tìm kiêm Đã nhập hàng
        public DataTable TimKiemDaNhapHang(string tuKhoa)
        {
            DataTable dt = new DataTable();
            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                tuKhoa = ""; // Hoặc thiết lập giá trị mặc định
            }
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                conn.Open();

                string query = @"
  SELECT
    MaYC,
    TrangThaiXuLy,
    DATE_FORMAT(NgayYeuCau, '%d/%m/%Y') AS NgayYeuCau,
    SoLuongThungS,
    SoLuongThungM,
    SoLuongThungL,
    DungTich,
    DATE_FORMAT(NgayHetHan, '%d/%m/%Y') AS NgayHetHan,
    CCCD,
    CASE
        WHEN VanChuyen = 1 THEN 'Có'
        ELSE 'Không'
    END AS VanChuyen
FROM YeuCauKhachHang
WHERE TrangThaiXuLy = 'Đã nhập hàng'
AND (
    LOWER(MaYC) LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR LOWER(TrangThaiXuLy) LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR LOWER(CCCD) LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR DATE_FORMAT(NgayYeuCau, '%d/%m/%Y') LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR SoLuongThungS LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR SoLuongThungL LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR SoLuongThungM LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR DungTich LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR DATE_FORMAT(NgayHetHan, '%d/%m/%Y') LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
)
";


                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tuKhoa", "%" + tuKhoa + "%");

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }

            return dt;
        }



        //Tìm kiêm Đã rút hàng
        public DataTable TimKiemDaRutHang(string tuKhoa)
        {
            DataTable dt = new DataTable();
            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                tuKhoa = ""; // Hoặc thiết lập giá trị mặc định
            }
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                conn.Open();

                string query = @"
                  SELECT
                    MaYC,
                    TrangThaiXuLy,
                    DATE_FORMAT(NgayYeuCau, '%d/%m/%Y') AS NgayYeuCau,
                    SoLuongThungS,
                    SoLuongThungM,
                    SoLuongThungL,
                    DungTich,
                    DATE_FORMAT(NgayHetHan, '%d/%m/%Y') AS NgayHetHan,
                    CCCD,
                    CASE
                        WHEN VanChuyen = 1 THEN 'Có'
                        ELSE 'Không'
                    END AS VanChuyen
                FROM YeuCauKhachHang
                WHERE TrangThaiXuLy = 'Đã rút hàng'
                AND (
                    LOWER(MaYC) LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
                    OR LOWER(TrangThaiXuLy) LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
                    OR LOWER(CCCD) LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
                    OR DATE_FORMAT(NgayYeuCau, '%d/%m/%Y') LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
                    OR SoLuongThungS LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
                    OR SoLuongThungL LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
                    OR SoLuongThungM LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
                    OR DungTich LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
                    OR DATE_FORMAT(NgayHetHan, '%d/%m/%Y') LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
                )
                ";


                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tuKhoa", "%" + tuKhoa + "%");

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }

            return dt;
        }
        //Tìm kiếm từ chối
        public DataTable TimKiemTuChoi(string tuKhoa)
        {
            DataTable dt = new DataTable();
            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                tuKhoa = ""; // Hoặc thiết lập giá trị mặc định
            }
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                conn.Open();


                string query = @"
  SELECT
    MaYC,
    TrangThaiXuLy,
    DATE_FORMAT(NgayYeuCau, '%d/%m/%Y') AS NgayYeuCau,
    SoLuongThungS,
    SoLuongThungM,
    SoLuongThungL,
    DungTich,
    DATE_FORMAT(NgayHetHan, '%d/%m/%Y') AS NgayHetHan,
    CCCD,
    CASE
        WHEN VanChuyen = 1 THEN 'Có'
        ELSE 'Không'
    END AS VanChuyen
FROM YeuCauKhachHang
WHERE TrangThaiXuLy = 'Từ chối'
AND (
    LOWER(MaYC) LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR LOWER(TrangThaiXuLy) LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR LOWER(CCCD) LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR DATE_FORMAT(NgayYeuCau, '%d/%m/%Y') LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR SoLuongThungS LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR SoLuongThungL LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR SoLuongThungM LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR DungTich LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR DATE_FORMAT(NgayHetHan, '%d/%m/%Y') LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
)
";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tuKhoa", "%" + tuKhoa + "%");

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }

            return dt;
        }
        //Tìm kiếm tất cả
        public DataTable TimKiemTatCa(string tuKhoa)
        {
            DataTable dt = new DataTable();
            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                tuKhoa = ""; // Hoặc thiết lập giá trị mặc định
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ketNoi))
                {
                    conn.Open();


                    string query = @"
  SELECT
    MaYC,
    TrangThaiXuLy,
    DATE_FORMAT(NgayYeuCau, '%d/%m/%Y') AS NgayYeuCau,
    SoLuongThungS,
    SoLuongThungM,
    SoLuongThungL,
    DungTich,
    DATE_FORMAT(NgayHetHan, '%d/%m/%Y') AS NgayHetHan,
    CCCD,
    CASE
        WHEN VanChuyen = 1 THEN 'Có'
        ELSE 'Không'
    END AS VanChuyen
FROM YeuCauKhachHang
WHERE  (
    LOWER(MaYC) LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR LOWER(TrangThaiXuLy) LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR LOWER(CCCD) LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR DATE_FORMAT(NgayYeuCau, '%d/%m/%Y') LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR SoLuongThungS LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR SoLuongThungL LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR SoLuongThungM LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR DungTich LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
    OR DATE_FORMAT(NgayHetHan, '%d/%m/%Y') LIKE LOWER(CONCAT('%', @tuKhoa, '%'))
)
";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@tuKhoa", "%" + tuKhoa + "%");

                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log lỗi hoặc hiển thị thông báo
                Console.WriteLine("Lỗi: " + ex.Message);
            }

            return dt;
        }

        // In excel
        public List<Dictionary<string, object>> GetDataByTrangThai(string trangThaiChon)
        {
            List<Dictionary<string, object>> ketQua = new List<Dictionary<string, object>>();

            // Xây dựng câu lệnh SQL tùy theo trạng thái
            string truyVan = @"SELECT
                MaYC,
                TrangThaiXuLy,
                DATE_FORMAT(NgayYeuCau, '%d/%m/%Y') AS NgayYeuCau,
                SoLuongThungS,
                SoLuongThungM,
                SoLuongThungL,
                DungTich,
                DATE_FORMAT(NgayHetHan, '%d/%m/%Y') AS NgayHetHan,
                CCCD,
                CASE
                    WHEN VanChuyen = 1 THEN 'Có'
                    ELSE 'Không'
                END AS VanChuyen
        FROM YeuCauKhachHang 
        WHERE 1 = 1 ";

            // Thêm điều kiện vào câu truy vấn nếu trạng thái khác "Tất cả"
            if (trangThaiChon != "Tất cả")
            {
                truyVan += " AND TrangThaiXuLy = @trangThaiXuLy";
            }

            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(truyVan, conn))
                {
                    if (trangThaiChon != "Tất cả")
                    {
                        cmd.Parameters.AddWithValue("@trangThaiXuLy", trangThaiChon);
                    }

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var dong = new Dictionary<string, object>
                            {
                                { "MaYC", reader["MaYC"] },
                                { "TrangThaiXuLy", reader["TrangThaiXuLy"] },
                                { "NgayYeuCau", reader["NgayYeuCau"] },
                                { "SoLuongThungS", reader["SoLuongThungS"] },
                                { "SoLuongThungM", reader["SoLuongThungM"] },
                                { "SoLuongThungL", reader["SoLuongThungL"] },
                                { "DungTich", reader["DungTich"] },
                                { "NgayHetHan", reader["NgayHetHan"] },
                                { "VanChuyen", reader["VanChuyen"] },
                                { "CCCD", reader["CCCD"] }
                            };
                            ketQua.Add(dong);
                        }
                    }
                }
            }

            return ketQua;
        }
        // lấy yêu cầu kiểm tra 
        public string GetTrangThaiYeuCau(string maYeuCau)
        {
            string trangThai = ""; // Mặc định trả về chuỗi trống

            string truyVan = @"SELECT TrangThaiXuLy FROM YeuCauKhachHang WHERE MaYC = @maYeuCau";

            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(truyVan, conn))
                {
                    cmd.Parameters.AddWithValue("@maYeuCau", maYeuCau);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            trangThai = reader["TrangThaiXuLy"].ToString();
                        }
                    }
                }
            }

            return trangThai;
        }
        //In va xuat: (26/11/2024)
        public void XuatPhieuNhapToPDF(string maYeuCau, string filePath)
        {
            try
            {
                // Câu truy vấn lấy thông tin từ cả 2 bảng YeuCauKhachHang và KhachHang, và thêm thông tin thùng từ bảng Thung
                string truyVan = @"
SELECT yc.*, kh.TenKH, kh.DiaChi, kh.SoDienThoai, kh.Email, t.MaNgan, t.temSo 
FROM YeuCauKhachHang yc
JOIN KhachHang kh ON yc.CCCD = kh.CCCD
LEFT JOIN Thung t ON yc.MaYC = t.MaYC 
WHERE yc.MaYC = @maYeuCau";

                using (MySqlConnection conn = new MySqlConnection(ketNoi))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(truyVan, conn))
                    {
                        cmd.Parameters.AddWithValue("@maYeuCau", maYeuCau);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // Nếu tìm thấy yêu cầu
                            {
                                // Đường dẫn font Arial Unicode và font đậm
                                string fontPathRegular = @"C:\Windows\Fonts\arial.ttf"; // Font thường
                                string fontPathBold = @"C:\Windows\Fonts\arialbd.ttf"; // Font đậm
                                PdfFont fontRegular = PdfFontFactory.CreateFont(fontPathRegular, PdfEncodings.IDENTITY_H);
                                PdfFont fontBold = PdfFontFactory.CreateFont(fontPathBold, PdfEncodings.IDENTITY_H);

                                // Tạo file PDF
                                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                                {
                                    PdfWriter writer = new PdfWriter(fs);
                                    PdfDocument pdf = new PdfDocument(writer);
                                    Document document = new Document(pdf, PageSize.A4);

                                    // Set margins (top, bottom, left, right)
                                    document.SetMargins(36, 36, 36, 36); // Adjust these values as necessary

                                    // Tiêu đề chính
                                    document.Add(
                                        new Paragraph("PHIẾU GỬI HÀNG")
                                            .SetTextAlignment(TextAlignment.CENTER)
                                            .SetFont(fontBold)
                                            .SetFontSize(22)
                                    );

                                    // Thông tin công ty
                                    document.Add(
                                        new Paragraph("WarehouseMA - QUẢN LÝ KHO")
                                            .SetTextAlignment(TextAlignment.CENTER)
                                            .SetFont(fontRegular)
                                            .SetFontSize(12)
                                    );
                                    LineSeparator ls = new LineSeparator(new SolidLine());
                                    document.Add(ls);

                                    document.Add(new Paragraph("\n"));

                                    // Thông tin khách hàng (được thay thế bằng các Paragraph)
                                    document.Add(new Paragraph("Tên Khách Hàng: ")
                                        .SetFont(fontBold).Add(new Text(reader["TenKH"].ToString()).SetFont(fontRegular)));
                                    document.Add(new Paragraph("Địa Chỉ: ")
                                        .SetFont(fontBold).Add(new Text(reader["DiaChi"].ToString()).SetFont(fontRegular)));
                                    document.Add(new Paragraph("Số Điện Thoại: ")
                                        .SetFont(fontBold).Add(new Text(reader["SoDienThoai"].ToString()).SetFont(fontRegular)));
                                    document.Add(new Paragraph("Email: ")
                                        .SetFont(fontBold).Add(new Text(reader["Email"].ToString()).SetFont(fontRegular)));
                                    document.Add(new Paragraph("Căn Cước Công Dân: ")
                                      .SetFont(fontBold).Add(new Text(reader["CCCD"].ToString()).SetFont(fontRegular)));
                                    document.Add(new Paragraph("WarehouseMA xin chân thành cảm ơn bạn đã lựa chọn tin tưởng gửi hàng hóa của mình ở chúng tôi.Sau đây là thông tin chi tiết về hàng hóa của bạn:")
                                     .SetFont(fontRegular)
                                    .SetFontSize(13));


                                    // Thông tin phiếu gửi
                                    document.Add(new Paragraph("Mã Yêu Cầu: ")
                                        .SetFont(fontBold).Add(new Text(reader["MaYC"].ToString()).SetFont(fontRegular)));
                                    document.Add(new Paragraph("Ngày Gửi: ")
                                        .SetFont(fontBold).Add(new Text(Convert.ToDateTime(reader["NgayYeuCau"]).ToString("dd/MM/yyyy HH:mm:ss")).SetFont(fontRegular)));
                                    document.Add(new Paragraph("Ngày Dự Kiến Lấy Hàng: ")
                                        .SetFont(fontBold).Add(new Text(Convert.ToDateTime(reader["NgayHetHan"]).ToString("dd/MM/yyyy HH:mm:ss")).SetFont(fontRegular)));

                                    document.Add(new Paragraph("\n"));

                                    // Thông tin hàng hóa gửi (dùng Paragraph thay thế Table)

                                    document.Add(new Paragraph("Vị Trí Lưu Kho: ").SetFont(fontBold));

                                    // Tiếp tục thêm thông tin về thùng (tem số và vị trí)
                                    do
                                    {
                                        string maNgan = reader["MaNgan"].ToString();
                                        string temSo = reader["temSo"].ToString();

                                        if (!string.IsNullOrEmpty(maNgan) && !string.IsNullOrEmpty(temSo))
                                        {
                                            document.Add(new Paragraph($"Thùng: {temSo}, Vị trí: {maNgan}")
                                                .SetFont(fontRegular));
                                        }

                                    } while (reader.Read()); // Tiến tới thùng tiếp theo nếu có

                                    /*      document.Add(new Paragraph("\n"));*/
                                    // Đoạn văn bản thêm ở cuối
                                    document.Add(new Paragraph("Mọi vấn đề khó khăn về gửi nhận hàng hóa, quý khách vui lòng liên hệ số hotline 038 995 0228 để được tư vấn chi tiết.")
                                        .SetFont(fontRegular)
                                        .SetFontSize(13)
                                        .SetTextAlignment(TextAlignment.LEFT));

                                    // Header và Footer
                                    string headerContent = $"Phiếu gửi hàng: {maYeuCau} | An toàn - hiệu quả - nhanh chóng";
                                    string footerNote = "WarehouseMA";

                                    int totalPages = pdf.GetNumberOfPages();
                                    for (int i = 1; i <= totalPages; i++)
                                    {
                                        PdfPage page = pdf.GetPage(i);
                                        PdfCanvas canvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdf);

                                        // Header
                                        canvas.BeginText();
                                        canvas.SetFontAndSize(fontRegular, 10);
                                        canvas.MoveText(34, page.GetPageSize().GetTop() - 20); // Vị trí Header
                                        canvas.ShowText(headerContent);
                                        canvas.EndText();

                                        // Footer
                                        canvas.BeginText();
                                        canvas.SetFontAndSize(fontRegular, 10);
                                        canvas.MoveText(34, 20); // Vị trí Footer bên trái
                                        canvas.ShowText(footerNote);

                                        // Hiển thị số trang ở Footer bên phải
                                        canvas.MoveText(page.GetPageSize().GetWidth() - 100, 0); // Điều chỉnh vị trí số trang
                                        canvas.ShowText($"Trang {i}/{totalPages}");

                                        canvas.EndText();
                                    }

                                    document.Close();
                                }

                                Console.WriteLine("Phiếu gửi đã được xuất thành công!");
                            }
                            else
                            {
                                Console.WriteLine("Không tìm thấy mã yêu cầu.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
        }
        //Yêu cầu khách hàng cập nhật giá  tiền thanh toán ban đầu(27/11/2024): 
        public void CapNhatGiaThanhToan(string maYeuCau, decimal tongTien)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ketNoi))
                {
                    conn.Open();
                    string query = "UPDATE YeuCauKhachHang SET GiaThanhToan = @GiaThanhToan WHERE MaYC = @MaYC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@GiaThanhToan", tongTien);
                        cmd.Parameters.AddWithValue("@MaYC", maYeuCau);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật GiaThanhToan: " + ex.Message);
            }
        }



    }

}
