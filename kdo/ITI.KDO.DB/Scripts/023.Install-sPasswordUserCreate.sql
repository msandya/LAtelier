create procedure dbo.sPasswordUserCreate
(
	@Mail nvarchar(150),
	@FirstName nvarchar(150),
	@LastName nvarchar(150),
	@Birthdate date,
	@Phone nvarchar(150),
    @Password varbinary(128),
	@Photo nvarchar(150)
)
as
begin
    insert into dbo.tUser(Mail, FirstName, LastName, Birthdate, Phone, Photo) 
	values( @Mail, @FirstName, @LastName, @Birthdate, @Phone,@Photo);
    declare @userId int;
    select @userId = scope_identity();
    insert into dbo.tPasswordUser(UserId,  [Password])
                           values(@userId, @Password);
    return 0;
end;