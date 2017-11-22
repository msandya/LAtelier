create table dbo.tUser
(
    UserId int identity(0, 1),
    FirstName nvarchar(32) not null,
    LastName  nvarchar(32) not null,
	Birthdate datetime2,
	Email nvarchar(128) not null,
	Phone nvarchar(12),
	Photo nvarchar(max)

    constraint PK_tUsers_UserId primary key(UserId),
    constraint CK_tUsers_FirstName check(FirstName <> N''),
    constraint CK_tUsers_LastName check(LastName <> N'')
);
insert into dbo.tUser(FirstName, LastName, Birthdate   , Email              , Phone       , Photo)
               values('N'      , 'N'     , '0001-01-01', 'nameEx@outlook.fr', '0712548565', 'aze');
