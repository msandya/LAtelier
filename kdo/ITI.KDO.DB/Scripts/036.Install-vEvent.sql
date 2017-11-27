create view dbo.vEvent
as
	select
		UserId = e.UserId,
		EventId = e.EventId,
		EventName = e.EventName,
		Descriptions = e.Descriptions,
		Dates = e.Dates

	from dbo.tEvent e
