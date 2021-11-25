Create database QLCF
use QLCF
-- Tạo bảng
create table NgDatHang 
(
	MaNDH int primary key not null,
	TenNDH nvarchar(50) not null,
	DiaChi nvarchar(150)
)

create table NhaCC
(
	MaNCC int primary key not null,
	TenNCC nvarchar(50) not null,
	DiaChi nvarchar(150),
	SDT varchar(13) 
)

create table Hang
(
	MaHang int primary key not null,
	TenHang nvarchar(50) not null,
	DonVi nvarchar(10),
	DonGia numeric(15,0) not null default 0
)

create table DAT
(
	MaDDH int primary key not null,
	MaNDH int not null,
	MaNCC int not null,
	ThoiGian date not null,
	TongTien numeric(15,0) default 0,
	TinhTrang nvarchar(100),
	foreign key (MaNDH) references NgDatHang,
	foreign key (MaNCC) references NhaCC
)

create table DatChiTiet
(
	MaDDH int not null,
	MaHang int not null,
	SoLuong int not null,
	ThanhTien numeric(15,0) default 0,
	primary key (MaDDH, MaHang),
	foreign key (MaHang) references Hang,
	foreign key (MaDDH) references DAT
)

create table Ban
(	
	SoBan int primary key not null,		-- 0 là bán mang về
	TinhTrang nvarchar(20)
)

create table Mon
(
	MaMon int primary key not null,
	TenMon nvarchar(50) not null,
	DonGia numeric(15,0) default 0,
	TinhTrang nvarchar(150)
)

create table XuatHD
(
	SoHDX int primary key not null,
	SoBan int not null,
	GioVao time,
	GioRa time,
	NgayXuat date,
	TongCong numeric(15,0) default 0,
	TinhTrang int,
	foreign key (SoBan) references Ban
)

create table XuatHDChiTiet
(
	SoHDX int not null,
	MaMon int not null,
	SoLuong int not null,
	ThanhTien numeric(15,0) default 0,
	primary key (MaMon, SoHDX),
	foreign key (MaMon) references Mon,
	foreign key (SoHDX) references XuatHD
)

create table Account
(
	TenDN varchar(50) primary key ,
	TenHienThi nvarchar(50) not null default N'Nhân viên',
	Loai int default 0, -- 0: nhân viên, 1: quản lý
	MatKhau varchar(50) not null default 12345
)

-- Chèn dữ liệu
insert into Account
values ('PTTHa2201', N'Thanh Hà',1, '13012420314234138112108765216110414524878123'),	-- Mật khẩu mặc định 12345
	   ('TTKPhu0209', N'Kim Phú',1, '13012420314234138112108765216110414524878123'),
	   ('NNQAnh2508', N'Quỳnh Anh',1, '13012420314234138112108765216110414524878123'),
	   ('DNMThu0704', N'Minh Thư',1, '13012420314234138112108765216110414524878123'),
	   ('PHManh1107', N'Hùng Mạnh',0, '13012420314234138112108765216110414524878123')

select * from Account

insert into NgDatHang (MaNDH,TenNDH, DiaChi)
values (1,N'Quỳnh Anh', N'182 Sóng Hồng, Thừa Thiên Huế'),
	   (2,N'Kim Phú', N'182 Sóng Hồng, Thừa Thiên Huế'),
	   (3,N'Minh Thư', N'182 Sóng Hồng, Thừa Thiên Huế'),
	   (4,N'Hùng Mạnh', N'182 Sóng Hồng, Thừa Thiên Huế'),
	   (5,N'Thanh Hà', N'182 Sóng Hồng, Thừa Thiên Huế')

select * from NgDatHang

Insert into Mon
values	(1,N'Trà Chanh','15000'),
		(2,N'Matcha đá xay','25000'),
		(3,N'Cà phê đen', '17000'),
		(4,N'Cà phê sữa', '11000'),
		(5,N'Cà phê sữa Sài Gòn', '28000')

select * from Mon

Insert into Ban
values	(0,N'Bán mang về'), (1,N'Trống'), (2,N'Trống'), (3,N'Trống'), (4,N'Trống'), (5,N'Trống'),
							(6,N'Trống'), (7,N'Trống'), (8,N'Trống'), (9,N'Trống'), (10,N'Trống'),
							(11,N'Trống'), (12,N'Trống'), (13,N'Trống'), (14,N'Trống'), (15,N'Trống'),
							(16,N'Trống'), (17,N'Trống'), (18,N'Trống'), (19,N'Trống')
select * from Ban

Insert into NhaCC
values  (1,N'Phương Hiền', N'90 Nguyễn Tất Thành, Thừa Thiên Huế', '0964831752'),
		(2,N'Trường', N'145 Sóng Hồng, Thừa Thiên Huế', '0238642048'),
		(3,N'Hoa Thi', N'12 Nguyễn Khoa Văn, Thừa Thiên Huế', '0892764251')
select * from NhaCC


Insert into DAT(MaDDH, MaNDH, MaNCC, ThoiGian)
values  (1,1, 3, '2021/09/03'),
		(2,2, 1, '2021/09/15'),
		(3,3, 2, '2021/09/28'),
		(4,4, 2, '2021/10/01'),
		(5,5, 2, '2021/10/10')
select * from DAT

Insert into Hang
Values	(1,N'Chanh tươi', 'kg', '10000'),
		(2,N'Đá viên', 'kg', '2000'),
		(3,N'Siro', 'chai', '50000'),
		(4,N'Đường đen', 'kg', '70000'),
		(5,N'Mứt cam', 'gram', '15000'),
		(6,N'Đường Hàn quốc', 'kg', '70000'),
		(7,N'Bột matcha', 'gram', '30000'),
		(8,N'Sữa ông thọ', 'lon', '19000'),
		(9,N'CF hạt loại 1', 'kg', '16000'),
		(10,N'CF sáng tạo 2', 'gói', '54000'),
		(11,N'CF I', 'kg', '7000'),
		(12,N'CF phin', 'kg', '10000'),
		(13,N'CF legend', 'gói', '100000')
select * from Hang

Insert into DatChiTiet(MaDDH, MaHang, SoLuong)
Values  (1, 1, 3), (1, 2, 10),
		(2, 9, 10), (2, 10, 24), (2, 11, 15), (2, 12, 15), (2, 13, 12),
		(3, 3, 3), (3, 4, 1),
		(4, 5, 10), (4, 6, 1),
		(5, 7, 10), (5, 8, 5)
select * from DatChiTiet
select * from XuatHD
select * from XuatHDChiTiet
-- Trigger
go
alter trigger tgUpdateXuatHDChiTiet
on XuatHDChiTiet
after insert, update
as
begin
	declare @soHDX int, @soBan int
	select @soHDX = SoHDX from inserted 
	select @soBan = SoBan from XuatHD where SoHDX = @soHDX and TinhTrang = 0

	update Ban set TinhTrang = N'Có khách' where SoBan = @soBan and @soBan != 0

	Update XuatHDChiTiet
	set ThanhTien = (select SoLuong from inserted where XuatHDChiTiet.MaMon = inserted.MaMon) * (Select DonGia from Mon where XuatHDChiTiet.MaMon = Mon.MaMon)
	where SoHDX = @soHDX and MaMon in (select MaMon from inserted) 

	update XuatHD 
	set TongCong = (select SUM(ThanhTien) from XuatHDChiTiet where XuatHD.SoHDX = XuatHDChiTiet.SoHDX)
	where SoHDX = @soHDX and TinhTrang = 0

	declare @dem int
	set @dem = (select COUNT(*) from XuatHDChiTiet where SoHDX = @soHDX)
	if @dem = 0
		delete XuatHD where SoHDX = @soHDX
end

go
create trigger tgUpdateXuatHD
on XuatHD
after update, delete
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
		where SoBan = @soBan and @soBan != 0
	end
	else 
	begin
		update Ban
		set TinhTrang = N'Có khách'
		where SoBan = @soBan and @soBan != 0
	end
end

go
create trigger tgInsertXuatHD
on XuatHD
after insert
as
begin
	declare @soHDX int, @soBan int, @dem int
	select @soHDX = SoHDX from inserted
	select @soBan = SoBan from inserted
	select @dem = COUNT(*) from XuatHD where SoHDX = @soHDX and TinhTrang = 0

	if (@dem = 0)
	begin
		update Ban
		set TinhTrang = N'Trống'
		where SoBan = @soBan and @soBan != 0
	end
	else 
	begin
		update Ban
		set TinhTrang = N'Có khách'
		where SoBan = @soBan and @soBan != 0
	end
end

go
alter trigger tgDeleteXuatHDChiTiet
on XuatHDChiTiet
after delete
as
begin
	declare @soHDX int, @soBan int, @dem int
	select @soHDX = SoHDX from deleted
	select @soBan = SoBan from XuatHD where SoHDX = @soHDX and TinhTrang = 0
	select @dem = COUNT(SoHDX) from XuatHDChiTiet where SoHDX = @soHDX  

	if (@dem = 0)
	begin
		update Ban set TinhTrang = N'Trống' where SoBan = @soBan and @soBan != 0
		delete XuatHD where SoHDX = @soHDX
	end

	update XuatHD 
	set TongCong = (select SUM(ThanhTien) from XuatHDChiTiet where XuatHD.SoHDX = XuatHDChiTiet.SoHDX)
	where SoHDX = @soHDX and TinhTrang = 0
end

go
alter trigger tgInsUpdDelDatChiTiet
on DatChiTiet
after insert, update, delete
as
begin
		update DatChiTiet set ThanhTien = SoLuong * (select DonGia from Hang where DatChiTiet.MaHang = Hang.MaHang)

		update DAT set TongTien = (select SUM(ThanhTien) from DatChiTiet where DAT.MaDDH = DatChiTiet.MaDDH)
end
select * from DAT
-- Hàm
go
create proc spLogin @tenDN varchar(50), @matKhau varchar(50)
as
begin
	select * from Account where TenDN = @tenDN and MatKhau = @matKhau
end

go
alter function fGetMaxSoHDX()
returns int
as
begin
	declare @soHDXmax int 
	set @soHDXmax = (Select MAX(SoHDX) from XuatHD)
	if @soHDXmax is null
	begin
		set @soHDXmax = 1
	end
	return @soHDXmax
end

go
create function fGetNewMaxMaMon()
returns int
as
begin
	declare @maMonMax int 
	set @maMonMax = (Select MAX(MaMon) from Mon) + 1
	if @maMonMax is null
		set @maMonMax = 1
	return @maMonMax
end

go
create function fGetMaxSoBan()
returns int
as
begin
	declare @soBanMax int 
	set @soBanMax = (Select MAX(SoBan) from Ban)
	if @soBanMax is null
		set @soBanMax = 1
	return @soBanMax
end

go
create function fGetMaxMaDDH()
returns int
as
begin
	declare @maDDHmax int 
	set @maDDHmax = (Select MAX(MaDDH) from DAT)
	if @maDDHmax is null
		set @maDDHmax = 1
	return @maDDHmax
end

go
create function fGetNewMaxMaHang()
returns int
as
begin
	declare @maHangMax int 
	set @maHangMax = (Select MAX(MaHang) from Hang) + 1
	if @maHangMax is null
		set @maHangMax = 1
	return @maHangMax
end

go
create function fGetMaxMaNCC()
returns int
as
begin
	declare @maNCCmax int 
	set @maNCCmax = (Select MAX(MaNCC) from NhaCC)
	if @maNCCmax is null
		set @maNCCmax = 1
	return @maNCCmax
end

go
create function fGetMaxMaNDH()
returns int
as
begin
	declare @maNDHmax int 
	set @maNDHmax = (Select MAX(MaNDH) from NgDatHang)
	if @maNDHmax is null
		set @maNDHmax = 1
	return @maNDHmax
end

go
alter function fCheckSDT (@soDT varchar(13))
returns int
as
begin
	declare @kq int = -1, @i int, @kiTu varchar(13), @so varchar(13) = @soDT
	set @i = LEN(@so)
	if(@i <10)
		return @kq
	while @i>0
	begin
		set @kiTu = SUBSTRING(@so,1,1)
		set @so = SUBSTRING(@so,2,LEN(@so)-1)
		if (@kiTu not in ('0','1','2','3','4','5','6','7','8','9'))
		begin
			set @kq = -1
			break
		end
		else
			set @kq = 1
		set @i = @i - 1
	end
	return @kq
end
select dbo.fCheckSDT('084578z7483')
go
alter FUNCTION fuConvertToUnsign1 ( @strInput NVARCHAR(4000) ) 
RETURNS NVARCHAR(4000)
AS 
BEGIN 
	IF @strInput IS NULL RETURN @strInput 
	IF @strInput = '' RETURN @strInput 
	DECLARE @RT NVARCHAR(4000) 
	DECLARE @SIGN_CHARS NCHAR(136) 
	DECLARE @UNSIGN_CHARS NCHAR (136) 
	SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) 
	SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' 
	DECLARE @COUNTER int DECLARE @COUNTER1 int 
	SET @COUNTER = 1 
	WHILE (@COUNTER <=LEN(@strInput)) 
	BEGIN 
		SET @COUNTER1 = 1 
		WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) 
		BEGIN 
			IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) 
			BEGIN 
			IF @COUNTER=1 
				SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) 
			ELSE 
				SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) 
			BREAK 
			END 
			SET @COUNTER1 = @COUNTER1 +1 
		END 
		SET @COUNTER = @COUNTER +1 
	END 
	SET @strInput = replace(@strInput,' ','-') 
	RETURN @strInput 
END

select * from Mon where dbo.fuConvertToUnsign1(TenMon) like N'%' + dbo.fuConvertToUnsign1(N'ữ') + N'%'

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
alter proc spUpdateAccount @tenDN varchar(50),	@tenHT nvarchar(50), @matKhau varchar(50), @newPass varchar(50)
as
begin
	declare @isRightPass int = 0
	select @isRightPass = COUNT(*) from Account where TenDN = @tenDN and MatKhau = @matKhau

	if (@isRightPass = 1)
	begin
		if (@newPass = null or @newPass = '')
		begin
			update Account set TenHienThi = @tenHT where TenDN = @tenDN
		end
		else
		begin
			update Account set TenHienThi = @tenHT, MatKhau = @newPass where TenDN = @tenDN
		end
	end
end

go
alter proc spInsertXuatHD @soBan int
as
begin
	declare @soHDX int 
	set @soHDX = (select dbo.fGetMaxSoHDX()) + 1
	insert into XuatHD(SoHDX, SoBan, GioVao, TinhTrang)
	values (@soHDX ,@soBan, GETDATE(), 0)
end
select * from XuatHD
go
create proc spInsertXuatHDChiTiet @soHDX int, @maMon int, @soLuong int
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

go
alter proc spInsertMon @tenMon nvarchar(50), @donGia numeric(15,0), @tinhTrang nvarchar(50)
as
begin
	declare @maMon int
	set @maMon = (select dbo.fGetNewMaxMaMon())
	insert into Mon
	values (@maMon, @tenMon, @donGia, @tinhTrang)
end

go 
alter proc spInsertHang @tenHang nvarchar(50), @donVi nvarchar(20), @donGia numeric(15,0)
as
begin
	declare @maHang int
	set @maHang = (select dbo.fGetNewMaxMaHang())
	insert into Hang
	values (@maHang, @tenHang, @donVi, @donGia)
end

select * from Hang

go
alter proc spInsertNDHang @tenNDHang nvarchar(100)
as
begin
	declare @maNDHang int, @diaChi nvarchar(150)
	set @diaChi = N'182 Sóng Hồng, Thừa Thiên Huế'
	set @maNDHang = (select dbo.fGetMaxMaNDH()) + 1
	insert into NgDatHang
	values (@maNDHang, @tenNDHang, @diaChi)
end

go
alter proc spInsertNCC @tenNCC nvarchar(100), @diaChi nvarchar(200), @soDT varchar(13)
as
begin
	declare @maNCC int
	set @maNCC = (select dbo.fGetMaxMaNCC()) + 1
	insert into NhaCC
	values (@maNCC, @tenNCC, @diaChi, @soDT)	
end

select * from NhaCC
select * from DatChiTiet

go
create proc spInsertBan @soBan int, @tinhTrang nvarchar(30)
as
begin
	insert into Ban
	values(@soBan, @tinhTrang)
end
exec spInsertBan @soBan, @tinhTrang

go
alter proc spSwitchTable @soBan1 int, @soBan2 int
as
begin
	declare @soHD1 int, @soHD2 int, @tinhTrangBan1 nvarchar(50), @tinhTrangBan2 nvarchar(50)

	select @soHD1 = SoHDX from XuatHD where SoBan = @soBan1 and TinhTrang = 0
	select @soHD2 = SoHDX from XuatHD where SoBan = @soBan2 and TinhTrang = 0
	select @tinhTrangBan1 = TinhTrang from Ban where SoBan = @soBan1
	select @tinhTrangBan2 = TinhTrang from Ban where SoBan = @soBan2

	if @tinhTrangBan1 = N'Có khách' and @tinhTrangBan2 = N'Trống' -- chuyển từ bàn có khách sang bàn trống
	begin
		update XuatHD
		set SoBan = @soBan2 
		where SoHDX = @soHD1
		
		update XuatHD set TongCong = (select SUM(ThanhTien) from XuatHDChiTiet where SoHDX = @soHD1) where SoHDX = @soHD1

		update Ban
		set TinhTrang = N'Trống'
		where SoBan = @soBan1 and SoBan != 0

		update Ban
		set TinhTrang = N'Có khách'
		where SoBan = @soBan2 and SoBan != 0
	end
	else if @tinhTrangBan1 = N'Có khách' and @tinhTrangBan2 = N'Có khách' -- chuyển 2 bàn có khách
	begin
		update XuatHD set SoBan = @soBan2 where SoHDX = @soHD1
		update XuatHD set SoBan = @soBan1 where SoHDX = @soHD2
	end
	else if @tinhTrangBan1 = N'Trống' and @tinhTrangBan2 = N'Trống' -- chuyển 2 bàn trống
		return
	else if @tinhTrangBan2 = N'Bán mang về'
		return
end

go
alter proc spGopBan @soBan1 int, @soBan2 int
as
begin
	declare @soHD1 int, @soHD2 int, @tinhTrangBan1 nvarchar(50), @tinhTrangBan2 nvarchar(50)

	select @soHD1 = SoHDX from XuatHD where SoBan = @soBan1 and TinhTrang = 0
	select @soHD2 = SoHDX from XuatHD where SoBan = @soBan2 and TinhTrang = 0
	select @tinhTrangBan1 = TinhTrang from Ban where SoBan = @soBan1
	select @tinhTrangBan2 = TinhTrang from Ban where SoBan = @soBan2

	if @tinhTrangBan1 = N'Có khách' and @tinhTrangBan2 = N'Có khách'  -- gộp 2 bàn có khách
	begin
		create table Bang (SoHDX int, MaMon int, SoLuong int, ThanhTien numeric(15,0))										-- tạo bảng trung gian
		declare @hoaDon2 table (SoHDX int, SoBan int, GioVao time, GioRa time, NgayXuat date, TongCong numeric(15,0), TinhTrang int)
		insert into @hoaDon2 select * from XuatHD where SoHDX = @soHD2
		insert into Bang(MaMon, SoLuong, ThanhTien) Select MaMon, SUM(SoLuong) as soluong, SUM(ThanhTien) as thanhtien		-- ghi vào bảng trung gian 
							from XuatHDChiTiet join XuatHD on XuatHDChiTiet.SoHDX = XuatHD.SoHDX 
							where TinhTrang = 0
							group by MaMon 
		update Bang set SoHDX = @soHD2
		delete XuatHDChiTiet where SoHDX = @soHD1 or SoHDX = @soHD2
		insert into XuatHD Select * from @hoaDon2
		insert into XuatHDChiTiet Select * from Bang
		drop table Bang
		delete XuatHD where SoHDX = @soHD1
		update Ban set TinhTrang = N'Trống' where SoBan = @soBan1 and @soBan1 != 0
	end
	else 
		return
end

go
alter proc spLayDATtuThoiGian @tuNgay date, @denNgay date
as
begin
	select MaDDH, TinhTrang, TenNDH, ThoiGian, TongTien, TenNCC  from DAT join NgDatHang on DAT.MaNDH = NgDatHang.MaNDH
					  join NhaCC on DAT.MaNCC = NhaCC.MaNCC
	where ThoiGian between @tuNgay and @denNgay
end

exec spLayDATtuThoiGian '10/01/2021' , '11/30/2021'

go
alter proc spGetListBillByDate @tuNgay date, @denNgay date
as
begin
	select SoHDX, SoBan, GioVao, GioRa, NgayXuat, TongCong from XuatHD where TinhTrang = 1 and NgayXuat between @tuNgay and @denNgay
end

go
alter proc spInsertDat @tenNDH nvarchar(100), @tenNCC nvarchar(100), @thoiGian date
as
begin
	declare @maDDH int, @maNDH int, @maNCC int
	set @maDDH = (Select dbo.fGetMaxMaDDH()) + 1
	select @maNDH = MaNDH from NgDatHang where TenNDH = @tenNDH
	select @maNCC = MaNCC from NhaCC where TenNCC = @tenNCC

	insert into DAT(MaDDH, MaNDH, MaNCC, ThoiGian) values(@maDDH, @maNDH, @maNCC, @thoiGian)
end

go
alter proc spUpdateDat @maDDH int, @tenNDH nvarchar(100), @tenNCC nvarchar(100), @thoiGian date
as
begin
	declare @maNDH int, @maNCC int
	select @maNDH = MaNDH from NgDatHang where TenNDH = @tenNDH
	select @maNCC = MaNCC from NhaCC where TenNCC = @tenNCC

	update DAT set MaNDH = @maNDH, MaNCC = @maNCC, ThoiGian = @thoiGian where MaDDH = @maDDH
end
go
create proc spInsertDatChiTiet @maDDH int, @maHang int, @soLuong int
as
begin
	declare @ktrMonTrongHD char(1)
	select @ktrMonTrongHD = COUNT(*) from DatChiTiet where MaDDH = @maDDH and MaHang = @maHang 

	if (@ktrMonTrongHD > 0)
	begin
		declare @soLuongMoi int
		set @soLuongMoi = (select SoLuong from DatChiTiet where MaDDH = @maDDH and MaHang = @maHang) +@soLuong
		if (@soLuongMoi > 0)
		begin
			update DatChiTiet
			set SoLuong = @soLuongMoi
			where MaDDH = @maDDH and MaHang = @maHang 
		end
		else 
		begin
			delete DatChiTiet where MaDDH = @maDDH and MaHang = @maHang
		end
	end
	else
	begin
		insert into DatChiTiet(MaDDH, MaHang, SoLuong)
		values (@maDDH, @maHang, @soLuong)
	end
end


-- Nháp

Update DatChiTiet
set ThanhTien = SoLuong * (Select DonGia from Hang where Hang.MaHang = DatChiTiet.MaHang)

Update DAT
set TongTien = 200000 where MaDDH = 6 TongTien + (Select SUM(ThanhTien) from DatChiTiet where DatChiTiet.MaDDH = DAT.MaDDH)

select * from XuatHDChiTiet order by SoHDX
select * from XuatHD
 
select * from DatChiTiet
select * from DAT

insert into Mon values(1,N'Trà đào', 18000, N'Không bán')

select DISTINCT TinhTrang from Mon

Select TenHang, SoLuong, DonGia, ThanhTien from DatChiTiet join Hang on DatChiTiet.MaHang = Hang.MaHang where MaDDH = 1

select MaDDH, TenNDH, TenNCC, ThoiGian, TongTien from DAT join NgDatHang on DAT.MaNDH = NgDatHang.MaNDH join NhaCC on DAT.MaNCC = NhaCC.MaNCC
insert into DatChiTiet(MaDDH,MaHang,SoLuong) values(6,1,3)

go
create proc spTimKiemMon @str nvarchar(100)
as
begin
	select * from Mon where (dbo.fuConvertToUnsign1(TenMon) like N'%' + dbo.fuConvertToUnsign1(@str) + N'%' )
							or (dbo.fuConvertToUnsign1(MaMon) like N'%' + dbo.fuConvertToUnsign1(@str) + N'%' )
							or (dbo.fuConvertToUnsign1(DonGia) like N'%' + dbo.fuConvertToUnsign1(@str) + N'%' )
							or (dbo.fuConvertToUnsign1(TinhTrang) like N'%' + dbo.fuConvertToUnsign1(@str) + N'%' )
end

go
create proc spTimKiemAcc @str nvarchar(100)
as
begin
	select * from Account where (dbo.fuConvertToUnsign1(TenDN) like N'%' + dbo.fuConvertToUnsign1(@str) + N'%' )
								or (dbo.fuConvertToUnsign1(TenHienThi) like N'%' + dbo.fuConvertToUnsign1(@str) + N'%' )
								or (dbo.fuConvertToUnsign1(Loai) like N'%' + dbo.fuConvertToUnsign1(@str) + N'%' )
end

go
create proc spTimKiemHang @str nvarchar(100)
as
begin
	select * from Hang where (dbo.fuConvertToUnsign1(TenHang) like N'%' + dbo.fuConvertToUnsign1(@str) + N'%' )
								or (dbo.fuConvertToUnsign1(DonVi) like N'%' + dbo.fuConvertToUnsign1(@str) + N'%' )
								or (dbo.fuConvertToUnsign1(DonGia) like N'%' + dbo.fuConvertToUnsign1(@str) + N'%' )
end

go
create proc spTimKiemNDH @str nvarchar(100)
as
begin
	select * from NgDatHang where (dbo.fuConvertToUnsign1(TenNDH) like N'%' + dbo.fuConvertToUnsign1(@str) + N'%' )
								or (dbo.fuConvertToUnsign1(DiaChi) like N'%' + dbo.fuConvertToUnsign1(@str) + N'%' )
end

go
create proc spTimKiemNCC @str nvarchar(100)
as
begin
	select * from NhaCC where (dbo.fuConvertToUnsign1(TenNCC) like N'%' + dbo.fuConvertToUnsign1(@str) + N'%' )
								or (dbo.fuConvertToUnsign1(DiaChi) like N'%' + dbo.fuConvertToUnsign1(@str) + N'%' )
								or (dbo.fuConvertToUnsign1(SDT) like N'%' + dbo.fuConvertToUnsign1(@str) + N'%' )
end

exec spTimKiemNCC N'á'

