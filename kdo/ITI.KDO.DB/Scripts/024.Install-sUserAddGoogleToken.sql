create procedure dbo.sUserAddGoogleToken
(
    @UserId       int,
    @GoogleId     varchar(32),
    @RefreshToken varchar(64)
)
as
begin
    insert into dbo.tGoogleUser(UserId, GoogleId, RefreshToken)
                         values(@UserId, @GoogleId, @RefreshToken);
    return 0;
end;
