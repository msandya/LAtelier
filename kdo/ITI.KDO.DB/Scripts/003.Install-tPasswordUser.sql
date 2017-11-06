create table dbo.tPasswordUser
(
    
	UserId     int,
    [Password] varbinary(64) not null,
	
	
	constraint PK_tPasswordUser primary key(UserId),
    constraint FK_tPasswordUser_UserId foreign key(UserId) references dbo.tUser(UserId)

);