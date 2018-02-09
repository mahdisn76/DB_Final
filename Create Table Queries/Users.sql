use hotel
create table Users (
	name nvarchar(50),
	family nvarchar(50),
	id int primary key,
	age int,
	education nvarchar(10),
	sex nvarchar(6),
	city nvarchar(20)
);