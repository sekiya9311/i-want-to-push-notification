using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;

namespace PushShitaiYoServerApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            FirebaseInitialize();
        }

        private void FirebaseInitialize()
        {
            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile(
                    @"D:\cres\push-shitai-yo-firebase-adminsdk-znj57-29412863ed.json"
                )
            });
        }
    }
}
