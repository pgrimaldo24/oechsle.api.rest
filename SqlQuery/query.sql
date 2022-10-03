create database Employees
go

create table Employees(
id int primary key identity(1,1) not null ,
name varchar(100) null,
document_number nvarchar(10) null,
salary decimal,
age int null,
profile_image varchar(255) null
)

--"id":1,"employee_name":"Tiger Nixon","employee_salary":320800,"employee_age":61,"profile_image":""},
--{"id":2,"employee_name":"Garrett Winters","employee_salary":170750,"employee_age":63,"profile_image":""},
--{"id":3,"employee_name":"Ashton Cox","employee_salary":86000,"employee_age":66,"profile_image":""},
--{"id":4,"employee_name":"Cedric Kelly","employee_salary":433060,"employee_age":22,"profile_image":""},
--{"id":5,"employee_name":"Airi Satou","employee_salary":162700,"employee_age":33,"profile_image":""},
--{"id":6,"employee_name":"Brielle Williamson","employee_salary":372000,"employee_age":61,"profile_image":""},
--{"id":7,"employee_name":"Herrod Chandler","employee_salary":137500,"employee_age":59,"profile_image":""},
--{"id":8,"employee_name":"Rhona Davidson","employee_salary":327900,"employee_age":55,"profile_image":""},
--{"id":9,"employee_name":"Colleen Hurst","employee_salary":205500,"employee_age":39,"profile_image":""},
--{"id":10,"employee_name":"Sonya Frost","employee_salary":103600,"employee_age":23,"profile_image":""}

 insert into Employees
values ('Tiger Nixon', '72192027', 320800, 61, 'YQR4Lr4ocwXaZHj7ftFWDiPXymEKE'),
('Garrett Winters', '24543342', 170750, 63, 'i0UhmFbIGC2KggETq20qIJGKQkgOhZ3oSSa7g6wdzVLFoDnDYtNEFAUU2kvBMYk+WEghLcTjzAC5ZCIg9MX/YQR4Lr4ocwXaZHj7ftFWDiPXymEKE'),
('Ashton Cox', '55434231', 86000, 66, 'gOhZ3oSSa7g6wdzVLFoDnDYtNEFAUU2kvBMYk+WEghLcTjzAC5ZCIg9MX/YQR4Lr4ocwXaZHj7ftFWDiPXymEKE'),
('Cedric Kelly', '45353523', 433060, 22, 'zAC5ZCIg9MX/YQR4Lr4ocwXaZHj7ftFWDiPXymEKE'),
('Airi Satou', '78978675', 162700, 33, 'l6+NWfQAEAjkIR8FcIrFOQI08C8ojb6yHM99hbIlFmMTgjPbAbveQi0UhmFbIGC2KggETq20qIJGKQkgOhZ3oSSa7g6wdzVLFoDnDYtNEFAUU2kvBMYk+WEghLcTjzAC5ZCIg9MX/YQR4Lr4ocwXaZHj7ftFWDiPXymEKE'),
('Brielle Williamson', '88876789', 372000, 59, 'OQI08C8ojb6yHM99hbIlFmMTgjPbAbveQi0UhmFbIGC2KggETq20qIJGKQkgOhZ3oSSa7g6wdzVLFoDnDYtNEFAUU2kvBMYk+WEghLcTjzAC5ZCIg9MX/YQR4Lr4ocwXaZHj7ftFWDiPXymEKE'),
('Herrod Chandler', '09087658', 137500, 39, 'jb6yHM99hbIlFmMTgjPbAbveQi0UhmFbIGC2KggETq20qIJGKQkgOhZ3oSSa7g6wdzVLFoDnDYtNEFAUU2kvBMYk+WEghLcTjzAC5ZCIg9MX/YQR4Lr4ocwXaZHj7ftFWDiPXymEKE'),
('Rhona Davidson', '00342134', 327900, 23, '6wdzVLFoDnDYtNEFAUU2kvBMYk+WEghLcTjzAC5ZCIg9MX/YQR4Lr4ocwXaZHj7ftFWDiPXymEKE'),
('Colleen Hurst', '72192027', 320800, 61, 'GC2KggETq20qIJGKQkgOhZ3oSSa7g6wdzVLFoDnDYtNEFAUU2kvBMYk+WEghLcTjzAC5ZCIg9MX/YQR4Lr4ocwXaZHj7ftFWDiPXymEKE'),
('Sonya Frost', '72192027', 320800, 61, '+WEghLcTjzAC5ZCIg9MX/YQR4Lr4ocwXaZHj7ftFWDiPXymEKE')


create table KeyApp(
id int primary key identity(1,1) not null,
[user] varchar(200) null,
[password] varchar(200) null,
flag bit not null default(1)
)



insert into KeyApp([user], [password])
values('admin', '9cde1assdd-13fa-42bf-9453-6d453cf9df74')