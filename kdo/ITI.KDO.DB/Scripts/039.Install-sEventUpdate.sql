create procedure dbo.sEventUpdate
(
    @EventId         int,
	@UserId 		 int,
	@Dates			 datetime2,
	@Descriptions 	 nvarchar(200),
	@EventName 	     nvarchar(32)
)
as
begin
	update dbo.tEvent
	set UserId = @UserId,
		Dates = @Dates,
		Descriptions = @Descriptions,
		EventName = @EventName
	where EventId = @EventId;
	return 0;
end;






		

