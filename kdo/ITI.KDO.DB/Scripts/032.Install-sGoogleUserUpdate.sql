create procedure dbo.sGoogleUserUpdate
(
	@UserId       int,
	@RefreshToken varchar(64)
)
as
begin
	update dbo.tGoogleUser set RefreshToken = @RefreshToken where UserId = @UserId;
	return 0;
end;