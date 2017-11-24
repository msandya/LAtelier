create procedure dbo.sPasswordUserCreate
(
	@Email nvarchar(128),
	@FirstName nvarchar(150),
	@LastName nvarchar(150),
    @Password varbinary(128)
)
as
begin
    insert into dbo.tUser(Email, FirstName, LastName) 
				   values(@Email, @FirstName, @LastName);
    declare @userId int;
    select @userId = scope_identity();
    insert into dbo.tPasswordUser(UserId,  [Password])
                           values(@userId, @Password);
    return 0;
end;
