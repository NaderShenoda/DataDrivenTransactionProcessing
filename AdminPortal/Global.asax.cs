using Microsoft.Extensions.DependencyInjection;
using System.Web.Mvc;
using System.Web.Routing;

namespace AdminPortal
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            var serviceCollection = new ServiceCollection();
            ServiceConfig.RegisterServices(serviceCollection);
            DependencyResolver.SetResolver(new ServiceProviderDependencyResolver(serviceCollection.BuildServiceProvider()));
        }
    }
}
