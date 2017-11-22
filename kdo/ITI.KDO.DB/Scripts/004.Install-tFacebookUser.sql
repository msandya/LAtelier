create table dbo.tFacebookUser
(
	UserId       int,
    FacebookId   varchar(32),
    AccessToken  varchar(64) not null,
	
	constraint PK_tFacebookUser primary key(UserId),
    constraint FK_tFacebookUser_UserId foreign key(UserId) references dbo.tUser(UserId),
    constraint UK_tFacebookUser_FacebookbId unique(FacebookId)
);
insert into dbo.tFacebookUser(UserId, FacebookId, AccessToken)
					   values(0     , 'N'       , 'N'        );