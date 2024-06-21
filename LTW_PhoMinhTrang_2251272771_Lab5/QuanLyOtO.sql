CREATE DATABASE QLYOTO
USE QLYOTO;
CREATE TABLE HangXe(
Id nvarchar (12) primary key,
TenHang nvarchar (20) not null,
DatNuoc nvarchar (20) not null,
);
CREATE TABLE OTO(
MaXe nvarchar (12) primary key,
TenXe nvarchar (20) not null,
HangXe nvarchar (20) not null,
GiaXe int not null,
NamSX datetime,
);


CREATE TABLE KhachHang(
Id nvarchar (12) primary key,
TenKH nvarchar (20) not null,
CMT nvarchar (20) not null,
);

CREATE TABLE KhachHangXe(
Id nvarchar (12) primary key,
IdKH nvarchar (12),
IdXe nvarchar(12),
FOREIGN KEY (IdKH) REFERENCES KhachHang(Id),
FOREIGN KEY (IdXe) REFERENCES OTO(MaXe)
);
