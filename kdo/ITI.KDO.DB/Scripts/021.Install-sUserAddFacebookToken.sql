create procedure dbo.sUserAddFacebookToken
(
    @UserId      int,
    @FacebookId  varchar(32),
    @AccessToken varchar(64)
)
as
begin
    insert into dbo.tFacebookUser(UserId,  FacebookId,  AccessToken)
                         values(@UserId, @FacebookId, @AccessToken);
    return 0;
end;
