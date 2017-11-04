create procedure dbo.sUserAddPassword
(
    @UserId   int,
    @Password varbinary(64)
)
as
begin
    insert into dbo.tPasswordUser(UserId,  [Password])
                           values(@UserId, @Password);
    return 0;
end;