﻿CREATE DATABASE QLYCAFE
USE QLYCAFE

create table DATHANG(
MADH NVARCHAR(10),
SOBAN NVARCHAR(20),
DOUONG NVARCHAR(20),
SOLUONG INT,
GIA INT ,
NGAY DATE,
);
INSERT INTO DATHANG VALUES (N'01',N'Bàn 1',N'Soda Chanh',1,10000,'03-03-2024');
INSERT INTO DATHANG VALUES  (N'02',N'Bàn 2',N'Matcha Latte',1,28000,'03-12-2024');
INSERT INTO DATHANG VALUES (N'03',N'Bàn 3',N'Bạc Xỉu',3,20000,'03-16-2024');
INSERT INTO DATHANG VALUES (N'04',N'Bàn 4',N'Trà Nhài',1,20000,'04-22-2024');
INSERT INTO DATHANG VALUES (N'05',N'Bàn 5',N'Trà Oolong',2,22000,'04-25-2024');
INSERT INTO DATHANG VALUES (N'06',N'Bàn 6',N'Blueberry Yogurt',2,22000,'05-05-2024');
INSERT INTO DATHANG VALUES (N'07',N'Bàn 7',N'Choco Latte',3,28000,'05-15-2024');
INSERT INTO DATHANG VALUES (N'08',N'Bàn 8',N'Trà Mận',2,20000,'05-15-2024');
INSERT INTO DATHANG VALUES (N'09',N'Bàn 9',N'Trà Nhài',2,20000,'04-18-2024');
INSERT INTO DATHANG VALUES (N'10',N'Bàn 10',N'Black Coffee',1,18000,'05-20-2024');