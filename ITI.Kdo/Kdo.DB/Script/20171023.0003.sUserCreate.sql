create proc iti.sUserCreate
(
	@Pseudo nvarchar(150),
	@FirstName nvarchar(150),
	@LastName nvarchar(150),
	@BirthDate date,
	@Tel nvarchar(10),
	@Email nvarchar(150),
	@ImageIdentity nvarchar(150)
)
as 
begin
	insert into iti.tUser(Pseudo, FirstName, LastName, BirthDate, Tel,  Email, ImageIdentity) values (@Pseudo,@FirstName,@LastName,@BirthDate,@Tel,@Email,@ImageIdentity);
	return 0;
end;