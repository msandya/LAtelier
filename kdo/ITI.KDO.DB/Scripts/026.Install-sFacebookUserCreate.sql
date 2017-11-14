create procedure dbo.sFacebookUserCreate
(
	@Email	     nvarchar(64),
	@Firstname   varchar(32),
	@Lastname    nvarchar(32),
    @FacebookId   varchar(32),
    @RefreshToken varchar(64)
)
as
begin
    insert into dbo.tUser(Email, Firstname, Lastname) values(@Email, @Firstname, @Lastname);
	declare @userId int;
	select @userId = SCOPE_IDENTITY();
	insert into dbo.tFacebookUser(UserId, FacebookId, RefreshToken)
						values(@userID, @facebookId, @RefreshToken);
	return 0;
end;