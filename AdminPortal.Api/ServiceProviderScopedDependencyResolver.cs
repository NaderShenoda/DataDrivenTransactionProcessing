using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace AdminPortal.Api
{
    public class ServiceProviderScopedDependencyResolver : IDependencyScope
    {
        protected readonly IServiceScope Scope;

        public ServiceProviderScopedDependencyResolver(IServiceScope scope)
            => Scope = scope;

        public virtual object GetService(Type serviceType)
            => Scope.ServiceProvider.GetService(serviceType);

        public virtual IEnumerable<object> GetServices(Type serviceType)
            => Scope.ServiceProvider.GetServices(serviceType);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
            => Scope.Dispose();
    }
}