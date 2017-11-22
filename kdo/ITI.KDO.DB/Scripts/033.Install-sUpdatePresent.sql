create proc dbo.sUpdatePresent
(
	@PresentName varchar(32),
	@Price float,
	@LinkPresent nvarchar(32),
	@CategoryPresentId int,
	@UserId int

)
as
begin
	update dbo.tPresent
	set PresentName = @PresentName,
		Price = @Price,
		LinkPresent = @LinkPresent,
		CategoryPresentId = @CategoryPresentId
	where UserId = @UserId;
	return 0;
end;