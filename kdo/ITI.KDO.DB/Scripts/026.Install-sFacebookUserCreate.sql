create procedure dbo.sFacebookUserCreate
(
	@Email	  nvarchar(64),
    @FacebookId   varchar(100),
    @RefreshToken varchar(64)
)
as
begin
    insert into dbo.tUser(Email) values(@Email);
	declare @userId int;
	select @userId = SCOPE_IDENTITY();
	insert into dbo.tFacebookUser(UserId, FacebookId, RefreshToken)
						values(@userID, @facebookId, @RefreshToken);
	return 0;
end;