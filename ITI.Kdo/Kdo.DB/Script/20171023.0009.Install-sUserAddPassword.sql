create procedure iti.sUserAddPassword
(
    @UserId   int,
    @Password varbinary(128)
)
as
begin
    update iti.tPasswordUser set [Password] = @Password where UserId = @UserId;
    return 0;
end;