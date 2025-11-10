# 🏢 WarehouseMA - Phần mềm Quản lý Kho Hàng trong Tòa nhà

**Đồ án học phần Công nghệ Phần mềm**  
Trường Đại học Tôn Đức Thắng (TDTU) - 2024  

---

## ℹ️ Tổng quan Dự án

**WarehouseMA** là ứng dụng quản lý kho hàng hóa, vật tư, công cụ, và dụng cụ trong tòa nhà.  
Hệ thống được phát triển để tối ưu hóa quy trình quản lý và vận hành, bao gồm hai loại kho chính:

- **Kho Nội Bộ**: Dành cho việc vận hành tòa nhà  
- **Kho Cho Thuê**: Dành cho cư dân hoặc đơn vị thuê

Phần mềm được phát triển theo quy trình đầy đủ gồm: **Phân tích**, **Thiết kế**, **Lập trình**, và **Kiểm thử**.

> ⚠️ **Lưu ý:**  
> Dự án hiện **không còn chạy được** do:  
> 1. Hosting cơ sở dữ liệu MySQL đã ngừng hoạt động.  
> 2. API Google Form dùng để nhận yêu cầu đăng ký/xuất hàng đã bị ngắt kết nối.  
>
> Tuy nhiên, **toàn bộ mã nguồn, tài liệu phân tích và thiết kế hệ thống** vẫn được giữ nguyên để minh chứng quy trình làm việc và kỹ năng chuyên môn.

---

## ⚙️ Công nghệ và Kỹ thuật

- **Ngôn ngữ:** C#  
- **Nền tảng:** .NET Framework (WinForms)  
- **Cơ sở dữ liệu:** MySQL / SQL Server  
- **Công cụ hỗ trợ:**  
  - Figma (thiết kế giao diện)  
  - Draw.io (vẽ sơ đồ UML)  
- **Kỹ thuật đặc biệt:**  
  - Tích hợp **Google Forms API** để tự động nhận yêu cầu nhập/xuất hàng  
  - Sử dụng **QR Code** để kiểm kê hàng hóa nhanh chóng

---

## 🧠 Vai trò và Đóng góp Cá nhân

**Vai trò chính:** Business Analyst (BA) & Main Developer  

| Lĩnh vực | Đóng góp |
| :--- | :--- |
| **Business Analyst (BA)** | Thu thập yêu cầu người dùng, viết **SRS** và **BRD**, thiết kế **ERD** và các sơ đồ **UML** (Use Case, Class, Activity, Sequence, State). Phân tích nghiệp vụ và xây dựng thuật toán tối ưu vị trí kho. |
| **Developer (Chính)** | Thiết kế và lập trình các module xử lý nghiệp vụ (Quản lý Kho, Yêu cầu, Đơn hàng, Kiểm kê). Tuân thủ coding convention và tối ưu hiệu suất xử lý dữ liệu. |
---

## 🛠️ Tính năng Chính

- **Quản lý Kho Tối Ưu:**  
  Theo dõi tình trạng, dung tích sử dụng và khả dụng của kho, kệ, tầng, ngăn.  
  Ứng dụng thuật toán tìm kiếm vị trí lưu trữ tối ưu cho hàng hóa mới.

- **Xử lý Yêu cầu Khách Hàng:**  
  Tiếp nhận dữ liệu từ Google Form hoặc QR Code.  
  Hỗ trợ duyệt và xuất phiếu nhập/xuất tự động.

- **Tính Phí Tự Động:**  
  Tự động tính phí lưu trữ theo thời gian, cộng thêm phí phạt khi quá hạn.

- **Kiểm Kê & Báo Cáo:**  
  Cung cấp công cụ kiểm kê nhanh, xuất báo cáo thống kê định kỳ dưới dạng **PDF** hoặc **Excel**.

---

## 📄 Tài Liệu Dự Án

- [📘 Báo cáo Tổng kết Dự án (PDF)](./Document/2024.12.04_TDT-N20-WarehouseMA.0-TongKet.pdf)  
  Bao gồm: SRS, BRD, ERD, UML, thiết kế UI/UX, kế hoạch dự án và tài liệu kiểm thử.

- **Mã nguồn:** Toàn bộ code C# WinForms và các script tạo cơ sở dữ liệu.

---

## 👥 Thành viên Nhóm

| Họ tên | MSSV | Vai trò |
| :--- | :--- | :--- |
| **Trần Khiết Lôi** | 52200216 | BA, Developer |
| **Trần Thiệu Khang** | 52200221 | Project Manager, Developer |
| **Lê Tiến Đạt** | 52200162 | Developer |
| **Phạm Tuấn Đạt** | 52200207 | Designer, Tester |
| **Trần Hồ Hoàng Vũ** | 52200214 | Designer, Tester |

---

## 🧾 Ghi chú

> Dự án được thực hiện với mục tiêu học tập và rèn luyện kỹ năng chuyên môn trong phân tích và phát triển phần mềm thực tế.  
> Toàn bộ mã nguồn và tài liệu được công khai phục vụ mục đích tham khảo học thuật.

---
