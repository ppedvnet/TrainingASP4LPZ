using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using Newtonsoft.Json.Serialization;
using CarRental.API.Models;

namespace CarRental.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Cors
            //config.EnableCors();

            //OData
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Car>("Odata");
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());

            // Web API configuration and services
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

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
