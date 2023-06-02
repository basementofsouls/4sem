use Samsonik;
--Производитель
--является агрегируемым объектом
create table Manufacturer(
	Id int IDENTITY(1,1) PRIMARY KEY,
	organization nvarchar(100),
	country nvarchar(100),
	address nvarchar(100),
	phone int,
);
--Кладовщик
--является агрегируемым объектом
create table Storekeeper(
	Id int IDENTITY(1,1) PRIMARY KEY,
	Experience int,
	FIO nvarchar(100),
	Adress nvarchar(100),
);
--продукт
create table Product(
	InventoryNumber int IDENTITY(1,1) PRIMARY KEY,
	Image varbinary(MAX),
	Name varchar(100) ,
	Size int,
	Weight int,
	Type varchar(100),
	Date date,
	Amount int,
	Price int,
	ManufacturerId int REFERENCES Manufacturer (Id),
	StorekeeperId int REFERENCES Storekeeper (Id),
);