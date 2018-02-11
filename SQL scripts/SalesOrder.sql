---- http://www2.amk.fi/digma.fi/www.amk.fi/opintojaksot/0303011/1142845462205/1142847802793/1142848508953/1142848642251.html

use NHibernateDemo 
go
--Create table SalesOrder
--( 
--	OrderId int not null identity(1,1) primary key,
--	OrderDate datetime not null,
--	HandlingCost decimal(19,2),
--	CustomerId int FOREIGN KEY REFERENCES Customer(Id)
--)

--select * from Customer

---- Inser data

--INSERT INTO SalesOrder
--VALUES( GETDATE(), 20.58, 1),
--('20170108', 40, 1),
--( '20180101', 20, 2),
--('20180108', 50, 3),
--( '20180601', 20, 3),
--('20170308', 140, 1),
--( '20180301', 120, 2)
-- select * from SalesOrder
select * from Customer2
where Id > 3

--Create table Product
--( 
--	ProductId int not null identity(1,1) primary key,
--	ProductName varchar(200),
--	UnitPrice decimal(19,2)
--)


--Create table SalesIncludes
--( 
--	Id int not null identity(1,1) primary key,
--	OrderId int FOREIGN KEY REFERENCES SalesOrder(OrderId),
--	Quantity int not null,
--	ProductId int FOREIGN KEY REFERENCES Product(ProductId),
--	Price decimal(19,2)

--)

select * from Customer
select * from SalesOrder
select * from Product
select * from SalesIncludes

--insert into Product
--values('Pen', 2.00),
--	('Mouse', 20),
--	('Keyboard', 40),
--	('LG Monitor', 300),
--	('Head Phone', 150),
--	('USB Drive', 10),
--	('iPad', 500),
--	('HDMI cable', 25)

--insert into SalesIncludes (OrderId, ProductId, Quantity)
--values(1, 1, 20),
--(1,2,23),
--(1, 7, 2),
--(2,2,10),
--(3,2,10),
--(3,3,1),
--(4,8, 20),
--(5,5,2),
--(5,6,7),
--(5,6,6),
--(6,2,3),
--(6,4,11),
--(7,2,3)

-- update Price in SalesIncludes
--update s
--set s.Price = s.Quantity*p.UnitPrice 
--from SalesIncludes as s
--inner join Product as p 
--on s.ProductId = p.ProductId