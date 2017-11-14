create procedure dbo.sGoogleUserCreate
(
	@Email	  nvarchar(64),
	@Firstname nvarchar(32),
	@Lastname nvarchar(32),
    @GoogleId   varchar(32),
    @RefreshToken varchar(64)
)
as
begin
    insert into dbo.tUser(Email, Firstname, Lastname) values(@Email, @Firstname, @Lastname);
	declare @userId int;
	select @userId = SCOPE_IDENTITY();
	insert into dbo.tGoogleUser(UserId, GoogleId, RefreshToken)
						values(@userID, @GoogleId, @RefreshToken);
	return 0;
end;