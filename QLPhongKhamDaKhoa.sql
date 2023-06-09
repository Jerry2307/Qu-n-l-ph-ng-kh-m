USE [QLPhongKhamDaKhoa]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 11/12/2022 2:10:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[MaAdmin] [int] IDENTITY(1,1) NOT NULL,
	[TaiKhoan] [varchar](50) NULL,
	[MatKhau] [varchar](50) NULL,
	[HoTen] [nvarchar](100) NULL,
 CONSTRAINT [PK_ADmin] PRIMARY KEY CLUSTERED 
(
	[MaAdmin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BacSi]    Script Date: 11/12/2022 2:10:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BacSi](
	[MaBacSi] [int] IDENTITY(1,1) NOT NULL,
	[MaChuyenKhoa] [int] NOT NULL,
	[TenBacSi] [nvarchar](max) NULL,
	[Tuoi] [nchar](10) NULL,
	[Anh] [varchar](max) NULL,
	[SDT] [nchar](10) NULL,
	[Email] [nchar](100) NULL,
	[TrinhDo] [nvarchar](max) NULL,
	[KinhNghiem] [nvarchar](20) NULL,
 CONSTRAINT [PK_BacSi] PRIMARY KEY CLUSTERED 
(
	[MaBacSi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BenhNhan]    Script Date: 11/12/2022 2:10:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BenhNhan](
	[MaBenhNhan] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](100) NULL,
	[TenDangNhap] [varchar](50) NULL,
	[MatKhau] [varchar](50) NULL,
	[NamSinh] [nchar](10) NULL,
	[Email] [nchar](100) NULL,
	[GioiTinh] [bit] NULL,
	[Anh] [varchar](max) NULL,
	[CMND_CCCD] [nchar](10) NULL,
	[DanToc] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[SDT] [nchar](10) NULL,
 CONSTRAINT [PK_BenhNhan] PRIMARY KEY CLUSTERED 
(
	[MaBenhNhan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChuyenKhoa]    Script Date: 11/12/2022 2:10:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChuyenKhoa](
	[MaChuyenKhoa] [int] IDENTITY(1,1) NOT NULL,
	[TenChuyenKhoa] [nvarchar](max) NULL,
 CONSTRAINT [PK_ChuyenKhoa] PRIMARY KEY CLUSTERED 
(
	[MaChuyenKhoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DatLichKham]    Script Date: 11/12/2022 2:10:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DatLichKham](
	[MaDatLich] [int] IDENTITY(1,1) NOT NULL,
	[MaDichVu] [int] NOT NULL,
	[MaBenhNhan] [int] NOT NULL,
	[MaBacSi] [int] NOT NULL,
	[NgayDatLich] [datetime] NULL,
	[TrieuChung] [nvarchar](max) NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_DatLichKham] PRIMARY KEY CLUSTERED 
(
	[MaDatLich] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DichVu]    Script Date: 11/12/2022 2:10:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DichVu](
	[MaDichVu] [int] IDENTITY(1,1) NOT NULL,
	[TenDichVu] [nvarchar](max) NULL,
	[Gia] [float] NULL,
 CONSTRAINT [PK_DichVu] PRIMARY KEY CLUSTERED 
(
	[MaDichVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoSoBenhAn]    Script Date: 11/12/2022 2:10:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoSoBenhAn](
	[MaHoSo] [int] IDENTITY(1,1) NOT NULL,
	[MaBenhNhan] [int] NULL,
	[NgayNhapVien] [datetime] NULL,
	[NgayXuatVien] [datetime] NULL,
	[TomTatBenhAn] [nvarchar](max) NULL,
	[MaNguoiThan] [int] NULL,
 CONSTRAINT [PK_HoSoBenhNhan] PRIMARY KEY CLUSTERED 
(
	[MaHoSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiThan]    Script Date: 11/12/2022 2:10:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiThan](
	[MaNguoiThan] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](100) NULL,
	[NamSinh] [nchar](10) NULL,
 CONSTRAINT [PK_NguoiThan] PRIMARY KEY CLUSTERED 
(
	[MaNguoiThan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TuVan]    Script Date: 11/12/2022 2:10:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TuVan](
	[STT] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[SDT] [char](10) NULL,
	[MaBacSi] [int] NOT NULL,
	[NDTuVan] [nvarchar](max) NULL,
 CONSTRAINT [PK_TuVan] PRIMARY KEY CLUSTERED 
(
	[STT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([MaAdmin], [TaiKhoan], [MatKhau], [HoTen]) VALUES (1, N'admin', N'admin', N'Lê Anh Duy')
INSERT [dbo].[Admin] ([MaAdmin], [TaiKhoan], [MatKhau], [HoTen]) VALUES (2, N'trungnguyen', N'trungnguyen', N'Nguyễn Trung Nguyên')
SET IDENTITY_INSERT [dbo].[Admin] OFF
GO
SET IDENTITY_INSERT [dbo].[BacSi] ON 

INSERT [dbo].[BacSi] ([MaBacSi], [MaChuyenKhoa], [TenBacSi], [Tuoi], [Anh], [SDT], [Email], [TrinhDo], [KinhNghiem]) VALUES (1, 2, N'Lê Anh Duy', N'60 tuổi   ', N'TM1.jpeg', N'0977049323', N'anhduy0910dp1@gmail.com                                                                             ', N'Giáo sư', N'25 năm')
INSERT [dbo].[BacSi] ([MaBacSi], [MaChuyenKhoa], [TenBacSi], [Tuoi], [Anh], [SDT], [Email], [TrinhDo], [KinhNghiem]) VALUES (2, 2, N'Nguyễn Trung Nguyên', N'54 tuổi   ', N'TM3.jpeg', N'0273462372', N'trungnguyen01252@gmail.com                                                                          ', N'Tiến sĩ, CK II', N'25 năm')
INSERT [dbo].[BacSi] ([MaBacSi], [MaChuyenKhoa], [TenBacSi], [Tuoi], [Anh], [SDT], [Email], [TrinhDo], [KinhNghiem]) VALUES (6, 6, N'Vũ Thị Thanh Thủy', N'45        ', N'NT2.jpg', N'0977049322', N'anhduy0910dp1@gmail.com                                                                             ', N'PGS.TS.BS', N'20 năm')
INSERT [dbo].[BacSi] ([MaBacSi], [MaChuyenKhoa], [TenBacSi], [Tuoi], [Anh], [SDT], [Email], [TrinhDo], [KinhNghiem]) VALUES (7, 6, N'Nguyễn Thị Tuyết Minh', N'45        ', N'TM2.png', N'1478963250', N'ocheoo0910@gmail.com                                                                                ', N'Bác sĩ chuyên khoa II', N'20')
SET IDENTITY_INSERT [dbo].[BacSi] OFF
GO
SET IDENTITY_INSERT [dbo].[BenhNhan] ON 

INSERT [dbo].[BenhNhan] ([MaBenhNhan], [HoTen], [TenDangNhap], [MatKhau], [NamSinh], [Email], [GioiTinh], [Anh], [CMND_CCCD], [DanToc], [DiaChi], [SDT]) VALUES (1, N'Lê Anh Duy', N'leanhduy', N'123', N'2001      ', N'anhduy0910dp1@gmail.com                                                                             ', 1, N'312719765_591674379309424_1001717299347739058_n.jpg', N'123456789 ', N'Kinh', N'Quận 1', N'0987654329')
INSERT [dbo].[BenhNhan] ([MaBenhNhan], [HoTen], [TenDangNhap], [MatKhau], [NamSinh], [Email], [GioiTinh], [Anh], [CMND_CCCD], [DanToc], [DiaChi], [SDT]) VALUES (5, N'Nguyễn Trung Nguyên', N'nguyen', N'nguyen', N'1989      ', N'ocheoo0910@gmail.com                                                                                ', 1, N'!!!.jpg', N'123456789 ', N'kinh', N'Hutech', N'0977049323')
INSERT [dbo].[BenhNhan] ([MaBenhNhan], [HoTen], [TenDangNhap], [MatKhau], [NamSinh], [Email], [GioiTinh], [Anh], [CMND_CCCD], [DanToc], [DiaChi], [SDT]) VALUES (9, N'Nguyễn Thị Nu', N'nu', N'123', N'2001      ', N'anhduy0910dp1@gmail.com                                                                             ', 0, NULL, N'987654321 ', N'Kinh', N'Quận 12 ', N'0977049323')
INSERT [dbo].[BenhNhan] ([MaBenhNhan], [HoTen], [TenDangNhap], [MatKhau], [NamSinh], [Email], [GioiTinh], [Anh], [CMND_CCCD], [DanToc], [DiaChi], [SDT]) VALUES (16, N'Phan Minh Thuận', N'thuan', N'123', N'2001      ', N'anhduy0910dp1@gmail.com                                                                             ', 1, NULL, N'0123456987', N'Kinh', N'TP.HCM', N'0977049323')
SET IDENTITY_INSERT [dbo].[BenhNhan] OFF
GO
SET IDENTITY_INSERT [dbo].[ChuyenKhoa] ON 

INSERT [dbo].[ChuyenKhoa] ([MaChuyenKhoa], [TenChuyenKhoa]) VALUES (1, N'Khoa Sản')
INSERT [dbo].[ChuyenKhoa] ([MaChuyenKhoa], [TenChuyenKhoa]) VALUES (2, N'Khoa Tim mạch')
INSERT [dbo].[ChuyenKhoa] ([MaChuyenKhoa], [TenChuyenKhoa]) VALUES (3, N'Khoa Cơ xương')
INSERT [dbo].[ChuyenKhoa] ([MaChuyenKhoa], [TenChuyenKhoa]) VALUES (4, N'Khoa Răng hàm mặt')
INSERT [dbo].[ChuyenKhoa] ([MaChuyenKhoa], [TenChuyenKhoa]) VALUES (5, N'Khoa Chuẩn đoán hình ảnh')
INSERT [dbo].[ChuyenKhoa] ([MaChuyenKhoa], [TenChuyenKhoa]) VALUES (6, N'Khoa Nội tiết')
SET IDENTITY_INSERT [dbo].[ChuyenKhoa] OFF
GO
SET IDENTITY_INSERT [dbo].[DatLichKham] ON 

INSERT [dbo].[DatLichKham] ([MaDatLich], [MaDichVu], [MaBenhNhan], [MaBacSi], [NgayDatLich], [TrieuChung], [TrangThai]) VALUES (16, 5, 1, 1, CAST(N'2022-12-01T00:00:00.000' AS DateTime), N'đau dạ dày', 1)
INSERT [dbo].[DatLichKham] ([MaDatLich], [MaDichVu], [MaBenhNhan], [MaBacSi], [NgayDatLich], [TrieuChung], [TrangThai]) VALUES (17, 5, 1, 1, CAST(N'2022-11-26T10:30:00.000' AS DateTime), N'đau dạ dày', 0)
INSERT [dbo].[DatLichKham] ([MaDatLich], [MaDichVu], [MaBenhNhan], [MaBacSi], [NgayDatLich], [TrieuChung], [TrangThai]) VALUES (18, 5, 1, 1, CAST(N'2022-12-03T12:36:00.000' AS DateTime), N'đau dạ dày', 0)
INSERT [dbo].[DatLichKham] ([MaDatLich], [MaDichVu], [MaBenhNhan], [MaBacSi], [NgayDatLich], [TrieuChung], [TrangThai]) VALUES (20, 5, 1, 1, CAST(N'2022-11-26T23:50:00.000' AS DateTime), N'đau dạ dày', 1)
INSERT [dbo].[DatLichKham] ([MaDatLich], [MaDichVu], [MaBenhNhan], [MaBacSi], [NgayDatLich], [TrieuChung], [TrangThai]) VALUES (21, 5, 1, 1, CAST(N'2022-12-03T22:51:00.000' AS DateTime), N'đau dạ dày', 0)
INSERT [dbo].[DatLichKham] ([MaDatLich], [MaDichVu], [MaBenhNhan], [MaBacSi], [NgayDatLich], [TrieuChung], [TrangThai]) VALUES (22, 5, 1, 1, CAST(N'2022-12-02T21:56:00.000' AS DateTime), N'đau dạ dày', 1)
INSERT [dbo].[DatLichKham] ([MaDatLich], [MaDichVu], [MaBenhNhan], [MaBacSi], [NgayDatLich], [TrieuChung], [TrangThai]) VALUES (23, 5, 1, 1, CAST(N'2022-12-04T22:58:00.000' AS DateTime), N'đau dạ dày', 0)
INSERT [dbo].[DatLichKham] ([MaDatLich], [MaDichVu], [MaBenhNhan], [MaBacSi], [NgayDatLich], [TrieuChung], [TrangThai]) VALUES (24, 5, 1, 1, CAST(N'2022-11-26T12:13:00.000' AS DateTime), N'đau dạ dày', 1)
INSERT [dbo].[DatLichKham] ([MaDatLich], [MaDichVu], [MaBenhNhan], [MaBacSi], [NgayDatLich], [TrieuChung], [TrangThai]) VALUES (25, 5, 1, 1, CAST(N'2022-12-03T12:16:00.000' AS DateTime), N'xxxxxxxxxxxxxxxx', 1)
INSERT [dbo].[DatLichKham] ([MaDatLich], [MaDichVu], [MaBenhNhan], [MaBacSi], [NgayDatLich], [TrieuChung], [TrangThai]) VALUES (26, 7, 1, 1, CAST(N'2022-12-02T19:35:00.000' AS DateTime), N'đau dạ dày', 1)
INSERT [dbo].[DatLichKham] ([MaDatLich], [MaDichVu], [MaBenhNhan], [MaBacSi], [NgayDatLich], [TrieuChung], [TrangThai]) VALUES (27, 7, 1, 1, CAST(N'2022-12-01T13:41:00.000' AS DateTime), N'đau dạ dày', 1)
INSERT [dbo].[DatLichKham] ([MaDatLich], [MaDichVu], [MaBenhNhan], [MaBacSi], [NgayDatLich], [TrieuChung], [TrangThai]) VALUES (28, 3, 1, 1, CAST(N'2022-12-10T16:37:00.000' AS DateTime), N'đau dạ dày', 1)
INSERT [dbo].[DatLichKham] ([MaDatLich], [MaDichVu], [MaBenhNhan], [MaBacSi], [NgayDatLich], [TrieuChung], [TrangThai]) VALUES (29, 2, 1, 1, CAST(N'2022-11-26T16:39:00.000' AS DateTime), N'đau dạ dày', 1)
INSERT [dbo].[DatLichKham] ([MaDatLich], [MaDichVu], [MaBenhNhan], [MaBacSi], [NgayDatLich], [TrieuChung], [TrangThai]) VALUES (30, 3, 5, 1, CAST(N'2022-11-24T16:18:00.000' AS DateTime), N'Đau mắt', 0)
INSERT [dbo].[DatLichKham] ([MaDatLich], [MaDichVu], [MaBenhNhan], [MaBacSi], [NgayDatLich], [TrieuChung], [TrangThai]) VALUES (31, 5, 1, 1, CAST(N'2022-11-11T20:52:00.000' AS DateTime), N'đau dạ dày', 0)
INSERT [dbo].[DatLichKham] ([MaDatLich], [MaDichVu], [MaBenhNhan], [MaBacSi], [NgayDatLich], [TrieuChung], [TrangThai]) VALUES (32, 5, 1, 2, CAST(N'2022-11-20T12:51:00.000' AS DateTime), N'đau dạ dày', 0)
INSERT [dbo].[DatLichKham] ([MaDatLich], [MaDichVu], [MaBenhNhan], [MaBacSi], [NgayDatLich], [TrieuChung], [TrangThai]) VALUES (33, 5, 1, 1, CAST(N'2022-11-30T15:08:00.000' AS DateTime), N'đau dạ dày', 0)
INSERT [dbo].[DatLichKham] ([MaDatLich], [MaDichVu], [MaBenhNhan], [MaBacSi], [NgayDatLich], [TrieuChung], [TrangThai]) VALUES (34, 5, 1, 1, CAST(N'2022-11-27T00:00:00.000' AS DateTime), N'đau dạ dày', 0)
INSERT [dbo].[DatLichKham] ([MaDatLich], [MaDichVu], [MaBenhNhan], [MaBacSi], [NgayDatLich], [TrieuChung], [TrangThai]) VALUES (35, 7, 1, 1, CAST(N'2022-12-10T08:52:00.000' AS DateTime), N'abcxzy', NULL)
INSERT [dbo].[DatLichKham] ([MaDatLich], [MaDichVu], [MaBenhNhan], [MaBacSi], [NgayDatLich], [TrieuChung], [TrangThai]) VALUES (36, 2, 1, 1, CAST(N'2022-12-16T13:00:00.000' AS DateTime), N'Nhứt đầu, chóng mặt', NULL)
SET IDENTITY_INSERT [dbo].[DatLichKham] OFF
GO
SET IDENTITY_INSERT [dbo].[DichVu] ON 

INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [Gia]) VALUES (1, N'Khám Cấp Cứu', 250000)
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [Gia]) VALUES (2, N'Khám RHM', 150000)
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [Gia]) VALUES (3, N'Khám Mắt', 150000)
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [Gia]) VALUES (4, N'Khám Thai', 200000)
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [Gia]) VALUES (5, N'Gói khám – Trẻ em từ 0 đến 6 tuổi', 600000)
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [Gia]) VALUES (6, N'Gói khám – Trẻ em từ 7 đến 15 tuổi', 900000)
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [Gia]) VALUES (7, N'Gói khám tổng quát – Thiếu niên từ 16 đến dưới 18 ', 2036000)
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [Gia]) VALUES (8, N'Khám khớp', 250000)
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [Gia]) VALUES (9, N'Khám Tổng Quát', 30000)
SET IDENTITY_INSERT [dbo].[DichVu] OFF
GO
SET IDENTITY_INSERT [dbo].[HoSoBenhAn] ON 

INSERT [dbo].[HoSoBenhAn] ([MaHoSo], [MaBenhNhan], [NgayNhapVien], [NgayXuatVien], [TomTatBenhAn], [MaNguoiThan]) VALUES (1, 1, CAST(N'2022-11-11T00:00:00.000' AS DateTime), CAST(N'2022-11-19T00:00:00.000' AS DateTime), N'a', 2)
SET IDENTITY_INSERT [dbo].[HoSoBenhAn] OFF
GO
SET IDENTITY_INSERT [dbo].[NguoiThan] ON 

INSERT [dbo].[NguoiThan] ([MaNguoiThan], [HoTen], [NamSinh]) VALUES (2, N'Nguyễn Văn A', N'1978      ')
SET IDENTITY_INSERT [dbo].[NguoiThan] OFF
GO
SET IDENTITY_INSERT [dbo].[TuVan] ON 

INSERT [dbo].[TuVan] ([STT], [HoTen], [Email], [SDT], [MaBacSi], [NDTuVan]) VALUES (1, N'Lê Anh Duy', N'anhduy0910dp1@gmail.com', N'0977049323', 1, N'maaaa')
INSERT [dbo].[TuVan] ([STT], [HoTen], [Email], [SDT], [MaBacSi], [NDTuVan]) VALUES (2, N'Lê Anh Duy', N'anhduy0910dp1@gmail.com', N'0977049323', 1, N'abc')
INSERT [dbo].[TuVan] ([STT], [HoTen], [Email], [SDT], [MaBacSi], [NDTuVan]) VALUES (3, N'Lê Anh Duy', N'anhduy0910dp1@gmail.com', N'0977049323', 2, N'maaaa')
INSERT [dbo].[TuVan] ([STT], [HoTen], [Email], [SDT], [MaBacSi], [NDTuVan]) VALUES (4, N'Lê Anh Duy', N'anhduy0910dp1@gmail.com', N'0977049323', 2, N'maaaa')
INSERT [dbo].[TuVan] ([STT], [HoTen], [Email], [SDT], [MaBacSi], [NDTuVan]) VALUES (5, N'Lê Anh Duy', N'anhduy0910dp1@gmail.com', N'0977049323', 2, N'maaaa')
INSERT [dbo].[TuVan] ([STT], [HoTen], [Email], [SDT], [MaBacSi], [NDTuVan]) VALUES (6, N'Lê Anh Duy', N'anhduy0910dp1@gmail.com', N'0977049323', 2, N'maaaa')
INSERT [dbo].[TuVan] ([STT], [HoTen], [Email], [SDT], [MaBacSi], [NDTuVan]) VALUES (7, N'Phan Minh Thuận', N'trungnguyen01252@gmail.com', N'0977049323', 6, N'Cách trị bệnh trĩ')
INSERT [dbo].[TuVan] ([STT], [HoTen], [Email], [SDT], [MaBacSi], [NDTuVan]) VALUES (8, N'Phan Minh Thuận', N'trungnguyen01252@gmail.com', N'0977049323', 1, N'đau tim')
SET IDENTITY_INSERT [dbo].[TuVan] OFF
GO
ALTER TABLE [dbo].[BacSi]  WITH CHECK ADD  CONSTRAINT [FK_BacSi_ChuyenKhoa] FOREIGN KEY([MaChuyenKhoa])
REFERENCES [dbo].[ChuyenKhoa] ([MaChuyenKhoa])
GO
ALTER TABLE [dbo].[BacSi] CHECK CONSTRAINT [FK_BacSi_ChuyenKhoa]
GO
ALTER TABLE [dbo].[DatLichKham]  WITH CHECK ADD  CONSTRAINT [FK_DatLichKham_BacSi] FOREIGN KEY([MaBacSi])
REFERENCES [dbo].[BacSi] ([MaBacSi])
GO
ALTER TABLE [dbo].[DatLichKham] CHECK CONSTRAINT [FK_DatLichKham_BacSi]
GO
ALTER TABLE [dbo].[DatLichKham]  WITH CHECK ADD  CONSTRAINT [FK_DatLichKham_BenhNhan] FOREIGN KEY([MaBenhNhan])
REFERENCES [dbo].[BenhNhan] ([MaBenhNhan])
GO
ALTER TABLE [dbo].[DatLichKham] CHECK CONSTRAINT [FK_DatLichKham_BenhNhan]
GO
ALTER TABLE [dbo].[DatLichKham]  WITH CHECK ADD  CONSTRAINT [FK_DatLichKham_DichVu] FOREIGN KEY([MaDichVu])
REFERENCES [dbo].[DichVu] ([MaDichVu])
GO
ALTER TABLE [dbo].[DatLichKham] CHECK CONSTRAINT [FK_DatLichKham_DichVu]
GO
ALTER TABLE [dbo].[HoSoBenhAn]  WITH CHECK ADD  CONSTRAINT [FK_HoSoBenhNhan_BenhNhan] FOREIGN KEY([MaBenhNhan])
REFERENCES [dbo].[BenhNhan] ([MaBenhNhan])
GO
ALTER TABLE [dbo].[HoSoBenhAn] CHECK CONSTRAINT [FK_HoSoBenhNhan_BenhNhan]
GO
ALTER TABLE [dbo].[HoSoBenhAn]  WITH CHECK ADD  CONSTRAINT [FK_HoSoBenhNhan_NguoiThan] FOREIGN KEY([MaNguoiThan])
REFERENCES [dbo].[NguoiThan] ([MaNguoiThan])
GO
ALTER TABLE [dbo].[HoSoBenhAn] CHECK CONSTRAINT [FK_HoSoBenhNhan_NguoiThan]
GO
ALTER TABLE [dbo].[TuVan]  WITH CHECK ADD  CONSTRAINT [FK_TuVan_BacSi] FOREIGN KEY([MaBacSi])
REFERENCES [dbo].[BacSi] ([MaBacSi])
GO
ALTER TABLE [dbo].[TuVan] CHECK CONSTRAINT [FK_TuVan_BacSi]
GO
