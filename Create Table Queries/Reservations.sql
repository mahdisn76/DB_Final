use hotel
create table Reservations(
	h_id int,
	u_id int,
	r_id int,
	enterance_date date,
	nights_count int,
	price float,
	primary key(h_id , u_id , r_id, enterance_date),
	foreign key(u_id) references Users(id),
	foreign key(r_id, h_id) references Rooms(id, h_id)
);
