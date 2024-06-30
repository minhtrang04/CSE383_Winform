create database QLHT
use QLHT
create table SV(
MaSo int,
HoTen nvarchar(50),
NgaySinh datetime,
GioiTinh bit,
DiaChi nvarchar(30),
DienThoai int,
MaKhoa nchar(10),
);
create table Khoa(
MaKhoa nchar(10),
TenKhoa nchar(30),
);
create table KetQua(
MaSo int,
MaMH nchar(10),
Diem int,
);
create table Mon(
MaMH nchar(10),
TenMH nchar(30),
SoTiet int,
);