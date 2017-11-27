create procedure dbo.sEventDelete
(
	@EventId int
)
as
begin
    delete from dbo.tEvent where EventId = @EventId;
	return 0;
end;