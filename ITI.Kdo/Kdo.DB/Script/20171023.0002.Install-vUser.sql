create view iti.vUser
as
	select
		UserId = t.UserId,
		Pseudo = t.Pseudo,
		FirstName = t.FirstName,
		LastName = t.LastName,
		BirthDate = t.BirthDate,
		Email = t.Email,
		Tel = t.Tel,
		ImageIdentity = t.ImageIdentity
	from iti.tUser t
	where t.UserId <> 0;