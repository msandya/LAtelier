create view iti.vUser
as
	select
		UserId = t.UserId,
		Pseudo = t.Pseudo,
		FirstName = t.FirstName,
		LastName = t.LastName,
		Email = t.Email,
		PhoneTel = t.PhoneTel
	from iti.tUser t
	where t.UserId <> 0;