create database Samsonik;

use Samsonik;

--�������������
--�������� ������������ ��������
create table Manufacturer(
	Id int IDENTITY(1,1) PRIMARY KEY,
	organization nvarchar(100),
	country nvarchar(100),
	address nvarchar(100),
	phone int,
);

--���������
--�������� ������������ ��������
create table Storekeeper(
	Id int IDENTITY(1,1) PRIMARY KEY,
	Experience int,
	FIO nvarchar(100),
	Adress nvarchar(100),
);

--�������
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

CREATE PROCEDURE DeleteProductsByEvenId
AS
BEGIN
    DELETE FROM Product WHERE InventoryNumber % 2 = 0;
END


CREATE TRIGGER trg_PreventLowPriceProduct
ON Product
INSTEAD OF INSERT
AS
BEGIN
    -- �������� �� ������� ������� � ������������ ����������
    IF EXISTS (SELECT 1 FROM inserted WHERE Price < 100)
    BEGIN
        RAISERROR ('���������� ������� � ����� ����� 100 ���������.', 16, 1)
        ROLLBACK
    END
    ELSE
    BEGIN
        -- ������� ���������� �������
        INSERT INTO Product (Image, Name, Size, Weight, Type, Date, Amount, Price, ManufacturerId, StorekeeperId)
        SELECT Image, Name, Size, Weight, Type, Date, Amount, Price, ManufacturerId, StorekeeperId
        FROM inserted;
    END
END;


drop database Samsonik;

