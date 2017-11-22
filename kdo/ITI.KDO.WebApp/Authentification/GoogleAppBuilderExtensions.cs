using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.KDO.WebApp.Authentification
{
    public static class GoogleAppBuilderExtensions
    {
        public static IApplicationBuilder UseGoogleAuthentication(
            this IApplicationBuilder app, 
            Action<GoogleOptions> configuration)
        {
            GoogleOptions options = new GoogleOptions();
            configuration(options);
            app.UseGoogleAuthentication(options);
            return app;
        }
    }
}
