using DAL.Model;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg.OpenPgp;
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
using System.Collections;



namespace WarehouseMA.DAL
{
    public class QuanLyKhoDAL
    {
        private string ketNoi = "server=sql5.freesqldatabase.com;Database=sql5742970;Uid=sql5742970;Pwd=BPHD48Fx7i;Charset=utf8mb4";

        public void CapNhatTrangThaiKe(string maKe, string trangThaiMoi)
        {
            using (MySqlConnection conn = new MySqlConnection(ketNoi)) // ketNoi là chuỗi kết nối
            {
                conn.Open(); // Mở kết nối
                string query = "UPDATE KeChoThue SET TrangThai = @TrangThai WHERE MaKe = @MaKe";
                using (MySqlCommand cmd = new MySqlCommand(query, conn)) // Truyền đối tượng conn
                {
                    cmd.Parameters.AddWithValue("@TrangThai", trangThaiMoi);
                    cmd.Parameters.AddWithValue("@MaKe", maKe);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable LayDuLieuKhoNoiBo()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    string query = @"
                    SELECT 
                        MaKho as 'Mã kho',
                        ChucNang as 'Chức năng'
                    FROM KhoNoiBo 
                    ";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return dt;
                }
            }
            return dt;
        }

        public DataTable LayDuLieuKhoChoThue()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    string query = @"
                    SELECT 
                        MaKho as 'Mã kho',
                        DungTichKhaDung 'Dung tích khả dụng',
                        DungTichDaDung as 'Dung tích đã dùng'
                    FROM KhoChoThue 
                    ";
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


        //public DataTable LayDuLieuKho()
        //{
        //    DataTable dt = new DataTable();
        //    using (MySqlConnection conn = new MySqlConnection(ketNoi))
        //    {
        //        try
        //        {
        //            conn.Open();
        //            string query = @"
        //            SELECT 
        //                MaKho,
        //                MaNhanVien
        //            FROM Kho
        //            ";
        //            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
        //            adapter.Fill(dt);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception("Lỗi khi lấy dữ liệu: " + ex.Message);
        //        }
        //    }
        //    return dt;
        //}

        public DataTable LayDuLieuKeNoiBo()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    string query = @"
            SELECT 
                MaKe as 'Mã kệ',
                MaKho as 'Mã kho'
            FROM KeNoiBo
            ";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi lấy dữ liệu: " + ex.Message);
                }
            }
            return dt;
        }


        public DataTable LayDuLieuKeChoThue()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    string query = @"
            SELECT 
                MaKe as 'Mã kệ', 
                MaKho as 'Mã kho' ,
                DungTichDaDung as 'Dung tích đã dùng', 
                DungTichKhaDung as 'Dung tích khả dụng',
                TrangThai as 'Trạng thái'
            FROM KeChoThue
            ";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi lấy dữ liệu: " + ex.Message);
                }
            }
            return dt;
        }


        public DataTable LayDuLieuTang()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    string query = @"
            SELECT 
                MaTang as 'Mã tầng',
                MaKe as 'Mã kệ',
                DungTichDaDung as 'Dung tích đã dùng',
                DungTichKhaDung as 'Dung tích khả dụng'
            FROM Tang
            ";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi lấy dữ liệu: " + ex.Message);
                }
            }
            return dt;
        }

        public DataTable LayDuLieuNgan()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    string query = @"
            SELECT 
                MaNgan as 'Mã ngăn',
                DungTichDaDung as 'Dung tích đã dùng',
                DungTichKhaDung as 'Dung tích khả dụng',
                MaTang as 'Mã tầng'
            FROM Ngan
            ";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi lấy dữ liệu: " + ex.Message);
                }
            }
            return dt;
        }

        public DataTable LayDuLieuThung()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    MaThung as 'Mã thùng',
                    MaYC as 'Mã yêu cầu',
                    MaNgan as 'Mã ngăn',
                    TemSo as 'Tem số',
                    TrangThai as 'Trạng thái', 
                    DungTich as 'Dung tích',
                    NgayNhapKho as 'Ngày nhập kho',
                    MaNV as 'Mã nhân viên',
                    MoTaHangHoa as 'Mô tả hàng hóa',
                    NgayGiaHan as 'Ngày gia hạn'
                FROM Thung
            ";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return dt;
        }



        public DataTable LayDuLieuHangHoaNoiBo()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    string query = @"
                    SELECT 
                        MaHangHoa as 'Mã hàng hóa', MaKe as 'Mã kệ', DonViTinh as 'Đơn vị tính',SoLuong as 'Số lượng',MoTaHangHoa as 'Mô tả hàng hóa'
                    FROM HangHoaNoiBo
                    ";
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



        public string NapDuLieuVaoKhoNoiBo(string maNhanVien, string maKho, string chucNang)
        {
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO Kho (MaKho, MaNV) VALUES (@MaKho, @MaNhanVien)";
                    string query1 = @"INSERT INTO KhoNoiBo (MaKho, ChucNang) VALUES (@MaKho, @ChucNang)";
                    string query2 = @"select count(*) from Kho where MaKho = @MaKho"; // kiểm tra mã kho có tồn tại chưa
                    string query3 = @"select count(*) from NhanVienKho where MaNV = @MaNV"; // kiểm tra mã kho có tồn tại chưa


                    // kiểm tra mã kho
                    using (MySqlCommand cmd2 = new MySqlCommand(query2, conn))
                    {
                        // Thêm tham số để tránh SQL Injection
                        cmd2.Parameters.AddWithValue("@MaKho", maKho);
                        int countKho = Convert.ToInt32(cmd2.ExecuteScalar());

                        if (countKho > 0)
                        {
                            Console.WriteLine("Mã kho đã tồn tại");
                            return "Mã kho đã tồn tại";
                        }
                    }


                    // kiểm tra mã nhân viên
                    using (MySqlCommand cmd3 = new MySqlCommand(query3, conn))
                    {
                        // Thêm tham số để tránh SQL Injection
                        cmd3.Parameters.AddWithValue("@MaNV", maNhanVien);
                        int countNhanVien = Convert.ToInt32(cmd3.ExecuteScalar());

                        if (countNhanVien == 0)
                        {
                            Console.WriteLine("Mã nhân viên không tồn tại");
                            return "Mã nhân viên không tồn tại";
                        }
                    }


                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        // Thêm tham số để tránh SQL Injection
                        command.Parameters.AddWithValue("@MaKho", maKho);
                        command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);

                        // Thực thi lệnh
                        int rowsAffected = command.ExecuteNonQuery();
                    }

                    using (MySqlCommand command = new MySqlCommand(query1, conn))
                    {
                        // Thêm tham số để tránh SQL Injection
                        command.Parameters.AddWithValue("@MaKho", maKho);
                        command.Parameters.AddWithValue("@ChucNang", chucNang);

                        // Thực thi lệnh
                        int rowsAffected = command.ExecuteNonQuery();
                    }

                    return "Thêm thành công";


                }
                catch (Exception ex)
                {
                    return ("Lỗi khi lấy dữ liệu: ") +  ex.Message;

                }
            }
        }



        public string NapDuLieuVaoKhoChoThue(string maNhanVien, string maKho, float dungTichKhaDung, float dungTichDaDung)
        {
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO Kho (MaKho, MaNV) VALUES (@MaKho, @MaNhanVien)";
                    string query1 = @"INSERT INTO KhoChoThue (MaKho, DungTichDaDung,DungTichKhaDung) VALUES (@MaKho, @DungTichDaDung,@DungTichKhaDung)";
                    string query2 = @"select count(*) from Kho where MaKho = @MaKho"; // kiểm tra mã kho có tồn tại chưa
                    string query3 = @"select count(*) from NhanVienKho where MaNV = @MaNV"; // kiểm tra mã kho có tồn tại chưa

                    // kiểm tra mã kho
                    using (MySqlCommand cmd2 = new MySqlCommand(query2, conn))
                    {
                        // Thêm tham số để tránh SQL Injection
                        cmd2.Parameters.AddWithValue("@MaKho", maKho);
                        int countKho = Convert.ToInt32(cmd2.ExecuteScalar());

                        if (countKho > 0)
                        {
                            //Console.WriteLine("Mã kho đã tồn tại");
                            return "Mã kho đã tồn tại";
                        }
                    }

                    // kiểm tra mã nhân viên
                    using (MySqlCommand cmd3 = new MySqlCommand(query3, conn))
                    {
                        // Thêm tham số để tránh SQL Injection
                        cmd3.Parameters.AddWithValue("@MaNV", maNhanVien);
                        int countNhanVien = Convert.ToInt32(cmd3.ExecuteScalar());

                        if (countNhanVien == 0)
                        {
                            Console.WriteLine("Mã nhân viên không tồn tại");
                            return "Mã nhân viên không tồn tại";
                        }
                    }


                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        // Thêm tham số để tránh SQL Injection
                        command.Parameters.AddWithValue("@MaKho", maKho);
                        command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);

                        // Thực thi lệnh
                        int rowsAffected = command.ExecuteNonQuery();
                    }

                    using (MySqlCommand command = new MySqlCommand(query1, conn))
                    {
                        // Thêm tham số để tránh SQL Injection
                        command.Parameters.AddWithValue("@MaKho", maKho);
                        command.Parameters.AddWithValue("@DungTichDaDung", dungTichDaDung);
                        command.Parameters.AddWithValue("@DungTichKhaDung", dungTichKhaDung);
                        // Thực thi lệnh
                        int rowsAffected = command.ExecuteNonQuery();
                    }

                    return "Thêm thành công";


                }
                catch (Exception ex)
                {
                    //throw new Exception("Lỗi khi lấy dữ liệu: " + ex.Message);
                    return "Lỗi khi lấy dữ liệu :" + ex.Message;
                }
            }
        }


        public string NapDuLieuVaoKeNoiBo(string maKho)
        {
            using  (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO KeNoiBo  (MaKho, MaKe) values (@MaKho, @MaKe)";
                    string query1 = "SELECT COUNT(*) FROM KeNoiBo WHERE MaKho = @MaKho";
                    string query2 = "SELECT COUNT(*) FROM KhoNoiBo WHERE MaKho = @MaKho";
                    var count = 0;


                    // Kiểm tra xem Mã kho có tồn tại trong bảng kho nội bộ hay ko
                    using (MySqlCommand cmd2 = new MySqlCommand(query2, conn))
                    {

                        cmd2.Parameters.AddWithValue("@MaKho", maKho);
                        int countKhoNoiBo = Convert.ToInt32(cmd2.ExecuteScalar());

                        if ( countKhoNoiBo == 0)
                        {
                            //Console.WriteLine("Mã kho không tồn tại");
                            return "Mã kho không tồn tại";
                        }
                    }

                   

                    // Nếu có đếm số kệ nằm trong kho nội bộ đó và + 1
                    using (MySqlCommand cmd1 = new MySqlCommand(query1, conn))
                    {
                        cmd1.Parameters.AddWithValue("@MaKho", maKho);
                        int countKeNoiBo = Convert.ToInt32(cmd1.ExecuteScalar());
                        count = countKeNoiBo + 1;
                    }




                    // Thực hiện tải dữ liệu lên database
                    using (MySqlCommand cmd3 = new MySqlCommand(query, conn))
                    {
                        var maKe = maKho + "_" + count.ToString();
                        cmd3.Parameters.AddWithValue("@MaKho", maKho);
                        cmd3.Parameters.AddWithValue("@MaKe", maKe);
                        int rowsAffected = cmd3.ExecuteNonQuery();
                    }


                    return "Thêm thành công";


                }
                catch (Exception ex)
                {
                    //throw new Exception("Lỗi khi lấy dữ liệu: " + ex.Message);
                    return "Lỗi khi lấy dữ liệu: " + ex.Message;
                }
            }
        }



        public string NapDuLieuVaoHangHoaNoiBo(string maKe, string donViTinh, string moTaHangHoa, int soLuong)
        {
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();

                    string query = @"INSERT INTO HangHoaNoiBo  (MaHangHoa, SoLuong,DonViTinh,MoTaHangHoa,MaKe) VALUES (@MaHangHoa, @SoLuong,@DonViTinh,@MoTaHangHoa,@MaKe)";
                    string query1 = "SELECT COUNT(*) FROM HangHoaNoiBo where MaKe = @Make";
                    string query2 = "SELECT COUNT(*) FROM KeNoiBo WHERE MaKe = @MaKe";
                    var count = 0;


                    // Kiểm tra xem Mã Kệ có tồn tại trong bảng kệ nội bộ hay ko
                    using (MySqlCommand cmd2 = new MySqlCommand(query2, conn))
                    {

                        cmd2.Parameters.AddWithValue("@MaKe", maKe);
                        int countKeNoiBo = Convert.ToInt32(cmd2.ExecuteScalar());

                        if (countKeNoiBo == 0)
                        {
                            Console.WriteLine("Mã kệ không tồn tại");
                            return "Mã kệ không tồn tại";
                        }
                    }


                    // Nếu có thì tự phát sinh mã hàng hóa nội bộ
                    using (MySqlCommand cmd1 = new MySqlCommand(query1, conn))
                    {
                        cmd1.Parameters.AddWithValue("@MaKe", maKe);
                        int countHangHoaNoiBo = Convert.ToInt32(cmd1.ExecuteScalar());
                        count = countHangHoaNoiBo + 1;
                    }



                    // Thực hiện tải dữ liệu lên database
                    using (MySqlCommand cmd3 = new MySqlCommand(query, conn))
                    {
                        var maHangHoa = maKe + "_" + count.ToString();
                        cmd3.Parameters.AddWithValue("@MaHangHoa", maHangHoa);
                        cmd3.Parameters.AddWithValue("@SoLuong", soLuong);
                        cmd3.Parameters.AddWithValue("@DonViTinh", donViTinh);
                        cmd3.Parameters.AddWithValue("@MaKe", maKe);
                        cmd3.Parameters.AddWithValue("@MoTahangHoa", moTaHangHoa);
                        int rowsAffected = cmd3.ExecuteNonQuery();
                    }


                    Console.WriteLine("Thêm thành công");
                    return "Thêm thành công";


                }
                catch (Exception ex)
                {
                    return "Lỗi khi lấy dữ liệu: " + ex.Message;
                }
            }
        }





        //public string NapDuLieuVaoKeChoThue(string maKho, float dungTichKhaDung )
        //{
        //    using (MySqlConnection conn = new MySqlConnection(ketNoi))
        //    {
        //        try
        //        {
        //            conn.Open();
        //            float dungTichKhaDungKho = 0f;
        //            float sumDungTichKe = 0f;

        //            string query = @"INSERT INTO KeChoThue  (MaKho,DungTichKhaDung,DungTichDaDung,MaKe) VALUES (@MaKho, @DungTichKhaDung,@DungTichDaDung,@MaKe)";
        //            string query1 = "SELECT DungTichKhaDung FROM KhoChoThue where MaKho = @MaKho";
        //            string query3 = "SELECT sum(DungTichKhaDung) FROM KeChoThue where MaKho = @MaKho";
        //            string query2 = "SELECT COUNT(*) FROM KhoChoThue WHERE MaKho = @MaKho";
        //            string query4 = "SELECT COUNT(*) FROM KeChoThue WHERE MaKho = @MaKho";
        //            var count = 0;


        //            // Kiểm tra xem Mã Kho có tồn tại trong bảng kho cho thuê hay ko
        //            using (MySqlCommand cmd2 = new MySqlCommand(query2, conn))
        //            {

        //                cmd2.Parameters.AddWithValue("@MaKho", maKho);
        //                int countKho = Convert.ToInt32(cmd2.ExecuteScalar());

        //                if (countKho == 0)
        //                {
        //                    Console.WriteLine("Mã kho không tồn tại");
        //                    return "Mã kho không tồn tại";
        //                }
        //            }


        //            // Nếu có, kiểm tra dung tích kho đó có đủ để thêm kệ hay ko
        //            // Lấy dung tích khả dụng của kho đó
        //            using (MySqlCommand cmd1 = new MySqlCommand(query1, conn))
        //            {

        //                cmd1.Parameters.AddWithValue("@MaKho", maKho);
        //                object result = cmd1.ExecuteScalar();
        //                if (result != null && result != DBNull.Value)
        //                {
        //                    dungTichKhaDungKho = float.Parse(result.ToString());
        //                }
        //                else
        //                {
        //                    return "Lỗi khi kiểm tra dung tích";
        //                }
        //            }

        //            // Lấy tổng dung tích kệ của kho đó
        //            using (MySqlCommand cmd3 = new MySqlCommand(query3, conn))
        //            {

        //                cmd3.Parameters.AddWithValue("@MaKho", maKho);
        //                object result = cmd3.ExecuteScalar();
        //                if (result != null && result != DBNull.Value)
        //                {
        //                    sumDungTichKe = Convert.ToSingle(result); // Hoặc float.Parse(result.ToString());
        //                }
        //                else
        //                {
        //                    sumDungTichKe = 0;
        //                }    


        //            }

        //            if (dungTichKhaDung > ( dungTichKhaDungKho - sumDungTichKe))
        //            {
        //                Console.WriteLine("Dung tích kho ko đủ để thêm kệ này");
        //                return"Dung tích kho kho đủ để them kệ này" ;
        //            }




        //            // Nếu ok hết thì đếm số kệ trong kho đó ròi + 1
        //            using (MySqlCommand cmd4 = new MySqlCommand(query4, conn))
        //            {
        //                cmd4.Parameters.AddWithValue("@MaKho", maKho);
        //                int countKe = Convert.ToInt32(cmd4.ExecuteScalar());
        //                count = countKe + 1;
        //            }



        //            // Thêm dữ liệu vào database
        //            using (MySqlCommand cmd = new MySqlCommand(query, conn))
        //            {
        //                string maKe = maKho + "_" + count.ToString();
        //                cmd.Parameters.AddWithValue("@MaKho", maKho);
        //                cmd.Parameters.AddWithValue("@MaKe", maKe);
        //                cmd.Parameters.AddWithValue("@DungTichKhaDung", dungTichKhaDung);
        //                cmd.Parameters.AddWithValue("@DungTichDaDung", 0);
        //                int rowsAffected = cmd.ExecuteNonQuery();
        //            }

        //            Console.WriteLine("Thêm thành công");
        //            return "Thêm thành công";

        //        }
        //        catch (Exception ex)
        //        {
        //            return "Lỗi khi thêm dữ liệu: " + ex.Message;
        //        }
        //    }
        //}

        public string NapDuLieuVaoKeChoThue(string maKho, float dungTichKhaDung)
        {
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    float dungTichKhaDungKho = 0f;
                    float sumDungTichKe = 0f;

                    string query = @"INSERT INTO KeChoThue  (MaKho,DungTichKhaDung,DungTichDaDung,MaKe,TrangThai) VALUES (@MaKho, @DungTichKhaDung,@DungTichDaDung,@MaKe,@TrangThai)";
                    string query1 = "SELECT (DungTichKhaDung + DungTichDaDung) FROM KhoChoThue where MaKho = @MaKho";
                    string query3 = "SELECT sum(DungTichKhaDung + DungTichDaDung) FROM KeChoThue where MaKho = @MaKho";
                    string query2 = "SELECT COUNT(*) FROM KhoChoThue WHERE MaKho = @MaKho";
                    string query4 = "SELECT COUNT(*) FROM KeChoThue WHERE MaKho = @MaKho";
                    var count = 0;


                    // Kiểm tra xem Mã Kho có tồn tại trong bảng kho cho thuê hay ko
                    using (MySqlCommand cmd2 = new MySqlCommand(query2, conn))
                    {

                        cmd2.Parameters.AddWithValue("@MaKho", maKho);
                        int countKho = Convert.ToInt32(cmd2.ExecuteScalar());

                        if (countKho == 0)
                        {
                            Console.WriteLine("Mã kho không tồn tại");
                            return "Mã kho không tồn tại";
                        }
                    }


                    // Nếu có, kiểm tra dung tích kho đó có đủ để thêm kệ hay ko
                    // Lấy dung tích khả dụng của kho đó
                    using (MySqlCommand cmd1 = new MySqlCommand(query1, conn))
                    {

                        cmd1.Parameters.AddWithValue("@MaKho", maKho);
                        object result = cmd1.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            dungTichKhaDungKho = float.Parse(result.ToString());
                        }
                        else
                        {
                            return "Lỗi khi kiểm tra dung tích";
                        }
                    }

                    // Lấy tổng dung tích kệ của kho đó
                    using (MySqlCommand cmd3 = new MySqlCommand(query3, conn))
                    {

                        cmd3.Parameters.AddWithValue("@MaKho", maKho);
                        object result = cmd3.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            sumDungTichKe = Convert.ToSingle(result); // Hoặc float.Parse(result.ToString());
                        }
                        else
                        {
                            sumDungTichKe = 0;
                        }


                    }

                    if (dungTichKhaDung > (dungTichKhaDungKho - sumDungTichKe))
                    {
                        Console.WriteLine("Dung tích kho ko đủ để thêm kệ này");
                        return "Dung tích kho kho đủ để them kệ này";
                    }




                    // Nếu ok hết thì đếm số kệ trong kho đó ròi + 1
                    using (MySqlCommand cmd4 = new MySqlCommand(query4, conn))
                    {
                        cmd4.Parameters.AddWithValue("@MaKho", maKho);
                        int countKe = Convert.ToInt32(cmd4.ExecuteScalar());
                        count = countKe + 1;
                    }



                    // Thêm dữ liệu vào database
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        string maKe = maKho + "_" + count.ToString();
                        cmd.Parameters.AddWithValue("@MaKho", maKho);
                        cmd.Parameters.AddWithValue("@MaKe", maKe);
                        cmd.Parameters.AddWithValue("@DungTichKhaDung", dungTichKhaDung);
                        cmd.Parameters.AddWithValue("@DungTichDaDung", 0);
                        cmd.Parameters.AddWithValue("@TrangThai", "Sẵn sàng");
                        int rowsAffected = cmd.ExecuteNonQuery();
                    }

                    Console.WriteLine("Thêm thành công");
                    return "Thêm thành công";

                }
                catch (Exception ex)
                {
                    return "Lỗi khi thêm dữ liệu: " + ex.Message;
                }
            }
        }





        ///////////////////////////////////////////////////////////////////////////// ĐANG LÀM CHỖ NÀY
        //public string NapDuLieuVaoTang(string maKe, float dungTichKhaDung)
        //{
        //    using (MySqlConnection conn = new MySqlConnection(ketNoi))
        //    {
        //        try
        //        {
        //            conn.Open();
        //            float dungTichKhaDungKe = 0f;
        //            float sumDungTichTang = 0f;

        //            string query = @"INSERT INTO Tang  (MaTang,DungTichKhaDung,DungTichDaDung,MaKe) VALUES (@MaTang, @DungTichKhaDung,@DungTichDaDung,@MaKe)";
        //            string query1 = "SELECT DungTichKhaDung FROM KeChoThue where MaKe = @MaKe";
        //            string query3 = "SELECT sum(DungTichKhaDung) FROM Tang where MaKe = @MaKe";
        //            string query2 = "SELECT COUNT(*) FROM KeChoThue WHERE MaKe = @MaKe"; // kiểm tra khóa ngoại có tồn tại ko
        //            string query4 = "SELECT COUNT(*) FROM Tang WHERE MaKe = @MaKe";  // đếm để tạo mã chính +1
        //            var count = 0;


        //            // Kiểm tra xem Mã kệ có tồn tại trong bảng kệ cho thuê hay ko
        //            using (MySqlCommand cmd2 = new MySqlCommand(query2, conn))
        //            {

        //                cmd2.Parameters.AddWithValue("@MaKe", maKe);
        //                int countKe = Convert.ToInt32(cmd2.ExecuteScalar());

        //                if (countKe == 0)
        //                {
        //                    Console.WriteLine("Mã kệ không tồn tại");
        //                    return "Mã kệ không tồn tại";
        //                }
        //            }


        //            // Nếu có, kiểm tra dung tích kệ đó có đủ để thêm tầng hay ko
        //            // Lấy dung tích khả dụng của kệ đó
        //            using (MySqlCommand cmd1 = new MySqlCommand(query1, conn))
        //            {

        //                cmd1.Parameters.AddWithValue("@MaKe", maKe);
        //                object result = cmd1.ExecuteScalar();
        //                if (result != null && result != DBNull.Value)
        //                {
        //                    dungTichKhaDungKe = float.Parse(result.ToString());
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Lỗi khi kiểm tra dung tích khả dụng");
        //                    return "Lỗi khi kiểm tra dung tích khả dụng";
        //                }
        //            }

        //            // Lấy tổng dung tích tầng của kệ đó
        //            using (MySqlCommand cmd3 = new MySqlCommand(query3, conn))
        //            {

        //                cmd3.Parameters.AddWithValue("@MaKe", maKe);
        //                object result = cmd3.ExecuteScalar();
        //                if (result != null && result != DBNull.Value)
        //                {
        //                    sumDungTichTang = Convert.ToSingle(result); // Hoặc float.Parse(result.ToString());
        //                }
        //                else
        //                {
        //                    sumDungTichTang = 0;
        //                }


        //            }

        //            if (dungTichKhaDung > (dungTichKhaDungKe - sumDungTichTang))
        //            {
        //                Console.WriteLine("Dung tích kệ ko đủ để thêm tầng này");
        //                return "Dung tích kệ không đủ để thêm tầng này";
        //            }




        //            // Nếu ok hết thì đếm số kệ trong kho đó ròi + 1
        //            using (MySqlCommand cmd4 = new MySqlCommand(query4, conn))
        //            {
        //                cmd4.Parameters.AddWithValue("@MaKe", maKe);
        //                int countTang = Convert.ToInt32(cmd4.ExecuteScalar());
        //                count = countTang + 1;
        //            }



        //            // Thêm dữ liệu vào database
        //            using (MySqlCommand cmd = new MySqlCommand(query, conn))
        //            {
        //                var maTang = maKe + "_" + count.ToString();
        //                cmd.Parameters.AddWithValue("@MaTang", maTang);
        //                cmd.Parameters.AddWithValue("@MaKe", maKe);
        //                cmd.Parameters.AddWithValue("@DungTichKhaDung", dungTichKhaDung);
        //                cmd.Parameters.AddWithValue("@DungTichDaDung", 0);
        //                int rowsAffected = cmd.ExecuteNonQuery();
        //            }

        //            Console.WriteLine("Thêm thành công");
        //            return "Thêm thành công";

        //        }
        //        catch (Exception ex)
        //        {
        //            return "Lỗi khi lấy dữ liệu: " + ex.Message;
        //        }
        //    }
        //}
        public string NapDuLieuVaoTang(string maKe, float dungTichKhaDung)
        {
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    float dungTichKhaDungKe = 0f;
                    float sumDungTichTang = 0f;

                    string query = @"INSERT INTO Tang  (MaTang,DungTichKhaDung,DungTichDaDung,MaKe) VALUES (@MaTang, @DungTichKhaDung,@DungTichDaDung,@MaKe)";
                    string query1 = "SELECT (DungTichKhaDung + DungTichDaDung) FROM KeChoThue where MaKe = @MaKe";
                    string query3 = "SELECT sum(DungTichKhaDung + DungTichDaDung) FROM Tang where MaKe = @MaKe";
                    string query2 = "SELECT COUNT(*) FROM KeChoThue WHERE MaKe = @MaKe"; // kiểm tra khóa ngoại có tồn tại ko
                    string query4 = "SELECT COUNT(*) FROM Tang WHERE MaKe = @MaKe";  // đếm để tạo mã chính +1
                    var count = 0;


                    // Kiểm tra xem Mã kệ có tồn tại trong bảng kệ cho thuê hay ko
                    using (MySqlCommand cmd2 = new MySqlCommand(query2, conn))
                    {

                        cmd2.Parameters.AddWithValue("@MaKe", maKe);
                        int countKe = Convert.ToInt32(cmd2.ExecuteScalar());

                        if (countKe == 0)
                        {
                            Console.WriteLine("Mã kệ không tồn tại");
                            return "Mã kệ không tồn tại";
                        }
                    }


                    // Nếu có, kiểm tra dung tích kệ đó có đủ để thêm tầng hay ko
                    // Lấy dung tích khả dụng của kệ đó
                    using (MySqlCommand cmd1 = new MySqlCommand(query1, conn))
                    {

                        cmd1.Parameters.AddWithValue("@MaKe", maKe);
                        object result = cmd1.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            dungTichKhaDungKe = float.Parse(result.ToString());
                        }
                        else
                        {
                            Console.WriteLine("Lỗi khi kiểm tra dung tích khả dụng");
                            return "Lỗi khi kiểm tra dung tích khả dụng";
                        }
                    }

                    // Lấy tổng dung tích tầng của kệ đó
                    using (MySqlCommand cmd3 = new MySqlCommand(query3, conn))
                    {

                        cmd3.Parameters.AddWithValue("@MaKe", maKe);
                        object result = cmd3.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            sumDungTichTang = Convert.ToSingle(result); // Hoặc float.Parse(result.ToString());
                        }
                        else
                        {
                            sumDungTichTang = 0;
                        }


                    }

                    if (dungTichKhaDung > (dungTichKhaDungKe - sumDungTichTang))
                    {
                        Console.WriteLine("Dung tích kệ ko đủ để thêm tầng này");
                        return "Dung tích kệ không đủ để thêm tầng này";
                    }




                    // Nếu ok hết thì đếm số kệ trong kho đó ròi + 1
                    using (MySqlCommand cmd4 = new MySqlCommand(query4, conn))
                    {
                        cmd4.Parameters.AddWithValue("@MaKe", maKe);
                        int countTang = Convert.ToInt32(cmd4.ExecuteScalar());
                        count = countTang + 1;
                    }



                    // Thêm dữ liệu vào database
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        var maTang = maKe + "_" + count.ToString();
                        cmd.Parameters.AddWithValue("@MaTang", maTang);
                        cmd.Parameters.AddWithValue("@MaKe", maKe);
                        cmd.Parameters.AddWithValue("@DungTichKhaDung", dungTichKhaDung);
                        cmd.Parameters.AddWithValue("@DungTichDaDung", 0);
                        int rowsAffected = cmd.ExecuteNonQuery();
                    }

                    Console.WriteLine("Thêm thành công");
                    return "Thêm thành công";

                }
                catch (Exception ex)
                {
                    return "Lỗi khi lấy dữ liệu: " + ex.Message;
                }
            }
        }




        //public string NapDuLieuVaoNgan(string maTang, float dungTichKhaDung)
        //{
        //    using (MySqlConnection conn = new MySqlConnection(ketNoi))
        //    {
        //        try
        //        {
        //            conn.Open();
        //            float dungTichKhaDungTang = 0f;
        //            float sumDungTichNgan = 0f;

        //            string query = @"INSERT INTO Ngan  (MaNgan,DungTichKhaDung,DungTichDaDung,MaTang) VALUES (@MaNgan, @DungTichKhaDung,@DungTichDaDung,@MaTang)";
        //            string query1 = "SELECT DungTichKhaDung FROM Tang where MaTang = @MaTang";
        //            string query3 = "SELECT sum(DungTichKhaDung) FROM Ngan where MaTang = @MaTang";
        //            string query2 = "SELECT COUNT(*) FROM Tang WHERE MaTang = @MaTang"; // kiểm tra khóa ngoại có tồn tại ko
        //            string query4 = "SELECT COUNT(*) FROM Ngan WHERE MaTang = @MaTang";  // đếm để tạo mã chính +1
        //            var count = 0;


        //            // Kiểm tra khóa ngoại
        //            using (MySqlCommand cmd2 = new MySqlCommand(query2, conn))
        //            {

        //                cmd2.Parameters.AddWithValue("@MaTang", maTang);
        //                int countTang = Convert.ToInt32(cmd2.ExecuteScalar());

        //                if (countTang == 0)
        //                {
        //                    Console.WriteLine("Mã tầng không tồn tại");
        //                    return "Mã tầng không tồn tại";
        //                }
        //            }


        //            // Nếu có, kiểm tra dung tích kệ đó có đủ để thêm tầng hay ko
        //            // Lấy dung tích khả dụng của tầng đó
        //            using (MySqlCommand cmd1 = new MySqlCommand(query1, conn))
        //            {

        //                cmd1.Parameters.AddWithValue("@MaTang", maTang);
        //                object result = cmd1.ExecuteScalar();
        //                if (result != null && result != DBNull.Value)
        //                {
        //                    dungTichKhaDungTang = float.Parse(result.ToString());
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Lỗi khi kiểm tra dung tích khả dụng");
        //                    return "lỗi khi kiểm tra dung tích khả dụng";
        //                }
        //            }

        //            // Lấy tổng dung tích ngăn
        //            using (MySqlCommand cmd3 = new MySqlCommand(query3, conn))
        //            {

        //                cmd3.Parameters.AddWithValue("@MaTang", maTang);
        //                object result = cmd3.ExecuteScalar();
        //                if (result != null && result != DBNull.Value)
        //                {
        //                    sumDungTichNgan = Convert.ToSingle(result); // Hoặc float.Parse(result.ToString());
        //                }
        //                else
        //                {
        //                    sumDungTichNgan = 0;
        //                }


        //            }

        //            if (dungTichKhaDung > (dungTichKhaDungTang - sumDungTichNgan))
        //            {
        //                Console.WriteLine("Dung tích tầng ko đủ để thêm ngăn này");
        //                return"Dung tích tầng không đủ để thêm ngăn này";
        //            }




        //            // Nếu ok hết thì đếm ngăn 
        //            using (MySqlCommand cmd4 = new MySqlCommand(query4, conn))
        //            {
        //                cmd4.Parameters.AddWithValue("@MaTang", maTang);
        //                int countNgan = Convert.ToInt32(cmd4.ExecuteScalar());
        //                count = countNgan + 1;
        //            }



        //            // Thêm dữ liệu vào database
        //            using (MySqlCommand cmd = new MySqlCommand(query, conn))
        //            {
        //                var maNgan = maTang + "_" + count.ToString();
        //                cmd.Parameters.AddWithValue("@MaTang", maTang);
        //                cmd.Parameters.AddWithValue("@MaNgan", maNgan);
        //                cmd.Parameters.AddWithValue("@DungTichKhaDung", dungTichKhaDung);
        //                cmd.Parameters.AddWithValue("@DungTichDaDung", 0);
        //                int rowsAffected = cmd.ExecuteNonQuery();
        //            }

        //            Console.WriteLine("Thêm thành công");
        //            return "Thêm thành công";

        //        }
        //        catch (Exception ex)
        //        {
        //            //throw new Exception("Lỗi khi lấy dữ liệu: " + ex.Message);
        //            return "Lỗi khi thêm dữ liệu: " + ex.Message;
        //        }
        //    }
        //}

        public string NapDuLieuVaoNgan(string maTang, float dungTichKhaDung)
        {
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    float dungTichKhaDungTang = 0f;
                    float sumDungTichNgan = 0f;

                    string query = @"INSERT INTO Ngan  (MaNgan,DungTichKhaDung,DungTichDaDung,MaTang) VALUES (@MaNgan, @DungTichKhaDung,@DungTichDaDung,@MaTang)";
                    string query1 = "SELECT (DungTichKhaDung + DungTichDaDung) FROM Tang where MaTang = @MaTang";
                    string query3 = "SELECT sum(DungTichKhaDung + DungTichDaDung) FROM Ngan where MaTang = @MaTang";
                    string query2 = "SELECT COUNT(*) FROM Tang WHERE MaTang = @MaTang"; // kiểm tra khóa ngoại có tồn tại ko
                    string query4 = "SELECT COUNT(*) FROM Ngan WHERE MaTang = @MaTang";  // đếm để tạo mã chính +1
                    var count = 0;


                    // Kiểm tra khóa ngoại
                    using (MySqlCommand cmd2 = new MySqlCommand(query2, conn))
                    {

                        cmd2.Parameters.AddWithValue("@MaTang", maTang);
                        int countTang = Convert.ToInt32(cmd2.ExecuteScalar());

                        if (countTang == 0)
                        {
                            Console.WriteLine("Mã tầng không tồn tại");
                            return "Mã tầng không tồn tại";
                        }
                    }


                    // Nếu có, kiểm tra dung tích kệ đó có đủ để thêm tầng hay ko
                    // Lấy dung tích khả dụng của tầng đó
                    using (MySqlCommand cmd1 = new MySqlCommand(query1, conn))
                    {

                        cmd1.Parameters.AddWithValue("@MaTang", maTang);
                        object result = cmd1.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            dungTichKhaDungTang = float.Parse(result.ToString());
                        }
                        else
                        {
                            Console.WriteLine("Lỗi khi kiểm tra dung tích khả dụng");
                            return "lỗi khi kiểm tra dung tích khả dụng";
                        }
                    }

                    // Lấy tổng dung tích ngăn
                    using (MySqlCommand cmd3 = new MySqlCommand(query3, conn))
                    {

                        cmd3.Parameters.AddWithValue("@MaTang", maTang);
                        object result = cmd3.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            sumDungTichNgan = Convert.ToSingle(result); // Hoặc float.Parse(result.ToString());
                        }
                        else
                        {
                            sumDungTichNgan = 0;
                        }


                    }

                    if (dungTichKhaDung > (dungTichKhaDungTang - sumDungTichNgan))
                    {
                        Console.WriteLine("Dung tích tầng ko đủ để thêm ngăn này");
                        return "Dung tích tầng không đủ để thêm ngăn này";
                    }




                    // Nếu ok hết thì đếm ngăn 
                    using (MySqlCommand cmd4 = new MySqlCommand(query4, conn))
                    {
                        cmd4.Parameters.AddWithValue("@MaTang", maTang);
                        int countNgan = Convert.ToInt32(cmd4.ExecuteScalar());
                        count = countNgan + 1;
                    }



                    // Thêm dữ liệu vào database
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        var maNgan = maTang + "_" + count.ToString();
                        cmd.Parameters.AddWithValue("@MaTang", maTang);
                        cmd.Parameters.AddWithValue("@MaNgan", maNgan);
                        cmd.Parameters.AddWithValue("@DungTichKhaDung", dungTichKhaDung);
                        cmd.Parameters.AddWithValue("@DungTichDaDung", 0);
                        int rowsAffected = cmd.ExecuteNonQuery();
                    }

                    Console.WriteLine("Thêm thành công");
                    return "Thêm thành công";

                }
                catch (Exception ex)
                {
                    //throw new Exception("Lỗi khi lấy dữ liệu: " + ex.Message);
                    return "Lỗi khi thêm dữ liệu: " + ex.Message;
                }
            }
        }





        // Đây là thêm vào bảng thùng bằng cách thủ công
        //public string NapDuLieuVaoThung(string moTa, float dungTich, DateTime ngayNhap,string temSo, string maNgan, string maYC,string trangThai,string maNV,DateTime ngayHH)
        //{
        //    using (MySqlConnection conn = new MySqlConnection(ketNoi))
        //    {
        //        try
        //        {
        //            conn.Open();
        //            string query = @"INSERT INTO Thung  (MaThung,MoTaHangHoa,DungTich,NgayNhapKho,TemSo,TrangThai,MaNgan,MaYC, MaNV,NgayHetHan) VALUES (@MaThung,@MoTaHangHoa,@DungTich,@NgayNhapKho,@TemSo,@TrangThai,@MaNgan,@MaYC, @MaNV,@NgayHetHan)";


        //            string query6 = "SELECT COUNT(*) FROM NhanVienKho WHERE MaNV = @MaNV"; // kiểm tra khóa ngoại có tại hay ko : mã nhân viên
        //            string query1 = "SELECT COUNT(*) FROM YeuCauKhachHang WHERE MaYC = @MaYC"; // kiểm tra khóa ngoại có tại hay ko : mã yêu cầu
        //            string query2 = "SELECT COUNT(*) FROM Ngan WHERE MaNgan = @MaNgan";  // kiểm tra khóa ngoại có tồn tại hay ko: mã ngăn
        //            string query3 = "SELECT COUNT(*) FROM Thung ";  // đếm để tạo mã chính +1


        //            // kiểm tra ngăn còn đủ dung tích để chứa thùng này ko
        //            string query4 = "SELECT DungTichKhaDung FROM Ngan where MaNgan = @MaNgan";
        //            string query5 = "SELECT DungTichDaDung FROM Ngan where MaNgan = @MaNgan";


        //            var count = 0;
        //            float dungTichKhaDungNgan = 0;
        //            float dungTichDaDungNgan = 0;






        //            // Kiểm tra mã YC
        //            using (MySqlCommand cmd1 = new MySqlCommand(query1, conn))
        //            {

        //                cmd1.Parameters.AddWithValue("@MaYC", maYC);
        //                int countYeuCau = Convert.ToInt32(cmd1.ExecuteScalar());

        //                if (countYeuCau == 0)
        //                {
        //                    Console.WriteLine("Mã yêu cầu không tồn tại");
        //                    return "Mã yêu cầu không tồn tại";
        //                }
        //            }


        //            // Kiểm tra mã ngăn
        //            using (MySqlCommand cmd2 = new MySqlCommand(query2, conn))
        //            {

        //                cmd2.Parameters.AddWithValue("@MaNgan", maNgan);
        //                int countNgan = Convert.ToInt32(cmd2.ExecuteScalar());

        //                if (countNgan == 0)
        //                {
        //                    Console.WriteLine("Mã ngăn không tồn tại");
        //                    return"Mã ngăn không tồn tại";
        //                }
        //            }



        //            // Kiểm tra mã nhân viên
        //            using (MySqlCommand cmd2 = new MySqlCommand(query6, conn))
        //            {

        //                cmd2.Parameters.AddWithValue("@MaNV", maNV);
        //                int countNV = Convert.ToInt32(cmd2.ExecuteScalar());

        //                if (countNV == 0)
        //                {
        //                    Console.WriteLine("Mã nhân viên không tồn tại");
        //                    return "Mã nhân viên không tồn tại";
        //                }
        //            }


        //            // Kiểm tra xem ngăn đó có đủ dung tích để chứa thùng đó ko
        //            using (MySqlCommand cmd4 = new MySqlCommand(query4, conn))   // lấy dung tích khả dụng của ngăn
        //            {

        //                cmd4.Parameters.AddWithValue("@MaNgan", maNgan);
        //                object result = cmd4.ExecuteScalar();
        //                dungTichKhaDungNgan = float.Parse(result.ToString());


        //            }

        //            using (MySqlCommand cmd5 = new MySqlCommand(query5, conn))   // lấy dung tích đã dùng của ngăn
        //            {

        //                cmd5.Parameters.AddWithValue("@MaNgan", maNgan);
        //                object result = cmd5.ExecuteScalar();
        //                dungTichDaDungNgan = float.Parse(result.ToString());
        //            }

        //            if ( dungTich > (dungTichKhaDungNgan - dungTichDaDungNgan))
        //            {
        //                Console.WriteLine("Ngăn không đủ dung tích để chứa thùng này");
        //                return "Ngăn không dủ dung tích để chứa thùng này";
        //            }    



        //            // Đếm số lượng thùng rồi + 1
        //            using (MySqlCommand cmd3 = new MySqlCommand(query3, conn))
        //            {
        //                int countThung = Convert.ToInt32(cmd3.ExecuteScalar());
        //                count = countThung + 1;
        //            }






        //            // Thêm dữ liệu vào database
        //            using (MySqlCommand cmd = new MySqlCommand(query, conn))
        //            {
        //                var maThung =  "MT_" + count.ToString();
        //                cmd.Parameters.AddWithValue("@Mathung", maThung);
        //                cmd.Parameters.AddWithValue("@MaNgan", maNgan);
        //                cmd.Parameters.AddWithValue("@DungTich", dungTich);
        //                cmd.Parameters.AddWithValue("@NgayNhapKho", ngayNhap);
        //                cmd.Parameters.AddWithValue("@TemSo", temSo);
        //                cmd.Parameters.AddWithValue("@TrangThai", trangThai);
        //                cmd.Parameters.AddWithValue("@MoTaHangHoa", moTa);
        //                cmd.Parameters.AddWithValue("@MaYC", maYC);
        //                cmd.Parameters.AddWithValue("@MaNV", maNV);
        //                cmd.Parameters.AddWithValue("@NgayHetHan", ngayHH);
        //                int rowsAffected = cmd.ExecuteNonQuery();
        //            }


        //            // cập nhật lại dung tích ngăn

        //            updateDungTich( maNgan,  dungTich,  conn);

        //            Console.WriteLine("Thêm thành công");
        //            return "Thêm thành công";

        //        }
        //        catch (Exception ex)
        //        {
        //            return ("Lỗi khi lấy dữ liệu: " + ex.Message);
        //         //   throw new Exception("Lỗi khi lấy dữ liệu: " + ex.Message);
        //        }
        //    }
        //}

        public string NapDuLieuVaoThung(string moTa, float dungTich, DateTime ngayNhap, string temSo, string maNgan, string maYC, string trangThai, string maNV, DateTime ngayHH)
        {
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO Thung  (MaThung,MoTaHangHoa,DungTich,NgayNhapKho,TemSo,TrangThai,MaNgan,MaYC, MaNV,NgayGiaHan) VALUES (@MaThung,@MoTaHangHoa,@DungTich,@NgayNhapKho,@TemSo,@TrangThai,@MaNgan,@MaYC, @MaNV,@NgayGiaHan)";


                    string query6 = "SELECT COUNT(*) FROM NhanVienKho WHERE MaNV = @MaNV"; // kiểm tra khóa ngoại có tại hay ko : mã nhân viên
                    string query1 = "SELECT COUNT(*) FROM YeuCauKhachHang WHERE MaYC = @MaYC"; // kiểm tra khóa ngoại có tại hay ko : mã yêu cầu
                    string query2 = "SELECT COUNT(*) FROM Ngan WHERE MaNgan = @MaNgan";  // kiểm tra khóa ngoại có tồn tại hay ko: mã ngăn
                    //string query3 = "SELECT COUNT(*) FROM Thung ";  // đếm để tạo mã chính +1


                    // kiểm tra ngăn còn đủ dung tích để chứa thùng này ko
                    string query4 = "SELECT DungTichKhaDung FROM Ngan where MaNgan = @MaNgan";
                    //string query5 = "SELECT DungTichDaDung FROM Ngan where MaNgan = @MaNgan";



                    float dungTichKhaDungNgan = 0;
                    //float dungTichDaDungNgan = 0;






                    // Kiểm tra mã YC
                    using (MySqlCommand cmd1 = new MySqlCommand(query1, conn))
                    {

                        cmd1.Parameters.AddWithValue("@MaYC", maYC);
                        int countYeuCau = Convert.ToInt32(cmd1.ExecuteScalar());

                        if (countYeuCau == 0)
                        {
                            Console.WriteLine("Mã yêu cầu không tồn tại");
                            return "Mã yêu cầu không tồn tại";
                        }
                    }


                    // Kiểm tra mã ngăn
                    using (MySqlCommand cmd2 = new MySqlCommand(query2, conn))
                    {

                        cmd2.Parameters.AddWithValue("@MaNgan", maNgan);
                        int countNgan = Convert.ToInt32(cmd2.ExecuteScalar());

                        if (countNgan == 0)
                        {
                            Console.WriteLine("Mã ngăn không tồn tại");
                            return "Mã ngăn không tồn tại";
                        }
                    }



                    // Kiểm tra mã nhân viên
                    using (MySqlCommand cmd2 = new MySqlCommand(query6, conn))
                    {

                        cmd2.Parameters.AddWithValue("@MaNV", maNV);
                        int countNV = Convert.ToInt32(cmd2.ExecuteScalar());

                        if (countNV == 0)
                        {
                            Console.WriteLine("Mã nhân viên không tồn tại");
                            return "Mã nhân viên không tồn tại";
                        }
                    }


                    // Kiểm tra xem ngăn đó có đủ dung tích để chứa thùng đó ko
                    using (MySqlCommand cmd4 = new MySqlCommand(query4, conn))   // lấy dung tích khả dụng của ngăn
                    {

                        cmd4.Parameters.AddWithValue("@MaNgan", maNgan);
                        object result = cmd4.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            dungTichKhaDungNgan = float.Parse(result.ToString());
                        }
                        else
                        {
                            dungTichKhaDungNgan = 0;
                        }



                    }



                    if (dungTich > dungTichKhaDungNgan)
                    {
                        Console.WriteLine("Ngăn không đủ dung tích để chứa thùng này");
                        return "Ngăn không dủ dung tích để chứa thùng này";
                    }



                    //// Đếm số lượng thùng rồi + 1
                    //using (MySqlCommand cmd3 = new MySqlCommand(query3, conn))
                    //{
                    //    int countThung = Convert.ToInt32(cmd3.ExecuteScalar());
                    //    count = countThung + 1;
                    //}






                    // Thêm dữ liệu vào database
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        var maThung = maYC + "_MT_" + temSo;
                        cmd.Parameters.AddWithValue("@Mathung", maThung);
                        cmd.Parameters.AddWithValue("@MaNgan", maNgan);
                        cmd.Parameters.AddWithValue("@DungTich", dungTich);
                        cmd.Parameters.AddWithValue("@NgayNhapKho", ngayNhap);
                        cmd.Parameters.AddWithValue("@TemSo", temSo);
                        cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                        cmd.Parameters.AddWithValue("@MoTaHangHoa", moTa);
                        cmd.Parameters.AddWithValue("@MaYC", maYC);
                        cmd.Parameters.AddWithValue("@MaNV", maNV);
                        cmd.Parameters.AddWithValue("@NgayGiaHan", ngayHH);
                        int rowsAffected = cmd.ExecuteNonQuery();
                    }


                    // cập nhật lại dung tích ngăn

                    updateDungTich(maNgan, dungTich, conn);

                    Console.WriteLine("Thêm thành công");
                    return "Thêm thành công";

                }
                catch (Exception ex)
                {
                    return ("Lỗi khi lấy dữ liệu: " + ex.Message);
                    //   throw new Exception("Lỗi khi lấy dữ liệu: " + ex.Message);
                }
            }
        }



        //public void updateDungTich (string maNgan, float dungTich, MySqlConnection conn)
        //{
        //    float newDungTichDaDungNgan = 0;
        //    float newDungTichDaDungTang = 0;
        //    float newDungTichDaDungKe = 0;
        //    float newDungTichDaDungKho = 0;

        //    string maTang = "";
        //    string maKe = "";
        //    string maKho = "";

        //    //update ngăn
        //    string query = "select DungTichDaDung from Ngan where MaNgan = @MaNgan";
        //    string query1 = "update Ngan set DungTichDaDung = @DungTichDaDung where MaNgan = @MaNgan";


        //    // update tầng
        //    string query3 = "select MaTang from Ngan where MaNgan = @MaNgan";
        //    string query4 = "select DungTichDaDung from Tang where MaTang = @MaTang";
        //    string query5 = "update Tang set DungTichDaDung = @DungTichDaDung where MaTang = @MaTang";


        //    // update kệ
        //    string query6 = "select MaKe from Tang where MaTang = @MaTang";
        //    string query7 = "select DungTichDaDung from KeChoThue where MaKe = @MaKe";
        //    string query8 = "update KeChoThue set DungTichDaDung = @DungTichDaDung where MaKe = @MaKe";


        //    // update kho
        //    string query9 = "select MaKho from KeChoThue where MaKe = @MaKe";
        //    string query10 = "select DungTichDaDung from KhoChoThue where MaKho = @MaKho";
        //    string query11 = "update KhoChoThue set DungTichDaDung = @DungTichDaDung where MaKho = @MaKho";



        //    // update dung tích ngăn
        //    using (MySqlCommand cmd = new MySqlCommand(query, conn))
        //    {

        //        cmd.Parameters.AddWithValue("@MaNgan", maNgan);
        //        object result = cmd.ExecuteScalar();
        //        //if ( result == null )
        //        //{
        //        //    newDungTichDaDungNgan = 0;
        //        //}    
        //        newDungTichDaDungNgan = float.Parse(result.ToString());
        //    }

        //    newDungTichDaDungNgan = newDungTichDaDungNgan + dungTich;


        //    using (MySqlCommand cmd1 = new MySqlCommand(query1, conn))
        //    {

        //        cmd1.Parameters.AddWithValue("@MaNgan", maNgan);
        //        cmd1.Parameters.AddWithValue("@DungTichDaDung", newDungTichDaDungNgan);
        //        int rowsAffected = cmd1.ExecuteNonQuery();
        //    }


        //    // update dung tích tầng 
        //    using (MySqlCommand cmd3 = new MySqlCommand(query3, conn))
        //    {

        //        cmd3.Parameters.AddWithValue("@MaNgan", maNgan);
        //        object result = cmd3.ExecuteScalar();
        //        maTang = (result.ToString());
        //    }

        //    using (MySqlCommand cmd4 = new MySqlCommand(query4, conn))
        //    {

        //        cmd4.Parameters.AddWithValue("@MaTang", maTang);
        //        object result = cmd4.ExecuteScalar();
        //        newDungTichDaDungTang = float.Parse(result.ToString()) + dungTich;
        //    }


        //    using (MySqlCommand cmd5 = new MySqlCommand(query5, conn))
        //    {

        //        cmd5.Parameters.AddWithValue("@MaTang", maTang);
        //        cmd5.Parameters.AddWithValue("@DungTichDaDung", newDungTichDaDungTang);
        //        int rowsAffected = cmd5.ExecuteNonQuery();
        //    }



        //    // update dung tích kệ
        //    using (MySqlCommand cmd6 = new MySqlCommand(query6, conn))
        //    {

        //        cmd6.Parameters.AddWithValue("@MaTang", maTang);
        //        object result = cmd6.ExecuteScalar();
        //        maKe = (result.ToString());
        //    }

        //    using (MySqlCommand cmd7 = new MySqlCommand(query7, conn))
        //    {

        //        cmd7.Parameters.AddWithValue("@MaKe", maKe);
        //        object result = cmd7.ExecuteScalar();
        //        newDungTichDaDungKe = float.Parse(result.ToString()) + dungTich;
        //    }


        //    using (MySqlCommand cmd8 = new MySqlCommand(query8, conn))
        //    {

        //        cmd8.Parameters.AddWithValue("@MaKe", maKe);
        //        cmd8.Parameters.AddWithValue("@DungTichDaDung", newDungTichDaDungKe);
        //        int rowsAffected = cmd8.ExecuteNonQuery();
        //    }


        //    // update dung tích kho 

        //    using (MySqlCommand cmd9 = new MySqlCommand(query9, conn))
        //    {

        //        cmd9.Parameters.AddWithValue("@MaKe", maKe);
        //        object result = cmd9.ExecuteScalar();
        //        maKho = (result.ToString());
        //    }

        //    using (MySqlCommand cmd10 = new MySqlCommand(query10, conn))
        //    {

        //        cmd10.Parameters.AddWithValue("@MaKho", maKho);
        //        object result = cmd10.ExecuteScalar();
        //        newDungTichDaDungKho = float.Parse(result.ToString()) + dungTich;
        //    }


        //    using (MySqlCommand cmd11 = new MySqlCommand(query11, conn))
        //    {

        //        cmd11.Parameters.AddWithValue("@MaKho", maKho);
        //        cmd11.Parameters.AddWithValue("@DungTichDaDung", newDungTichDaDungKho);
        //        int rowsAffected = cmd11.ExecuteNonQuery();
        //    }


        //}



        public void updateDungTich(string maNgan, float dungTich, MySqlConnection conn)
        {
            float newDungTichDaDungNgan = 0;
            float newDungTichDaDungTang = 0;
            float newDungTichDaDungKe = 0;
            float newDungTichDaDungKho = 0;

            float newDungTichKhaDungNgan = 0;
            float newDungTichKhaDungTang = 0;
            float newDungTichKhaDungKe = 0;
            float newDungTichKhaDungKho = 0;

            string maTang = "";
            string maKe = "";
            string maKho = "";

            //update ngăn
            string query = "select DungTichDaDung from Ngan where MaNgan = @MaNgan";
            string query1 = "update Ngan set DungTichDaDung = @DungTichDaDung, DungTichKhaDung = @DungTichKhaDung where MaNgan = @MaNgan";
            string query12 = "select DungTichKhaDung from Ngan where MaNgan = @MaNgan";


            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {

                cmd.Parameters.AddWithValue("@MaNgan", maNgan);
                object result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                {
                    newDungTichDaDungNgan = 0;
                }
                else
                {
                    newDungTichDaDungNgan = float.Parse(result.ToString());
                }

            }

            using (MySqlCommand cmd = new MySqlCommand(query12, conn))
            {

                cmd.Parameters.AddWithValue("@MaNgan", maNgan);
                object result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                {
                    newDungTichKhaDungNgan = 0;
                }
                else
                {
                    newDungTichKhaDungNgan = float.Parse(result.ToString());
                }

            }

            newDungTichKhaDungNgan = newDungTichKhaDungNgan - dungTich;
            newDungTichDaDungNgan = newDungTichDaDungNgan + dungTich;


            using (MySqlCommand cmd1 = new MySqlCommand(query1, conn))
            {

                cmd1.Parameters.AddWithValue("@MaNgan", maNgan);
                cmd1.Parameters.AddWithValue("@DungTichDaDung", newDungTichDaDungNgan);
                cmd1.Parameters.AddWithValue("@DungTichKhaDung", newDungTichKhaDungNgan);
                int rowsAffected = cmd1.ExecuteNonQuery();
            }

            // update tầng
            string query3 = "select MaTang from Ngan where MaNgan = @MaNgan";
            string query4 = "select DungTichDaDung from Tang where MaTang = @MaTang";
            string query5 = "update Tang set DungTichDaDung = @DungTichDaDung, DungTichKhaDung = @DungTichKhaDung where MaTang = @MaTang";
            string query14 = "select DungTichKhaDung from Tang where MaTang = @MaTang";


            using (MySqlCommand cmd3 = new MySqlCommand(query3, conn))
            {

                cmd3.Parameters.AddWithValue("@MaNgan", maNgan);
                object result = cmd3.ExecuteScalar();
                maTang = (result.ToString());
            }

            using (MySqlCommand cmd4 = new MySqlCommand(query4, conn))
            {

                cmd4.Parameters.AddWithValue("@MaTang", maTang);
                object result = cmd4.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    newDungTichDaDungTang = float.Parse(result.ToString()) + dungTich;
                }
                else
                {
                    newDungTichDaDungTang = 0;
                }

            }

            using (MySqlCommand cmd4 = new MySqlCommand(query14, conn))
            {

                cmd4.Parameters.AddWithValue("@MaTang", maTang);
                object result = cmd4.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    newDungTichKhaDungTang = float.Parse(result.ToString()) - dungTich;
                }
                else
                {
                    newDungTichKhaDungTang = 0;
                }

            }





            using (MySqlCommand cmd5 = new MySqlCommand(query5, conn))
            {

                cmd5.Parameters.AddWithValue("@MaTang", maTang);
                cmd5.Parameters.AddWithValue("@DungTichDaDung", newDungTichDaDungTang);
                cmd5.Parameters.AddWithValue("@DungTichKhaDung", newDungTichKhaDungTang);
                int rowsAffected = cmd5.ExecuteNonQuery();
            }



            // update kệ
            string query6 = "select MaKe from Tang where MaTang = @MaTang";
            string query7 = "select DungTichDaDung from KeChoThue where MaKe = @MaKe";
            string query8 = "update KeChoThue set DungTichDaDung = @DungTichDaDung, DungTichKhaDung = @DungTichKhaDung where MaKe = @MaKe";
            string query17 = "select DungTichKhaDung from KeChoThue where MaKe = @MaKe";


            using (MySqlCommand cmd6 = new MySqlCommand(query6, conn))
            {

                cmd6.Parameters.AddWithValue("@MaTang", maTang);
                object result = cmd6.ExecuteScalar();
                maKe = (result.ToString());
            }

            using (MySqlCommand cmd7 = new MySqlCommand(query7, conn))
            {

                cmd7.Parameters.AddWithValue("@MaKe", maKe);
                object result = cmd7.ExecuteScalar();
                newDungTichDaDungKe = float.Parse(result.ToString()) + dungTich;
            }

            using (MySqlCommand cmd7 = new MySqlCommand(query17, conn))
            {

                cmd7.Parameters.AddWithValue("@MaKe", maKe);
                object result = cmd7.ExecuteScalar();
                newDungTichKhaDungKe = float.Parse(result.ToString()) - dungTich;
            }


            using (MySqlCommand cmd8 = new MySqlCommand(query8, conn))
            {

                cmd8.Parameters.AddWithValue("@MaKe", maKe);
                cmd8.Parameters.AddWithValue("@DungTichDaDung", newDungTichDaDungKe);
                cmd8.Parameters.AddWithValue("@DungTichKhaDung", newDungTichKhaDungKe);
                int rowsAffected = cmd8.ExecuteNonQuery();
            }


            // update kho
            string query9 = "select MaKho from KeChoThue where MaKe = @MaKe";
            string query10 = "select DungTichDaDung from KhoChoThue where MaKho = @MaKho";
            string query11 = "update KhoChoThue set DungTichDaDung = @DungTichDaDung, DungTichKhaDung = @DungTichKhaDung where MaKho = @MaKho";
            string query20 = "select DungTichKhaDung from KhoChoThue where MaKho = @MaKho";


            using (MySqlCommand cmd9 = new MySqlCommand(query9, conn))
            {

                cmd9.Parameters.AddWithValue("@MaKe", maKe);
                object result = cmd9.ExecuteScalar();
                maKho = (result.ToString());
            }

            using (MySqlCommand cmd10 = new MySqlCommand(query10, conn))
            {

                cmd10.Parameters.AddWithValue("@MaKho", maKho);
                object result = cmd10.ExecuteScalar();
                newDungTichDaDungKho = float.Parse(result.ToString()) + dungTich;
            }

            using (MySqlCommand cmd10 = new MySqlCommand(query20, conn))
            {

                cmd10.Parameters.AddWithValue("@MaKho", maKho);
                object result = cmd10.ExecuteScalar();
                newDungTichKhaDungKho = float.Parse(result.ToString()) - dungTich;
            }


            using (MySqlCommand cmd11 = new MySqlCommand(query11, conn))
            {

                cmd11.Parameters.AddWithValue("@MaKho", maKho);
                cmd11.Parameters.AddWithValue("@DungTichDaDung", newDungTichDaDungKho);
                cmd11.Parameters.AddWithValue("@DungTichKhaDung", newDungTichKhaDungKho);
                int rowsAffected = cmd11.ExecuteNonQuery();
            }


        }



        public string XoaDuLieuKhoNoiBo(KhoNoiBo a)
        {
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    string query = @"delete from KhoNoiBo where MaKho = @MaKho";
                    string query1 = @"delete from Kho where MaKho = @MaKho";

                    

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        try
                        {
                            cmd.Parameters.AddWithValue("@MaKho", a.getMaKho());
                            int rowsAffected = cmd.ExecuteNonQuery();

                            
                                Console.WriteLine("Xóa thành công");
                                
                            
                        }
                        catch (Exception ex) 
                        {
                            Console.WriteLine("Lỗi không thể xóa.Vui lòng kiểm tra xem kho có đang chứa gì bên trong không");
                            return "Lỗi không thể xóa kho nội bộ: " + ex.Message;
                        }
                        
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query1, conn))
                    {
                        try
                        {
                            cmd.Parameters.AddWithValue("@MaKho", a.getMaKho());
                            int rowsAffected = cmd.ExecuteNonQuery();


                            Console.WriteLine("Xóa thành công");
                            return "Xóa thành công";


                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Lỗi không thể xóa.Vui lòng kiểm tra xem kho có đang chứa gì bên trong không");
                            return "Lỗi không thể xóa kho nội bộ: " + ex.Message;
                        }

                    }




                }
                catch (MySqlException ex) 
                {
                    Console.WriteLine("Lỗi khi xóa dữ liệu khỏi kho nội bộ: " + ex.Message);
                    return ("Lỗi khi xóa dữ liệu khỏi kho nội bộ: " + ex.Message);
                    //   throw new Exception("Lỗi khi lấy dữ liệu: " + ex.Message);
                }
            }

        }


        public string XoaDuLieuKhoChoThue(KhoChoThue a)
        {
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    string query = @"delete from KhoChoThue where MaKho = @MaKho";
                    string query1 = @"delete from Kho where MaKho = @MaKho";

                   

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        try
                        {
                            cmd.Parameters.AddWithValue("@MaKho", a.getMaKho());
                            int rowsAffected = cmd.ExecuteNonQuery();

                            
                               
                           
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Lỗi không thể xóa.Vui lòng kiểm tra xem kho có đang chứa gì bên trong không" + ex.Message);
                            return ("Lỗi không thể xóa kho cho thuê: " + ex.Message);
                        }

                    }
                    using (MySqlCommand cmd = new MySqlCommand(query1, conn))
                    {
                        try
                        {
                            cmd.Parameters.AddWithValue("@MaKho", a.getMaKho());
                            int rowsAffected = cmd.ExecuteNonQuery();
                            return "Xóa thành công";

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Lỗi không thể xóa.Vui lòng kiểm tra xem kho có đang chứa gì bên trong không" + ex.Message);
                            return ("Lỗi không thể kho cho thuê: " + ex.Message);
                        }

                    }


                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Lỗi khi xóa dữ liệu khỏi kho cho thuê: " + ex.Message);
                    //   throw new Exception("Lỗi khi lấy dữ liệu: " + ex.Message);
                    return ("Lỗi khi xóa dữ liệu khỏi kho cho thuê: " + ex.Message);
                }
            }

        }



        public string XoaDuLieuKeNoiBo(KeNoiBo a)
        {
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    string query = @"delete from KeNoiBo where MaKe = @MaKe";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        try
                        {
                            cmd.Parameters.AddWithValue("@MaKe", a.getMaKe());
                            int rowsAffected = cmd.ExecuteNonQuery();


                            return "xóa thành công";
                           
                           
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Lỗi không thể xóa.Vui lòng kiểm tra xem kệ có đang chứa gì bên trong không");
                            return ("Lỗi không thể xóa kệ nội bộ: " + e.Message);
                        }

                    }


                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Lỗi khi xóa dữ liệu khỏi kệ nội bộ: " + ex.Message);
                    return ("Lỗi khi xóa dữ liệu khỏi kệ nội bộ: " + ex.Message); 
                    //   throw new Exception("Lỗi khi lấy dữ liệu: " + ex.Message);
                }
            }

        }


        public string XoaDuLieuHangHoaNoiBo(HangHoaNoiBo a)
        {
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    string query = @"delete from HangHoaNoiBo where MaHangHoa = @MaHangHoa";
                    string query1 = "delete from KiemKeNoiBo where MaHangHoa = @MaHangHoa";

                    using (MySqlCommand cmd = new MySqlCommand(query1, conn))
                    {
                        try
                        {
                            cmd.Parameters.AddWithValue("@MaHangHoa", a.MaHH);
                            int rowsAffected = cmd.ExecuteNonQuery();
                           
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Lỗi không thể xóa.Vui lòng kiểm tra lại");
                            return ("Lỗi không thể xóa kiểm kê nội bộ: " + ex.Message);
                        }
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        try
                        {
                            cmd.Parameters.AddWithValue("@MaHangHoa", a.MaHH);
                            int rowsAffected = cmd.ExecuteNonQuery();
                                return ("Xóa thành công");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Lỗi không thể xóa.Vui lòng kiểm tra lại");
                            return ("Lỗi không thể xóa hàng hóa nội bộ: " + ex.Message);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Lỗi khi xóa dữ liệu khỏi hàng hóa nội bộ: " + ex.Message);
                    return ("Lỗi khi xóa dữ liệu khỏi hàng hóa nội bộ: " + ex.Message);
                    //   throw new Exception("Lỗi khi lấy dữ liệu: " + ex.Message);
                }
            }
        }




        public string XoaDuLieuKeChoThue(KeChoThue a)
        {
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    string query = @"delete from KeChoThue where MaKe = @MaKe";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        try
                        {
                            cmd.Parameters.AddWithValue("@MaKe", a.getMaKe());
                            int rowsAffected = cmd.ExecuteNonQuery();

                           
                                return ("Xóa thành công");
                           
                        }
                        catch  (Exception e)
                        {
                            Console.WriteLine("Lỗi không thể xóa.Vui lòng kiểm tra xem kệ có đang chứa gì không");
                            return ("Lỗi không thể xóa kệ cho thuê: " + e.Message);
                        }

                    }


                }
                catch (MySqlException ex)
                {
                   
                    return ("Lỗi khi xóa dữ liệu khỏi kệ cho thuê: " + ex.Message);
                    //   throw new Exception("Lỗi khi lấy dữ liệu: " + ex.Message);
                }
            }

        }




        public string XoaDuLieuTang(Tang a)
        {
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    string query = @"delete from Tang where MaTang = @MaTang";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        try
                        {
                            cmd.Parameters.AddWithValue("@MaTang", a.MaTang);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            
                                return ("Xóa thành công");
                           
                        }
                        catch (Exception e)
                        {
                            return ("Lỗi không thể xóa dữ liệu tầng: " + e.Message);
                             
                            
                        }

                    }


                }
                catch (MySqlException ex)
                {
                    return ("Lỗi khi xóa dữ liệu tầng: " + ex.Message);
                    
                    //   throw new Exception("Lỗi khi lấy dữ liệu: " + ex.Message);
                }
            }

        }




        //public string XoaDuLieuNgan(Ngan a)
        //{
        //    using (MySqlConnection conn = new MySqlConnection(ketNoi))
        //    {
        //        try
        //        {
        //            conn.Open();
        //            string query = @"delete from Ngan where MaNgan = @MaNgan";

        //            using (MySqlCommand cmd = new MySqlCommand(query, conn))
        //            {
        //                try
        //                {
        //                    cmd.Parameters.AddWithValue("@MaNgan", a.MaNgan);
        //                    int rowsAffected = cmd.ExecuteNonQuery();


        //                        return ("Xóa thành công");

        //                }
        //                catch (Exception e)
        //                {
        //                    return ("Lỗi không thể xóa dữ liệu ngăn: " + e.Message );

        //                }

        //            }


        //        }
        //        catch (MySqlException ex)
        //        {
        //            return ("Lỗi khi xóa dữ liệu ngăn: " + ex.Message);
        //            //   throw new Exception("Lỗi khi lấy dữ liệu: " + ex.Message);
        //        }
        //    }

        //}

        public string XoaDuLieuNgan(Ngan a)
        {
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    string query = @"delete from Ngan where MaNgan = @MaNgan";
                    string query1 = @"delete from KiemKe where MaNgan = @MaNgan";

                    using (MySqlCommand cmd = new MySqlCommand(query1, conn))
                    {
                        try
                        {
                            cmd.Parameters.AddWithValue("@MaNgan", a.MaNgan);
                            int rowsAffected = cmd.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Lỗi không thể xóa dữ liệu kiểm kê cho thuê: " + e.Message);
                            return ("Lỗi không thể xóa dữ liệu kiểm kê cho thuê: " + e.Message);

                        }
                    }
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        try
                        {
                            cmd.Parameters.AddWithValue("@MaNgan", a.MaNgan);
                            int rowsAffected = cmd.ExecuteNonQuery();
                            return ("Xóa thành công");

                        }
                        catch (Exception e)
                        {
                            return ("Lỗi không thể xóa dữ liệu ngăn: " + e.Message);

                        }

                    }
                }
                catch (MySqlException ex)
                {
                    return ("Lỗi khi xóa dữ liệu ngăn: " + ex.Message);
                    //   throw new Exception("Lỗi khi lấy dữ liệu: " + ex.Message);
                }
            }
        }



        public string XoaDuLieuThung(Thung a)
        {
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    string query = @"delete from Thung where MaThung = @MaThung";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        try
                        {
                            cmd.Parameters.AddWithValue("@MaThung", a.MaThung);
                            int rowsAffected = cmd.ExecuteNonQuery();


                            updateDungTichKhiXoa(a.MaNgan, a.DungTich, conn);
                            return ("Xóa thành công");
                        }
                        catch (Exception e)
                        {
                            return ("Lỗi không thể xóa dữ liệu thùng: " + e.Message);
                        }

                    }


                }
                catch (MySqlException ex)
                {
                    return ("Lỗi khi xóa dữ liệu thùng: " + ex.Message);
                    //   throw new Exception("Lỗi khi lấy dữ liệu: " + ex.Message);
                }
            }
        }




        //public void updateDungTichKhiXoa(string maNgan, float dungTich, MySqlConnection conn)
        //{
        //    float newDungTichDaDungNgan = 0;
        //    float newDungTichDaDungTang = 0;
        //    float newDungTichDaDungKe = 0;
        //    float newDungTichDaDungKho = 0;

        //    string maTang = "";
        //    string maKe = "";
        //    string maKho = "";

        //    //update ngăn
        //    string query = "select DungTichDaDung from Ngan where MaNgan = @MaNgan";
        //    string query1 = "update Ngan set DungTichDaDung = @DungTichDaDung where MaNgan = @MaNgan";


        //    // update tầng
        //    string query3 = "select MaTang from Ngan where MaNgan = @MaNgan";
        //    string query4 = "select DungTichDaDung from Tang where MaTang = @MaTang";
        //    string query5 = "update Tang set DungTichDaDung = @DungTichDaDung where MaTang = @MaTang";


        //    // update kệ
        //    string query6 = "select MaKe from Tang where MaTang = @MaTang";
        //    string query7 = "select DungTichDaDung from KeChoThue where MaKe = @MaKe";
        //    string query8 = "update KeChoThue set DungTichDaDung = @DungTichDaDung where MaKe = @MaKe";


        //    // update kho
        //    string query9 = "select MaKho from KeChoThue where MaKe = @MaKe";
        //    string query10 = "select DungTichDaDung from KhoChoThue where MaKho = @MaKho";
        //    string query11 = "update KhoChoThue set DungTichDaDung = @DungTichDaDung where MaKho = @MaKho";



        //    // update dung tích ngăn
        //    using (MySqlCommand cmd = new MySqlCommand(query, conn))
        //    {

        //        cmd.Parameters.AddWithValue("@MaNgan", maNgan);
        //        object result = cmd.ExecuteScalar();
        //        newDungTichDaDungNgan = float.Parse(result.ToString());
        //    }

        //    newDungTichDaDungNgan = newDungTichDaDungNgan - dungTich;


        //    using (MySqlCommand cmd1 = new MySqlCommand(query1, conn))
        //    {

        //        cmd1.Parameters.AddWithValue("@MaNgan", maNgan);
        //        cmd1.Parameters.AddWithValue("@DungTichDaDung", newDungTichDaDungNgan);
        //        int rowsAffected = cmd1.ExecuteNonQuery();
        //    }


        //    // update dung tích tầng 
        //    using (MySqlCommand cmd3 = new MySqlCommand(query3, conn))
        //    {

        //        cmd3.Parameters.AddWithValue("@MaNgan", maNgan);
        //        object result = cmd3.ExecuteScalar();
        //        maTang = (result.ToString());
        //    }

        //    using (MySqlCommand cmd4 = new MySqlCommand(query4, conn))
        //    {

        //        cmd4.Parameters.AddWithValue("@MaTang", maTang);
        //        object result = cmd4.ExecuteScalar();
        //        newDungTichDaDungTang = float.Parse(result.ToString()) - dungTich;
        //    }


        //    using (MySqlCommand cmd5 = new MySqlCommand(query5, conn))
        //    {

        //        cmd5.Parameters.AddWithValue("@MaTang", maTang);
        //        cmd5.Parameters.AddWithValue("@DungTichDaDung", newDungTichDaDungTang);
        //        int rowsAffected = cmd5.ExecuteNonQuery();
        //    }



        //    // update dung tích kệ
        //    using (MySqlCommand cmd6 = new MySqlCommand(query6, conn))
        //    {

        //        cmd6.Parameters.AddWithValue("@MaTang", maTang);
        //        object result = cmd6.ExecuteScalar();
        //        maKe = (result.ToString());
        //    }

        //    using (MySqlCommand cmd7 = new MySqlCommand(query7, conn))
        //    {

        //        cmd7.Parameters.AddWithValue("@MaKe", maKe);
        //        object result = cmd7.ExecuteScalar();
        //        newDungTichDaDungKe = float.Parse(result.ToString()) - dungTich;
        //    }


        //    using (MySqlCommand cmd8 = new MySqlCommand(query8, conn))
        //    {

        //        cmd8.Parameters.AddWithValue("@MaKe", maKe);
        //        cmd8.Parameters.AddWithValue("@DungTichDaDung", newDungTichDaDungKe);
        //        int rowsAffected = cmd8.ExecuteNonQuery();
        //    }


        //    // update dung tích kho 

        //    using (MySqlCommand cmd9 = new MySqlCommand(query9, conn))
        //    {

        //        cmd9.Parameters.AddWithValue("@MaKe", maKe);
        //        object result = cmd9.ExecuteScalar();
        //        maKho = (result.ToString());
        //    }

        //    using (MySqlCommand cmd10 = new MySqlCommand(query10, conn))
        //    {

        //        cmd10.Parameters.AddWithValue("@MaKho", maKho);
        //        object result = cmd10.ExecuteScalar();
        //        newDungTichDaDungKho = float.Parse(result.ToString()) - dungTich;
        //    }


        //    using (MySqlCommand cmd11 = new MySqlCommand(query11, conn))
        //    {

        //        cmd11.Parameters.AddWithValue("@MaKho", maKho);
        //        cmd11.Parameters.AddWithValue("@DungTichDaDung", newDungTichDaDungKho);
        //        int rowsAffected = cmd11.ExecuteNonQuery();
        //    }


        //}


        public void updateDungTichKhiXoa(string maNgan, float dungTich, MySqlConnection conn)
        {
            float newDungTichDaDungNgan = 0;
            float newDungTichDaDungTang = 0;
            float newDungTichDaDungKe = 0;
            float newDungTichDaDungKho = 0;

            float newDungTichKhaDungNgan = 0;
            float newDungTichKhaDungTang = 0;
            float newDungTichKhaDungKe = 0;
            float newDungTichKhaDungKho = 0;

            string maTang = "";
            string maKe = "";
            string maKho = "";

            //update ngăn
            string query = "select DungTichDaDung from Ngan where MaNgan = @MaNgan";
            string query1 = "update Ngan set DungTichDaDung = @DungTichDaDung, DungTichKhaDung = @DungTichKhaDung where MaNgan = @MaNgan";
            string query12 = "select DungTichKhaDung from Ngan where MaNgan = @MaNgan";


            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {

                cmd.Parameters.AddWithValue("@MaNgan", maNgan);
                object result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                {
                    newDungTichDaDungNgan = 0;
                }
                else
                {
                    newDungTichDaDungNgan = float.Parse(result.ToString());
                }

            }

            using (MySqlCommand cmd = new MySqlCommand(query12, conn))
            {

                cmd.Parameters.AddWithValue("@MaNgan", maNgan);
                object result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                {
                    newDungTichKhaDungNgan = 0;
                }
                else
                {
                    newDungTichKhaDungNgan = float.Parse(result.ToString());
                }

            }

            newDungTichKhaDungNgan = newDungTichKhaDungNgan + dungTich;
            newDungTichDaDungNgan = newDungTichDaDungNgan - dungTich;


            using (MySqlCommand cmd1 = new MySqlCommand(query1, conn))
            {

                cmd1.Parameters.AddWithValue("@MaNgan", maNgan);
                cmd1.Parameters.AddWithValue("@DungTichDaDung", newDungTichDaDungNgan);
                cmd1.Parameters.AddWithValue("@DungTichKhaDung", newDungTichKhaDungNgan);
                int rowsAffected = cmd1.ExecuteNonQuery();
            }

            // update tầng
            string query3 = "select MaTang from Ngan where MaNgan = @MaNgan";
            string query4 = "select DungTichDaDung from Tang where MaTang = @MaTang";
            string query5 = "update Tang set DungTichDaDung = @DungTichDaDung, DungTichKhaDung = @DungTichKhaDung where MaTang = @MaTang";
            string query14 = "select DungTichKhaDung from Tang where MaTang = @MaTang";


            using (MySqlCommand cmd3 = new MySqlCommand(query3, conn))
            {

                cmd3.Parameters.AddWithValue("@MaNgan", maNgan);
                object result = cmd3.ExecuteScalar();
                maTang = (result.ToString());
            }

            using (MySqlCommand cmd4 = new MySqlCommand(query4, conn))
            {

                cmd4.Parameters.AddWithValue("@MaTang", maTang);
                object result = cmd4.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    newDungTichDaDungTang = float.Parse(result.ToString()) - dungTich;
                }
                else
                {
                    newDungTichDaDungTang = 0;
                }

            }

            using (MySqlCommand cmd4 = new MySqlCommand(query14, conn))
            {

                cmd4.Parameters.AddWithValue("@MaTang", maTang);
                object result = cmd4.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    newDungTichKhaDungTang = float.Parse(result.ToString()) + dungTich;
                }
                else
                {
                    newDungTichKhaDungTang = 0;
                }

            }



            using (MySqlCommand cmd5 = new MySqlCommand(query5, conn))
            {

                cmd5.Parameters.AddWithValue("@MaTang", maTang);
                cmd5.Parameters.AddWithValue("@DungTichDaDung", newDungTichDaDungTang);
                cmd5.Parameters.AddWithValue("@DungTichKhaDung", newDungTichKhaDungTang);
                int rowsAffected = cmd5.ExecuteNonQuery();
            }



            // update kệ
            string query6 = "select MaKe from Tang where MaTang = @MaTang";
            string query7 = "select DungTichDaDung from KeChoThue where MaKe = @MaKe";
            string query8 = "update KeChoThue set DungTichDaDung = @DungTichDaDung, DungTichKhaDung = @DungTichKhaDung where MaKe = @MaKe";
            string query17 = "select DungTichKhaDung from KeChoThue where MaKe = @MaKe";


            using (MySqlCommand cmd6 = new MySqlCommand(query6, conn))
            {

                cmd6.Parameters.AddWithValue("@MaTang", maTang);
                object result = cmd6.ExecuteScalar();
                maKe = (result.ToString());
            }

            using (MySqlCommand cmd7 = new MySqlCommand(query7, conn))
            {

                cmd7.Parameters.AddWithValue("@MaKe", maKe);
                object result = cmd7.ExecuteScalar();
                newDungTichDaDungKe = float.Parse(result.ToString()) - dungTich;
            }

            using (MySqlCommand cmd7 = new MySqlCommand(query17, conn))
            {

                cmd7.Parameters.AddWithValue("@MaKe", maKe);
                object result = cmd7.ExecuteScalar();
                newDungTichKhaDungKe = float.Parse(result.ToString()) + dungTich;
            }


            using (MySqlCommand cmd8 = new MySqlCommand(query8, conn))
            {

                cmd8.Parameters.AddWithValue("@MaKe", maKe);
                cmd8.Parameters.AddWithValue("@DungTichDaDung", newDungTichDaDungKe);
                cmd8.Parameters.AddWithValue("@DungTichKhaDung", newDungTichKhaDungKe);
                int rowsAffected = cmd8.ExecuteNonQuery();
            }


            // update kho
            string query9 = "select MaKho from KeChoThue where MaKe = @MaKe";
            string query10 = "select DungTichDaDung from KhoChoThue where MaKho = @MaKho";
            string query11 = "update KhoChoThue set DungTichDaDung = @DungTichDaDung, DungTichKhaDung = @DungTichKhaDung where MaKho = @MaKho";
            string query20 = "select DungTichKhaDung from KhoChoThue where MaKho = @MaKho";


            using (MySqlCommand cmd9 = new MySqlCommand(query9, conn))
            {

                cmd9.Parameters.AddWithValue("@MaKe", maKe);
                object result = cmd9.ExecuteScalar();
                maKho = (result.ToString());
            }

            using (MySqlCommand cmd10 = new MySqlCommand(query10, conn))
            {

                cmd10.Parameters.AddWithValue("@MaKho", maKho);
                object result = cmd10.ExecuteScalar();
                newDungTichDaDungKho = float.Parse(result.ToString()) - dungTich;
            }

            using (MySqlCommand cmd10 = new MySqlCommand(query20, conn))
            {

                cmd10.Parameters.AddWithValue("@MaKho", maKho);
                object result = cmd10.ExecuteScalar();
                newDungTichKhaDungKho = float.Parse(result.ToString()) + dungTich;
            }


            using (MySqlCommand cmd11 = new MySqlCommand(query11, conn))
            {

                cmd11.Parameters.AddWithValue("@MaKho", maKho);
                cmd11.Parameters.AddWithValue("@DungTichDaDung", newDungTichDaDungKho);
                cmd11.Parameters.AddWithValue("@DungTichKhaDung", newDungTichKhaDungKho);
                int rowsAffected = cmd11.ExecuteNonQuery();
            }


        }







        public string capNhatKhoNoiBo(DataTable dt)
        {
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    // Tắt ràng buộc khóa ngoại
                    MySqlCommand disableFKConstraintsCommand = new MySqlCommand("SET foreign_key_checks = 0;", conn);
                    disableFKConstraintsCommand.ExecuteNonQuery();

                    foreach (DataRow row in dt.Rows)
                    {
                        string maKho = row["Mã kho"].ToString(); // Giả sử khóa chính là "MaKho"
                        string chucNang = row["Chức năng"].ToString();

                        // Xây dựng câu lệnh UPDATE cho dòng hiện tại
                        string updateQuery = "UPDATE KhoNoiBo SET ChucNang = @ChucNang WHERE MaKho = @MaKho";

                        using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@ChucNang", chucNang);
                            cmd.Parameters.AddWithValue("@MaKho", maKho);

                            // Thực thi câu lệnh UPDATE
                            cmd.ExecuteNonQuery();
                        }
                    }



                    // Bật lại ràng buộc khóa ngoại
                    MySqlCommand enableFKConstraintsCommand = new MySqlCommand("SET foreign_key_checks = 1;", conn);
                    enableFKConstraintsCommand.ExecuteNonQuery();
                    return("Cập nhật dữ liệu thành công!");
                }
                catch (Exception ex)
                {
                    // Bật lại ràng buộc khóa ngoại nếu có lỗi
                    MySqlCommand enableFKConstraintsCommand = new MySqlCommand("SET foreign_key_checks = 1;", conn);
                    enableFKConstraintsCommand.ExecuteNonQuery();
                    return  ( "Lỗi khi chỉnh sửa dữ liệu : " + ex.Message);
                }
            }
        }



        public bool kiemTraKhoaChinhKho(DataTable dt)
        {
            // Lấy tất cả giá trị trong cột "MaKho"
            var maKhoList = dt.AsEnumerable()
                              .Select(row => row["Mã kho"].ToString()) // Lấy giá trị từng hàng trong cột MaKho
                              .ToList();

            // Tìm các giá trị bị trùng
            var duplicatedMaKho = maKhoList.GroupBy(maKho => maKho) // Nhóm theo mã kho
                                           .Where(group => group.Count() > 1) // Chỉ lấy các nhóm có hơn 1 lần xuất hiện
                                           .Select(group => group.Key) // Lấy giá trị của nhóm (mã kho bị trùng)
                                           .ToList();

            if (duplicatedMaKho.Count > 0)
            {
                return false;
            }


            return true;
        }



        public string capNhatKeNoiBo(DataTable dt)   // ko cho sửa kệ nội bộ ???? ???????????????????????????????
        {
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    // Tắt ràng buộc khóa ngoại
                    MySqlCommand disableFKConstraintsCommand = new MySqlCommand("SET foreign_key_checks = 0;", conn);
                    disableFKConstraintsCommand.ExecuteNonQuery();

                    foreach (DataRow row in dt.Rows)
                    {
                        string maKho = row["Mã kho"].ToString(); // Giả sử khóa chính là "MaKho"
                        string maKe = row["Mã kệ"].ToString();

                        // Xây dựng câu lệnh UPDATE cho dòng hiện tại
                        string updateQuery = "UPDATE KeNoiBo SET MaKe = @MaKe WHERE MaKho = @MaKho";

                        using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaKe", maKe);
                            cmd.Parameters.AddWithValue("@MaKho", maKho);

                            // Thực thi câu lệnh UPDATE
                            cmd.ExecuteNonQuery();
                        }
                    }



                    // Bật lại ràng buộc khóa ngoại
                    MySqlCommand enableFKConstraintsCommand = new MySqlCommand("SET foreign_key_checks = 1;", conn);
                    enableFKConstraintsCommand.ExecuteNonQuery();
                    return ("Cập nhật dữ liệu thành công!");
                }
                catch (Exception ex)
                {
                    // Bật lại ràng buộc khóa ngoại nếu có lỗi
                    MySqlCommand enableFKConstraintsCommand = new MySqlCommand("SET foreign_key_checks = 1;", conn);
                    enableFKConstraintsCommand.ExecuteNonQuery();
                    return ("Lỗi khi chỉnh sửa dữ liệu : " + ex.Message);
                }
            }
        }



        public bool kiemTraKhoaChinhKe(DataTable dt)
        {
            // Lấy tất cả giá trị trong cột "MaKho"
            var maKeList = dt.AsEnumerable()
                              .Select(row => row["Mã kệ"].ToString()) // Lấy giá trị từng hàng trong cột MaKho
                              .ToList();

            // Tìm các giá trị bị trùng
            var duplicatedMaKe = maKeList.GroupBy(maKho => maKho) // Nhóm theo mã kho
                                           .Where(group => group.Count() > 1) // Chỉ lấy các nhóm có hơn 1 lần xuất hiện
                                           .Select(group => group.Key) // Lấy giá trị của nhóm (mã kho bị trùng)
                                           .ToList();

            if (duplicatedMaKe.Count > 0)
            {
                return false;
            }

            return true;
        }



        public string capNhatHangHoaNoiBo(DataTable dt) ///////////????????????????????????
        {
            List<string> loi = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    // Tắt ràng buộc khóa ngoại
                    MySqlCommand disableFKConstraintsCommand = new MySqlCommand("SET foreign_key_checks = 0;", conn);
                    disableFKConstraintsCommand.ExecuteNonQuery();

                    foreach (DataRow row in dt.Rows)
                    {
                        string maHH = row["Mã hàng hóa"].ToString(); // Giả sử khóa chính là "MaKho"
         
                        string moTa = row["Mô tả hàng hóa"].ToString();
                        string donViTinh = row["Đơn vị tính"].ToString();
                        int soLuong = Int32.Parse(row["Số lượng"].ToString());

                        // kiểm tra xem số lượng có hợp lệ ko
                        if ( int.TryParse(row["Số lượng"].ToString() , out int result) == false   )
                        {
                            loi.Add(maHH);
                            continue; // nếu ko thì note lại mã hh này và continue
                        }
                        else
                        {
                            if (result < 0)
                            {
                                loi.Add(maHH);
                                continue; // nếu ko thì note lại mã hh này và continue
                            }    
                        }    


                        // Xây dựng câu lệnh UPDATE cho dòng hiện tại
                        string updateQuery = "UPDATE HangHoaNoiBo SET MoTaHangHoa = @MoTaHangHoa, DonViTinh = @DonViTinh, SoLuong = @SoLuong WHERE MaHangHoa = @MaHH";

                        using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaHH", maHH);
                            cmd.Parameters.AddWithValue("@MoTaHangHoa", moTa);
                            cmd.Parameters.AddWithValue("@DonViTinh", donViTinh);
                            cmd.Parameters.AddWithValue("@SoLuong", soLuong);


                            // Thực thi câu lệnh UPDATE
                            cmd.ExecuteNonQuery();
                        }
                    }



                    // Bật lại ràng buộc khóa ngoại
                    MySqlCommand enableFKConstraintsCommand = new MySqlCommand("SET foreign_key_checks = 1;", conn);
                    enableFKConstraintsCommand.ExecuteNonQuery();

                    if (loi.Count > 0)
                    {
                        string thongBao = "Cập nhật dữ liệu thành công. Các dòng bị lỗi:  ";
                        foreach (string a in loi)
                        {
                            thongBao += a + " ";
                        }
                        return thongBao;
                    }    

                    return ("Cập nhật dữ liệu thành công!");
                }
                catch (Exception ex)
                {
                    // Bật lại ràng buộc khóa ngoại nếu có lỗi
                    MySqlCommand enableFKConstraintsCommand = new MySqlCommand("SET foreign_key_checks = 1;", conn);
                    enableFKConstraintsCommand.ExecuteNonQuery();
                    return ("Lỗi khi chỉnh sửa : " + ex.Message);
                }
            }
        }



        //public bool kiemTraKhoaChinhHangHoa(DataTable dt)
        //{
        //    // Lấy tất cả giá trị trong cột "MaKho"
        //    var maHHList = dt.AsEnumerable()
        //                      .Select(row => row["Mã hàng hóa"].ToString()) // Lấy giá trị từng hàng trong cột MaKho
        //                      .ToList();

        //    // Tìm các giá trị bị trùng
        //    var duplicatedMaHH = maHHList.GroupBy(maKho => maKho) // Nhóm theo mã kho
        //                                   .Where(group => group.Count() > 1) // Chỉ lấy các nhóm có hơn 1 lần xuất hiện
        //                                   .Select(group => group.Key) // Lấy giá trị của nhóm (mã kho bị trùng)
        //                                   .ToList();

        //    if (duplicatedMaHH.Count > 0)
        //    {
        //        return false;
        //    }

        //    return true;
        //}



        public string capNhatKhoChoThue(DataTable dt)
        {
            List<string> loi = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                { 
                    conn.Open();
                    // Tắt ràng buộc khóa ngoại
                    MySqlCommand disableFKConstraintsCommand = new MySqlCommand("SET foreign_key_checks = 0;", conn);
                    disableFKConstraintsCommand.ExecuteNonQuery();


                    string query = "select sum(DungTich) from Thung where SUBSTRING_INDEX(MaNgan, '_', 1) = @MaKho ";
                    string query1 = "select sum(DungTichKhaDung) from KeChoThue where MaKho = @MaKho ";
                    foreach (DataRow row in dt.Rows)
                    {
                        if ( row == null)
                        {
                            continue;
                        }    
                        float tongDungTich = 0;
                        float tongDungTichKhaDung = 0;

                        string maKho = row["Mã kho"].ToString(); // Giả sử khóa chính là "MaKho"
                        float dungTichKhaDung = float.Parse( row["Dung tích khả dụng"].ToString());
                        float dungTichDaDung = float.Parse(row["Dung tích đã dùng"].ToString());

                        Console.WriteLine("cccccc");


                        // kiểm tra dung tích có hợp lệ ko
                        if ( dungTichDaDung <0 || dungTichKhaDung <0 )
                        {
                            loi.Add(maKho);
                            continue;
                        }


                        // kiểm tra dung tích đã dùng của kho có khớp với tổng dung tích của các thùng nằm trong kho đó hay ko
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaKho", maKho);
                            object result = cmd.ExecuteScalar();
                            if (  result == null || result == DBNull.Value)
                            {
                                tongDungTich = 0;
                            } 
                            else
                            {
                                tongDungTich = float.Parse(result.ToString());
                            }
                        }
                        Console.WriteLine(tongDungTich.ToString());
                        Console.WriteLine("gggg");

                        // kiểm tra dung tích khả dụng của kho có khớp với tổng dung tích khả dụng của các kệ nằm trong kho đó hay ko
                        using (MySqlCommand cmd = new MySqlCommand(query1, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaKho", maKho);
                            object result = cmd.ExecuteScalar();
                            if (result == null || result == DBNull.Value)
                            {
                                tongDungTichKhaDung = 0;
                            }
                            else
                            {
                                tongDungTichKhaDung = float.Parse(result.ToString());
                            }
                        }

                        if (tongDungTich != dungTichDaDung)
                        {
                            loi.Add(maKho);
                            continue;
                        }
                        if (dungTichKhaDung < tongDungTichKhaDung )
                        {
                            loi.Add(maKho);
                            continue;
                        }


                        Console.WriteLine("ádadadsd");

                        // Xây dựng câu lệnh UPDATE cho dòng hiện tại
                        string updateQuery = "UPDATE KhoChoThue SET DungTichDaDung = @DungTichDaDung, DungTichKhadung = @DungTichKhadung  WHERE MaKho = @MaKho";

                        using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaKho", maKho);
                            cmd.Parameters.AddWithValue("@DungTichDaDung", dungTichDaDung);
                            cmd.Parameters.AddWithValue("@DungTichKhadung", dungTichKhaDung);
                        


                            // Thực thi câu lệnh UPDATE
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Bật lại ràng buộc khóa ngoại
                    MySqlCommand enableFKConstraintsCommand = new MySqlCommand("SET foreign_key_checks = 1;", conn);
                    enableFKConstraintsCommand.ExecuteNonQuery();



                    if (loi.Count > 0)
                    {
                        string thongBao = "Cập nhật dữ liệu thành công. Các dòng bị lỗi:  ";
                        foreach (string a in loi)
                        {
                            thongBao += a + " ";
                        }
                        return thongBao;
                    }

                    return ("Cập nhật dữ liệu thành công!");
                }
                catch (Exception ex)
                {
                    

                    // Bật lại ràng buộc khóa ngoại nếu có lỗi
                    MySqlCommand enableFKConstraintsCommand = new MySqlCommand("SET foreign_key_checks = 1;", conn);
                    enableFKConstraintsCommand.ExecuteNonQuery();
                    return ("lỗi khi chỉnh sửa dữ liệu: " + ex.Message);
                }
            }
        }




        public string capNhatKeChoThue(DataTable dt)
        {

            List<string> loi = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    // Tắt ràng buộc khóa ngoại
                    MySqlCommand disableFKConstraintsCommand = new MySqlCommand("SET foreign_key_checks = 0;", conn);
                    disableFKConstraintsCommand.ExecuteNonQuery();


                    string query = "select sum(DungTich) from Thung where SUBSTRING_INDEX(MaNgan, '_', 2) = @MaKe ";
                    string query1 = "select sum(DungTichKhaDung) from Tang where MaKe = @MaKe ";

                    string query2 = "select sum(DungTichKhaDung) from KeChoThue where SUBSTRING_INDEX(MaKe, '_', 1) = SUBSTRING_INDEX(@MaKe, '_', 1) and MaKe != @Make ";
                    string query3 = "select DungTichKhaDung from KhoChoThue where MaKho = SUBSTRING_INDEX(@MaKe, '_', 1) ";
                    foreach (DataRow row in dt.Rows)
                    {
                        float tongDungTich =0 ;
                        float tongDungTichKhaDungTang = 0;

                        float tongDungTichKhaDungKe = 0;
                        float dungTichKhaDungKho=0;

                        string maKe = row["Mã kệ"].ToString(); 
                        float dungTichKhaDung = float.Parse(row["Dung tích khả dụng"].ToString());
                        float dungTichDaDung = float.Parse(row["Dung tích đã dùng"].ToString());


                        // kiểm tra dung tích có hợp lệ ko
                        if (dungTichDaDung < 0 || dungTichKhaDung < 0)
                        {
                            loi.Add(maKe);
                            continue;
                        }


                        // kiểm tra dung tích đã dùng của kệ có khớp với tổng dung tích của các thùng nằm trong kệ đó hay ko
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaKe", maKe);
                            object result = cmd.ExecuteScalar();
                            if (result == null || result == DBNull.Value)
                            {
                                tongDungTich = 0;
                            }
                            else
                            {
                                tongDungTich = float.Parse(result.ToString());
                            }
                        }


                        // kiểm tra dung tích khả dụng của kệ có khớp với tổng dung tích khả dụng của các tầng nằm trong kho đó hay ko
                        using (MySqlCommand cmd = new MySqlCommand(query1, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaKe", maKe);
                            object result = cmd.ExecuteScalar();
                            if (result == null || result == DBNull.Value)
                            {
                                tongDungTichKhaDungTang = 0;
                            }
                            else
                            {
                                tongDungTichKhaDungTang = float.Parse(result.ToString());
                            }
                        }


                        // lấy tổng dung tích các kệ nằm chung kho với kệ này ( ko tính kệ này )
                        using (MySqlCommand cmd = new MySqlCommand(query2, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaKe", maKe);
                            object result = cmd.ExecuteScalar();
                            if (result == null || result == DBNull.Value)
                            {
                                tongDungTichKhaDungKe = 0;
                            }
                            else
                            {
                                tongDungTichKhaDungKe = float.Parse(result.ToString());
                            }
                        }

                        // lấy dung tích khả dụng của kho chứa kệ này
                        using (MySqlCommand cmd = new MySqlCommand(query3, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaKe", maKe);
                            object result = cmd.ExecuteScalar();
                            if (result == null || result == DBNull.Value)
                            {
                                dungTichKhaDungKho = 0;
                            }
                            else
                            {
                                dungTichKhaDungKho = float.Parse(result.ToString());
                            }
                        }




                        if (tongDungTich != dungTichDaDung)
                        {
                            loi.Add(maKe);
                            continue;
                        }
                        if (dungTichKhaDung < tongDungTichKhaDungTang )
                        {
                            loi.Add(maKe);
                            continue;
                        }
                        if (dungTichKhaDung > dungTichKhaDungKho - tongDungTichKhaDungKe)
                        {
                            loi.Add(maKe);
                            continue;
                        }

                        // Xây dựng câu lệnh UPDATE cho dòng hiện tại
                        string updateQuery = "UPDATE KeChoThue SET DungTichDaDung = @DungTichDaDung, DungTichKhadung = @DungTichKhadung  WHERE MaKe = @MaKe";

                        using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaKe", maKe);
                            cmd.Parameters.AddWithValue("@DungTichDaDung", dungTichDaDung);
                            cmd.Parameters.AddWithValue("@DungTichKhadung", dungTichKhaDung);



                            // Thực thi câu lệnh UPDATE
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Bật lại ràng buộc khóa ngoại
                    MySqlCommand enableFKConstraintsCommand = new MySqlCommand("SET foreign_key_checks = 1;", conn);
                    enableFKConstraintsCommand.ExecuteNonQuery();



                    if (loi.Count > 0)
                    {
                        string thongBao = "Cập nhật dữ liệu thành công. Các dòng bị lỗi:  ";
                        foreach (string a in loi)
                        {
                            thongBao += a + " ";
                        }
                        return thongBao;
                    }

                    return ("Cập nhật dữ liệu thành công!");
                }
                catch (Exception ex)
                {


                    // Bật lại ràng buộc khóa ngoại nếu có lỗi
                    MySqlCommand enableFKConstraintsCommand = new MySqlCommand("SET foreign_key_checks = 1;", conn);
                    enableFKConstraintsCommand.ExecuteNonQuery();
                    return ("lỗi khi chỉnh sửa dữ liệu: " + ex.Message);
                }
            }
        }




        public string capNhatTang(DataTable dt)
        {
            List<string> loi = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    // Tắt ràng buộc khóa ngoại
                    MySqlCommand disableFKConstraintsCommand = new MySqlCommand("SET foreign_key_checks = 0;", conn);
                    disableFKConstraintsCommand.ExecuteNonQuery();


                    string query = "select sum(DungTich) from Thung where SUBSTRING_INDEX(MaNgan, '_', 3) = @MaTang ";
                    string query1 = "select sum(DungTichKhaDung) from Ngan where SUBSTRING_INDEX(MaNgan, '_', 3) = @MaTang ";

                    string query2 = "select sum(DungTichKhaDung) from Tang where SUBSTRING_INDEX(MaTang, '_', 2) = SUBSTRING_INDEX(@MaTang, '_', 2) and MaTang != @MaTang ";
                    string query3 = "select DungTichKhaDung from KeChoThue where MaKe = SUBSTRING_INDEX(@MaTang, '_', 2) ";
                    foreach (DataRow row in dt.Rows)
                    {
                        float tongDungTich;
                        float tongDungTichKhaDungNgan;

                        float tongDungTichKhaDungTang;
                        float dungTichKhaDungKe;

                        string maTang = row["Mã tầng"].ToString();
                        float dungTichKhaDung = float.Parse(row["Dung tích khả dụng"].ToString());
                        float dungTichDaDung = float.Parse(row["Dung tích đã dùng"].ToString());


                        // kiểm tra dung tích có hợp lệ ko
                        if (dungTichDaDung < 0 || dungTichKhaDung < 0)
                        {
                            loi.Add(maTang);
                            continue;
                        }


                        // kiểm tra dung tích đã dùng của tầng có khớp với tổng dung tích của các thùng nằm trong tầng đó hay ko
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaTang", maTang);
                            object result = cmd.ExecuteScalar();
                            if (result == null || result == DBNull.Value)
                            {
                                tongDungTich = 0;
                            }
                            else
                            {
                                tongDungTich = float.Parse(result.ToString());
                            }
                        }


                        // kiểm tra dung tích khả dụng của tầng có > tổng dung tích khả dụng của các ngăn nằm trong kho đó hay ko
                        using (MySqlCommand cmd = new MySqlCommand(query1, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaTang", maTang);
                            object result = cmd.ExecuteScalar();
                            if (result == null || result == DBNull.Value)
                            {
                                tongDungTichKhaDungNgan = 0;
                            }
                            else
                            {
                                tongDungTichKhaDungNgan = float.Parse(result.ToString());
                            }
                        }


                        // lấy tổng dung tích khả dụng các tầng nằm chung kệ
                        using (MySqlCommand cmd = new MySqlCommand(query2, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaTang", maTang);
                            object result = cmd.ExecuteScalar();
                            if (result == null  || result == DBNull.Value)
                            {
                                tongDungTichKhaDungTang = 0;
                            }
                            else
                            {
                                tongDungTichKhaDungTang = float.Parse(result.ToString());
                            }
                        }

                        // lấy dung tích khả dụng của kệ chứa tầng này
                        using (MySqlCommand cmd = new MySqlCommand(query3, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaTang", maTang);
                            object result = cmd.ExecuteScalar();
                            if (result == null || result == DBNull.Value)
                            {
                                dungTichKhaDungKe = 0;
                            }
                            else
                            {
                                dungTichKhaDungKe = float.Parse(result.ToString());
                            }
                        }




                        if (tongDungTich != dungTichDaDung)
                        {
                            loi.Add(maTang);
                            continue;
                        }
                        if (dungTichKhaDung < tongDungTichKhaDungNgan)
                        {
                            loi.Add(maTang);
                            continue;
                        }
                        if (dungTichKhaDung > dungTichKhaDungKe - tongDungTichKhaDungTang)
                        {
                            loi.Add(maTang);
                            continue;
                        }

                        // Xây dựng câu lệnh UPDATE cho dòng hiện tại
                        string updateQuery = "UPDATE Tang SET DungTichDaDung = @DungTichDaDung, DungTichKhadung = @DungTichKhadung  WHERE MaTang = @MaTang";

                        using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaTang", maTang);
                            cmd.Parameters.AddWithValue("@DungTichDaDung", dungTichDaDung);
                            cmd.Parameters.AddWithValue("@DungTichKhadung", dungTichKhaDung);



                            // Thực thi câu lệnh UPDATE
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Bật lại ràng buộc khóa ngoại
                    MySqlCommand enableFKConstraintsCommand = new MySqlCommand("SET foreign_key_checks = 1;", conn);
                    enableFKConstraintsCommand.ExecuteNonQuery();



                    if (loi.Count > 0)
                    {
                        string thongBao = "Cập nhật dữ liệu thành công. Các dòng bị lỗi:  ";
                        foreach (string a in loi)
                        {
                            thongBao += a + " ";
                        }
                        return thongBao;
                    }

                    return ("Cập nhật dữ liệu thành công!");
                }
                catch (Exception ex)
                {


                    // Bật lại ràng buộc khóa ngoại nếu có lỗi
                    MySqlCommand enableFKConstraintsCommand = new MySqlCommand("SET foreign_key_checks = 1;", conn);
                    enableFKConstraintsCommand.ExecuteNonQuery();
                    return ("lỗi khi chỉnh sửa dữ liệu: " + ex.Message);
                }
            }
        }


        //public bool kiemTraKhoaChinhTang(DataTable dt)
        //{
        //    // Lấy tất cả giá trị trong cột "MaKho"
        //    var maTangList = dt.AsEnumerable()
        //                      .Select(row => row["Mã tầng"].ToString()) // Lấy giá trị từng hàng trong cột MaKho
        //                      .ToList();

        //    // Tìm các giá trị bị trùng
        //    var duplicatedMaTang = maTangList.GroupBy(maKho => maKho) // Nhóm theo mã kho
        //                                   .Where(group => group.Count() > 1) // Chỉ lấy các nhóm có hơn 1 lần xuất hiện
        //                                   .Select(group => group.Key) // Lấy giá trị của nhóm (mã kho bị trùng)
        //                                   .ToList();

        //    if (duplicatedMaTang.Count > 0)
        //    {
        //        return false;
        //    }

        //    return true;
        //}



        public string capNhatNgan(DataTable dt)
        {
            List<string> loi = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    // Tắt ràng buộc khóa ngoại
                    MySqlCommand disableFKConstraintsCommand = new MySqlCommand("SET foreign_key_checks = 0;", conn);
                    disableFKConstraintsCommand.ExecuteNonQuery();


                    string query = "select sum(DungTich) from Thung where MaNgan = @MaNgan ";
                    string query1 = "select sum(DungTichKhaDung) from Ngan where MaTang = @MaTang and MaNgan != @MaNgan ";
                    string query2 = "select DungTichKhaDung from Tang where MaTang = @MaTang";
                    foreach (DataRow row in dt.Rows)
                    {
                        float tongDungTich;
                        float tongDungTichKhaDungNgan;
                        float DungTichKhaDungTang;

                        string maNgan = row["Mã ngăn"].ToString();
                        string maTang = row["Mã tầng"].ToString();
                        float dungTichKhaDung = float.Parse(row["Dung tích khả dụng"].ToString());
                        float dungTichDaDung = float.Parse(row["Dung tích đã dùng"].ToString());


                        // kiểm tra dung tích có hợp lệ ko
                        if (dungTichDaDung < 0 || dungTichKhaDung < 0)
                        {
                            loi.Add(maNgan);
                            continue;
                        }


                        // kiểm tra dung tích đã dùng của ngăn có khớp với tổng dung tích của các thùng nằm trong ngăn đó hay ko
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaTang", maTang);
                            object result = cmd.ExecuteScalar();
                            if (result == null || result == DBNull.Value)
                            {
                                tongDungTich = 0;
                            }
                            else
                            {
                                tongDungTich = float.Parse(result.ToString());
                            }
                        }

                        // kiểm tra dung tích khả dụng
                        using (MySqlCommand cmd = new MySqlCommand(query1, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaTang", maTang);
                            cmd.Parameters.AddWithValue("@MaNgan", maNgan);
                            object result = cmd.ExecuteScalar();
                            if (result == null || result == DBNull.Value )
                            {
                                tongDungTichKhaDungNgan = 0;
                            }
                            else
                            {
                                tongDungTichKhaDungNgan = float.Parse(result.ToString());
                            }
                        }

                        using (MySqlCommand cmd = new MySqlCommand(query2, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaTang", maTang);
                            
                            object result = cmd.ExecuteScalar();
                            if (result == null || result == DBNull.Value)
                            {
                                DungTichKhaDungTang = 0;
                            }
                            else
                            {
                                DungTichKhaDungTang = float.Parse(result.ToString());
                            }
                        }

                        if (tongDungTich != dungTichDaDung)
                        {
                            loi.Add(maNgan);
                            continue;
                        }
                        if (dungTichKhaDung > DungTichKhaDungTang -  tongDungTichKhaDungNgan)
                        {
                            loi.Add(maNgan);
                            continue;
                        }

                        // Xây dựng câu lệnh UPDATE cho dòng hiện tại
                        string updateQuery = "UPDATE Ngan SET DungTichDaDung = @DungTichDaDung, DungTichKhadung = @DungTichKhadung  WHERE MaNgan = @MaNgan";

                        using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaNgan", maNgan);
                            cmd.Parameters.AddWithValue("@DungTichDaDung", dungTichDaDung);
                            cmd.Parameters.AddWithValue("@DungTichKhadung", dungTichKhaDung);



                            // Thực thi câu lệnh UPDATE
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Bật lại ràng buộc khóa ngoại
                    MySqlCommand enableFKConstraintsCommand = new MySqlCommand("SET foreign_key_checks = 1;", conn);
                    enableFKConstraintsCommand.ExecuteNonQuery();



                    if (loi.Count > 0)
                    {
                        string thongBao = "Cập nhật dữ liệu thành công. Các dòng bị lỗi:  ";
                        foreach (string a in loi)
                        {
                            thongBao += a + " ";
                        }
                        return thongBao;
                    }

                    return ("Cập nhật dữ liệu thành công!");
                }
                catch (Exception ex)
                {


                    // Bật lại ràng buộc khóa ngoại nếu có lỗi
                    MySqlCommand enableFKConstraintsCommand = new MySqlCommand("SET foreign_key_checks = 1;", conn);
                    enableFKConstraintsCommand.ExecuteNonQuery();
                    return ("lỗi khi chỉnh sửa dữ liệu: " + ex.Message);
                }
            }
        }


        public bool kiemTraKhoaChinhNgan(DataTable dt)
        {
            // Lấy tất cả giá trị trong cột "MaKho"
            var maNganList = dt.AsEnumerable()
                              .Select(row => row["Mã ngăn"].ToString()) // Lấy giá trị từng hàng trong cột MaKho
                              .ToList();

            // Tìm các giá trị bị trùng
            var duplicatedMaNgan = maNganList.GroupBy(maKho => maKho) // Nhóm theo mã kho
                                           .Where(group => group.Count() > 1) // Chỉ lấy các nhóm có hơn 1 lần xuất hiện
                                           .Select(group => group.Key) // Lấy giá trị của nhóm (mã kho bị trùng)
                                           .ToList();

            if (duplicatedMaNgan.Count > 0)
            {
                return false;
            }

            return true;
        }



        public string capNhatThung(DataTable dt)
        {

            List<string> loi = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    // Tắt ràng buộc khóa ngoại
                    MySqlCommand disableFKConstraintsCommand = new MySqlCommand("SET foreign_key_checks = 0;", conn);
                    disableFKConstraintsCommand.ExecuteNonQuery();


                    string query = "update Thung set NgayGiaHan = @NgayGiaHan, MoTaHangHoa = @MoTaHangHoa where MaThung = @MaThung";

                    foreach (DataRow row in dt.Rows)
                    {
                        string maThung = row["Mã thùng"].ToString();
                        string moTa = row["Mô tả hàng hóa"].ToString();
                        DateTime ngayNhap = DateTime.Parse(row["Ngày nhập kho"].ToString());

                        if (DateTime.TryParse(row["Ngày gia hạn"].ToString(), out DateTime result) == false)
                        {
                            Console.WriteLine("Ngày gia hạn không hợp lệ");
                            return "Ngày gia hạn không hợp lệ";
                        }

                       

                        if (result < ngayNhap)
                        {
                            loi.Add(maThung);
                            continue;
                        }

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaThung", maThung);
                            cmd.Parameters.AddWithValue("@MoTaHangHoa", moTa);
                            cmd.Parameters.AddWithValue("@NgayGiaHan", DateTime.Parse(row["Ngày gia hạn"].ToString()));

                            // Thực thi câu lệnh UPDATE
                            cmd.ExecuteNonQuery();
                        }

                    }

                    // Bật lại ràng buộc khóa ngoại
                    MySqlCommand enableFKConstraintsCommand = new MySqlCommand("SET foreign_key_checks = 1;", conn);
                    enableFKConstraintsCommand.ExecuteNonQuery();



                    if (loi.Count > 0)
                    {
                        string thongBao = "Đã cập nhật. Các dòng chưa hợp lệ:  ";
                        foreach (string a in loi)
                        {
                            thongBao += a + " ";
                        }
                        return thongBao;
                    }

                    return ("Cập nhật dữ liệu thành công!");
                }
                catch (Exception ex)
                {
                    // Bật lại ràng buộc khóa ngoại nếu có lỗi
                    MySqlCommand enableFKConstraintsCommand = new MySqlCommand("SET foreign_key_checks = 1;", conn);
                    enableFKConstraintsCommand.ExecuteNonQuery();
                    return ("lỗi khi chỉnh sửa dữ liệu: " + ex.Message);
                }
            }
        }


        //public string capNhatThung(DataTable dt)
        //{

        //    List<string> loi = new List<string>();
        //    using (MySqlConnection conn = new MySqlConnection(ketNoi))
        //    {
        //        try
        //        {
        //            conn.Open();
        //            // Tắt ràng buộc khóa ngoại
        //            MySqlCommand disableFKConstraintsCommand = new MySqlCommand("SET foreign_key_checks = 0;", conn);
        //            disableFKConstraintsCommand.ExecuteNonQuery();


        //            string query = "select (DungTichKhaDung - DungTichDaDung) from Ngan where MaNgan = @MaNgan";

        //            foreach (DataRow row in dt.Rows)
        //            {


        //                string maThung = row["Mã thùng"].ToString();
        //                string maNgan = row["Mã ngăn"].ToString();
        //                string trangThai = row["Trạng thái"].ToString();
        //                float dungTich = float.Parse(row["Dung tích"].ToString());
        //                string moTa = row["Mô tả"].ToString();
        //                DateTime ngayHH = DateTime.Parse(row["Ngày nhập kho"].ToString());
        //                DateTime ngayNhap = DateTime.Parse(row["Ngày hết hạn"].ToString());
        //                string temSo = row["Tem số"].ToString();



        //                // kiểm tra dung tích có hợp lệ ko
        //                if (dungTich < 0)
        //                {
        //                    loi.Add(maThung);
        //                    continue;
        //                }

        //                if (ngayHH < ngayNhap)
        //                {
        //                    loi.Add(maThung);
        //                    continue;
        //                }

        //                if (trangThai != "Chưa lấy" && trangThai != "Đã lấy" && trangThai != "0" && trangThai != "1")
        //                {
        //                    loi.Add(maThung);
        //                    continue;
        //                }

        //                if ( int.TryParse(temSo,out int result) == false)
        //                {
        //                    loi.Add(maThung);
        //                    continue;
        //                }    
        //                else
        //                {
        //                    if ( result < 0)
        //                    {
        //                        loi.Add(maThung);
        //                        continue;
        //                    }    
        //                }




        //                float dungTichNgan;

        //                // kiểm tra dung tích ngăn còn đủ để chứa ko
        //                using (MySqlCommand cmd = new MySqlCommand(query, conn))
        //                {
        //                    cmd.Parameters.AddWithValue("@MaNgan", maNgan);

        //                    object ketQua = cmd.ExecuteScalar();

        //                    if (ketQua == null || ketQua == DBNull.Value)
        //                    {
        //                        dungTichNgan = 0;
        //                    }
        //                    else
        //                    {
        //                        dungTichNgan = float.Parse(ketQua.ToString());
        //                    }


        //                }

        //                if ( dungTich > dungTichNgan)
        //                {
        //                    loi.Add(maThung);
        //                    continue;
        //                }    



        //                // Xây dựng câu lệnh UPDATE cho dòng hiện tại
        //                string updateQuery = "UPDATE Thung SET DungTich = @DungTich, TrangThai = @TrangThai, NgayHetHan = @NgayHetHan,MoTa = @MoTa,TemSo = @TemSo  WHERE MaThung = @MaThung";

        //                string updateNgan = "update Ngan set DungTichDaDung = @DungTich where MaNgan = @MaNgan";
        //                string updateTang = "update Tang set DungTichDaDung = @DungTich where MaTang = SUBSTRING_INDEX(@MaNgan, '_', 3)";
        //                string updateKe = "update KeChoThue set DungTichDaDung = @DungTich where MaKe = SUBSTRING_INDEX(@MaNgan, '_', 2)";
        //                string updateKho = "update KhoChoThue set DungTichDaDung = @DungTich where MaKho = SUBSTRING_INDEX(@MaNgan, '_', 1)";

        //                string query_ngan = "select sum(DungTich) from Thung where MaNgan = @MaNgan ";
        //                string query_tang = "select sum(DungTich) from Thung where SUBSTRING_INDEX(MaNgan, '_', 3) = SUBSTRING_INDEX(@MaNgan, '_', 3) ";
        //                string query_ke = "select sum(DungTich) from Thung where SUBSTRING_INDEX(MaNgan, '_', 2) = SUBSTRING_INDEX(@MaNgan, '_', 2) ";
        //                string query_kho = "select sum(DungTich) from Thung where SUBSTRING_INDEX(MaNgan, '_', 1) = SUBSTRING_INDEX(@MaNgan, '_', 1) ";



        //                using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
        //                {
        //                    cmd.Parameters.AddWithValue("@DungTich", dungTich);
        //                    cmd.Parameters.AddWithValue("@TrangThai", trangThai);
        //                    cmd.Parameters.AddWithValue("@NgayHetHan", ngayHH);
        //                    cmd.Parameters.AddWithValue("@MoTa", moTa);
        //                    cmd.Parameters.AddWithValue("@TemSo", temSo);
        //                    cmd.Parameters.AddWithValue("@MaThung", maThung);

        //                    // Thực thi câu lệnh UPDATE
        //                    cmd.ExecuteNonQuery();
        //                }



        //                float dungTichDaDungNgan;
        //                using (MySqlCommand cmd = new MySqlCommand(query_ngan, conn))
        //                {
        //                    cmd.Parameters.AddWithValue("@MaNgan", maNgan);

        //                    object ketQua = cmd.ExecuteScalar();
        //                    if (ketQua == null || ketQua == DBNull.Value)
        //                    {
        //                        dungTichDaDungNgan = 0;
        //                    }
        //                    else
        //                    {
        //                        dungTichDaDungNgan = float.Parse(ketQua.ToString());
        //                    }



        //                    // Thực thi câu lệnh UPDATE
        //                    cmd.ExecuteNonQuery();
        //                }

        //                using (MySqlCommand cmd = new MySqlCommand(updateNgan, conn))
        //                {
        //                    cmd.Parameters.AddWithValue("@DungTich", dungTichDaDungNgan);

        //                    // Thực thi câu lệnh UPDATE
        //                    cmd.ExecuteNonQuery();
        //                }


        //                float dungTichDaDungTang;
        //                using (MySqlCommand cmd = new MySqlCommand(query_tang, conn))
        //                {
        //                    cmd.Parameters.AddWithValue("@MaNgan", maNgan);

        //                    object ketQua = cmd.ExecuteScalar();
        //                    if (ketQua == null || ketQua == DBNull.Value)
        //                    {
        //                        dungTichDaDungTang = 0;
        //                    }
        //                    else
        //                    {
        //                        dungTichDaDungTang = float.Parse(ketQua.ToString());
        //                    }




        //                    cmd.ExecuteNonQuery();
        //                }


        //                using (MySqlCommand cmd = new MySqlCommand(updateTang, conn))
        //                {
        //                    cmd.Parameters.AddWithValue("@DungTich", dungTichDaDungTang);

        //                    // Thực thi câu lệnh UPDATE
        //                    cmd.ExecuteNonQuery();
        //                }



        //                float dungTichDaDungKe;
        //                using (MySqlCommand cmd = new MySqlCommand(query_ke, conn))
        //                {
        //                    cmd.Parameters.AddWithValue("@MaNgan", maNgan);

        //                    object ketQua = cmd.ExecuteScalar();


        //                    if (ketQua == null || ketQua == DBNull.Value)
        //                    {
        //                        dungTichDaDungKe = 0;
        //                    }
        //                    else
        //                    {
        //                        dungTichDaDungKe = float.Parse(ketQua.ToString());
        //                    }


        //                    // Thực thi câu lệnh UPDATE
        //                    cmd.ExecuteNonQuery();
        //                }


        //                using (MySqlCommand cmd = new MySqlCommand(updateKe, conn))
        //                {
        //                    cmd.Parameters.AddWithValue("@DungTich", dungTichDaDungKe);

        //                    // Thực thi câu lệnh UPDATE
        //                    cmd.ExecuteNonQuery();
        //                }





        //                float dungTichDaDungKho;
        //                using (MySqlCommand cmd = new MySqlCommand(query_kho, conn))
        //                {
        //                    cmd.Parameters.AddWithValue("@MaNgan", maNgan);

        //                    object ketQua = cmd.ExecuteScalar();
        //                    if (ketQua == null || ketQua == DBNull.Value)
        //                    {
        //                        dungTichDaDungKho = 0;
        //                    }
        //                    else
        //                    {
        //                        dungTichDaDungKho = float.Parse(ketQua.ToString());
        //                    }


        //                    // Thực thi câu lệnh UPDATE
        //                    cmd.ExecuteNonQuery();
        //                }



        //                using (MySqlCommand cmd = new MySqlCommand(updateKho, conn))
        //                {
        //                    cmd.Parameters.AddWithValue("@MaNgan", maNgan);


        //                    // Thực thi câu lệnh UPDATE
        //                    cmd.ExecuteNonQuery();
        //                }


        //            }

        //            // Bật lại ràng buộc khóa ngoại
        //            MySqlCommand enableFKConstraintsCommand = new MySqlCommand("SET foreign_key_checks = 1;", conn);
        //            enableFKConstraintsCommand.ExecuteNonQuery();



        //            if (loi.Count > 0)
        //            {
        //                string thongBao = "Cập nhật dữ liệu thành công. Các dòng bị lỗi:  ";
        //                foreach (string a in loi)
        //                {
        //                    thongBao += a + " ";
        //                }
        //                return thongBao;
        //            }

        //            return ("Cập nhật dữ liệu thành công!");
        //        }
        //        catch (Exception ex)
        //        {


        //            // Bật lại ràng buộc khóa ngoại nếu có lỗi
        //            MySqlCommand enableFKConstraintsCommand = new MySqlCommand("SET foreign_key_checks = 1;", conn);
        //            enableFKConstraintsCommand.ExecuteNonQuery();
        //            return ("lỗi khi chỉnh sửa dữ liệu: " + ex.Message);
        //        }
        //    }
        //}





        public bool kiemTraKhoaChinhThung(DataTable dt)
        {
            // Lấy tất cả giá trị trong cột "MaKho"
            var maThungList = dt.AsEnumerable()
                              .Select(row => row["Mã thùng"].ToString()) // Lấy giá trị từng hàng trong cột MaKho
                              .ToList();

            // Tìm các giá trị bị trùng
            var duplicatedMaThung = maThungList.GroupBy(maKho => maKho) // Nhóm theo mã kho
                                           .Where(group => group.Count() > 1) // Chỉ lấy các nhóm có hơn 1 lần xuất hiện
                                           .Select(group => group.Key) // Lấy giá trị của nhóm (mã kho bị trùng)
                                           .ToList();

            if (duplicatedMaThung.Count > 0)
            {
                return false;
            }

            return true;
        }

        public List<string> KiemTraHetHan()
        {
            List<string> ycHetHan = new List<string>();
            DataTable dt = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Thung WHERE DATEDIFF(NgayGiaHan, @NgayHienTai) <= 5";

                    // Create the MySqlCommand and add the parameter
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NgayHienTai", DateTime.Now);

                        // Use MySqlDataAdapter to fill the DataTable
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }

                    // Iterate through the rows of the DataTable
                    foreach (DataRow row in dt.Rows)
                    {
                        ycHetHan.Add(row["MaThung"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return ycHetHan;
        }


        public List<string> KiemTraSoLuong()
        {
            List<string> slKhongDu = new List<string>();
            DataTable dt = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(ketNoi))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM HangHoaNoiBo WHERE SoLuong = 0";

                    // Create the MySqlCommand and add the parameter
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                       

                        // Use MySqlDataAdapter to fill the DataTable
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }

                    // Iterate through the rows of the DataTable
                    foreach (DataRow row in dt.Rows)
                    {
                        slKhongDu.Add(row["MaHangHoa"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return slKhongDu;
        }














        //public bool CapNhat(string maYeuCauHienTai, string trangthaimoi)
        //{
        //    try
        //    {
        //        using (MySqlConnection conn = new MySqlConnection(ketNoi))
        //        {
        //            conn.Open();
        //            string query = "UPDATE YeuCauKhachHang SET TrangThaiXuLy = @trangthaimoi WHERE MaYC = @maYeuCauHienTai";
        //            using (MySqlCommand cmd = new MySqlCommand(query, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@trangthaimoi", trangthaimoi);
        //                cmd.Parameters.AddWithValue("maYeuCauHienTai", maYeuCauHienTai);
        //                cmd.ExecuteNonQuery();
        //                int rowsAffected = cmd.ExecuteNonQuery();

        //                // Trả về true nếu có ít nhất một dòng được cập nhật
        //                return rowsAffected > 0;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Lỗi khi cập nhật trạng thái: " + ex.Message);
        //    }
        //}

        //public (string Email, string TenKhachHang, DateTime NgayDangKy, int SoLuongThungS, int SoLuongThungM, int SoLuongThungL, DateTime NgayHetHan) LayThongTinKho(string maYeuCau)
        //{
        //    string idNhanVien = "";
        //    string idKho = "";


        //    using (MySqlConnection conn = new MySqlConnection(ketNoi))
        //    {
        //        try
        //        {
        //            conn.Open();
        //            string query = @"SELECT y.MaYC, y.TrangThaiXuLy, y.NgayYeuCau, y.SoLuongThungS, y.SoLuongThungM, y.SoLuongThungL, 
        //                            y.DungTich, y.NgayHetHan, y.VanChuyen, k.TenKH, k.Email 
        //                            FROM YeuCauKhachHang y
        //                            INNER JOIN KhachHang k ON y.CCCD = k.CCCD
        //                            WHERE y.MaYC = @maYeuCau AND y.TrangThaiXuLy = 'Đang xử lý'";

        //            using (MySqlCommand cmd = new MySqlCommand(query, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@maYeuCau", maYeuCau);

        //                using (var reader = cmd.ExecuteReader())
        //                {
        //                    if (reader.Read())
        //                    {
        //                        emailNguoiNhan = reader["Email"].ToString();
        //                        tenKhachHang = reader["TenKH"].ToString();
        //                        ngayDangKy = reader.GetDateTime(reader.GetOrdinal("NgayYeuCau"));
        //                        soLuongThungS = reader.GetInt32(reader.GetOrdinal("SoLuongThungS"));
        //                            soLuongThungM = reader.GetInt32(reader.GetOrdinal("SoLuongThungM"));
        //                            soLuongThungL = reader.GetInt32(reader.GetOrdinal("SoLuongThungL"));
        //                            ngayHetHan = reader.GetDateTime(reader.GetOrdinal("NgayHetHan"));
        //                        }
        //                    }
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine("Lỗi khi lấy thông tin yêu cầu: " + ex.Message);
        //            }
        //        }

        //        return (emailNguoiNhan, tenKhachHang, ngayDangKy, soLuongThungS, soLuongThungM, soLuongThungL, ngayHetHan);
        //    }


        public string inDanhSach(string danhSach, string filePath)
        {
            try
            {
                string truyVan = "";
                if (danhSach == "Danh sách kho nội bộ")
                {
                    truyVan = " SELECT \r\n     MaKho as 'Mã kho',\r\n     ChucNang as 'Chức năng'\r\n FROM KhoNoiBo ";
                }
                if (danhSach == "Danh sách kệ nội bộ")
                {
                    truyVan = "SELECT \r\n    MaKe as 'Mã kệ',\r\n    MaKho as 'Mã kho'\r\nFROM KeNoiBo";
                }
                if (danhSach == "Danh sách hàng hóa nội bộ")
                {
                    truyVan = "SELECT \r\n    MaHangHoa as 'Mã hàng hóa', MaKe as 'Mã kệ', DonViTinh as 'Đơn vị tính',SoLuong as 'Số lượng',MoTaHangHoa as 'Mô tả hàng hóa'\r\nFROM HangHoaNoiBo";
                }
                if (danhSach == "Danh sách kho cho thuê")
                {
                    truyVan = "SELECT \r\n    MaKho as 'Mã kho',\r\n    DungTichKhaDung 'Dung tích khả dụng',\r\n    DungTichDaDung as 'Dung tích đã dùng'\r\nFROM KhoChoThue ";
                }
                if (danhSach == "Danh sách kệ cho thuê")
                {
                    truyVan = "SELECT \r\n     MaKe as 'Mã kệ', \r\n     MaKho as 'Mã kho' ,\r\n     DungTichDaDung as 'Dung tích đã dùng', \r\n     DungTichKhaDung as 'Dung tích khả dụng'\r\n FROM KeChoThue";
                }
                if (danhSach == "Danh sách tầng")
                {
                    truyVan = "SELECT \r\n    MaTang as 'Mã tầng',\r\n    MaKe as 'Mã kệ',\r\n    DungTichDaDung as 'Dung tích đã dùng',\r\n    DungTichKhaDung as 'Dung tích khả dụng'\r\nFROM Tang";
                }
                if (danhSach == "Danh sách ngăn")
                {
                    truyVan = "SELECT \r\n     MaNgan as 'Mã ngăn',\r\n     DungTichDaDung as 'Dung tích đã dùng',\r\n     DungTichKhaDung as 'Dung tích khả dụng',\r\n     MaTang as 'Mã tầng'\r\n FROM Ngan";
                }
                if (danhSach == "Danh sách thùng")
                {
                    truyVan = "SELECT \r\n      MaThung as 'Mã thùng',\r\n      MaYC as 'Mã yêu cầu',\r\n      MaNgan as 'Mã ngăn',\r\n      TemSo as 'Tem số',\r\n      TrangThai as 'Trạng thái', \r\n      DungTich as 'Dung tích',\r\n      NgayNhapKho as 'Ngày nhập kho',\r\n      MaNV as 'Mã nhân viên',\r\n      MoTaHangHoa as 'Mô tả hàng hóa',\r\n      NgayGiaHan as 'Ngày gia hạn'\r\n  FROM Thung";
                }
             

                DataTable dt = new DataTable();

                using (MySqlConnection conn = new MySqlConnection(ketNoi))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(truyVan, conn))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(truyVan, conn);

                        adapter.Fill(dt);

                        if ( dt == null)
                        {
                            return "không có dữ liệu để in";
                        }    


                        // Đường dẫn font Arial Unicode
                        string fontPath = @"C:\Windows\Fonts\arial.ttf"; // Đường dẫn chính xác tới font
                        PdfFont font = PdfFontFactory.CreateFont(fontPath, PdfEncodings.IDENTITY_H);

                        // Tạo file PDF

                        using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                        {
                            
                            PdfWriter writer = new PdfWriter(fs);
                            PdfDocument pdf = new PdfDocument(writer);
                            Document document = new Document(pdf);
                            
                            // Sử dụng font hỗ trợ tiếng Việt
                            document.SetFont(font);

                            // Tiêu đề phiếu nhập
                            //document.Add(new Paragraph(danhSach).SetFontSize(22));
                            Text tieuDe = new Text(danhSach.ToUpper()).SetFont(font);
                            document.Add(new Paragraph().Add(tieuDe).SetFontSize(23).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                            document.Add(new Paragraph().Add("WarehouseMA - QUẢN LÝ KHO").SetFontSize(13).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));

                            document.Add(new Paragraph("\n")); // Thêm dòng trống

                            // Tạo bảng PDF với số cột bằng số cột trong DataTable
                            Table table = new Table(UnitValue.CreatePercentArray(dt.Columns.Count)).UseAllAvailableWidth();


                            // Thêm header từ DataTable
                            foreach (DataColumn column in dt.Columns) // 'dt' là DataTable chứa dữ liệu
                            {
                                Text boldText = new Text(column.ColumnName).SetFont(font);

                                // Tạo Paragraph
                                Paragraph paragraph = new Paragraph().Add(boldText).SetFontSize(12).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);

                                // Thêm vào bảng
                                table.AddHeaderCell(new Cell().Add(paragraph));
                            }

                            // Thêm dữ liệu từ DataTable
                            foreach (DataRow row in dt.Rows)
                            {
                                foreach (var cellValue in row.ItemArray)
                                {
                                    table.AddCell(new Cell().Add(new Paragraph(cellValue?.ToString() ?? "").SetFontSize(10)));
                                }
                            }

                            // Thêm bảng vào tài liệu
                            document.Add(table);
                            document.Add(new Paragraph("\n"));
                            document.Add(new Paragraph("\n"));
                            document.Add(new Paragraph("\n"));
                            // Thêm dòng trống nếu cần



                            // Thêm chỗ ký tên xác nhận
                            document.Add(new Paragraph().Add("Tp. Hồ Chí Minh, ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString()).SetFontSize(13).SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT));
                            document.Add(new Paragraph().Add("Người kiểm duyệt").SetFontSize(13).SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT));





                            // Sau khi thêm các nội dung, thêm Header và Footer
                            string ngayYeuCau = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                            string headerContent = $"{danhSach} | Ngày xuất báo cáo: {ngayYeuCau}";
                            string footerNote = "Phần mềm: WarehouseMA";

                         

                            // Đánh số trang và thêm header/footer
                            int totalPages = pdf.GetNumberOfPages();
                            for (int i = 1; i <= totalPages; i++)
                            {
                                PdfPage page = pdf.GetPage(i);
                                PdfCanvas canvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdf);

                                // Header
                                canvas.BeginText();
                                canvas.SetFontAndSize(font, 10);
                                canvas.MoveText(34, page.GetPageSize().GetTop() - 20); // Vị trí Header (trên cùng)
                                canvas.ShowText(headerContent);
                                canvas.EndText();

                                // Footer
                                canvas.BeginText();
                                canvas.SetFontAndSize(font, 10);
                                canvas.MoveText(34, 20); // Vị trí Footer (dưới cùng)
                                canvas.ShowText(footerNote);
                                canvas.MoveText(400, 0); // Di chuyển qua phải để đánh số trang
                                canvas.ShowText($"Trang {i}/{totalPages}");
                                canvas.EndText();
                            }
                            document.Close();
                        }

                        return ("Xuất file thành công tới đường dẫn: " + filePath);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine($"Lỗi: {ex.Message}");
                
                return ("Lỗi khi xuất phiếu nhập: " + ex.Message + "\nStackTrace: " + ex.StackTrace);
            }
        }


    }

}
