create table users(id int primary key identity ,
firstname varchar(100) not null,
lastname varchar(50) not null ,email varchar(100)
unique not null, password varchar(100) not null,
created_at DATETIME not null default current_timestamp
)

insert into users(firstname,lastname,email,password) values('Inayat','khan', 
'imamu9909@gmail.com','inayat@12')

truncate table users

select * from users