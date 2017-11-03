create procedure SelectWithPaging
    @PageNumber int,
    @RowsPerPage int,
    @TotalRows int output
as
begin

    set nocount on;
    
    select      @TotalRows = count(*)
    from        [Table] [t]
    inner join  [OtherTable] [ot] on [t].[Id] = [ot].[Id]

    select      [t].[Name],
                [ot].[Name]
    from        [Table] [t]
    inner join  [OtherTable] [ot] on [t].[Id] = [ot].[Id]
    order by    [t].[Name], [ot].[Name]
    offset      ((@PageNumber - 1) * @RowsPerPage) rows fetch next @RowsPerPage row ONLY

end
go


		

