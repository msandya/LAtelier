create procedure dbo.sAddUserPresent
(
    @PresentName  varchar(32),
    @Price			    float,
	@LinkPresent nvarchar(32),
	@CategoryPresentId    int,
	@UserId               int
)
as
begin
    insert into dbo.tPresent(PresentName, Price, LinkPresent, CategoryPresentId, UserId)
					  values(@PresentName, @Price, @LinkPresent, @CategoryPresentId, @UserId)
end;