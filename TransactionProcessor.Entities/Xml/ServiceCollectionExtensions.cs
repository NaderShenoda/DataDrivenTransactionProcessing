using Microsoft.Extensions.DependencyInjection;

namespace TransactionProcessor.Entities.Xml
{
    public static class ServiceCollectionExtensions
    {
        public static void AddXmlEntityInstanceReader(this IServiceCollection services)
        {
            services.AddSingleton<IXmlInstanceReader, XmlInstanceReader>();
            services.AddSingleton<IReadXml, ArrayXmlReader>();
            services.AddSingleton<IReadXml, DataInstanceXmlReader>();
            services.AddSingleton<IReadXml, ValueXmlReader>();
        }
    }
}
