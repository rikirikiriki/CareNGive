use master
go
create database [CareNGive]
drop database [CareNGive]
go
use [CareNGive]
go
create table [Users]
(
	[UserID] int identity primary key,
	[FirstName] nvarchar(30)not null,
	[LastName] nvarchar(30)not null,
	[Email] varchar(50) not null unique,
	[Password] varchar(15)not null
	--[PasswordHash] varbinary(64)not null
)
go
create table [Categories]
(
	[CategoryID] int identity primary key,
	[ParentCategory] int foreign key references [Categories]([CategoryID]),
	[CategoryName] nvarchar(50) not null,
	[Description] nvarchar(max),
	CONSTRAINT UK_ParentCategoryName UNIQUE ([ParentCategory],[CategoryName])
)
go
create table [Type]
(
	[TypeID] int identity primary key,
	[TypeName] varchar(15)not null
)
go
create table [ContactInfo]
(
	[ContactID] int identity primary key,
	[UserID] int foreign key references [Users]([UserID])not null,
	[Phone1] varchar(25)not null,
	[Phone2] varchar(25),
	[Address] nvarchar(60),
	[Neighborhood] nvarchar(60),
	[City] nvarchar(20)not null,
	[State] nvarchar(20),
	[Country] nvarchar(20) default 'Israel' not null,
	[PostalCode] nvarchar(10)
)
go
create table [Advertisements]
(
	[AdID] int identity primary key,
	[UserID] int foreign key references [Users]([UserID])not null,
	[CategoryID] int foreign key references Categories([CategoryID])not null,
	[TypeID] int foreign key references [Type]([TypeID]) not null,
	[AdName] nvarchar(30) not null,
	[Description] nvarchar(max),
	[Quantity] smallint default '1',	
	[ContactID] int foreign key references [ContactInfo]([ContactID])not null,
	[CreationDate] datetime default getdate(),
	[Image] varchar(max)
)
go
insert into dbo.[Type] ([TypeName])
values ('Product'),('Service')
go

insert into dbo.[Categories]([ParentCategory],[CategoryName],[Description])
values
(null,'Appliances','Home Appliances, Industrial Appliances'),(null,'Clothes and Accessories','Men, Women, Boys, Girls, Baby'),
(null,'Electronics','Computers, Gadgets, Phones'),(null,'Entertainment','Board Games, Books, Electronic Games, Toys'),
(null,'Events','Bar Mitzva, Birthday, Bris, Wedding '),(null,'Food','Cooking, Groceries'),(null,'Furniture','Home, Office'),
(null,'Health','Doctors, Medicine, Vitamins'),(null,'Houseware','Bath, Bedding, Decor, Dishes'),
(null,'Professionals','Accounting, Child Care, Graphic Design, Home Improvement, Law, Technician, Tutoring'),
(null,'Real Estate','Agents, Rent, Sale'),(null,'Transportation','Car Service, Movers, Small Deliveries'),
(null,'Other','Baby Paraphernalia, School Supplies, Other')
 go
 insert into dbo.[Categories]([ParentCategory],[CategoryName],[Description])
values(1,'Home Appliances',null),(1,'Industrial Appliances',null), (2,'Men',null), (2,'Women',null), (2,'Boys',null), 
(2,'Girls',null),(2,'Baby',null),(3,'Computers',null),(3,'Gadgets',null),(3,'Phones',null),(4,'Board Games',null),
(4,'Books',null),(4,'Electronic Games',null),(4,'Toys',null),(5,'Bar Mitzva',null),(5,'Birthday',null),(5,'Bris',null),
(5,'Wedding',null),(6,'Cooking',null),(6,'Groceries',null),(7,'Home',null),(7,'Office',null),(8,'Doctors',null),
(8,'Medicine',null),(8,'Vitamins',null),(9,'Bath',null),(9,'Bedding',null),(9,'Decor',null),(9,'Dishes',null), 
(10,'Accounting',null),(10,'Child Care',null),(10,'Graphic Design',null),(10,'Home Improvement',null),(10,'Law',null),
(10,'Technician',null),(10,'Tutoring',null),(11,'Agents',null),(11,'Rent',null),(11,'Sale',null),(12,'Car Service',null), 
(12,'Movers',null), (12,'Small Deliveries',null), (13,'Baby Paraphernalia',null), (13,'School Supplies',null), 
(13,'Other',null)
go
--insert into dbo.[Categories] ([ParentCategory],[CategoryName],[Description])
--values (null,'Appliances',null),(null,'Clothes & Accessories',null),(null,'Electronics',null),
--(null,'Entertainment',null),(null,'Events',null),(null,'Food',null),(null,'Furniture',null),
--(null,'Health',null),(null,'Houseware',null),(null,'Professionals',null),
--(null,'Real Estate',null),(null,'Transportation',null),(null,'Other',null)

--insert into dbo.[Categories]([ParentCategory],[CategoryName],[Description])
--values(1,'Home Appliances',null),(1,'Indurstrial Appliances',null),(2,'Men',null),(2,'Women',null),(2,'Boys',null),
--(2,'Girl',null),(2,'Baby',null),(3,'Computers',null),(3,'Gadgets',null), (3,'Phones',null),(4,'Board Games',null), 
--(4,'Books',null),(4,'Electronics',null),(4,'Toyes',null),(5,'Bar Mitzva',null),(5,'Birthday',null),(5,'Bris',null),
--(5,'Wedding',null), (6,'Cooking',null),(6,'Groceries',null),(7,'Home',null),(7,'Office',null),(8,'Doctors',null),
--(8,'Medicine',null),(8,'Vitamins',null),(9,'Bath',null),(9,'Bedding',null),(9,'Decor',null),(9,'Dishes',null),
--(10,'Acountant',null),(10,'Child Care',null),(10,'Graphic Design',null),(10,'Home Improvement',null),(10,'Lawyer',null),
--(10,'Technition',null),(10,'Tutors',null),(11,'Car Service',null),(11,'Movers',null),(11,'Small Deliveries',null),
--(12,'Agents',null),(12,'Rent',null),(12,'Sale',null), (13,'Baby paraphernalia',null),(13,'School Supplies',null),
--(13,'Other',null)
--go


