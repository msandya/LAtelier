create view dbo.vCountUserEvent
as
select
	p.UserId,
	count(p.EventId) as ParticipationEvent
	from dbo.tParticipant p group by p.UserId






		

