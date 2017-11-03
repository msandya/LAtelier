create proc iti.sUserCreate
(
	@Pseudo nvarchar(150),
	@FirstName nvarchar(150),
	@LastName nvarchar(150),
	@Email nvarchar(150),
	@BirthDate date,
	@PhoneTel nvarchar(150)
)
as 
begin
	insert into iti.tUser(Pseudo, FirstName, LastName, BirthDate, Email)
	values (@Pseudo, @FirstName, @LastName, @BirthDate, @Email);
	return 0;
end;