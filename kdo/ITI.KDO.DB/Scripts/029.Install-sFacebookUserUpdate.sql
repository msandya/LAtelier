create procedure dbo.sFacebookUserUpdate
(
    @FacebookId varchar(32),
    @RefreshToken varchar(64)
)
as
begin
    update dbo.tFacebookUser set RefreshToken = @RefreshToken where FacebookId = @facebookId;
    return 0;
end;