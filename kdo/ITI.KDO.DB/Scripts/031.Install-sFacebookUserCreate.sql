create procedure dbo.sFacebookUserCreate
(
	@Email	  nvarchar(64),
    @FacebookId   varchar(100),
    @AccessToken varchar(64),
	@FirstName nvarchar(32),
	@LastName nvarchar(32)
)
as
begin
    insert into dbo.tUser(Email, FirstName, LastName) values(@Email, @FirstName, @LastName);
	declare @userId int;
	select @userId = SCOPE_IDENTITY();
	insert into dbo.tFacebookUser(UserId, FacebookId, AccessToken)
						values(@userID, @facebookId, @AccessToken);
	return 0;
end;