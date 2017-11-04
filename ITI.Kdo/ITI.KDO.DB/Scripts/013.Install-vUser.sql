create view dbo.vUser
as
	select
		UserId = u.UserId,
		FirstName = u.FirstName,
		LastName = u.LastName,
		Birthdate = u.Birthdate,
		Email = u.Email,
		Phone = u.Phone,
		Photo = u.Photo,
		[Password] = case when p.[Password] is null then 0x else p.[Password] end,
		GoogleRefreshToken = case when gl.RefreshToken is null then '' else gl.RefreshToken end,
        GoogleId = case when gl.GoogleId is null then '' else gl.GoogleId end,
		FacebookRefreshToken = case when fb.RefreshToken is null then '' else fb.RefreshToken end,
		FacebookId = case when fb.FacebookId is null then '' else fb.FacebookId end

	from dbo.tUser u
		left outer join dbo.tPasswordUser p on p.UserId = u.UserId
		left outer join dbo.tGoogleUser gl on gl.UserId = u.UserId
		left outer join dbo.tFacebookUser fb on fb.UserId = u.UserId
	where u.UserId <> 0;