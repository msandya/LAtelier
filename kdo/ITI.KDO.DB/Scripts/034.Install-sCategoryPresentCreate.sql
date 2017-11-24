create proc dbo.sCategoryPresentCreate
(
	@CategoryName nvarchar(32),
	@Link nvarchar(32)

)
as
begin
	insert into dbo.tCategoryPresent(CategoryName, Link)
	values(@CategoryName, @Link);
	return scope_identity();
end;