CREATE DATABASE QLSV3;
go
USE QLSV3;
go

CREATE TABLE LOGIN (
    email VARCHAR(30) PRIMARY KEY,
    pass VARCHAR(20)
);

CREATE TABLE SV (
    maSv VARCHAR(12) PRIMARY KEY,
    tenSv NVARCHAR(30),
    gioiTinh NVARCHAR(5),
    ngaySinh DATE,
    diaChi NVARCHAR(30),
	nienkhoa NVARCHAR(30),
    khoa NVARCHAR(30),
    lop VARCHAR(10),
    gpa FLOAT
);