create database QLWf04
use QLWf04

create table hoaqua(
    id INT PRIMARY KEY IDENTITY(1,1),
    tensp NVARCHAR(25) NOT NULL,
    dongia FLOAT NOT NULL,
    soluong INT NOT NULL,
    thanhtien float ,
);
CREATE TABLE dulieu (
    id INT PRIMARY KEY IDENTITY(1,1),
    ngay DATE NOT NULL,
    tensp NVARCHAR(255) NOT NULL,
    dongia FLOAT NOT NULL,
    soluong INT NOT NULL,
    thanhtien float,
);
