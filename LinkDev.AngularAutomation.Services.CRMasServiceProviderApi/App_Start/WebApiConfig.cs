using LinkDev.AngularAutomation.Services.CRMasServiceProviderApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http.Headers;

namespace LinkDev.AngularAutomation.Services.CRMasServiceProviderApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MessageHandlers.Add(new CorsHandler());
            // To do : Set at global place ex web.config 

            // Web API configuration and services 
            //config.EnableCors();
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
