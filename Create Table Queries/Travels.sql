use hotel
Create Table Travels(
	v_id int,
	price float,
	start_point nvarchar(20),
	destination nvarchar(20),
	t_date date,
	t_time time,
	r_capacity int, --remainig capacity
	Primary key (v_id, t_date, t_time),
	Foreign Key (v_id) References Vehicles(id)
);