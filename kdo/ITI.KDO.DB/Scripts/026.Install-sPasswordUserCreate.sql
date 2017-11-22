create procedure dbo.sPasswordUserCreate
(
	@Email nvarchar(128),
	@FirstName nvarchar(150),
	@LastName nvarchar(150),
	@Birthdate date,
	@Phone nvarchar(12),
    @Password varbinary(128),
	@Photo nvarchar(150)
)
as
begin
    insert into dbo.tUser(Email, FirstName, LastName, Birthdate, Phone, Photo) 
				   values(@Email, @FirstName, @LastName, @Birthdate, @Phone,@Photo);
    declare @userId int;
    select @userId = scope_identity();
    insert into dbo.tPasswordUser(UserId,  [Password])
                           values(@userId, @Password);
    return 0;
end;
