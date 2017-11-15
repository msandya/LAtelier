using ITI.KDO.DAL;
using ITI.KDO.WebApp.Authentication;
using ITI.KDO.WebApp.Services;
using Microsoft.AspNetCore.Authentication.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.KDO.WebApp.Authentification
{
    public class FacebookExternalAuthenticationManager : IExternalAuthenticationManager
    {
        readonly UserServices _userServices;

        public FacebookExternalAuthenticationManager(UserServices userServices)
        {
            _userServices = userServices;
        }

        public void CreateOrUpdateUser(OAuthCreatingTicketContext context)
        {
            if(context.AccessToken != null)
            {
                _userServices.CreateOrUpdateFacebookUser(context.GetEmail(), context.GetFacebookId(), context.AccessToken);
            }
        }

        public User FindUser(OAuthCreatingTicketContext context)
        {
            return _userServices.FindUser(context.GetEmail());
        }
    }
}
