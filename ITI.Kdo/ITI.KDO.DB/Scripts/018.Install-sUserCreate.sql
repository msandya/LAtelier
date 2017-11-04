create proc dbo.sUserCreate
(
	@FirstName nvarchar(32),
	@LastName nvarchar(32),
	@Birthdate datetime2,
	@Email nvarchar(32),
	@Phone integer,
	@Photo nvarchar(32)

)
as
begin
	insert into dbo.tUser(FirstName, LastName, Birthdate, Email, Phone, Photo)
	values(@FirstName, @LastName, @Birthdate, @Email, @Phone, @Photo);
	return 0;
end






		

