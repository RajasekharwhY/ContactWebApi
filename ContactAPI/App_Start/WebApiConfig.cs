﻿using ContactAPI.App_Start;
using Newtonsoft.Json.Serialization;
using System.Web.Http;


namespace ContactAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
           

            // Web API configuration and services
            AutofacConfig.Register();
            
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //By default Web API return XML data  
            //We can remove this by clearing the SupportedMediaTypes option as follows  
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            //Now set the serializer setting for JsonFormatter to Indented to get Json Formatted data  
            config.Formatters.JsonFormatter.SerializerSettings.Formatting =
                Newtonsoft.Json.Formatting.Indented;

            //For converting data in Camel Case  
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
        }
    }
}
