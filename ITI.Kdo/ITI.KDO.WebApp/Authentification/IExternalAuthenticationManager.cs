using ITI.KDO.DAL;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace ITI.KDO.WebApp.Authentication
{
    public interface IExternalAuthenticationManager
    {
        void CreateOrUpdateUser( OAuthCreatingTicketContext context );

        User FindUser( OAuthCreatingTicketContext context );
    }
}