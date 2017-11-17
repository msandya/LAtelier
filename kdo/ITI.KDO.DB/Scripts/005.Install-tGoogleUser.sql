create table dbo.tGoogleUser
(    
	UserId        int,
    RefreshToken  varchar(64) not null,
	
	constraint PK_tGoogleUser primary key(UserId),
    constraint FK_tGoogleUser_UserId foreign key(UserId) references dbo.tUser(UserId),
);
insert into dbo.tGoogleUser(UserId, RefreshToken)
					 values(0     , 'N'         );