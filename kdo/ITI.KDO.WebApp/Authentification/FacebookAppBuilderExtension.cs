using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.KDO.WebApp.Authentification
{
    public static class FacebookAppBuilderExtension
    {
        public static IApplicationBuilder UseFacebookAuthentication(
            this IApplicationBuilder app,
            Action<FacebookOptions> configuration)
        {
            FacebookOptions options = new FacebookOptions();
            configuration(options);
            app.UseFacebookAuthentication(options);
            return app;
        }
    }
}
