create procedure dbo.sGoogleUserCreate
(
	@Email	  nvarchar(64),
    @RefreshToken varchar(64)
)
as
begin
    insert into dbo.tUser(Email, FirstName, LastName) values(@Email, 'N', 'N');
	declare @userId int;
	select @userId = SCOPE_IDENTITY();
	insert into dbo.tGoogleUser(UserId, RefreshToken)
						values(@userID, @RefreshToken);
	return 0;
end;