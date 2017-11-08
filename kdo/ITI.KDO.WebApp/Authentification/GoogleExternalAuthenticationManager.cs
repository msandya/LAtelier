using System;
using System.Collections.Generic;
using ITI.KDO.WebApp.Services;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.OAuth;
using ITI.KDO.WebApp.Authentication;
using ITI.KDO.DAL;

namespace ITI.KDO.WebApp.Authentification
{
    public class GoogleExternalAuthenticationManager : IExternalAuthenticationManager
    {
        readonly UserServices _userService;

        public GoogleExternalAuthenticationManager(UserServices userService)
        {
            _userService = userService;
        }

        public void CreateOrUpdateUser(OAuthCreatingTicketContext context)
        {
            if (context.RefreshToken != null)
            {
                _userService.CreateOrUpdateGoogleUser(context.GetEmail(),context.GetGoogleId(),context.RefreshToken);
            }
        }

        public User FindUser(OAuthCreatingTicketContext context)
        {
            return _userService.FindUser(context.GetEmail());
        }
    }
}

