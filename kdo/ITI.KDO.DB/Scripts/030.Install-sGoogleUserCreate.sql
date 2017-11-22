create procedure dbo.sGoogleUserCreate
(
	@Email	  nvarchar(64),
	@GoogleId nvarchar,
    @RefreshToken varchar(64),
	@FirstName nvarchar(32),
	@LastName nvarchar(32)
)
as
begin
    insert into dbo.tUser(Email, FirstName, LastName) values(@Email, @FirstName, @LastName);
	declare @userId int;
	select @userId = SCOPE_IDENTITY();
	insert into dbo.tGoogleUser(UserId, GoogleId, RefreshToken)
						values(@userID, @GoogleId, @RefreshToken);
	return 0;
end;