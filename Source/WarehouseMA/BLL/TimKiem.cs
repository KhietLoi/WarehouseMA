using System.Collections.Generic;
using System.Data;
using System;
using WarehouseMA.DAL;
using System.Linq;
using WarehouseMA.BLL;

public class TimKiem
{
    private QuanLyKhoDAL khoDAL = new QuanLyKhoDAL();

    public string TimVaGhiNhanNhieuGoiY(int tongDungTichYeuCau)
    {
        DataTable khoChoThueList = khoDAL.LayDuLieuKhoChoThue();
        DataTable keList = khoDAL.LayDuLieuKeChoThue();

        int tongDungTichKhaDung = khoChoThueList.AsEnumerable()
            //.Sum(row => Convert.ToInt32(row["DungTichKhaDung"]));
            .Sum(row => Convert.ToInt32(row["Dung tích khả dụng"]));

        if (tongDungTichKhaDung < tongDungTichYeuCau)
        {
            return "Không đủ dung tích trong tất cả các kho để đáp ứng yêu cầu.";
        }

        int dungTichConLai = tongDungTichYeuCau;
        List<string> keDaSuDung = new List<string>();

        // Duyệt qua tất cả các kệ, ưu tiên theo dung tích khả dụng nhỏ nhất, và bỏ qua kệ đang được xếp hàng.
        var kePhuHop = keList.AsEnumerable()
          .Where(ke => Convert.ToInt32(ke["Dung tích khả dụng"]) > 0 &&
                       ke["Trạng thái"].ToString() != "Đang xếp hàng") // Kiểm tra trạng thái
          .OrderBy(ke => Convert.ToInt32(ke["Dung tích khả dụng"]));

        foreach (var keRow in kePhuHop)
        {
            if (dungTichConLai <= 0) break;

            string maKho = keRow["Mã kho"].ToString();
            string maKe = keRow["Mã kệ"].ToString();
            int dungTichKe = Convert.ToInt32(keRow["Dung tích khả dụng"]);

            // Sử dụng dung tích tối đa từ kệ
            int dungTichSuDung = Math.Min(dungTichKe, dungTichConLai);
            dungTichConLai -= dungTichSuDung;
            keDaSuDung.Add($"Kho: {maKho}, Kệ: {maKe}, Sử dụng: {dungTichSuDung}L");


            // Cập nhật trạng thái kệ là 'Đang xếp hàng'
            khoDAL.CapNhatTrangThaiKe(maKe, "Đang xếp hàng");
            // Nếu đã đủ dung tích, thoát vòng lặp
            if (dungTichConLai <= 0) break;
        }

        if (dungTichConLai > 0)
        {
            return $"Các kệ đang bận. Dung tích còn lại: {dungTichConLai}L";
        }

        return string.Join("\n", keDaSuDung);
    }

    /*    public string TimNhieuKhoVaKePhuHop(int tongDungTichYeuCau)
        {
            DataTable khoChoThueList = khoDAL.LayDuLieuKhoChoThue();
            DataTable keList = khoDAL.LayDuLieuKeChoThue();

            // Sao chép lại dữ liệu ban đầu để sử dụng trong mỗi lần tìm kiếm
            var khoChoThueListCopy = khoChoThueList.Copy();
            var keListCopy = keList.Copy();

            List<string> danhSachKhoVaKe = new List<string>();
            int dungTichConLai = tongDungTichYeuCau;

            // Tiến hành tìm kiếm nhiều lần cho đến khi yêu cầu dung tích được thỏa mãn
            while (dungTichConLai > 0)
            {
                // Lấy kho và kệ có dung tích khả dụng lớn nhất
                var khoPhuHop = khoChoThueListCopy.AsEnumerable()
                    .OrderByDescending(row => Convert.ToInt32(row["DungTichKhaDung"]))
                    .ToList();

                // Nếu không còn kho nào khả dụng, thoát ra
                if (!khoPhuHop.Any())
                {
                    return "Không đủ dung tích trong tất cả các kho để đáp ứng yêu cầu.";
                }

                // Tìm kho và kệ trong kho đó
                foreach (var khoRow in khoPhuHop)
                {
                    if (dungTichConLai <= 0) break;  // Nếu dung tích yêu cầu đã đầy, thoát khỏi vòng lặp

                    string maKho = khoRow["MaKho"].ToString();
                    List<string> keTrongKho = new List<string>();

                    var kePhuHop = keListCopy.AsEnumerable()
                        .Where(row => row["MaKho"].ToString() == maKho)
                        .OrderByDescending(row => Convert.ToInt32(row["DungTichKhaDung"]))
                        .ToList();

                    foreach (var keRow in kePhuHop)
                    {
                        if (dungTichConLai <= 0) break;  // Nếu dung tích yêu cầu đã đầy, thoát khỏi vòng lặp

                        string maKe = keRow["MaKe"].ToString();
                        int dungTichKe = Convert.ToInt32(keRow["DungTichKhaDung"]);

                        if (dungTichKe > 0)
                        {
                            int dungTichSuDung = Math.Min(dungTichKe,
                                dungTichConLai);  // Tính dung tích sẽ sử dụng
                            keTrongKho.Add($"{maKe} ({dungTichSuDung}L)");  // Thêm kệ vào danh sách kết quả
                            dungTichConLai -= dungTichSuDung;  // Cập nhật dung tích còn lại
                                                               // Sau khi sử dụng dung tích của kệ, cập nhật lại kệ trong danh sách để giảm dung tích của kệ
                            keRow["DungTichKhaDung"] = Convert.ToInt32(keRow["DungTichKhaDung"]) - dungTichSuDung;
                        }
                    }

                    // Nếu có kệ phù hợp, thêm vào danh sách kết quả
                    if (keTrongKho.Count > 0)
                    {
                        danhSachKhoVaKe.Add($"Kho: {maKho}, Kệ: {string.Join(", ", keTrongKho)}");
                    }
                }
            }

            if (dungTichConLai > 0)
            {
                return "Không đủ kệ trong các kho để đáp ứng yêu cầu.";
            }

            // Trả về tất cả các vị trí phù hợp
            return $"Vị trí phù hợp:\n{string.Join("\n", danhSachKhoVaKe)}";
        }

    */

}
