using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;

namespace Books.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // xml serializer
            config.Formatters.XmlFormatter.UseXmlSerializer = true;

            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;

            json.SerializerSettings.Formatting = Formatting.Indented;

        }
    }
}
