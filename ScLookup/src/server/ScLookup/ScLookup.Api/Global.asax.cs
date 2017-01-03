using Autofac;
using Autofac.Integration.WebApi;
using ScLookup.Models;
using System.Reflection;
using System.Web.Http;

namespace ScLookup.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule(new ModelsModule());

            var container = builder.Build();
            var config = GlobalConfiguration.Configuration;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
