create view dbo.vAuthenticationProvider
as
    select usr.UserId, usr.ProviderName
    from (select UserId = u.UserId,
              ProviderName = 'KDO'
          from dbo.tPasswordUser u
          union all
          select UserId = u.UserId,
              ProviderName = 'Facebook'
          from dbo.tFacebookUser u
          union all
          select UserId = u.UserId,
              ProviderName = 'Google'
          from dbo.tGoogleUser u) usr
    where usr.UserId <> 0;