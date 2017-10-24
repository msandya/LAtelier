create table iti.tUser
(
	UserId int identity(0,1),
	Pseudo nvarchar(150) not null,
	FirstName nvarchar(150) not null,
	LastName nvarchar(150) not null,
	Email nvarchar(150) not null,
	PhoneTel nvarchar(150)


	constraint PK_tUser primary key(UserId),
	constraint UK_tUser unique(Pseudo),
	constraint CK_tUser_Pseudo check(Pseudo <> N'')
);

insert into iti.tUser(Pseudo, FirstName, LastName, Email) 
values				 ('N'   , 'N'      , 'N'     , 'N');