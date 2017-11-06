create table dbo.tParticipant
(
	UserId int not null,
	EventId int not null,
	ParticipantType bit not null
	
    constraint PK_tParticipant_UserId_QuantityId primary key(UserId, EventId),
	constraint FK_tParticipant_EventId foreign key(EventId) references dbo.tEvent(EventId),
	constraint FK_tParticipant_UserId foreign key(UserId) references dbo.tUser(UserId),
);