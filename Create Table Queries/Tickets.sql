use hotel
Create Table Tickets(
	u_id int,
	v_id int,
	t_date date,
	t_time time
	--primary key(u_id, v_id, t_date, t_time),
	foreign key(u_id) references users(id),
	foreign key(v_id, t_date, t_time) references travels
);