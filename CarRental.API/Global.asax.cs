using System.Net.Http.Extensions.Compression.Core.Compressors;
using System.Web.Http;
using Microsoft.AspNet.WebApi.Extensions.Compression.Server;
using CarRental.API.Filters;

namespace CarRental.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Filter
            GlobalConfiguration.Configuration.Filters.Add(new CarExceptionFilterAttribute());

            GlobalConfiguration.Configure(WebApiConfig.Register);

            // GZIP Kompression
            GlobalConfiguration.Configuration.MessageHandlers.Insert(0, 
                new ServerCompressionHandler(
                    new GZipCompressor(), new DeflateCompressor()
                ));
        }
    }
}
