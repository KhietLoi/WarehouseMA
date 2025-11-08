-- phpMyAdmin SQL Dump
-- version 4.7.1
-- https://www.phpmyadmin.net/
--
-- Máy chủ: sql5.freesqldatabase.com
-- Thời gian đã tạo: Th10 27, 2024 lúc 08:11 AM
-- Phiên bản máy phục vụ: 5.5.62-0ubuntu0.14.04.1
-- Phiên bản PHP: 7.0.33-0ubuntu0.16.04.16

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `sql5742970`
--

DELIMITER $$
--
-- Thủ tục
--
CREATE DEFINER=`sql5742970`@`%` PROCEDURE `CapNhatDungTichKe` (IN `p_MaKe` VARCHAR(50), IN `p_DungTich` INT, IN `p_TrangThai` VARCHAR(50))  BEGIN
    UPDATE KeChoThue
    SET DungTichDaDung = DungTichDaDung + p_DungTich,
        DungTichKhaDung = DungTichKhaDung - p_DungTich,
        TrangThai = p_TrangThai
    WHERE MaKe = p_MaKe;
END$$

CREATE DEFINER=`sql5742970`@`%` PROCEDURE `CapNhatDungTichKe_XuatHang` (IN `p_MaKe` VARCHAR(50), IN `p_DungTich` INT)  BEGIN
    UPDATE KeChoThue
    SET DungTichDaDung = DungTichDaDung - p_DungTich,
        DungTichKhaDung = DungTichKhaDung + p_DungTich
    WHERE MaKe = p_MaKe;
END$$

CREATE DEFINER=`sql5742970`@`%` PROCEDURE `CapNhatDungTichKho` (IN `p_MaKho` VARCHAR(50), IN `p_DungTich` INT)  BEGIN
    UPDATE KhoChoThue
    SET DungTichDaDung = DungTichDaDung + p_DungTich,
        DungTichKhaDung = DungTichKhaDung - p_DungTich
    WHERE MaKho = p_MaKho;
END$$

CREATE DEFINER=`sql5742970`@`%` PROCEDURE `CapNhatDungTichKho_XuatHang` (IN `p_MaKho` VARCHAR(50), IN `p_DungTich` INT)  BEGIN
    UPDATE KhoChoThue
    SET DungTichDaDung = DungTichDaDung - p_DungTich,
        DungTichKhaDung = DungTichKhaDung + p_DungTich
    WHERE MaKho = p_MaKho;
END$$

CREATE DEFINER=`sql5742970`@`%` PROCEDURE `CapNhatDungTichNgan` (IN `p_MaNgan` VARCHAR(50), IN `p_DungTich` INT)  BEGIN
    UPDATE Ngan
    SET DungTichDaDung = DungTichDaDung + p_DungTich,
        DungTichKhaDung = DungTichKhaDung - p_DungTich
    WHERE MaNgan = p_MaNgan;
END$$

CREATE DEFINER=`sql5742970`@`%` PROCEDURE `CapNhatDungTichNgan_XuatHang` (IN `p_MaNgan` VARCHAR(50), IN `p_DungTich` INT)  BEGIN
    UPDATE Ngan
    SET DungTichDaDung = DungTichDaDung - p_DungTich,
        DungTichKhaDung = DungTichKhaDung + p_DungTich
    WHERE MaNgan = p_MaNgan;
END$$

CREATE DEFINER=`sql5742970`@`%` PROCEDURE `CapNhatDungTichTang` (IN `p_MaTang` VARCHAR(50), IN `p_DungTich` INT)  BEGIN
    UPDATE Tang
    SET DungTichDaDung = DungTichDaDung + p_DungTich,
        DungTichKhaDung = DungTichKhaDung - p_DungTich
    WHERE MaTang = p_MaTang;
END$$

CREATE DEFINER=`sql5742970`@`%` PROCEDURE `CapNhatDungTichTang_XuatHang` (IN `p_MaTang` VARCHAR(50), IN `p_DungTich` INT)  BEGIN
    UPDATE Tang
    SET DungTichDaDung = DungTichDaDung - p_DungTich,
        DungTichKhaDung = DungTichKhaDung + p_DungTich
    WHERE MaTang = p_MaTang;
END$$

CREATE DEFINER=`sql5742970`@`%` PROCEDURE `GenerateMaThung` (IN `maYC` VARCHAR(50), IN `temSo` VARCHAR(50), OUT `maThung` VARCHAR(100))  BEGIN
    -- Tạo mã thùng theo định dạng: maYC_MT_TEMSO
    SET maThung = CONCAT(maYC, '_MT_', temSo);
END$$

CREATE DEFINER=`sql5742970`@`%` PROCEDURE `ThemMaYeuCauKhachHang` (IN `TrangThaiXuLy` VARCHAR(50), IN `NgayYeuCau` DATETIME, IN `SoLuongThungS` INT, IN `SoLuongThungM` INT, IN `SoLuongThungL` INT, IN `DungTich` FLOAT, IN `NgayHetHan` DATETIME, IN `VanChuyen` VARCHAR(50), IN `CCCD` VARCHAR(20))  BEGIN
    DECLARE lastMaYC VARCHAR(10);
    DECLARE newMaYC VARCHAR(10);
    DECLARE maSo INT;

    -- Lấy mã MaYC cuối cùng từ bảng
    SELECT SUBSTRING(MaYC, 3) INTO lastMaYC 
    FROM YeuCauKhachHang
    ORDER BY MaYC DESC
    LIMIT 1;

    -- Kiểm tra nếu bảng chưa có MaYC
    IF lastMaYC IS NULL THEN
        SET newMaYC = 'YC0001';
    ELSE
        -- Tăng giá trị mã lên 1
        SET maSo = CAST(lastMaYC AS UNSIGNED) + 1;
        SET newMaYC = CONCAT('YC', LPAD(maSo, 4, '0'));
    END IF;


    -- Thêm bản ghi mới với MaYC tự phát sinh
    INSERT INTO YeuCauKhachHang (MaYC, TrangThaiXuLy, NgayYeuCau, SoLuongThungS, SoLuongThungM, SoLuongThungL, DungTich, NgayHetHan, VanChuyen, CCCD)
    VALUES (newMaYC, TrangThaiXuLy, NgayYeuCau, SoLuongThungS, SoLuongThungM, SoLuongThungL, DungTich, NgayHetHan, VanChuyen, CCCD);
END$$

CREATE DEFINER=`sql5742970`@`%` PROCEDURE `XuatMaDonHang` (IN `maYC` VARCHAR(255), OUT `exportCode` VARCHAR(255))  BEGIN
    DECLARE randomNum INT;

    -- Tạo một số ngẫu nhiên trong phạm vi từ 1000 đến 9999
    SET randomNum = FLOOR(RAND() * (9999 - 1000 + 1)) + 1000;

    -- Tạo mã xuất hàng theo định dạng XH_{MaYC}_{Số Random}
    SET exportCode = CONCAT('XH_', maYC, '_', randomNum);
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `DonHang`
--

CREATE TABLE `DonHang` (
  `MaDH` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `NgayXuatKho` datetime NOT NULL,
  `GiaTien` float NOT NULL DEFAULT '20',
  `PhiPhuThu` float NOT NULL,
  `ThanhTien` float NOT NULL,
  `MaNV` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `MaYC` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `TemSo` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `CCCD` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `DonHang`
--

INSERT INTO `DonHang` (`MaDH`, `NgayXuatKho`, `GiaTien`, `PhiPhuThu`, `ThanhTien`, `MaNV`, `MaYC`, `TemSo`, `CCCD`) VALUES
('XH_YC0001_3501', '2024-11-27 02:21:04', 360000, 0, 360000, 'NV01', 'YC0001', '1_2_3', '094567890345'),
('XH_YC0002_6646', '2024-11-27 13:28:20', 0, 0, 0, 'NV01', 'YC0002', '1_2', '09878226828822'),
('XH_YC0002_9687', '2024-11-27 13:50:25', 0, 0, 0, 'NV01', 'YC0002', '3_4', '09878226828822');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `HangHoaNoiBo`
--

CREATE TABLE `HangHoaNoiBo` (
  `MaHangHoa` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `SoLuong` int(11) NOT NULL,
  `DonViTinh` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `MoTaHangHoa` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `MaKe` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `HangHoaNoiBo`
--

INSERT INTO `HangHoaNoiBo` (`MaHangHoa`, `SoLuong`, `DonViTinh`, `MoTaHangHoa`, `MaKe`) VALUES
('M_1_3', 40, 'chai', 'abc', 'M_1'),
('Z_1_2', 5, 'chai', 'abc', 'Z_1'),
('Z_1_3', 60, 'chai', 'abc', 'Z_1');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `KeChoThue`
--

CREATE TABLE `KeChoThue` (
  `MaKe` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `DungTichKhaDung` float NOT NULL,
  `DungTichDaDung` float NOT NULL,
  `MaKho` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `TrangThai` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT 'Sẵn sàng'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `KeChoThue`
--

INSERT INTO `KeChoThue` (`MaKe`, `DungTichKhaDung`, `DungTichDaDung`, `MaKho`, `TrangThai`) VALUES
('A_1', 500, 0, 'A', 'Sẵn sàng'),
('A_2', 500, 0, 'A', 'Sẵn sàng'),
('B_1', 500, 0, 'B', 'Sẵn sàng'),
('B_2', 500, 0, 'B', 'Sẵn sàng'),
('C_1', 500, 0, 'C', 'Sẵn sàng'),
('C_2', 500, 0, 'C', 'Sẵn sàng'),
('D_1', 500, 0, 'D', 'Sẵn sàng'),
('D_2', 500, 0, 'D', 'Sẵn sàng');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `KeNoiBo`
--

CREATE TABLE `KeNoiBo` (
  `MaKe` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `MaKho` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `KeNoiBo`
--

INSERT INTO `KeNoiBo` (`MaKe`, `MaKho`) VALUES
('M_1', 'M'),
('M_2', 'M'),
('Z_1', 'Z'),
('Z_2', 'Z');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `KhachHang`
--

CREATE TABLE `KhachHang` (
  `TenKH` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `SoDienThoai` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Email` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `DiaChi` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `CCCD` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `KhachHang`
--

INSERT INTO `KhachHang` (`TenKH`, `SoDienThoai`, `Email`, `DiaChi`, `CCCD`) VALUES
('Trần Khiết Lôi', '0389950228', 'lp.n3.1110@gmail.com', 'B609', '094567890345'),
('Lôi đẹp zai', '0389950227', 'lp.n3.1110@gmail.com', 'I0806', '09878226828822');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `Kho`
--

CREATE TABLE `Kho` (
  `MaKho` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `MaNV` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `Kho`
--

INSERT INTO `Kho` (`MaKho`, `MaNV`) VALUES
('A', 'NV01'),
('B', 'NV01'),
('C', 'NV01'),
('D', 'NV01'),
('M', 'NV01'),
('Z', 'NV01'),
('H', 'NV02');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `KhoChoThue`
--

CREATE TABLE `KhoChoThue` (
  `DungTichKhaDung` float NOT NULL,
  `DungTichDaDung` float NOT NULL,
  `MaKho` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `KhoChoThue`
--

INSERT INTO `KhoChoThue` (`DungTichKhaDung`, `DungTichDaDung`, `MaKho`) VALUES
(1000, 0, 'A'),
(1000, 0, 'B'),
(1000, 0, 'C'),
(1000, 0, 'D');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `KhoNoiBo`
--

CREATE TABLE `KhoNoiBo` (
  `ChucNang` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `MaKho` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `KhoNoiBo`
--

INSERT INTO `KhoNoiBo` (`ChucNang`, `MaKho`) VALUES
('Môi trường', 'M'),
('Vệ sinh', 'Z');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `KiemKe`
--

CREATE TABLE `KiemKe` (
  `MaKK` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `NgayKK` datetime NOT NULL,
  `DungTichDaDung` float NOT NULL,
  `MaNV` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `MaNgan` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `KiemKe`
--

INSERT INTO `KiemKe` (`MaKK`, `NgayKK`, `DungTichDaDung`, `MaNV`, `MaNgan`) VALUES
('KKCT_1', '2024-11-27 00:00:00', 120, 'NV02', 'A_1_1_1'),
('KKCT_10', '2024-11-30 00:00:00', 0, 'NV02', 'B_1_1_2'),
('KKCT_11', '2024-11-30 00:00:00', 0, 'NV02', 'B_1_2_1'),
('KKCT_12', '2024-11-30 00:00:00', 0, 'NV02', 'B_1_2_2'),
('KKCT_13', '2024-11-30 00:00:00', 0, 'NV02', 'B_2_1_1'),
('KKCT_14', '2024-11-30 00:00:00', 0, 'NV02', 'B_2_1_2'),
('KKCT_15', '2024-11-30 00:00:00', 0, 'NV02', 'B_2_2_1'),
('KKCT_16', '2024-11-30 00:00:00', 0, 'NV02', 'B_2_2_2'),
('KKCT_2', '2024-11-27 00:00:00', 5, 'NV02', 'A_1_1_2'),
('KKCT_3', '2024-11-27 00:00:00', 60, 'NV02', 'A_1_2_1'),
('KKCT_4', '2024-11-27 00:00:00', 70, 'NV02', 'A_1_2_2'),
('KKCT_5', '2024-11-27 00:00:00', 0, 'NV02', 'A_2_1_1'),
('KKCT_6', '2024-11-27 00:00:00', 0, 'NV02', 'A_2_1_2'),
('KKCT_7', '2024-11-27 00:00:00', 0, 'NV02', 'A_2_2_1'),
('KKCT_8', '2024-11-27 00:00:00', 0, 'NV02', 'A_2_2_2'),
('KKCT_9', '2024-11-30 00:00:00', 0, 'NV02', 'B_1_1_1');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `KiemKeNoiBo`
--

CREATE TABLE `KiemKeNoiBo` (
  `MaKK` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `MaNV` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `NgayKK` datetime NOT NULL,
  `MaHangHoa` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `SoLuong` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `KiemKeNoiBo`
--

INSERT INTO `KiemKeNoiBo` (`MaKK`, `MaNV`, `NgayKK`, `MaHangHoa`, `SoLuong`) VALUES
('KKNB_1', 'NV02', '2024-11-30 00:00:00', 'Z_1_2', 5),
('KKNB_2', 'NV02', '2024-11-30 00:00:00', 'Z_1_3', 60);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `Ngan`
--

CREATE TABLE `Ngan` (
  `MaNgan` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `DungTichDaDung` float NOT NULL,
  `DungTichKhaDung` float NOT NULL,
  `MaTang` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `Ngan`
--

INSERT INTO `Ngan` (`MaNgan`, `DungTichDaDung`, `DungTichKhaDung`, `MaTang`) VALUES
('A_1_1_1', 0, 125, 'A_1_1'),
('A_1_1_2', 0, 125, 'A_1_1'),
('A_1_2_1', 0, 125, 'A_1_2'),
('A_1_2_2', 0, 125, 'A_1_2'),
('A_2_1_1', 0, 125, 'A_2_1'),
('A_2_1_2', 0, 125, 'A_2_1'),
('A_2_2_1', 0, 125, 'A_2_2'),
('A_2_2_2', 0, 125, 'A_2_2'),
('B_1_1_1', 0, 125, 'B_1_1'),
('B_1_1_2', 0, 125, 'B_1_1'),
('B_1_2_1', 0, 125, 'B_1_2'),
('B_1_2_2', 0, 125, 'B_1_2'),
('B_2_1_1', 0, 125, 'B_2_1'),
('B_2_1_2', 0, 125, 'B_2_1'),
('B_2_2_1', 0, 125, 'B_2_2'),
('B_2_2_2', 0, 125, 'B_2_2'),
('C_1_1_1', 0, 125, 'C_1_1'),
('C_1_1_2', 0, 125, 'C_1_1'),
('C_1_2_1', 0, 125, 'C_1_2'),
('C_1_2_2', 0, 125, 'C_1_2'),
('C_2_1_1', 0, 125, 'C_2_1'),
('C_2_1_2', 0, 125, 'C_2_1'),
('C_2_2_1', 0, 125, 'C_2_2'),
('C_2_2_2', 0, 125, 'C_2_2'),
('D_1_1_1', 0, 125, 'D_1_1'),
('D_1_1_2', 0, 125, 'D_1_1'),
('D_1_2_1', 0, 125, 'D_1_2'),
('D_1_2_2', 0, 125, 'D_1_2'),
('D_2_1_1', 0, 125, 'D_2_1'),
('D_2_1_2', 0, 125, 'D_2_1'),
('D_2_2_1', 0, 125, 'D_2_2'),
('D_2_2_2', 0, 125, 'D_2_2');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `NhanVienKho`
--

CREATE TABLE `NhanVienKho` (
  `MaNV` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `TenNV` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `SoDienThoai` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `NhanVienKho`
--

INSERT INTO `NhanVienKho` (`MaNV`, `TenNV`, `SoDienThoai`) VALUES
('NV01', 'Lam Dinh Khoa', '903351923'),
('NV02', 'Vu Van Kiet', '0907827631');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `Tang`
--

CREATE TABLE `Tang` (
  `MaTang` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `DungTichDaDung` float NOT NULL,
  `DungTichKhaDung` float NOT NULL,
  `MaKe` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `Tang`
--

INSERT INTO `Tang` (`MaTang`, `DungTichDaDung`, `DungTichKhaDung`, `MaKe`) VALUES
('A_1_1', 0, 250, 'A_1'),
('A_1_2', 0, 250, 'A_1'),
('A_2_1', 0, 250, 'A_2'),
('A_2_2', 0, 250, 'A_2'),
('B_1_1', 0, 250, 'B_1'),
('B_1_2', 0, 250, 'B_1'),
('B_2_1', 0, 250, 'B_2'),
('B_2_2', 0, 250, 'B_2'),
('C_1_1', 0, 250, 'C_1'),
('C_1_2', 0, 250, 'C_1'),
('C_2_1', 0, 250, 'C_2'),
('C_2_2', 0, 250, 'C_2'),
('D_1_1', 0, 250, 'D_1'),
('D_1_2', 0, 250, 'D_1'),
('D_2_1', 0, 250, 'D_2'),
('D_2_2', 0, 250, 'D_2');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `Thung`
--

CREATE TABLE `Thung` (
  `MaThung` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `MoTaHangHoa` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `DungTich` float NOT NULL,
  `NgayNhapKho` datetime NOT NULL,
  `TemSo` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `TrangThai` bit(1) NOT NULL DEFAULT b'1',
  `MaNgan` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `MaYC` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `MaNV` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `NgayGiaHan` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `Thung`
--

INSERT INTO `Thung` (`MaThung`, `MoTaHangHoa`, `DungTich`, `NgayNhapKho`, `TemSo`, `TrangThai`, `MaNgan`, `MaYC`, `MaNV`, `NgayGiaHan`) VALUES
('YC0001_MT_1', 'M', 30, '2024-11-24 01:58:07', '1', b'0', 'A_1_1_1', 'YC0001', 'NV01', '2024-11-27 19:00:00'),
('YC0001_MT_2', 'L', 60, '2024-11-24 01:58:07', '2', b'0', 'A_1_1_1', 'YC0001', 'NV01', '2024-11-27 19:00:00'),
('YC0001_MT_3', 'L', 60, '2024-11-24 01:58:07', '3', b'0', 'A_1_1_2', 'YC0001', 'NV01', '2024-11-27 19:00:00'),
('YC0002_MT_1', 'S', 20, '2024-11-26 13:01:54', '1', b'0', 'A_1_1_1', 'YC0002', 'NV01', '2024-11-28 20:00:00'),
('YC0002_MT_2', 'M', 30, '2024-11-26 13:01:54', '2', b'0', 'A_1_1_1', 'YC0002', 'NV01', '2024-11-28 20:00:00'),
('YC0002_MT_3', 'L', 60, '2024-11-26 13:01:54', '3', b'0', 'A_1_1_1', 'YC0002', 'NV01', '2024-11-28 20:00:00'),
('YC0002_MT_4', 'L', 60, '2024-11-26 13:01:54', '4', b'0', 'A_1_1_2', 'YC0002', 'NV01', '2024-11-28 20:00:00');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `YeuCauKhachHang`
--

CREATE TABLE `YeuCauKhachHang` (
  `MaYC` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `TrangThaiXuLy` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT 'waiting',
  `NgayYeuCau` datetime NOT NULL,
  `SoLuongThungS` int(11) NOT NULL,
  `SoLuongThungM` int(11) NOT NULL,
  `SoLuongThungL` int(11) NOT NULL,
  `DungTich` float NOT NULL,
  `NgayHetHan` datetime NOT NULL,
  `VanChuyen` bit(1) NOT NULL,
  `CCCD` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `YeuCauKhachHang`
--

INSERT INTO `YeuCauKhachHang` (`MaYC`, `TrangThaiXuLy`, `NgayYeuCau`, `SoLuongThungS`, `SoLuongThungM`, `SoLuongThungL`, `DungTich`, `NgayHetHan`, `VanChuyen`, `CCCD`) VALUES
('YC0001', 'Đã nhập hàng', '2024-11-24 01:35:11', 0, 1, 2, 150, '2024-11-26 19:00:00', b'1', '094567890345'),
('YC0002', 'Đã rút hàng', '2024-11-26 12:54:59', 1, 1, 2, 170, '2024-11-28 20:00:00', b'1', '09878226828822');

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `DonHang`
--
ALTER TABLE `DonHang`
  ADD PRIMARY KEY (`MaDH`),
  ADD KEY `MaNV` (`MaNV`),
  ADD KEY `MaYC` (`MaYC`),
  ADD KEY `CCCD` (`CCCD`);

--
-- Chỉ mục cho bảng `HangHoaNoiBo`
--
ALTER TABLE `HangHoaNoiBo`
  ADD PRIMARY KEY (`MaHangHoa`),
  ADD KEY `MaKe` (`MaKe`);

--
-- Chỉ mục cho bảng `KeChoThue`
--
ALTER TABLE `KeChoThue`
  ADD PRIMARY KEY (`MaKe`),
  ADD KEY `MaKho` (`MaKho`);

--
-- Chỉ mục cho bảng `KeNoiBo`
--
ALTER TABLE `KeNoiBo`
  ADD PRIMARY KEY (`MaKe`),
  ADD KEY `MaKho` (`MaKho`);

--
-- Chỉ mục cho bảng `KhachHang`
--
ALTER TABLE `KhachHang`
  ADD PRIMARY KEY (`CCCD`);

--
-- Chỉ mục cho bảng `Kho`
--
ALTER TABLE `Kho`
  ADD PRIMARY KEY (`MaKho`),
  ADD KEY `MaNV` (`MaNV`);

--
-- Chỉ mục cho bảng `KhoChoThue`
--
ALTER TABLE `KhoChoThue`
  ADD PRIMARY KEY (`MaKho`);

--
-- Chỉ mục cho bảng `KhoNoiBo`
--
ALTER TABLE `KhoNoiBo`
  ADD PRIMARY KEY (`MaKho`);

--
-- Chỉ mục cho bảng `KiemKe`
--
ALTER TABLE `KiemKe`
  ADD PRIMARY KEY (`MaKK`),
  ADD KEY `MaNV` (`MaNV`),
  ADD KEY `MaNgan` (`MaNgan`);

--
-- Chỉ mục cho bảng `KiemKeNoiBo`
--
ALTER TABLE `KiemKeNoiBo`
  ADD PRIMARY KEY (`MaKK`),
  ADD KEY `MaHangHoa` (`MaHangHoa`),
  ADD KEY `MaNV` (`MaNV`);

--
-- Chỉ mục cho bảng `Ngan`
--
ALTER TABLE `Ngan`
  ADD PRIMARY KEY (`MaNgan`),
  ADD KEY `MaTang` (`MaTang`);

--
-- Chỉ mục cho bảng `NhanVienKho`
--
ALTER TABLE `NhanVienKho`
  ADD PRIMARY KEY (`MaNV`);

--
-- Chỉ mục cho bảng `Tang`
--
ALTER TABLE `Tang`
  ADD PRIMARY KEY (`MaTang`),
  ADD KEY `MaKe` (`MaKe`);

--
-- Chỉ mục cho bảng `Thung`
--
ALTER TABLE `Thung`
  ADD PRIMARY KEY (`MaThung`),
  ADD KEY `MaNgan` (`MaNgan`),
  ADD KEY `MaYC` (`MaYC`),
  ADD KEY `FK_Thung_NhanVienKho` (`MaNV`);

--
-- Chỉ mục cho bảng `YeuCauKhachHang`
--
ALTER TABLE `YeuCauKhachHang`
  ADD PRIMARY KEY (`MaYC`),
  ADD KEY `CCCD` (`CCCD`);

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng `DonHang`
--
ALTER TABLE `DonHang`
  ADD CONSTRAINT `DonHang_ibfk_1` FOREIGN KEY (`MaNV`) REFERENCES `NhanVienKho` (`MaNV`),
  ADD CONSTRAINT `DonHang_ibfk_2` FOREIGN KEY (`MaYC`) REFERENCES `YeuCauKhachHang` (`MaYC`),
  ADD CONSTRAINT `DonHang_ibfk_3` FOREIGN KEY (`CCCD`) REFERENCES `KhachHang` (`CCCD`);

--
-- Các ràng buộc cho bảng `HangHoaNoiBo`
--
ALTER TABLE `HangHoaNoiBo`
  ADD CONSTRAINT `HangHoaNoiBo_ibfk_1` FOREIGN KEY (`MaKe`) REFERENCES `KeNoiBo` (`MaKe`);

--
-- Các ràng buộc cho bảng `KeChoThue`
--
ALTER TABLE `KeChoThue`
  ADD CONSTRAINT `KeChoThue_ibfk_1` FOREIGN KEY (`MaKho`) REFERENCES `KhoChoThue` (`MaKho`);

--
-- Các ràng buộc cho bảng `KeNoiBo`
--
ALTER TABLE `KeNoiBo`
  ADD CONSTRAINT `KeNoiBo_ibfk_1` FOREIGN KEY (`MaKho`) REFERENCES `KhoNoiBo` (`MaKho`);

--
-- Các ràng buộc cho bảng `Kho`
--
ALTER TABLE `Kho`
  ADD CONSTRAINT `Kho_ibfk_1` FOREIGN KEY (`MaNV`) REFERENCES `NhanVienKho` (`MaNV`);

--
-- Các ràng buộc cho bảng `KhoChoThue`
--
ALTER TABLE `KhoChoThue`
  ADD CONSTRAINT `KhoChoThue_ibfk_1` FOREIGN KEY (`MaKho`) REFERENCES `Kho` (`MaKho`);

--
-- Các ràng buộc cho bảng `KhoNoiBo`
--
ALTER TABLE `KhoNoiBo`
  ADD CONSTRAINT `KhoNoiBo_ibfk_1` FOREIGN KEY (`MaKho`) REFERENCES `Kho` (`MaKho`);

--
-- Các ràng buộc cho bảng `KiemKe`
--
ALTER TABLE `KiemKe`
  ADD CONSTRAINT `KiemKe_ibfk_1` FOREIGN KEY (`MaNV`) REFERENCES `NhanVienKho` (`MaNV`),
  ADD CONSTRAINT `KiemKe_ibfk_2` FOREIGN KEY (`MaNgan`) REFERENCES `Ngan` (`MaNgan`);

--
-- Các ràng buộc cho bảng `KiemKeNoiBo`
--
ALTER TABLE `KiemKeNoiBo`
  ADD CONSTRAINT `KiemKeNoiBo_ibfk_1` FOREIGN KEY (`MaHangHoa`) REFERENCES `HangHoaNoiBo` (`MaHangHoa`),
  ADD CONSTRAINT `KiemKeNoiBo_ibfk_2` FOREIGN KEY (`MaNV`) REFERENCES `NhanVienKho` (`MaNV`);

--
-- Các ràng buộc cho bảng `Ngan`
--
ALTER TABLE `Ngan`
  ADD CONSTRAINT `Ngan_ibfk_1` FOREIGN KEY (`MaTang`) REFERENCES `Tang` (`MaTang`);

--
-- Các ràng buộc cho bảng `Tang`
--
ALTER TABLE `Tang`
  ADD CONSTRAINT `Tang_ibfk_1` FOREIGN KEY (`MaKe`) REFERENCES `KeChoThue` (`MaKe`);

--
-- Các ràng buộc cho bảng `Thung`
--
ALTER TABLE `Thung`
  ADD CONSTRAINT `FK_Thung_NhanVienKho` FOREIGN KEY (`MaNV`) REFERENCES `NhanVienKho` (`MaNV`),
  ADD CONSTRAINT `Thung_ibfk_1` FOREIGN KEY (`MaNgan`) REFERENCES `Ngan` (`MaNgan`),
  ADD CONSTRAINT `Thung_ibfk_2` FOREIGN KEY (`MaYC`) REFERENCES `YeuCauKhachHang` (`MaYC`);

--
-- Các ràng buộc cho bảng `YeuCauKhachHang`
--
ALTER TABLE `YeuCauKhachHang`
  ADD CONSTRAINT `YeuCauKhachHang_ibfk_1` FOREIGN KEY (`CCCD`) REFERENCES `KhachHang` (`CCCD`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
