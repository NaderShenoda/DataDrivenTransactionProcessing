using AdminPortal.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Net.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace AdminPortal
{
    public class ServiceConfig
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<HomeController>();
            services.AddTransient<DataDefinitionController>();

            services.AddHttpClient<DataDefinitionController, DataDefinitionController>()
                .AddPolicyHandler(GetRetryPolicy());
        }

        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2,
                                                                            retryAttempt)));
        }
    }
}
