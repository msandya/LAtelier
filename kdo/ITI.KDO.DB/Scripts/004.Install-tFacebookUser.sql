create table dbo.tFacebookUser
(
	UserId      int,
    FacebookId    int,
    RefreshToken varchar(64) not null,
	
	constraint PK_tFacebookUser primary key(UserId),
    constraint FK_tFacebookUser_UserId foreign key(UserId) references dbo.tUser(UserId),
    constraint UK_tFacebookUser_FacebookbId unique(FacebookId)
);