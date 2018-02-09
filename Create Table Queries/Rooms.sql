use hotel
Create Table Rooms(
	h_id int,
	id int,
	bed_num int,
	bed_type nvarchar(15),
	price float,
	primary key (id , h_id),
	foreign key (h_id) references hotels(id)
);