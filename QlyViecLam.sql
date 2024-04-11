create database QlyViecLam

use QlyViecLam

create table tblQuyenHan(
	sMaQuyen varchar(10) primary key,
	sTenQuyen nvarchar(10)
)

create table tblTaiKhoan(
	sMaTK varchar(10) primary key,
	sMaQuyen varchar(10),
	sTaiKhoan varchar(20),
	sMatKhau varchar(20),
	sTinhTrang nvarchar(20),
	foreign key (sMaQuyen) references tblQuyenHan(sMaQuyen)
)
select * from tblTaiKhoan

create table tblNhanVien
(
	sMaNV varchar(10) primary key,
	sMaTK varchar(10),
	sMaHD varchar(10),
	sTenNV nvarchar(50),
	sEmail varchar(50),
	iCCCD int,
	dNgaysinh date,
	iSDT int,
	sDiachi nvarchar(100),

	foreign key (sMaTK) references tblTaikhoan(sMaTK)

)
select * from tblNhanVien
delete tblNhanVien where sMaNV='NV1'

create table tblThongTinTuyenDung
(
	sMaTD varchar(10) primary key,
	sDoituong nvarchar(50),
	dNgayyeucau date,
	dNgayhethan date,
	sMotaTD nvarchar(500),
	iMucluong int,
	sDaingo nvarchar(500),
	sNoilamviec nvarchar(100),
	sVitri nvarchar(50)
)

insert into tblThongTinTuyenDung
values
('TD1', 'tot nghiep', '20240105', '20240707', 'mo ta td1', 10000, 'dai ngo td1', 'noi lam viec td1', 'coder'),
('TD2', 'tot nghiep', '20240505', '20240507', 'mo ta td2', 20000, 'dai ngo td2', 'noi lam viec td2', 'coder')

select * from tblThongTinTuyenDung
delete from tblThongTinTuyenDung where sMaTD = 'TD2'

create table tblThongBao
(
	sMaThongbao varchar(10) primary key,
	sMaNV varchar(10),
	dNgayThongbao date,
	sNoidung nvarchar(500),

	foreign key (sMaNV) references tblNhanVien(sMaNV)
)

create table tblHopDong
(
	sMaHD varchar(10) primary key,
	dNgayky date,
	sThoihan nvarchar(10),
	sMachucvu varchar(10),
	sMaphongban varchar(10),
	iLuong int,
)

create table tblPhongBan
(
	sMaphongban varchar(10) primary key,
	sTenphongban nvarchar(50)
)

create table tblChucVu
(
	sMachucvu varchar(10) primary key,
	sTenchucvu nvarchar(50)
)

create table tblDanhSachUngTuyen
(
	iMaDanhsach int primary key identity(1,1),
	sMaTD varchar(10),
	sMaNV varchar(10),
	foreign key (sMaTD) references tblThongTinTuyenDung(sMaTD),
	foreign key (sMaNV) references tblNhanVien(sMaNV)
)

select * from tblQuyenHan

insert into tblQuyenHan
values
(1, 'admin'),
(2, 'nhan vien')

insert into tblTaiKhoan
values
('2','2','abc','123','ok'),
('1','1','admin','1','ok')

select * from tblTaiKhoan

select * from tblNhanVien
delete tblNhanVien where sMaNV = 'NV1'

select * from tblDanhSachUngTuyen
delete from tblDanhSachUngTuyen

select * from tblNhanVien
delete from tblNhanVien

select * from tblThongTinTuyenDung

select * from tblThongBao