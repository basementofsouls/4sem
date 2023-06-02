create database Samsonik;

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
    -- Проверка на наличие записей с недопустимой стоимостью
    IF EXISTS (SELECT 1 FROM inserted WHERE Price < 100)
    BEGIN
        RAISERROR ('Добавление товаров с ценой менее 100 запрещено.', 16, 1)
        ROLLBACK
    END
    ELSE
    BEGIN
        -- Вставка допустимых записей
        INSERT INTO Product (Image, Name, Size, Weight, Type, Date, Amount, Price, ManufacturerId, StorekeeperId)
        SELECT Image, Name, Size, Weight, Type, Date, Amount, Price, ManufacturerId, StorekeeperId
        FROM inserted;
    END
END;


drop database Samsonik;

