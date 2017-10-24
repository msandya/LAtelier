create table dbo.tUserPresent
(
    UserId int not null,
	PresentId int not null


    constraint PK_tUserPresent_UserId_PresentId primary key(UserId, PresentId),
	constraint FK_tUserPresent_UserId foreign key(UserId) references dbo.tUser(UserId),
	constraint FK_tUserPresent_PresentId foreign key(PresentId) references dbo.tPresent(PresentId),
);