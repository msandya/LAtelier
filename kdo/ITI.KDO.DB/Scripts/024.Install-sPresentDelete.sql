create procedure dbo.sPresentDelete
(
	@PresentId int
)
as
begin
    delete from dbo.tPresent where PresentId = @PresentId;
	return 0;
end;