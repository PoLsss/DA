USE [master]
GO
/****** Object:  Database [QLKS]    Script Date: 5/25/2022 8:41:18 PM ******/
CREATE DATABASE [QLKS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLKS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\QLKS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QLKS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\QLKS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QLKS] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLKS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLKS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLKS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLKS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLKS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLKS] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLKS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLKS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLKS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLKS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLKS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLKS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLKS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLKS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLKS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLKS] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QLKS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLKS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLKS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLKS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLKS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLKS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLKS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLKS] SET RECOVERY FULL 
GO
ALTER DATABASE [QLKS] SET  MULTI_USER 
GO
ALTER DATABASE [QLKS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLKS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLKS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLKS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLKS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QLKS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLKS', N'ON'
GO
ALTER DATABASE [QLKS] SET QUERY_STORE = OFF
GO
USE [QLKS]
GO
/****** Object:  Table [dbo].[BAOCAODT]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BAOCAODT](
	[MaBaoCao] [char](5) NOT NULL,
	[TenBaoCao] [varchar](50) NULL,
	[NgayLap] [date] NULL,
	[ThangBaoCao] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaBaoCao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CT_PHIEUTHUE]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CT_PHIEUTHUE](
	[MaCTPT] [char](5) NOT NULL,
	[MaKH] [char](5) NULL,
	[NgayLap] [datetime] NULL,
 CONSTRAINT [PK__CT_PHIEU__1E4E606BD9356DE8] PRIMARY KEY CLUSTERED 
(
	[MaCTPT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTBAOCAODT]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTBAOCAODT](
	[MaCTBC] [char](5) NOT NULL,
	[MaBaoCao] [char](5) NULL,
	[MaLoaiPhong] [char](5) NULL,
	[DoanhThu] [float] NULL,
	[TyLe] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCTBC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTHD]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTHD](
	[MaCTHD] [char](5) NOT NULL,
	[MaHD] [char](5) NULL,
	[MaCTPT] [char](5) NULL,
	[Count] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCTHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOADON]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOADON](
	[MaHD] [char](5) NOT NULL,
	[CheckOut] [datetime] NULL,
	[status] [int] NOT NULL,
	[TongTien] [int] NULL,
 CONSTRAINT [PK__HOADON__2725A6E0820E1539] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MaKH] [char](5) NOT NULL,
	[TenKH] [nvarchar](50) NULL,
	[MaLoaiKH] [char](5) NULL,
	[CMND] [varchar](20) NULL,
	[SDT] [varchar](15) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[QuocTich] [nvarchar](50) NULL,
	[GioiTinh] [nvarchar](30) NULL,
 CONSTRAINT [PK__KHACHHAN__2725CF1ED91D4D89] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAIKH]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAIKH](
	[MaLoaiKH] [char](5) NOT NULL,
	[TenLoaiKH] [nvarchar](50) NULL,
	[HeSoPhuThu] [float] NULL,
 CONSTRAINT [PK__LOAIKH__12250B7EE4E16B49] PRIMARY KEY CLUSTERED 
(
	[MaLoaiKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAIPHONG]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAIPHONG](
	[MaLoaiPhong] [char](5) NOT NULL,
	[TenLoaiPhong] [nvarchar](50) NULL,
	[SoKHMax] [int] NULL,
	[DonGia] [int] NULL,
 CONSTRAINT [PK__LOAIPHON__2302121770B3D00D] PRIMARY KEY CLUSTERED 
(
	[MaLoaiPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHATKI]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHATKI](
	[MaNK] [int] IDENTITY(1,1) NOT NULL,
	[MaPhong] [char](5) NULL,
	[MaCTPT] [char](5) NULL,
	[NgayBD] [datetime] NULL,
	[NgayKT] [datetime] NULL,
	[IsDay] [int] NULL,
	[MaPhieu] [char](5) NULL,
	[SoNguoiHT] [int] NULL,
 CONSTRAINT [PK__NHATKI__2725D73FE32E0380] PRIMARY KEY CLUSTERED 
(
	[MaNK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHIEUTHUE]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUTHUE](
	[MaPhieu] [char](5) NOT NULL,
	[MaPhong] [char](5) NULL,
	[NgayBD] [datetime] NULL,
	[NgayKT] [datetime] NULL,
	[IsDay] [int] NULL,
	[MaCTPT] [char](5) NULL,
	[SoNguoiHT] [int] NULL,
 CONSTRAINT [PK__PHIEUTHU__2660BFE0E3ADBE9C] PRIMARY KEY CLUSTERED 
(
	[MaPhieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHONG]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHONG](
	[MaPhong] [char](5) NOT NULL,
	[TenPhong] [nvarchar](50) NULL,
	[MaLoaiPhong] [char](5) NULL,
	[DonDep] [nvarchar](50) NULL,
	[TinhTrang] [nvarchar](50) NULL,
 CONSTRAINT [PK__PHONG__20BD5E5BC8056E49] PRIMARY KEY CLUSTERED 
(
	[MaPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHUTHU]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHUTHU](
	[STT_KH] [int] NULL,
	[TyLePhuThu] [float] NULL,
	[MaPhuThu] [int] IDENTITY(1,1) NOT NULL,
	[TenPhuThu] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhuThu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THAMSO]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THAMSO](
	[MaThamSo] [char](5) NOT NULL,
	[TenThamSo] [varchar](20) NULL,
	[GiaTri] [float] NULL,
	[GhiChu] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaThamSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
	[UserName] [nvarchar](100) NULL,
	[Password] [nvarchar](100) NULL,
	[CapDoQuyen] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[CT_PHIEUTHUE] ([MaCTPT], [MaKH], [NgayLap]) VALUES (N'CT004', N'KH019', CAST(N'2022-05-25T13:00:46.670' AS DateTime))
GO
INSERT [dbo].[CT_PHIEUTHUE] ([MaCTPT], [MaKH], [NgayLap]) VALUES (N'CT005', N'KH019', CAST(N'2022-05-25T13:08:52.437' AS DateTime))
GO
INSERT [dbo].[CT_PHIEUTHUE] ([MaCTPT], [MaKH], [NgayLap]) VALUES (N'CT010', N'KH019', CAST(N'2022-05-25T14:22:15.177' AS DateTime))
GO
INSERT [dbo].[CT_PHIEUTHUE] ([MaCTPT], [MaKH], [NgayLap]) VALUES (N'CT011', N'KH019', CAST(N'2022-05-25T14:29:29.847' AS DateTime))
GO
INSERT [dbo].[CT_PHIEUTHUE] ([MaCTPT], [MaKH], [NgayLap]) VALUES (N'CT012', N'KH019', CAST(N'2022-05-25T14:39:53.707' AS DateTime))
GO
INSERT [dbo].[CT_PHIEUTHUE] ([MaCTPT], [MaKH], [NgayLap]) VALUES (N'CT013', N'KH019', CAST(N'2022-05-25T14:41:29.903' AS DateTime))
GO
INSERT [dbo].[CT_PHIEUTHUE] ([MaCTPT], [MaKH], [NgayLap]) VALUES (N'CT014', N'KH019', CAST(N'2022-05-25T14:42:38.680' AS DateTime))
GO
INSERT [dbo].[CT_PHIEUTHUE] ([MaCTPT], [MaKH], [NgayLap]) VALUES (N'CT015', N'KH019', CAST(N'2022-05-25T14:47:06.283' AS DateTime))
GO
INSERT [dbo].[CT_PHIEUTHUE] ([MaCTPT], [MaKH], [NgayLap]) VALUES (N'CT016', N'KH019', CAST(N'2022-05-25T14:47:54.467' AS DateTime))
GO
INSERT [dbo].[CT_PHIEUTHUE] ([MaCTPT], [MaKH], [NgayLap]) VALUES (N'CT017', N'KH019', CAST(N'2022-05-25T14:49:16.633' AS DateTime))
GO
INSERT [dbo].[CT_PHIEUTHUE] ([MaCTPT], [MaKH], [NgayLap]) VALUES (N'CT018', N'KH019', CAST(N'2022-05-25T14:49:44.653' AS DateTime))
GO
INSERT [dbo].[CT_PHIEUTHUE] ([MaCTPT], [MaKH], [NgayLap]) VALUES (N'CT019', N'KH019', CAST(N'2022-05-25T14:58:32.787' AS DateTime))
GO
INSERT [dbo].[CT_PHIEUTHUE] ([MaCTPT], [MaKH], [NgayLap]) VALUES (N'CT020', N'KH019', CAST(N'2022-05-25T15:11:51.503' AS DateTime))
GO
INSERT [dbo].[CT_PHIEUTHUE] ([MaCTPT], [MaKH], [NgayLap]) VALUES (N'CT021', N'KH019', CAST(N'2022-05-25T15:12:08.363' AS DateTime))
GO
INSERT [dbo].[CT_PHIEUTHUE] ([MaCTPT], [MaKH], [NgayLap]) VALUES (N'CT022', N'KH019', CAST(N'2022-05-25T15:21:14.390' AS DateTime))
GO
INSERT [dbo].[CT_PHIEUTHUE] ([MaCTPT], [MaKH], [NgayLap]) VALUES (N'CT024', N'KH019', CAST(N'2022-05-25T15:36:25.843' AS DateTime))
GO
INSERT [dbo].[CT_PHIEUTHUE] ([MaCTPT], [MaKH], [NgayLap]) VALUES (N'CT025', N'KH019', CAST(N'2022-05-25T15:36:51.070' AS DateTime))
GO
INSERT [dbo].[CT_PHIEUTHUE] ([MaCTPT], [MaKH], [NgayLap]) VALUES (N'CT027', N'KH019', CAST(N'2022-05-25T19:49:42.393' AS DateTime))
GO
INSERT [dbo].[CT_PHIEUTHUE] ([MaCTPT], [MaKH], [NgayLap]) VALUES (N'CT028', N'KH019', CAST(N'2022-05-25T19:50:17.523' AS DateTime))
GO
INSERT [dbo].[CT_PHIEUTHUE] ([MaCTPT], [MaKH], [NgayLap]) VALUES (N'CT029', N'KH019', CAST(N'2022-05-25T19:51:19.980' AS DateTime))
GO
INSERT [dbo].[CT_PHIEUTHUE] ([MaCTPT], [MaKH], [NgayLap]) VALUES (N'CT030', N'KH019', CAST(N'2022-05-25T19:51:51.403' AS DateTime))
GO
INSERT [dbo].[CT_PHIEUTHUE] ([MaCTPT], [MaKH], [NgayLap]) VALUES (N'CT031', N'KH019', CAST(N'2022-05-25T20:15:08.363' AS DateTime))
GO
INSERT [dbo].[CT_PHIEUTHUE] ([MaCTPT], [MaKH], [NgayLap]) VALUES (N'CT032', N'KH019', CAST(N'2022-05-25T20:16:45.727' AS DateTime))
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT006', N'HD006', N'CT004', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT007', N'HD007', N'CT005', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT012', N'HD012', N'CT010', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT013', N'HD013', N'CT011', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT014', N'HD014', N'CT012', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT015', N'HD015', N'CT013', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT016', N'HD016', N'CT014', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT017', N'HD017', N'CT015', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT018', N'HD018', N'CT015', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT019', N'HD019', N'CT015', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT020', N'HD020', N'CT016', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT021', N'HD021', N'CT016', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT022', N'HD022', N'CT016', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT023', N'HD023', N'CT017', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT024', N'HD024', N'CT017', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT025', N'HD025', N'CT018', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT026', N'HD026', N'CT018', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT027', N'HD027', N'CT018', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT028', N'HD028', N'CT019', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT029', N'HD029', N'CT019', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT030', N'HD030', N'CT019', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT031', N'HD031', N'CT020', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT032', N'HD032', N'CT021', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT033', N'HD033', N'CT022', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT034', N'HD034', N'CT022', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT035', N'HD035', N'CT022', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT036', N'HD036', N'CT022', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT039', N'HD039', N'CT024', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT040', N'HD040', N'CT025', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT041', N'HD041', N'CT027', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT042', N'HD042', N'CT028', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT043', N'HD043', N'CT029', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT044', N'HD044', N'CT029', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT045', N'HD045', N'CT031', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT046', N'HD046', N'CT031', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT047', N'HD047', N'CT031', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT048', N'HD048', N'CT032', 1)
GO
INSERT [dbo].[CTHD] ([MaCTHD], [MaHD], [MaCTPT], [Count]) VALUES (N'CT049', N'HD049', N'CT032', 1)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD001', CAST(N'2022-05-25T12:18:45.890' AS DateTime), 1, 255000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD002', CAST(N'2022-05-25T12:18:49.627' AS DateTime), 1, 225000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD003', CAST(N'2022-05-25T12:18:52.550' AS DateTime), 1, 225000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD004', CAST(N'2022-05-25T12:20:09.523' AS DateTime), 1, 2100000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD005', CAST(N'2022-05-25T12:42:04.027' AS DateTime), 1, 900000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD006', CAST(N'2022-05-25T13:07:26.070' AS DateTime), 1, 675000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD007', CAST(N'2022-05-25T13:09:41.223' AS DateTime), 1, 225000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD008', CAST(N'2022-05-25T13:13:17.277' AS DateTime), 1, 300000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD009', CAST(N'2022-05-25T13:16:03.677' AS DateTime), 1, 2100000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD010', CAST(N'2022-05-25T13:36:21.667' AS DateTime), 1, 300000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD011', CAST(N'2022-05-25T13:37:26.600' AS DateTime), 1, 200000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD012', CAST(N'2022-05-25T14:22:27.517' AS DateTime), 1, 1350000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD013', CAST(N'2022-05-25T14:29:37.713' AS DateTime), 1, 510000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD014', CAST(N'2022-05-25T14:40:39.857' AS DateTime), 1, 225000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD015', CAST(N'2022-05-25T14:41:36.550' AS DateTime), 1, 225000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD016', CAST(N'2022-05-25T14:42:45.900' AS DateTime), 1, 225000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD017', CAST(N'2022-05-25T14:47:12.957' AS DateTime), 1, 225000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD018', CAST(N'2022-05-25T14:47:21.117' AS DateTime), 1, 225000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD019', CAST(N'2022-05-25T14:47:23.780' AS DateTime), 1, 255000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD020', CAST(N'2022-05-25T14:48:01.147' AS DateTime), 1, 1785000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD021', CAST(N'2022-05-25T14:48:04.047' AS DateTime), 1, 225000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD022', CAST(N'2022-05-25T14:48:06.783' AS DateTime), 1, 900000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD023', CAST(N'2022-05-25T14:49:23.820' AS DateTime), 1, 1350000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD024', CAST(N'2022-05-25T14:49:26.797' AS DateTime), 1, 1530000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD025', CAST(N'2022-05-25T14:49:56.940' AS DateTime), 1, 1020000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD026', CAST(N'2022-05-25T14:49:59.883' AS DateTime), 1, 450000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD027', CAST(N'2022-05-25T14:50:03.063' AS DateTime), 1, 675000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD028', CAST(N'2022-05-25T14:58:42.067' AS DateTime), 1, 225000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD029', CAST(N'2022-05-25T14:58:47.380' AS DateTime), 1, 225000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD030', CAST(N'2022-05-25T15:16:59.733' AS DateTime), 1, 255000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD031', CAST(N'2022-05-25T15:17:05.820' AS DateTime), 1, 1350000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD032', CAST(N'2022-05-25T15:17:08.797' AS DateTime), 1, 900000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD033', CAST(N'2022-05-25T15:21:23.227' AS DateTime), 1, 225000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD034', CAST(N'2022-05-25T15:21:28.877' AS DateTime), 1, 225000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD035', CAST(N'2022-05-25T15:21:36.210' AS DateTime), 1, 300000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD036', CAST(N'2022-05-25T15:21:39.550' AS DateTime), 1, 255000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD037', CAST(N'2022-05-25T15:22:53.070' AS DateTime), 1, 675000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD038', CAST(N'2022-05-25T15:22:56.260' AS DateTime), 1, 450000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD039', CAST(N'2022-05-25T16:19:41.013' AS DateTime), 1, 225000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD040', CAST(N'2022-05-25T16:19:45.920' AS DateTime), 1, 1575000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD041', CAST(N'2022-05-25T19:49:51.080' AS DateTime), 1, 450000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD042', CAST(N'2022-05-25T19:50:26.743' AS DateTime), 1, 450000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD043', CAST(N'2022-05-25T19:51:30.017' AS DateTime), 1, 225000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD044', CAST(N'2022-05-25T19:51:37.007' AS DateTime), 1, 300000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD045', CAST(N'2022-05-25T20:15:18.383' AS DateTime), 1, 2100000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD046', CAST(N'2022-05-25T20:15:26.660' AS DateTime), 1, 2100000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD047', CAST(N'2022-05-25T20:15:33.533' AS DateTime), 1, 2100000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD048', CAST(N'2022-05-25T20:16:59.443' AS DateTime), 1, 1785000)
GO
INSERT [dbo].[HOADON] ([MaHD], [CheckOut], [status], [TongTien]) VALUES (N'HD049', CAST(N'2022-05-25T20:17:03.740' AS DateTime), 1, 1785000)
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH001', N'Ngyen Qua', N'LKH02', N'000000000000', N'1111111111', N'dddddddddddddddddddddd', N'dgjsgds', N'Nữ')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH004', N'111111111', N'LKH02', N'1111111', N'1111111111', N'111111111111', N'1', N'Nữ')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH005', N'123', N'LKH02', N'123', N'123', N'123', N'123', N'Nam')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH006', N'3333', N'LKH02', N'333', N'333', N'333', N'333', N'Nam')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH007', N'ccccccccccccc', N'LKH02', N'1111111', N'1344444444', N'44444444444', N'444444', N'Nam')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH008', N'HHGHG', N'LKH02', N'12212', N'1221', N'GHG', N'HG', N'Nam')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH009', N'nguy', N'LKH02', N'88989', N'989898', N'jhjh', N'jhjh', N'Nữ')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH010', N'1212', N'LKH02', N'1212', N'1212', N'121', N'212', N'Nam')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH011', N'sdsd', N'LKH02', N'2323', N'2323', N'wds', N'233', N'Nam')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH012', N'ASAS', N'LKH02', N'1233', N'121313', N'FDFD', N'FDF', N'Nam')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH013', N'USER 1', N'LKH02', N'1231', N'123', N'123', N'123', N'Nam')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH014', N'USER2', N'LKH02', N'333', N'33', N'333', N'33', N'Nữ')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH015', N'sdsd', N'LKH02', N'223', N'33', N'2', N'3', N'Nam')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH016', N'nhguy', N'LKH02', N'23', N'98', N'998', N'98', N'Nữ')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH017', N'user3', N'LKH02', N'121', N'12311', N'1', N'1', N'Nam')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH018', N'user9', N'LKH02', N'000', N'000', N'777', N'77', N'Nam')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH019', N'test', N'LKH02', N'22', N'1', N'1', N'1', N'Nam')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH020', N'USER1', N'LKH02', N'1', N'1', N'1', N'1', N'Nam')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH021', N'USER1', N'LKH02', N'1', N'1', N'1', N'1', N'Nam')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH022', N'USER1', N'LKH02', N'1', N'1', N'1', N'1', N'Nữ')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH023', N'EE', N'LKH02', N'21', N'12', N'12', N'12', N'Nam')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH024', N'user1', N'LKH02', N'65', N'65', N'65', N'65', N'Nam')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH025', N'12', N'LKH02', N'12', N'21', N'12', N'21', N'Nam')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH026', N'user2', N'LKH02', N'12', N'1111111111', N'11111', N'11', N'Nam')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH027', N'123', N'LKH02', N'123', N'123', N'123', N'123', N'Nữ')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH028', N'87', N'LKH02', N'87', N'87', N'87', N'87', N'Nam')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH029', N'mmmmmm', N'LKH02', N'33333333333', N'333333333', N'33333333', N'3333333333', N'Nữ')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH030', N'123', N'LKH02', N'123', N'1231', N'123', N'123', N'Nam')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH033', N'AS', N'LKH02', N'12', N'33', N'AS', N'12', N'Nữ')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH034', N'Nguyenx Thanh', N'LKH01', N'098766565672', N'1231111111', N'dsdssd', N'Việt Nam', N'Nữ')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH035', N'nguyen thanh ', N'LKH02', N'098879', N'09988789', N'hj', N'jhjh', N'Nữ')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH036', N'NBBNB', N'LKH02', N'545454', N'5454', N'545454', N'54545', N'Nam')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH037', N'Test', N'LKH02', N'7676', N'767', N'8', N'9', N'Nam')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH038', N'TEST CT PHONG', N'LKH02', N'12', N'4', N'6', N'7', N'Nữ')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH039', N'1', N'LKH02', N'1', N'274512', N'2', N'2', N'Nam')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH040', N'1', N'LKH02', N'2', N'41432', N'1', N'1', N'Nam')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH041', N'gf', N'LKH02', N'765', N'5555667', N'h', N'g', N'Nam')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH042', N'qw', N'LKH02', N'21', N'121212', N'qw', N'qw', N'Nam')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH043', N'656', N'LKH02', N'656', N'786876', N'7778', N'76786', N'Nam')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH044', N'hghgj', N'LKH02', N'09', N'09090', N'09', N'09', N'Nam')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH045', N'2121', N'LKH02', N'121', N'212', N'121', N'21', N'Nam')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH046', N'hgdddsg', N'LKH02', N'8778678323', N'90676867', N'987678', N'876876', N'Nữ')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH048', N'2132', N'LKH02', N'3213', N'32132323', N'123123', N'213', N'Nam')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH050', N'DJSJHDBSHF', N'LKH02', N'122222222222', N'1212121212', N'DSSDSD', N'DSDSD', N'Nam')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH051', N'sdfsdfdf', N'LKH02', N'122222222222', N'1231232222', N'dsfdsfsdf', N'11231dsd', N'Nam')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH052', N'Nguyenx Thanh Thien QIa', N'LKH01', N'1213', N'0517531921', N'1', N'Việt Nam', N'Nam')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH054', N'hgshdbndsjg', N'LKH01', N'65665654', N'8584676657', N'121', N'Việt Nam', N'Nữ')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH055', N'shdhfjbsbncxhzg', N'LKH01', N'12', N'0000000000', N'1', N'Việt Nam', N'Nữ')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH056', N'Nguyen Duc Long', N'LKH02', N'666666666666', N'0882971121', N'HCM', N'VN', N'Nữ')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH057', N'Âu Lạc Nhi', N'LKH01', N'989878787878', N'0987125014', N'An Giang', N'Việt Nam', N'Nữ')
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [MaLoaiKH], [CMND], [SDT], [DiaChi], [QuocTich], [GioiTinh]) VALUES (N'KH058', N'Nguyeenx Thanh Thien Qua', N'LKH02', N'092812617171', N'1112312121', N'An Giang', N'Singapore', N'Nữ')
GO
INSERT [dbo].[LOAIKH] ([MaLoaiKH], [TenLoaiKH], [HeSoPhuThu]) VALUES (N'LKH01', N'Nội địa', 1)
GO
INSERT [dbo].[LOAIKH] ([MaLoaiKH], [TenLoaiKH], [HeSoPhuThu]) VALUES (N'LKH02', N'Nước ngoài', 1.5)
GO
INSERT [dbo].[LOAIPHONG] ([MaLoaiPhong], [TenLoaiPhong], [SoKHMax], [DonGia]) VALUES (N'P01  ', N'Phòng A', 3, 150000)
GO
INSERT [dbo].[LOAIPHONG] ([MaLoaiPhong], [TenLoaiPhong], [SoKHMax], [DonGia]) VALUES (N'P02  ', N'Phòng B', 3, 170000)
GO
INSERT [dbo].[LOAIPHONG] ([MaLoaiPhong], [TenLoaiPhong], [SoKHMax], [DonGia]) VALUES (N'P03  ', N'Phòng C', 3, 200000)
GO
SET IDENTITY_INSERT [dbo].[NHATKI] ON 
GO
INSERT [dbo].[NHATKI] ([MaNK], [MaPhong], [MaCTPT], [NgayBD], [NgayKT], [IsDay], [MaPhieu], [SoNguoiHT]) VALUES (69, N'P102 ', N'CT004', CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-27T00:00:00.000' AS DateTime), 1, N'PT001', 1)
GO
INSERT [dbo].[NHATKI] ([MaNK], [MaPhong], [MaCTPT], [NgayBD], [NgayKT], [IsDay], [MaPhieu], [SoNguoiHT]) VALUES (70, N'P102 ', N'CT005', CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-25T00:00:00.000' AS DateTime), 1, N'PT001', 1)
GO
INSERT [dbo].[NHATKI] ([MaNK], [MaPhong], [MaCTPT], [NgayBD], [NgayKT], [IsDay], [MaPhieu], [SoNguoiHT]) VALUES (75, N'P102 ', N'CT010', CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-30T00:00:00.000' AS DateTime), 1, N'PT001', 1)
GO
INSERT [dbo].[NHATKI] ([MaNK], [MaPhong], [MaCTPT], [NgayBD], [NgayKT], [IsDay], [MaPhieu], [SoNguoiHT]) VALUES (78, N'P101 ', N'CT012', CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-25T00:00:00.000' AS DateTime), 1, N'PT003', 1)
GO
INSERT [dbo].[NHATKI] ([MaNK], [MaPhong], [MaCTPT], [NgayBD], [NgayKT], [IsDay], [MaPhieu], [SoNguoiHT]) VALUES (79, N'P102 ', N'CT013', CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-25T00:00:00.000' AS DateTime), 1, N'PT003', 1)
GO
INSERT [dbo].[NHATKI] ([MaNK], [MaPhong], [MaCTPT], [NgayBD], [NgayKT], [IsDay], [MaPhieu], [SoNguoiHT]) VALUES (80, N'P101 ', N'CT014', CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-25T00:00:00.000' AS DateTime), 1, N'PT003', 1)
GO
INSERT [dbo].[NHATKI] ([MaNK], [MaPhong], [MaCTPT], [NgayBD], [NgayKT], [IsDay], [MaPhieu], [SoNguoiHT]) VALUES (81, N'P101 ', N'CT015', CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-25T00:00:00.000' AS DateTime), 1, N'PT003', 1)
GO
INSERT [dbo].[NHATKI] ([MaNK], [MaPhong], [MaCTPT], [NgayBD], [NgayKT], [IsDay], [MaPhieu], [SoNguoiHT]) VALUES (82, N'P102 ', N'CT015', CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-25T00:00:00.000' AS DateTime), 1, N'PT004', 1)
GO
INSERT [dbo].[NHATKI] ([MaNK], [MaPhong], [MaCTPT], [NgayBD], [NgayKT], [IsDay], [MaPhieu], [SoNguoiHT]) VALUES (84, N'P102 ', N'CT016', CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-25T00:00:00.000' AS DateTime), 1, N'PT003', 1)
GO
INSERT [dbo].[NHATKI] ([MaNK], [MaPhong], [MaCTPT], [NgayBD], [NgayKT], [IsDay], [MaPhieu], [SoNguoiHT]) VALUES (86, N'P101 ', N'CT016', CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-28T00:00:00.000' AS DateTime), 1, N'PT005', 3)
GO
INSERT [dbo].[NHATKI] ([MaNK], [MaPhong], [MaCTPT], [NgayBD], [NgayKT], [IsDay], [MaPhieu], [SoNguoiHT]) VALUES (87, N'P102 ', N'CT017', CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-30T00:00:00.000' AS DateTime), 1, N'PT003', 1)
GO
INSERT [dbo].[NHATKI] ([MaNK], [MaPhong], [MaCTPT], [NgayBD], [NgayKT], [IsDay], [MaPhieu], [SoNguoiHT]) VALUES (89, N'P101 ', N'CT018', CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-26T00:00:00.000' AS DateTime), 1, N'PT003', 1)
GO
INSERT [dbo].[NHATKI] ([MaNK], [MaPhong], [MaCTPT], [NgayBD], [NgayKT], [IsDay], [MaPhieu], [SoNguoiHT]) VALUES (90, N'P102 ', N'CT018', CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-27T00:00:00.000' AS DateTime), 1, N'PT004', 1)
GO
INSERT [dbo].[NHATKI] ([MaNK], [MaPhong], [MaCTPT], [NgayBD], [NgayKT], [IsDay], [MaPhieu], [SoNguoiHT]) VALUES (92, N'P101 ', N'CT019', CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-25T00:00:00.000' AS DateTime), 1, N'PT003', 1)
GO
INSERT [dbo].[NHATKI] ([MaNK], [MaPhong], [MaCTPT], [NgayBD], [NgayKT], [IsDay], [MaPhieu], [SoNguoiHT]) VALUES (93, N'P102 ', N'CT019', CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-25T00:00:00.000' AS DateTime), 1, N'PT004', 1)
GO
INSERT [dbo].[NHATKI] ([MaNK], [MaPhong], [MaCTPT], [NgayBD], [NgayKT], [IsDay], [MaPhieu], [SoNguoiHT]) VALUES (95, N'P101 ', N'CT020', CAST(N'2022-05-26T00:00:00.000' AS DateTime), CAST(N'2022-05-31T00:00:00.000' AS DateTime), 1, N'PT006', 1)
GO
INSERT [dbo].[NHATKI] ([MaNK], [MaPhong], [MaCTPT], [NgayBD], [NgayKT], [IsDay], [MaPhieu], [SoNguoiHT]) VALUES (96, N'P102 ', N'CT021', CAST(N'2022-05-28T00:00:00.000' AS DateTime), CAST(N'2022-05-31T00:00:00.000' AS DateTime), 1, N'PT007', 1)
GO
INSERT [dbo].[NHATKI] ([MaNK], [MaPhong], [MaCTPT], [NgayBD], [NgayKT], [IsDay], [MaPhieu], [SoNguoiHT]) VALUES (98, N'P101 ', N'CT022', CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-25T00:00:00.000' AS DateTime), 1, N'PT001', 1)
GO
INSERT [dbo].[NHATKI] ([MaNK], [MaPhong], [MaCTPT], [NgayBD], [NgayKT], [IsDay], [MaPhieu], [SoNguoiHT]) VALUES (99, N'P102 ', N'CT022', CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-25T00:00:00.000' AS DateTime), 1, N'PT002', 1)
GO
INSERT [dbo].[NHATKI] ([MaNK], [MaPhong], [MaCTPT], [NgayBD], [NgayKT], [IsDay], [MaPhieu], [SoNguoiHT]) VALUES (105, N'P101 ', N'CT024', CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-25T00:00:00.000' AS DateTime), 1, N'PT004', 2)
GO
INSERT [dbo].[NHATKI] ([MaNK], [MaPhong], [MaCTPT], [NgayBD], [NgayKT], [IsDay], [MaPhieu], [SoNguoiHT]) VALUES (106, N'P102 ', N'CT025', CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-31T00:00:00.000' AS DateTime), 1, N'PT005', 1)
GO
INSERT [dbo].[NHATKI] ([MaNK], [MaPhong], [MaCTPT], [NgayBD], [NgayKT], [IsDay], [MaPhieu], [SoNguoiHT]) VALUES (112, N'P102 ', N'CT027', CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-26T00:00:00.000' AS DateTime), 1, N'PT005', 1)
GO
INSERT [dbo].[NHATKI] ([MaNK], [MaPhong], [MaCTPT], [NgayBD], [NgayKT], [IsDay], [MaPhieu], [SoNguoiHT]) VALUES (113, N'P101 ', N'CT028', CAST(N'2022-05-30T00:00:00.000' AS DateTime), CAST(N'2022-05-31T00:00:00.000' AS DateTime), 1, N'PT005', 1)
GO
INSERT [dbo].[NHATKI] ([MaNK], [MaPhong], [MaCTPT], [NgayBD], [NgayKT], [IsDay], [MaPhieu], [SoNguoiHT]) VALUES (114, N'P101 ', N'CT029', CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-25T00:00:00.000' AS DateTime), 1, N'PT001', 1)
GO
INSERT [dbo].[NHATKI] ([MaNK], [MaPhong], [MaCTPT], [NgayBD], [NgayKT], [IsDay], [MaPhieu], [SoNguoiHT]) VALUES (115, N'P303 ', N'CT029', CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-25T00:00:00.000' AS DateTime), 1, N'PT002', 3)
GO
INSERT [dbo].[NHATKI] ([MaNK], [MaPhong], [MaCTPT], [NgayBD], [NgayKT], [IsDay], [MaPhieu], [SoNguoiHT]) VALUES (116, N'P101 ', N'CT030', CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-25T00:00:00.000' AS DateTime), 1, N'PT001', 1)
GO
INSERT [dbo].[NHATKI] ([MaNK], [MaPhong], [MaCTPT], [NgayBD], [NgayKT], [IsDay], [MaPhieu], [SoNguoiHT]) VALUES (117, N'P102 ', N'CT030', CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-25T00:00:00.000' AS DateTime), 1, N'PT002', 1)
GO
INSERT [dbo].[NHATKI] ([MaNK], [MaPhong], [MaCTPT], [NgayBD], [NgayKT], [IsDay], [MaPhieu], [SoNguoiHT]) VALUES (118, N'P301 ', N'CT031', CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-31T00:00:00.000' AS DateTime), 1, N'PT003', 1)
GO
INSERT [dbo].[NHATKI] ([MaNK], [MaPhong], [MaCTPT], [NgayBD], [NgayKT], [IsDay], [MaPhieu], [SoNguoiHT]) VALUES (119, N'P302 ', N'CT031', CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-31T00:00:00.000' AS DateTime), 1, N'PT004', 3)
GO
INSERT [dbo].[NHATKI] ([MaNK], [MaPhong], [MaCTPT], [NgayBD], [NgayKT], [IsDay], [MaPhieu], [SoNguoiHT]) VALUES (120, N'P303 ', N'CT031', CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-31T00:00:00.000' AS DateTime), 1, N'PT005', 1)
GO
INSERT [dbo].[NHATKI] ([MaNK], [MaPhong], [MaCTPT], [NgayBD], [NgayKT], [IsDay], [MaPhieu], [SoNguoiHT]) VALUES (121, N'P202 ', N'CT032', CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-31T00:00:00.000' AS DateTime), 1, N'PT003', 1)
GO
INSERT [dbo].[NHATKI] ([MaNK], [MaPhong], [MaCTPT], [NgayBD], [NgayKT], [IsDay], [MaPhieu], [SoNguoiHT]) VALUES (122, N'P203 ', N'CT032', CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-31T00:00:00.000' AS DateTime), 1, N'PT004', 3)
GO
INSERT [dbo].[NHATKI] ([MaNK], [MaPhong], [MaCTPT], [NgayBD], [NgayKT], [IsDay], [MaPhieu], [SoNguoiHT]) VALUES (123, N'P201 ', N'CT032', CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-31T00:00:00.000' AS DateTime), 1, N'PT005', 2)
GO
SET IDENTITY_INSERT [dbo].[NHATKI] OFF
GO
INSERT [dbo].[PHIEUTHUE] ([MaPhieu], [MaPhong], [NgayBD], [NgayKT], [IsDay], [MaCTPT], [SoNguoiHT]) VALUES (N'PT001', N'P101 ', CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-25T00:00:00.000' AS DateTime), 1, N'CT030', 1)
GO
INSERT [dbo].[PHIEUTHUE] ([MaPhieu], [MaPhong], [NgayBD], [NgayKT], [IsDay], [MaCTPT], [SoNguoiHT]) VALUES (N'PT002', N'P102 ', CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-25T00:00:00.000' AS DateTime), 1, N'CT030', 1)
GO
INSERT [dbo].[PHIEUTHUE] ([MaPhieu], [MaPhong], [NgayBD], [NgayKT], [IsDay], [MaCTPT], [SoNguoiHT]) VALUES (N'PT004', N'P203 ', CAST(N'2022-05-25T00:00:00.000' AS DateTime), CAST(N'2022-05-31T00:00:00.000' AS DateTime), 1, N'CT032', 3)
GO
INSERT [dbo].[PHONG] ([MaPhong], [TenPhong], [MaLoaiPhong], [DonDep], [TinhTrang]) VALUES (N'P101 ', N'P101', N'P01  ', N'Chưa dọn dẹp', N'Phòng đang thuê')
GO
INSERT [dbo].[PHONG] ([MaPhong], [TenPhong], [MaLoaiPhong], [DonDep], [TinhTrang]) VALUES (N'P102 ', N'P102', N'P01  ', N'Chưa dọn dẹp', N'Phòng đã đặt')
GO
INSERT [dbo].[PHONG] ([MaPhong], [TenPhong], [MaLoaiPhong], [DonDep], [TinhTrang]) VALUES (N'P201 ', N'P201', N'P02  ', N'Chưa dọn dẹp', N'Phòng trống')
GO
INSERT [dbo].[PHONG] ([MaPhong], [TenPhong], [MaLoaiPhong], [DonDep], [TinhTrang]) VALUES (N'P202 ', N'P202', N'P02  ', N'Chưa dọn dẹp', N'Phòng trống')
GO
INSERT [dbo].[PHONG] ([MaPhong], [TenPhong], [MaLoaiPhong], [DonDep], [TinhTrang]) VALUES (N'P203 ', N'P203', N'P02  ', N'Đã dọn dẹp', N'Phòng đang thuê')
GO
INSERT [dbo].[PHONG] ([MaPhong], [TenPhong], [MaLoaiPhong], [DonDep], [TinhTrang]) VALUES (N'P301 ', N'P301', N'P03  ', N'Chưa dọn dẹp', N'Phòng trống')
GO
INSERT [dbo].[PHONG] ([MaPhong], [TenPhong], [MaLoaiPhong], [DonDep], [TinhTrang]) VALUES (N'P302 ', N'P302', N'P03  ', N'Chưa dọn dẹp', N'Phòng trống')
GO
INSERT [dbo].[PHONG] ([MaPhong], [TenPhong], [MaLoaiPhong], [DonDep], [TinhTrang]) VALUES (N'P303 ', N'P303', N'P03  ', N'Chưa dọn dẹp', N'Phòng trống')
GO
SET IDENTITY_INSERT [dbo].[PHUTHU] ON 
GO
INSERT [dbo].[PHUTHU] ([STT_KH], [TyLePhuThu], [MaPhuThu], [TenPhuThu]) VALUES (3, 0.25, 2, N'Phụ th khách thứ 3')
GO
INSERT [dbo].[PHUTHU] ([STT_KH], [TyLePhuThu], [MaPhuThu], [TenPhuThu]) VALUES (1, 0, 3, N'Phụ th khách thứ 1')
GO
INSERT [dbo].[PHUTHU] ([STT_KH], [TyLePhuThu], [MaPhuThu], [TenPhuThu]) VALUES (2, 0, 4, N'Phụ th khách thứ 2')
GO
SET IDENTITY_INSERT [dbo].[PHUTHU] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [DisplayName], [UserName], [Password], [CapDoQuyen]) VALUES (1, N'Tantanphatphat', N'admin', N'db69fc039dcbd2962cb4d28f5891aae1', 1)
GO
INSERT [dbo].[Users] ([Id], [DisplayName], [UserName], [Password], [CapDoQuyen]) VALUES (2, N'Nhan vien 1', N'staff1', N'15ea5540544c00e1530ccc5aad1b7bb7', 2)
GO
INSERT [dbo].[Users] ([Id], [DisplayName], [UserName], [Password], [CapDoQuyen]) VALUES (3, N'Nhan vien 2', N'staff2', N'3878d341de7d00ef13891966ec547b20', 2)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[CT_PHIEUTHUE] ADD  CONSTRAINT [DF__CT_PHIEUT__NgayL__084B3915]  DEFAULT (getdate()) FOR [NgayLap]
GO
ALTER TABLE [dbo].[CTHD] ADD  DEFAULT ((0)) FOR [Count]
GO
ALTER TABLE [dbo].[HOADON] ADD  CONSTRAINT [DF__HOADON__status__4F47C5E3]  DEFAULT ((0)) FOR [status]
GO
ALTER TABLE [dbo].[HOADON] ADD  CONSTRAINT [DF__HOADON__TongTien__6BAEFA67]  DEFAULT ((0)) FOR [TongTien]
GO
ALTER TABLE [dbo].[KHACHHANG] ADD  DEFAULT ('0') FOR [GioiTinh]
GO
ALTER TABLE [dbo].[PHIEUTHUE] ADD  CONSTRAINT [DF__PHIEUTHUE__NgayB__0D44F85C]  DEFAULT (getdate()) FOR [NgayBD]
GO
ALTER TABLE [dbo].[PHIEUTHUE] ADD  CONSTRAINT [DF__PHIEUTHUE__NgayK__0E391C95]  DEFAULT (NULL) FOR [NgayKT]
GO
ALTER TABLE [dbo].[PHIEUTHUE] ADD  CONSTRAINT [DF__PHIEUTHUE__IsDay__11158940]  DEFAULT ((1)) FOR [IsDay]
GO
ALTER TABLE [dbo].[CT_PHIEUTHUE]  WITH CHECK ADD  CONSTRAINT [FK__CT_PHIEUTH__MaKH__398D8EEE] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([MaKH])
GO
ALTER TABLE [dbo].[CT_PHIEUTHUE] CHECK CONSTRAINT [FK__CT_PHIEUTH__MaKH__398D8EEE]
GO
ALTER TABLE [dbo].[CTBAOCAODT]  WITH CHECK ADD FOREIGN KEY([MaBaoCao])
REFERENCES [dbo].[BAOCAODT] ([MaBaoCao])
GO
ALTER TABLE [dbo].[CTBAOCAODT]  WITH CHECK ADD  CONSTRAINT [FK__CTBAOCAOD__MaLoa__440B1D61] FOREIGN KEY([MaLoaiPhong])
REFERENCES [dbo].[LOAIPHONG] ([MaLoaiPhong])
GO
ALTER TABLE [dbo].[CTBAOCAODT] CHECK CONSTRAINT [FK__CTBAOCAOD__MaLoa__440B1D61]
GO
ALTER TABLE [dbo].[CTHD]  WITH CHECK ADD  CONSTRAINT [FK__CTHD__MaCTPT__3D5E1FD2] FOREIGN KEY([MaCTPT])
REFERENCES [dbo].[CT_PHIEUTHUE] ([MaCTPT])
GO
ALTER TABLE [dbo].[CTHD] CHECK CONSTRAINT [FK__CTHD__MaCTPT__3D5E1FD2]
GO
ALTER TABLE [dbo].[CTHD]  WITH CHECK ADD  CONSTRAINT [FK__CTHD__MaHD__3C69FB99] FOREIGN KEY([MaHD])
REFERENCES [dbo].[HOADON] ([MaHD])
GO
ALTER TABLE [dbo].[CTHD] CHECK CONSTRAINT [FK__CTHD__MaHD__3C69FB99]
GO
ALTER TABLE [dbo].[KHACHHANG]  WITH CHECK ADD  CONSTRAINT [FK__KHACHHANG__MaLoa__286302EC] FOREIGN KEY([MaLoaiKH])
REFERENCES [dbo].[LOAIKH] ([MaLoaiKH])
GO
ALTER TABLE [dbo].[KHACHHANG] CHECK CONSTRAINT [FK__KHACHHANG__MaLoa__286302EC]
GO
ALTER TABLE [dbo].[NHATKI]  WITH CHECK ADD  CONSTRAINT [FK__NHATKI__MaCTPT__7BB05806] FOREIGN KEY([MaCTPT])
REFERENCES [dbo].[CT_PHIEUTHUE] ([MaCTPT])
GO
ALTER TABLE [dbo].[NHATKI] CHECK CONSTRAINT [FK__NHATKI__MaCTPT__7BB05806]
GO
ALTER TABLE [dbo].[NHATKI]  WITH CHECK ADD  CONSTRAINT [FK__NHATKI__MaPhong__7ABC33CD] FOREIGN KEY([MaPhong])
REFERENCES [dbo].[PHONG] ([MaPhong])
GO
ALTER TABLE [dbo].[NHATKI] CHECK CONSTRAINT [FK__NHATKI__MaPhong__7ABC33CD]
GO
ALTER TABLE [dbo].[PHIEUTHUE]  WITH CHECK ADD  CONSTRAINT [FK__PHIEUTHUE__MaCTP__0B27A5C0] FOREIGN KEY([MaCTPT])
REFERENCES [dbo].[CT_PHIEUTHUE] ([MaCTPT])
GO
ALTER TABLE [dbo].[PHIEUTHUE] CHECK CONSTRAINT [FK__PHIEUTHUE__MaCTP__0B27A5C0]
GO
ALTER TABLE [dbo].[PHIEUTHUE]  WITH CHECK ADD  CONSTRAINT [FK__PHIEUTHUE__MaPho__300424B4] FOREIGN KEY([MaPhong])
REFERENCES [dbo].[PHONG] ([MaPhong])
GO
ALTER TABLE [dbo].[PHIEUTHUE] CHECK CONSTRAINT [FK__PHIEUTHUE__MaPho__300424B4]
GO
ALTER TABLE [dbo].[PHONG]  WITH CHECK ADD  CONSTRAINT [FK__PHONG__MaLoaiPho__2D27B809] FOREIGN KEY([MaLoaiPhong])
REFERENCES [dbo].[LOAIPHONG] ([MaLoaiPhong])
GO
ALTER TABLE [dbo].[PHONG] CHECK CONSTRAINT [FK__PHONG__MaLoaiPho__2D27B809]
GO
/****** Object:  StoredProcedure [dbo].[SP_DelKH]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_DelKH]
@MaKH char(5)
as begin
delete KHACHHANG where MaKH=@MaKH
end
GO
/****** Object:  StoredProcedure [dbo].[USP_AddHoaDon]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_AddHoaDon]
@MaHD char(5), @CheckOut datetime, @ST int, @TongTien int,
@MaCTHD char(5), @MaCTPT char(5), @Count int
as begin
insert into HOADON values(@MaHD, @CheckOut, @ST, @TongTien)
insert into CTHD values(@MaCTHD, @MaHD, @MaCTPT, @Count)
select  CT.MaCTPT, HD.MaHD, CheckOut, TongTien, status, PT.MaPhong, NgayBD, NgayKT
from CT_PHIEUTHUE CT, CTHD, HOADON HD, PHIEUTHUE PT
WHERE CT.MaCTPT=CTHD.MaCTPT AND CTHD.MaHD = HD.MaHD AND PT.MaCTPT = CT.MaCTPT
and HD.MaHD = @MaHD
end
GO
/****** Object:  StoredProcedure [dbo].[USP_AddHoaDonUP]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_AddHoaDonUP]
@MaHD char(5), @CheckOut datetime , @ST int, @TongTien int,
@MaCTHD char(5), @MaCTPT char(5), @Count int, @MaPhieu char(5)
as begin
insert into HOADON values(@MaHD, @CheckOut, @ST, @TongTien)
insert into CTHD values(@MaCTHD, @MaHD, @MaCTPT, @Count)

delete PHIEUTHUE where MaPhieu=@MaPhieu

select  CT.MaCTPT, HD.MaHD, CheckOut, TongTien, status, NK.MaPhong, NgayBD, NgayKT
from CT_PHIEUTHUE CT, CTHD, HOADON HD, NHATKI NK
WHERE CT.MaCTPT=CTHD.MaCTPT AND CTHD.MaHD = HD.MaHD AND NK.MaCTPT = CT.MaCTPT
and HD.MaHD =@MaHD AND NK.MaPhieu=@MaPhieu
end
GO
/****** Object:  StoredProcedure [dbo].[USP_AddLoaiPhong]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_AddLoaiPhong]
@MaLP char(5), @TenLP nvarchar(50), @Max int, @DG int
as begin
insert into LOAIPHONG VALUES(@MaLP, @TenLP, @Max, @DG)
end
GO
/****** Object:  StoredProcedure [dbo].[USP_CHECK_EXIST]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_CHECK_EXIST]
@MaPhong char(5)
as
begin
select MaPhong from PHONG WHERE MaPhong = @MaPhong
end
GO
/****** Object:  StoredProcedure [dbo].[USP_CheckTenLP]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_CheckTenLP]
@TenLP nvarchar(50)
as begin
select * from LOAIPHONG where TenLoaiPhong = @TenLP
end
GO
/****** Object:  StoredProcedure [dbo].[USP_CheckTrungTenLKH]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_CheckTrungTenLKH]
@TenLKH nvarchar(50)
as begin
select * from LOAIKH WHERE TenLoaiKH=@TenLKH
end
GO
/****** Object:  StoredProcedure [dbo].[USP_CheckTrungTenPTNgO]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_CheckTrungTenPTNgO]
@TenPT nvarchar(50)
as begin
select * from PHUTHU WHERE TenPhuThu=@TenPT
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Del_CTPT]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Del_CTPT]
@MaCTPhieu char(5) 
AS BEGIN
Update  PHONG
set TinhTrang=N'Phòng trống'
from Phong P inner join NHATKI PT ON P.MaPhong = PT.MaPhong
WHERE PT.MaCTPT = @MaCTPhieu

DELETE CTHD
WHERE MaCTPT=@MaCTPhieu

delete NHATKI WHERE MaCTPT=@MaCTPhieu
delete PHIEUTHUE WHERE MaCTPT=@MaCTPhieu

DELETE CT_PHIEUTHUE --SELECT *
where MaCTPT=@MaCTPhieu
END
GO
/****** Object:  StoredProcedure [dbo].[USP_DelLP]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_DelLP]
@MaLP char(5)
as begin
delete LOAIPHONG WHERE MaLoaiPhong=@MaLP
end
GO
/****** Object:  StoredProcedure [dbo].[USP_DelPhong]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_DelPhong]
@MaPhong char(5)
as begin
DELETE PHIEUTHUE WHERE MaPhong=@MaPhong
DeLETE NHATKI WHERE MaPhong=@MaPhong
DELETE PHONG WHERE MaPhong=@MaPhong
end
GO
/****** Object:  StoredProcedure [dbo].[USP_DelPHUTHU]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_DelPHUTHU]
@MaPT int
as begin
delete PHUTHU WHERE MaPhuThu=@MaPT
end
GO
/****** Object:  StoredProcedure [dbo].[USP_DelPTKhachQT]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_DelPTKhachQT]
@MaLKH char(5)
as begin
DELETE LOAIKH where MaLoaiKH = @MaLKH
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetCTPhieuTheoMaPhieu]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetCTPhieuTheoMaPhieu]
@MaCTPhieu char(5) 
AS BEGIN
select PT.MaPhieu, PT.MaPhong, NgayBD, SoNguoiHT, NgayKT, KH.MaKH, P.TinhTrang, CT.NgayLap, 
TenKH, IsDay, PT.MaCTPT
from NHATKI PT, PHONG P, CT_PHIEUTHUE CT, KHACHHANG KH
WHERE PT.MaPhong=P.MaPhong and CT.MaCTPT=PT.MaCTPT and KH.MaKH=CT.MaKH
AND PT.MaCTPT= @MaCTPhieu
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetDoanhThuLPtheoThang]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetDoanhThuLPtheoThang]
@month int
as begin
select  TenLoaiPhong, sum(TongTien) as DoanhThu, month(CheckOut) Thang
,(SUM(CAST(TongTien AS BIGINT))*100/
(select sum(TongTien) 
from LOAIPHONG LP, PHONG P, NHATKI PT, CT_PHIEUTHUE CT, CTHD, HOADON HD
WHERE LP.MaLoaiPhong=P.MaLoaiPhong AND P.MaPhong=PT.MaPhong AND PT.MaCTPT=CT.MaCTPT
AND CT.MaCTPT=CTHD.MaCTPT AND CTHD.MaHD=HD.MaHD  And month(CheckOut) =5-- @month
))  as TyLe

from LOAIPHONG LP, PHONG P, NHATKI PT, CT_PHIEUTHUE CT, CTHD, HOADON HD
WHERE LP.MaLoaiPhong=P.MaLoaiPhong AND P.MaPhong=PT.MaPhong AND PT.MaCTPT=CT.MaCTPT
AND CT.MaCTPT=CTHD.MaCTPT AND CTHD.MaHD=HD.MaHD 
and month(CheckOut) = 5--@month
group by TenLoaiPhong,  month(CheckOut)
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetDoanhThuTheoLoaiPhong]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetDoanhThuTheoLoaiPhong]
@TenLP nvarchar(50), @Thang int, @Nam int
as begin
select  SUM(HD.TongTien) as DoanhThu
from LOAIPHONG LP, PHONG P, NHATKI PT, CT_PHIEUTHUE CT, CTHD, HOADON HD
WHERE LP.MaLoaiPhong=P.MaLoaiPhong AND P.MaPhong=PT.MaPhong AND PT.MaCTPT=CT.MaCTPT
AND CT.MaCTPT=CTHD.MaCTPT AND CTHD.MaHD=HD.MaHD 
and TenLoaiPhong=@TenLP and month(CheckOut)=@Thang and year(CheckOut)=@Nam
group by TenLoaiPhong
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetDoanhThuTheoLPALL]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetDoanhThuTheoLPALL]
@TenLP nvarchar(50)
as begin
select  SUM(HD.TongTien) as DoanhThu
from LOAIPHONG LP, PHONG P, NHATKI PT, CT_PHIEUTHUE CT, CTHD, HOADON HD
WHERE LP.MaLoaiPhong=P.MaLoaiPhong AND P.MaPhong=PT.MaPhong AND PT.MaCTPT=CT.MaCTPT
AND CT.MaCTPT=CTHD.MaCTPT AND CTHD.MaHD=HD.MaHD 
and TenLoaiPhong=@TenLP
group by TenLoaiPhong
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetDonGiaPhong]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetDonGiaPhong]
@MaP char(5)
as begin
select DonGia 
from PHONG P, LOAIPHONG LP
WHERE P.MaLoaiPhong = LP.MaLoaiPhong 
and MaPhong = @MaP
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetHD]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetHD]
as begin
select * from CTHD LEFT JOIN HOADON HD
ON CTHD.MaHD=HD.MaHD
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetHDTheoMaHD]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[USP_GetHDTheoMaHD]
@MaHD char(5), @CheckOut datetime
as begin
select  CT.MaCTPT, HD.MaHD, CheckOut, TongTien, status, P.MaPhong, NgayBD, NgayKT, PT.MaPhieu, SoNguoiHT
,TenLoaiKH, HeSoPhuThu
from CT_PHIEUTHUE CT, CTHD, HOADON HD, NHATKI PT, PHONG P, KHACHHANG KH, LOAIKH LKH
WHERE CT.MaCTPT=CTHD.MaCTPT AND CTHD.MaHD = HD.MaHD AND PT.MaCTPT = CT.MaCTPT and P.MaPhong=PT.MaPhong
and KH.MaKH=CT.MaKH AND KH.MaLoaiKH=LKH.MaLoaiKH
and HD.MaHD = @MaHD and HD.CheckOut=@CheckOut
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetKHTheo_SDT]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetKHTheo_SDT]
@SDT varchar(15)
as begin
select * from KHACHHANG where SDT=@SDT
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetLoaiPhong]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetLoaiPhong]
AS
BEGIN
select * from LOAIPHONG
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetMaCTPTTheoMaPhieu]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetMaCTPTTheoMaPhieu]
@MaPhieu char(5)
as begin
select MaCTPT from  CT_PHIEUTHUE
where MaPhieu=@MaPhieu
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetNameKHTheoMaPhieu]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetNameKHTheoMaPhieu]
@MaPhieu char(5)
as begin
select TenKH from KHACHHANG KH, CT_PHIEUTHUE CT
where KH.MaKH=CT.MaKH AND CT.MaCTPT =@MaPhieu
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetNewRe]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetNewRe]
as begin
SELECT TOP 1 * FROM KHACHHANG ORDER BY MaKH DESC
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetNewRe_CTPT]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetNewRe_CTPT]
as begin
SELECT TOP 1 * FROM CT_PHIEUTHUE ORDER BY MaCTPT DESC
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetNewRe_LP]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetNewRe_LP]
as begin
SELECT TOP 1 * FROM LOAIPHONG ORDER BY MaLoaiPhong DESC
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetNewRe_MaCTHD]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetNewRe_MaCTHD]
as begin
select top 1 * from CTHD ORDER BY MaCTHD DESC
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetNewRe_MaHD]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetNewRe_MaHD]
as begin
select top 1 * from HOADON ORDER BY MaHD DESC
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetNewRecord]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetNewRecord]
as begin
SELECT TOP 1 * FROM PHIEUTHUE ORDER BY MaPhieu DESC
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetPhieu]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[USP_GetPhieu]
as
begin
select TenKH, MaCTPT, NgayLap
from CT_PHIEUTHUE CT, KHACHHANG K
where K.MaKH=CT.MaKH
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GETpHONG]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GETpHONG]
AS BEGIN
select  MaPhong, TinhTrang, DonDep, SoNguoiHT, TenLoaiPhong
from LOAIPHONG LP LEFT JOIN PHONG P ON LP.MaLoaiPhong=P.MaLoaiPhong
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetPhongTheoNgay]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetPhongTheoNgay]
@NgayBD datetime , @NgayKT datetime
as begin
SELECT * FROM (PHONG LEFT JOIN PHIEUTHUE PT ON PHONG.MaPhong=PT.MaPhong)
left join LOAIPHONG LP on LP.MaLoaiPhong=PHONG.MaLoaiPhong 
except
SELECT * FROM (PHONG LEFT JOIN PHIEUTHUE PT ON PHONG.MaPhong=PT.MaPhong)
left join LOAIPHONG LP on LP.MaLoaiPhong=PHONG.MaLoaiPhong 
where( @NgayBD <= NgayKT and @NgayBD >= NgayBD)
or (@NgayKT <= NgayKT and @NgayKT >= @NgayBD)
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetPhongTrong]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetPhongTrong]
AS BEGIN
select * from PHONG P join LOAIPHONG LP on P.MaLoaiPhong=LP.MaLoaiPhong
where   P.MaPhong in
(select MaPhong from PHONG P, LOAIPHONG LP
WHERE P.MaLoaiPhong=LP.MaLoaiPhong
EXCEPT
SELECT MaPhong
from PHIEUTHUE)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetPhongTrong_Simple]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[USP_GetPhongTrong_Simple]
AS BEGIN
select * from PHONG P, LOAIPHONG L
where P.MaLoaiPhong=L.MaLoaiPhong and TinhTrang=N'Phòng trống'
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetSLPhongDaDat]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetSLPhongDaDat]
@month int, @year int
as begin
select count(NK.MaPhieu)
from NHATKI NK
where month(NgayBD) = @month and year(NgayBD)=@year
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetSoKHMax]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetSoKHMax]
@MaPhong char(5)
as begin
select SoKHMax from PHONG P, LOAIPHONG LP
WHERE P.MaLoaiPhong=LP.MaLoaiPhong AND MaPhong=@MaPhong
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetTablePhong]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetTablePhong]
as select * from PHONG
GO
/****** Object:  StoredProcedure [dbo].[USP_GetTablePhong1]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[USP_GetTablePhong1]
as select * from PHONG, LOAIPHONG where PHONG.MaLoaiPhong=LOAIPHONG.MaLoaiPhong
GO
/****** Object:  StoredProcedure [dbo].[USP_GetTablePhong2]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetTablePhong2]
as begin
select  (P.MaPhong), P.TenPhong, TinhTrang, DonDep, KH.TenKH, LP.TenLoaiPhong, 
			PT.IsDay, NgayBD, SoNguoiHT, NgayKT, CT.MaCTPT, PT.MaPhieu    
			, TenLoaiKH, HeSoPhuThu
from PHONG P left join PHIEUTHUE PT 
on  PT.MaPhong=P.MaPhong left join CT_PHIEUTHUE CT
on CT.MaCTPT=PT.MaCTPT  left join KHACHHANG KH
on KH.MaKH = CT.MaKH LEFT JOIN LOAIPHONG LP
ON LP.MaLoaiPhong = P.MaLoaiPhong
left join LOAIKH LKH on LKH.MaLoaiKH=KH.MaLoaiKH
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetTienPhong]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetTienPhong]
@MaPhong char(5)
as begin
select DonGia from PHONG P, LOAIPHONG LP
where LP.MaLoaiPhong=P.MaLoaiPhong AND MaPhong=@MaPhong
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetTyLePhuThuKhach]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetTyLePhuThuKhach]
@SoKhach int
as begin
select TyLePhuThu from PHUTHU where STT_KH=@SoKhach
end
GO
/****** Object:  StoredProcedure [dbo].[USP_INSERT_CTPT]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_INSERT_CTPT]
@TinhTrang nvarchar(50), @SoNguoi int,@MaPhong char(5), @NgayBD datetime, @NgayKT datetime,
@MaCTPT char(5), @MaPhieu char(5)
as begin
UPDATE PHONG SET TinhTrang = @TinhTrang where MaPhong = @MaPhong
insert into PHIEUTHUE values(@MaPhieu, @MaPhong, @NgayBD, @NgayKT, 1, @MaCTPT, @SoNguoi)
insert into NHATKI(MaPhong, MaCTPT, NgayBD, NgayKT, IsDay , MaPhieu, SoNguoiHT)
values(@MaPhong, @MaCTPT, @NgayBD, @NgayKT,1, @MaPhieu, @SoNguoi)

end
GO
/****** Object:  StoredProcedure [dbo].[USP_INSERT_KH]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_INSERT_KH]
@MaKH char(5), @TenKH nvarchar(50), @MaLKKH char(5), @CMND VARCHAR(20), @SDT VARCHAR(15), @DiaChi nvarchar(50),
@QT nvarchar(50), @GioiTinh nvarchar(30)
AS BEGIN
insert into KHACHHANG values(@MaKH, @TenKH, @MaLKKH, @CMND, @SDT, @DiaChi, @QT, @GioiTinh)
select * from KHACHHANG where MaKH=@MaKH
END
GO
/****** Object:  StoredProcedure [dbo].[USP_INSERT_PT]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_INSERT_PT]
@MaCTPhieu char(5) ,@MaKH char(5), @NgayLap datetime
as begin
insert into CT_PHIEUTHUE(MaCTPT, MaKH ,NgayLap) values(@MaCTPhieu, @MaKH, @NgayLap)
select * from CT_PHIEUTHUE CT
where CT.MaCTPT = @MaCTPhieu
end
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertCTPT_DP]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[USP_InsertCTPT_DP]
@MaCTPT char(5), @MaKH char(5), @NgayLap datetime
as begin
insert into CT_PHIEUTHUE values(@MaCTPT, @MaKH, @NgayLap)
select * from CT_PHIEUTHUE where MaCTPT=@MaCTPT
end
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertKHQT]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_InsertKHQT]
@TenLKH nvarchar(50), @Heso float, @Ma char(5)
as begin
insert into LOAIKH values(@Ma,@TenLKH, @Heso )
end
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertPhong]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_InsertPhong]
@MaPhong char(5) , @TenPhong nvarchar(50) , @MaLoaiP char(5) , @Dondep nvarchar(50),
@TinhTrang nvarchar(50) 
AS
BEGIN
insert into PHONG VALUES(@MaPhong, @TenPhong, @MaLoaiP, @Dondep, @TinhTrang);
end
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertPTNgO]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_InsertPTNgO]
@Tenpt nvarchar(50), @SK int, @TyLe float
as begin
insert into PHUTHU(TenPhuThu, STT_KH, TyLePhuThu) values(@Tenpt, @SK, @TyLe)
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Login]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[USP_Login] 
@username nvarchar(100), @password nvarchar(100)
as
begin
	Select * from dbo.Users where UserName = @username and Password= @password
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Loginn]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[USP_Loginn] 
@user nvarchar(100), @password nvarchar(100)
as
begin
	Select * from dbo.Users where UserName = @user and Password= @password
end
GO
/****** Object:  StoredProcedure [dbo].[USP_UPDATE_DONDEP]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_UPDATE_DONDEP] 
	@DonDep nvarchar(50),
	@MaPhong char(5)
AS
begin
update PHONG 
set DonDep = @DonDep
where MaPhong = @MaPhong
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Update_TTP]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Update_TTP]
@MaP char(5), @TT nvarchar(50), @DonDep nvarchar(50)
as begin
UPDATE PHONG SET TinhTrang=@TT, DonDep=@DonDep
--SELECT*
from PHONG P, NHATKI NK, CT_PHIEUTHUE CT
WHERE P.MaPhong=NK.MaPhong AND NK.MaCTPT=CT.MaCTPT AND NK.MaPhong= @MaP
end
GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateKH]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_UpdateKH]
@MaKH char(5), @TenKH  nvarchar(50), @CMND varchar(20), @SDT varchar(15),
@DiaChi nvarchar(50), @QT nvarchar(50), @GTinh nvarchar(30)
as begin
Update KHACHHANG
SET TenKH=@TenKH, CMND=@CMND, SDT=@SDT, DiaChi=@DiaChi, QuocTich=@QT, GioiTinh=@GTinh
where MaKH=@MaKH
end
GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateLP]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_UpdateLP]
@MaLP char(5), @TenLP nvarchar(5), @SN int, @DG int
as begin
update LOAIPHONG
set TenLoaiPhong=@TenLP, SoKHMax=@SN, DonGia=@DG
where MaLoaiPhong=@MaLP
end
GO
/****** Object:  StoredProcedure [dbo].[USP_UpdatePTNguoiO]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_UpdatePTNguoiO]
@TenPT nvarchar(50), @SK int, @TyLe float, @MaPT int
as begin
update PHUTHU set TyLePhuThu=@TyLe, STT_KH=@SK, TenPhuThu=@TenPT
where MaPhuThu=@MaPT
end
GO
/****** Object:  StoredProcedure [dbo].[USP_UpdatePTQT]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_UpdatePTQT]
@Ma char(5), @TenLKH nvarchar(50), @Heso float
as begin
update LOAIKH SET TenLoaiKH=@TenLKH, HeSoPhuThu=@Heso
where MaLoaiKH=@Ma
end
GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateTinhTrangPhong]    Script Date: 5/25/2022 8:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_UpdateTinhTrangPhong]
@MaPhong char(5), @TinhTrang nvarchar(50)
as begin
UPDATE  PHONG 
set TinhTrang =@TinhTrang -- select*
from PHONG P
WHERE P.MaPhong=@MaPhong

end
GO
USE [master]
GO
ALTER DATABASE [QLKS] SET  READ_WRITE 
GO
