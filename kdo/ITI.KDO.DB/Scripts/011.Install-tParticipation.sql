create table dbo.tParticipation
(    
	QuantityId int not null,
	UserId int not null,
	EventId int not null,
	AmountUserPrice int not null	
	
	constraint PK_tParticipation_UserId_EventId_QuantityId primary key(UserId, EventId, QuantityId),
	constraint FK_tParticipation_QuantityId foreign key(QuantityId) references dbo.tQuantity(QuantityId),
	constraint FK_tarticipation_UserId_EventId foreign key(UserId, EventId) references dbo.tParticipant(UserId, EventId),
);