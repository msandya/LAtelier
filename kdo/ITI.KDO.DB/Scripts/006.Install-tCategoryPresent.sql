create table dbo.tCategoryPresent
(
    CategoryPresentId int identity(0, 1),
    CategoryName nvarchar(32) not null,
	Link nvarchar(32) not null

    constraint PK_tCategoryPresent_CategoryPresentId primary key(CategoryPresentId),
    constraint CK_tPresents_PresentName check(CategoryName <> N''),
);
insert into dbo.tCategoryPresent(CategoryName, Link)
               values('Informatique', 'www.azeazea');
insert into dbo.tCategoryPresent(CategoryName, Link)
               values('Electro-ménagé', 'www.azeazea');