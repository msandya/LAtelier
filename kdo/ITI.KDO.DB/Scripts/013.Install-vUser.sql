create view dbo.vUser
as
	select
		UserId = u.UserId,
		FirstName = u.FirstName,
		LastName = u.LastName,
		Birthdate = u.Birthdate,
		Mail = u.Mail,
		Phone = u.Phone,
		Photo = u.Photo
	from dbo.tUser u
	where u.UserId <> 0;