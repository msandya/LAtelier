create procedure dbo.sDeletePresent
(
	@UserId int,
	@PresentId int
)
as
begin
	delete from dbo.tPresent where PresentId = @presentId and UserId = @UserId;
	return 0;

	end;