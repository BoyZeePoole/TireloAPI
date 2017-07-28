using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using TireloAPI.Provider;

namespace TireloAPI {
    public partial class Startup {
        public void ConfigurationOAuth(IAppBuilder app) {
            //HttpConfiguration config = new HttpConfiguration();
            //GlobalConfiguration.Configure(WebApiConfig.Register);

            var oAuthServerOptions = new OAuthAuthorizationServerOptions() {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new AdAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            //            WebApiConfig.Register(config);
            //            app.UseWebApi(config);
        }
    }
}
