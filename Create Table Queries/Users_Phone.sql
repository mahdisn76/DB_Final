use hotel
Create Table User_Phone(
	id int,
	phone nvarchar(14),
	primary key (id , phone),
	Foreign  key (id) references Users(id) 
);