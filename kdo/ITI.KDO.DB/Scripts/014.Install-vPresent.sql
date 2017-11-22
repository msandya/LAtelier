create view dbo.vPresent
as
	select
		UserId = p.UserId,
		CategoryPresentId = c.CategoryPresentId,
		CategoryName = c.CategoryName,
		Link = c.Link,
		PresentId = p.PresentId,
		PresentName = p.PresentName,
		Price = p.Price,
		LinkPresent = p.LinkPresent		

	from dbo.tPresent p
	inner join dbo.tCategoryPresent c on p.CategoryPresentId = c.CategoryPresentId