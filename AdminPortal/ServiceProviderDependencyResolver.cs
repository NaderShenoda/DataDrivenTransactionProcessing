using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AdminPortal
{
    public class ServiceProviderDependencyResolver : IDependencyResolver
    {
        protected readonly IServiceProvider Provider;

        public ServiceProviderDependencyResolver(IServiceProvider provider)
            => Provider = provider;

        public virtual object GetService(Type serviceType)
            => Provider.GetService(serviceType);

        public virtual IEnumerable<object> GetServices(Type serviceType)
            => Provider.GetServices(serviceType);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
            => (Provider as IDisposable)?.Dispose();
    }
}