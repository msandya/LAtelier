create procedure dbo.sPasswordUserUpdate
(
    @UserId   int,
    @Password varbinary(64)
)
as
begin
    update dbo.tPasswordUser set [Password] = @Password where UserId = @UserId;
    return 0;
end;