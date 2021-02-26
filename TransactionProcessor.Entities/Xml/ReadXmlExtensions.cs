using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransactionProcessor.Entities.Xml
{
    public static class ReadXmlExtensions
    {
        public static TSource CanRead<TSource, TDest>(this IEnumerable<TSource> readerInstances, TDest itemToRead) where TSource : IReadXml
        {
            var canRead = readerInstances.Where(instance => instance.CanRead(itemToRead)).ToArray();
            if (!canRead.Any())
            {
                throw new ArgumentException($"Could not find xml reader for {typeof(TDest).Name} in collection of {typeof(TSource).Name}.", nameof(itemToRead));
            }
            if (canRead.Count() > 1)
            {
                throw new ArgumentException($"More than one xml reader ({canRead.Count()}) found for {typeof(TDest).Name} in collection of {typeof(TSource).Name}.", nameof(itemToRead));
            }
            return canRead.Single();
        }
    }
}
