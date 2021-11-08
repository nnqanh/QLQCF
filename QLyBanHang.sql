Create database QLCF
use QLCF
-- Tạo bảng
Create table NgDatHang 
(
	MaNDH int primary key identity(1,1),
	TenNDH nvarchar(50) not null,
	DiaChi nvarchar(150)
)

Create table NhaCC
(
	MaNCC int primary key identity(1,1),
	TenNCC nvarchar(50) not null,
	DiaChi nvarchar(150),
	SDT varchar(13) 
)

create table Hang
(
	MaHang int primary key identity(1,1),
	TenHang nvarchar(50) not null,
	DonVi nvarchar(10),
	DonGia int not null default 0
)

create table DAT
(
	MaDDH int primary key identity(1,1),
	MaNDH int not null,
	MaNCC int not null,
	ThoiGian date not null,
	TongTien int default 0,
	foreign key (MaNDH) references NgDatHang,
	foreign key (MaNCC) references NhaCC
)

create table DatChiTiet
(
	MaDDH int not null,
	MaHang int not null,
	SoLuong int not null,
	ThanhTien int default 0,
	primary key (MaDDH, MaHang),
	foreign key (MaHang) references Hang,
	foreign key (MaDDH) references DAT
)

create table Ban
(	
	SoBan int primary key identity(0,1),		-- 0 là bán mang về
	TinhTrang nvarchar(20)
)

create table Mon
(
	MaMon int primary key identity(1,1),
	TenMon nvarchar(50) not null,
	DonGia int default 0
)

create table XuatHD
(
	SoHDX int primary key identity(1,1),
	SoBan int not null,
	GioVao time,
	GioRa time,
	NgayXuat date,
	TongCong int default 0,
	TinhTrang int,
	foreign key (SoBan) references Ban
)

create table XuatHDChiTiet
(
	SoHDX int not null,
	MaMon int not null,
	SoLuong int not null,
	ThanhTien int default 0,
	primary key (MaMon, SoHDX),
	foreign key (MaMon) references Mon,
	foreign key (SoHDX) references XuatHD
)

Create table Account
(
	TenDN varchar(50) primary key ,
	TenHienThi nvarchar(50) not null default N'Nhân viên',
	MatKhau varchar(50) not null default 0,
	Loai varchar(20) default -0 -- 0: nhân viên, 1: quản lý
)

-- Chèn dữ liệu
insert into Account
values ('PTTHa2201', N'Thanh Hà', '22012001', 0),
	   ('TTKPhu0209', N'Kim Phú', '02092001', 0),
	   ('NNQAnh2508', N'Quỳnh Anh', '25082001', 0),
	   ('DNMThu0704', N'Minh Thư', '07042001', 0),
	   ('PHManh1107', N'Hùng Mạnh', '11071999',1)

insert into NgDatHang (TenNDH, DiaChi)
values (N'Quỳnh Anh', N'182 Sóng Hồng, Thừa Thiên Huế'),
	   (N'Kim Phú', N'182 Sóng Hồng, Thừa Thiên Huế'),
	   (N'Minh Thư', N'182 Sóng Hồng, Thừa Thiên Huế'),
	   (N'Hùng Mạnh', N'182 Sóng Hồng, Thừa Thiên Huế'),
	   (N'Thanh Hà', N'182 Sóng Hồng, Thừa Thiên Huế')

Insert into Mon(TenMon,DonGia)
values	(N'Trà Chanh','15000'),
		(N'Matcha đá xay','25000'),
		(N'Cà phê đen', '17000'),
		(N'Cà phê sữa', '11000'),
		(N'Cà phê sữa Sài Gòn', '28000')

Insert into Ban(TinhTrang)
values	(N'Trống'),
		(N'Trống'),
		(N'Trống'),
		(N'Trống'),
		(N'Trống'),
		(N'Trống')		

Insert into NhaCC(TenNCC, DiaChi, SDT)
values  (N'Phương Hiền', N'90 Nguyễn Tất Thành, Thừa Thiên Huế', '0964831752'),
		(N'Trường', N'145 Sóng Hồng, Thừa Thiên Huế', '0238642048'),
		(N'Hoa Thi', N'12 Nguyễn Khoa Văn, Thừa Thiên Huế', '0892764251')

Insert into DAT(MaNDH, MaNCC, ThoiGian)
values  (1, 3, '2021/09/03'),
		(2, 1, '2021/09/15'),
		(3, 2, '2021/09/28'),
		(4, 2, '2021/10/01'),
		(5, 2, '2021/10/10')

Insert into Hang(TenHang, DonVi, DonGia)
Values	(N'Chanh tươi', 'kg', '10000'),
		(N'Đá viên', 'kg', '2000'),
		(N'Siro', 'chai', '50000'),
		(N'Đường đen', 'kg', '70000'),
		(N'Mứt cam', 'gram', '15000'),
		(N'Đường Hàn quốc', 'kg', '70000'),
		(N'Bột matcha', 'gram', '30000'),
		(N'Sữa ông thọ', 'lon', '19000'),
		(N'CF hạt loại 1', 'kg', '16000'),
		(N'CF sáng tạo 2', 'gói', '54000'),
		(N'CF I', 'kg', '7000'),
		(N'CF phin', 'kg', '10000'),
		(N'CF legend', 'gói', '100000')

Insert into DatChiTiet(MaDDH, MaHang, SoLuong)
Values  (1, 1, 3), (1, 2, 10),
		(2, 9, 10), (2, 10, 24), (2, 11, 15), (2, 12, 15), (2, 13, 12),
		(3, 3, 3), (3, 4, 1),
		(4, 5, 10), (4, 6, 1),
		(5, 7, 10), (5, 8, 5)

-- Trigger
go
create trigger tgUpdateXuatHDChiTiet
on XuatHDChiTiet
after insert, update
as
begin
	declare @soHDX int, @soBan int
	select @soHDX = SoHDX from inserted 
	select @soBan = SoBan from XuatHD where SoHDX = @soHDX and TinhTrang = 0

	update Ban set TinhTrang = N'Có khách' where SoBan = @soBan

	Update XuatHDChiTiet
	set ThanhTien = (select SoLuong from inserted) * (Select DonGia from Mon where XuatHDChiTiet.MaMon = Mon.MaMon)
end

go
create trigger tgUpdateXuatHD
on XuatHD
after update
as
begin
	declare @soHDX int, @soBan int, @dem int
	select @soHDX = SoHDX from deleted 
	select @soBan = SoBan from deleted
	select @dem = COUNT(*) from XuatHD where SoHDX = @soHDX and TinhTrang = 0
	
	if (@dem = 0)
	begin
		update Ban
		set TinhTrang = N'Trống'
		where SoBan = @soBan
	end
end

-- thủ tục
go
create proc spThanhToan @soHDX int
as
begin
	Update XuatHD
	set TinhTrang = 1, GioRa = GETDATE(), NgayXuat = GETDATE()
	where SoHDX = @soHDX

	Update XuatHD
	set TongCong = TongCong + (Select SUM(ThanhTien) from XuatHDChiTiet where XuatHDChiTiet.SoHDX = XuatHD.SoHDX)

end

go
create proc spGetAccountByUserName @userName varchar(50)
as
begin
	Select * from Account where TenDN = @userName
end

go
create proc spLogin @tenDN varchar(50), @matKhau varchar(50)
as
begin
	select * from Account where TenDN = @tenDN and MatKhau = @matKhau
end

go
create proc spGetTableList
as
begin
	select * from Ban
end

go
alter proc spInsertXuatHD @soBan int
as
begin
	insert into XuatHD(SoBan, GioVao, TinhTrang)
	values (@soBan, GETDATE(), 0)
end

go
alter proc spInsertXuatHDChiTiet @soHDX int, @maMon int, @soLuong int
as
begin
	declare @ktrMonTrongHD char(1)
	select @ktrMonTrongHD = COUNT(*) from XuatHDChiTiet where SoHDX = @soHDX and MaMon = @maMon 

	if (@ktrMonTrongHD > 0)
	begin
		declare @soLuongMoi int
		set @soLuongMoi = (select SoLuong from XuatHDChiTiet where SoHDX = @soHDX and MaMon = @maMon) +@soLuong
		if (@soLuongMoi > 0)
		begin
			update XuatHDChiTiet
			set SoLuong = @soLuongMoi
			where SoHDX = @soHDX and MaMon = @maMon 
		end
		else 
		begin
			delete XuatHDChiTiet where SoHDX = @soHDX and MaMon = @maMon
		end
	end
	else
	begin
		insert into XuatHDChiTiet (SoHDX, MaMon, SoLuong)
		values (@soHDX, @maMon, @soLuong)
	end
end

-- Nháp

Update DatChiTiet
set ThanhTien = SoLuong * (Select DonGia from Hang where Hang.MaHang = DatChiTiet.MaHang)

Update DAT
set TongTien = TongTien + (Select SUM(ThanhTien) from DatChiTiet where DatChiTiet.MaDDH = DAT.MaDDH)

delete XuatHDChiTiet
delete XuatHD

select COUNT(*) from XuatHDChiTiet where SoHDX = 1 and MaMon = 9 

select * from Ban

select * from XuatHD

Select * from XuatHDChiTiet order by SoHDX

select * from Mon

select * from XuatHDChiTiet where SoHDX = 1


Select TenMon, SoLuong, DonGia, ThanhTien
from XuatHDChiTiet join XuatHD on XuatHDChiTiet.SoHDX = XuatHD.SoHDX
			join Mon on XuatHDChiTiet.MaMon = Mon.MaMon
where TinhTrang = 0 and XuatHD.SoHDX = 1 





