using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
[assembly: Microsoft.Owin.OwinStartup(typeof(TireloAPI.Startup))]

namespace TireloAPI {
    public partial class Startup {
        public void Configuration(Owin.IAppBuilder app) {
            ConfigurationOAuth(app);
        }
    }
}