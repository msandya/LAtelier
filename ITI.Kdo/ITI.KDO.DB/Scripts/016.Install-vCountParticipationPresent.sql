create view dbo.vCountParticipationPresent
as
select
	p.UserId,
	count(q.PresentId) as ParticipationPresent
	from dbo.tQuantity q 
	inner join dbo.tPresent p on q.PresentId = p.PresentId group by p.UserId
	having p.UserId > 0