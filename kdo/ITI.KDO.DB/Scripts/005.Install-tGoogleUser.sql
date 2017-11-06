create table dbo.tGoogleUser
(
    
	UserId      int,
    GoogleId    int,
    RefreshToken  varchar(64) not null,
	
	
	constraint PK_tGoogleUser primary key(UserId),
    constraint FK_tGoogleUser_UserId foreign key(UserId) references dbo.tUser(UserId),
    constraint UK_tGoogleUser_GoogleId unique(GoogleId)
);

insert into dbo.tGoogleUser(UserId, GoogleId, RefreshToken) values(0, 0, '');