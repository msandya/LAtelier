create procedure dbo.sUserAddGoogleToken
(
    @UserId       int,
	@RefreshToken varchar(64)
)
as
begin
    insert into dbo.tGoogleUser(UserId, RefreshToken)
                         values(@UserId, @RefreshToken);
    return 0;
end;
