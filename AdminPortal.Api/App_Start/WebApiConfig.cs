using AdminPortal.Api.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Web.Http;

namespace AdminPortal.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var configuration = new ConfigurationBuilder().Add(new LegacyConfigurationProvider()).Build();

            config.EnableCors();

            // Web API configuration and services
            var services = new ServiceCollection();


            services.AddTransient(provider => provider);

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("default"));
            });

            services.AddTransient<DataDefinitionController>();
            services.AddTransient<DataFieldDefinitionController>();

            var serviceProvider = services.BuildServiceProvider();
            config.DependencyResolver = new ServiceProviderDependencyResolver(serviceProvider);

            // Web API routes
            config.MapHttpAttributeRoutes();
        }
    }
}
