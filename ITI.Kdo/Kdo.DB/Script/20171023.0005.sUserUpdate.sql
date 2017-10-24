create proc iti.sUserUpdate
(
	@UserId int,
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
	update iti.tUser
	set Pseudo = @Pseudo,
		FirstName = @FirstName,
		LastName = @LastName,
		BirthDate = @BirthDate,
		Tel = @Tel,
		Email = @Email,
		ImageIdentity = @ImageIdentity
	where UserId = @UserId
	return 0;
end;