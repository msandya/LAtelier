using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.OAuth;
using System.Security.Claims;

namespace ITI.KDO.WebApp.Authentification
{
    public static class OAuthCreatingTicketContextExtensions
    {
        public static string GetEmail(this OAuthCreatingTicketContext @this)
        {
            return @this.Identity.FindFirst(c => c.Type == ClaimTypes.Email).Value;
        }

        static string GetNameIdentifier(this OAuthCreatingTicketContext @this)
        {
            return @this.Identity.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;
        }
    }
}
