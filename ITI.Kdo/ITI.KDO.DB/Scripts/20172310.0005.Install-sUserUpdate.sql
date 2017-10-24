create proc iti.sUserUpdate
(
	@UserId int,
	@Pseudo nvarchar(150),
	@FirstName nvarchar(150),
	@LastName nvarchar(150),
	@Email nvarchar(150),
	@PhoneTel nvarchar(150)
)
as
begin
	update iti.tUser
	set Pseudo = @Pseudo,
		FirstName = @FirstName,
		LastName = @LastName,
		Email = @Email,
		PhoneTel = @PhoneTel
	where UserId = @UserId
	return 0;
end;