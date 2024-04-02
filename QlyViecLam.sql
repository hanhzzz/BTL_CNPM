create database QlyViecLam

use QlyViecLam

create table tblQuyenHan(
	sMaQuyen varchar(10) primary key,
	sTenQuyen nvarchar(10)
)

create table tblTaiKhoan(
	sMaTK varchar(10) primary key,
	sMaNV varchar(10),
	sMaQuyen varchar(10),
	sTaiKhoan varchar(20),
	sMatKhau varchar(20),
	sTinhTrang nvarchar(20),
	foreign key (sMaQuyen) references tblQuyenHan(sMaQuyen)
)

select * from tblQuyenHan

insert into tblTaiKhoan
values
('2',NULL,'2','abc','123','ok'),
('1',NULL,'1','admin','1','ok')

select * from tblTaiKhoan