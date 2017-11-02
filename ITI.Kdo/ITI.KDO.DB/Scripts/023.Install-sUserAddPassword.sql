create procedure dbo.sUserAddPassword
(
    @UserId   int,
    @Password varbinary(128)
)
as
begin
    insert into dbo.tPasswordUser(UserId,  [Password])
                           values(@UserId, @Password);
    return 0;
end;