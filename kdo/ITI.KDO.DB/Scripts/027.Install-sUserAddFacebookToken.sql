create procedure dbo.sUserAddFacebookToken
(
    @UserId       int,
	@Firstname nvarchar(32),
	@Lastname nvarchar(32),
    @FacebookId     varchar(32),
    @RefreshToken varchar(64)
)
as
begin
    insert into dbo.tFacebookUser(UserId,  FacebookId,  RefreshToken)
                         values(@UserId, @FacebookId, @RefreshToken);
    return 0;
end;
