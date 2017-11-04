create procedure dbo.sSelectPresentWithPagingForUserId
(
    @PageNumber int,
    @RowsPerPage int,
	@UserId int,
    @TotalRows int output
)
as
begin

    set nocount on;
    
    select      @TotalRows = count(*)
    from        dbo.tPresent [p]
    inner join  dbo.tCategoryPresent [cp] on [p].[PresentId] = [cp].[CategoryPresentId]
	where		[p].[UserId] = @UserId

    select      [p].[PresentName],
                [cp].[CategoryName]
    from        dbo.tPresent [p]
    inner join  dbo.tCategoryPresent [cp] on [p].[PresentId] = [cp].[CategoryPresentId]
	where		[p].[UserId] = @UserId
    order by    [p].[PresentName], [cp].[CategoryPresentId]
    offset      ((@PageNumber - 1) * @RowsPerPage) rows fetch next @RowsPerPage row ONLY

end
go


		

