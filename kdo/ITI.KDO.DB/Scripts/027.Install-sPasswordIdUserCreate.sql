create procedure dbo.sPasswordIdUserCreate
(
	@UserId int,
    @Password varbinary(128)
)
as
begin
    insert into dbo.tPasswordUser(UserId,  [Password])
                           values(@userId, @Password);
    return 0;
end;
