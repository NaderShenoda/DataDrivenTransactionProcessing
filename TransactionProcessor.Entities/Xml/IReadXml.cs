using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace TransactionProcessor.Entities.Xml
{
    public interface IReadXml
    {
        bool CanRead<T>(T itemToRead);
        Task Read<T>(IEnumerable<IReadXml> xmlReaders, XmlReader reader, T itemToRead, CancellationToken cancellationToken = default);
    }
}
