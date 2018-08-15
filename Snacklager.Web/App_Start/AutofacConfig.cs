using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Snacklager.Data;
using Snacklager.Logic;
using Snacklager.Logic.Contracts;

namespace Snacklager.Web.App_Start
{
    // IoC Container Klasse
    public static class AutofacConfig
    {
        public static void RegisterComponents()
        {
            var builder = new ContainerBuilder();

            // Abhängigkeiten im Controller registrieren
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            
            //builder.Register(c => new SnacklagerDB()).InstancePerRequest();
            builder.Register(c => new SnacklagerDB("SnacklagerDBModel")).InstancePerRequest();

            builder.RegisterType<SnackRepository>().As<ISnackRepository>().InstancePerRequest();
            builder.RegisterType<Repository<Zutaten>>().As<IRepository<Zutaten>>().InstancePerRequest();

            // Abhängigkeiten auflösen
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}