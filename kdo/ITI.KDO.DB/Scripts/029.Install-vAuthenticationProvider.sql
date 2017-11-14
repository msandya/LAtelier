create view dbo.vAuthenticationProvider
as
	select usr.UserId, usr.ProviderName
	from (select UserId = u.UserId,
			  ProviderName = 'KDO'
		  from dbo.tPasswordUser u
		  union
		  select UserId = u.UserId,
			  ProviderName = 'Google'
		  from dbo.tGoogleUser u) usr
	where usr.UserId <> 0;

		

