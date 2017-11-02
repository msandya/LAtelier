create table dbo.tGoogleUser
(
    
	UserId      int,
    GoogleId    int,
    AccessToken varchar(64) not null,
	
	
	constraint PK_tGoogleUser primary key(UserId),
    constraint FK_tGoogleUser_UserId foreign key(UserId) references dbo.tUser(UserId),
    constraint UK_tGoogleUser_GoogleId unique(GoogleId)
);

insert into dbo.tGoogleUser(UserId, GoogleId, AccessToken) values(0, 0, '');