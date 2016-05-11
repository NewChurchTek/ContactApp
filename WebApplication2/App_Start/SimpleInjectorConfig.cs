using ContactApp.Services;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;

namespace ContactApp
{
    public class SimpleInjectorConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            container.Register<IContactManager, ContactManager>(Lifestyle.Transient);
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
