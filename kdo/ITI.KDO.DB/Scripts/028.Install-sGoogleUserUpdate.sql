create procedure dbo.sGoogleUserUpdate
(
    @GoogleId varchar(32),
    @RefreshToken varchar(64)
)
as
begin
    update dbo.tGoogleUser set RefreshToken = @RefreshToken where GoogleId = @GoogleId;
    return 0;
end;