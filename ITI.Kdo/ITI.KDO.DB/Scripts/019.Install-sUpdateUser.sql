create proc dbo.sUpdateUser
(
    @UserId int,
	@FirstName nvarchar(32),
	@LastName nvarchar(32),
	@Birthdate datetime2,
	@Mail nvarchar(32),
	@Phone integer,
	@Photo nvarchar(32)

)
as
begin
	update dbo.tUser
	set FirstName = @FirstName,
		LastName = @LastName,
		Birthdate = @Birthdate,
		Mail = @Mail,
		Phone = @Phone,
		Photo = @Photo  
	where UserId = @UserId;
	return 0;
end;






		

