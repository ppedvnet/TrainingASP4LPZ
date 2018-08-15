using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using Snacklager.Web.App_Start;
using Snacklager.Web.Helpers;

namespace Snacklager.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfig.RegisterComponents();
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
            ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
