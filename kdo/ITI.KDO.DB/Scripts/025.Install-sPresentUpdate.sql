create proc dbo.sPresentUpdate
(
    @PresentId         int,
	@UserId 		   int,
	@CategoryPresentId int,
	@Price             float,
	@LinkPresent 	   nvarchar(32),
	@PresentName 	   nvarchar(32)
)
as
begin
	update dbo.tPresent
	set UserId = @UserId,
		CategoryPresentId = @CategoryPresentId,
		Price = @Price,
		LinkPresent = @LinkPresent,
		PresentName = @PresentName
	where PresentId = @PresentId;
	return 0;
end;






		

