create procedure iti.sPasswordUserCreate
(
    @Pseudo nvarchar(150),
	@Email nvarchar(150),
	@FirstName nvarchar(150),
	@LastName nvarchar(150),
	@BirthDate date,
	@PhoneTel nvarchar(150),
    @Password varbinary(128)
)
as
begin
    insert into iti.tUser(Pseudo, Email, FirstName, LastName, BirthDate, PhoneTel) 
	values(@Pseudo, @Email, @FirstName, @LastName, @BirthDate, @PhoneTel);
    declare @userId int;
    select @userId = scope_identity();
    insert into iti.tPasswordUser(UserId,  [Password])
                           values(@userId, @Password);
    return 0;
end;