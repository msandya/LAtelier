using ITI.KDO.DAL;
using Microsoft.AspNetCore.Authentication.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.KDO.WebApp
{
    public interface IExternalAuthenticationManager
    {
        void CreateOrUpdateUser(OAuthCreatingTicketContext context);

        User FindUser(OAuthCreatingTicketContext context);
    }
}
