create proc iti.sUserCreate
(
	@Pseudo nvarchar(150),
	@FirstName nvarchar(150),
	@LastName nvarchar(150),
	@Email nvarchar(150),
	@PhoneTel nvarchar(150)
)
as 
begin
	insert into iti.tUser(Pseudo, FirstName, LastName, Email)
	values (@Pseudo, @FirstName, @LastName, @Email);
	return 0;
end;