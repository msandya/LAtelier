create table dbo.tEvent
(
    EventId int not null,
	NameEvent nvarchar(32) not null,
	Descriptions nvarchar(32) not null,
	Dates datetime2 not null,
	UserId int not null

    constraint PK_tEvent_EventId primary key(EventId),
	constraint FK_tEvent_UserId foreign key(UserId) references dbo.tUser(UserId),
);