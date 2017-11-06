create table dbo.tUser
(
    UserId int identity(0, 1),
    FirstName nvarchar(32) not null,
    LastName  nvarchar(32) not null,
	Birthdate datetime2 not null,
	Email nvarchar(32) not null,
	Phone int not null,
	Photo nvarchar(max) not null

    constraint PK_tUsers_UserId primary key(UserId),
    constraint UK_tUsers_FirstName_LastName unique(FirstName, LastName),
    constraint CK_tUsers_FirstName check(FirstName <> N''),
    constraint CK_tUsers_LastName check(LastName <> N'')
);

insert into dbo.tUser(FirstName, LastName, Birthdate, Email, Phone, Photo)
                  values('John', 'Doe', '0001-01-01', 'jiji@outlook.fr', 0712548565, 'aze');