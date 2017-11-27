create procedure dbo.sEventCreate
(
	@EventName nvarchar(32),
	@Descriptions nvarchar(200),
	@Dates datetime2,
	@UserId int
)
as
begin
	insert into dbo.tEvent(EventName, Descriptions, Dates, UserId)
	values(@EventName, @Descriptions, @Dates, @UserId);
	return 0;
end
