using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using TransactionProcessor.Entities.Instance;

namespace TransactionProcessor.Entities.Xml
{
    public class ValueXmlReader : XmlReaderBase<SimpleDataFieldInstance>
    {
        protected override Task Read(IEnumerable<IReadXml> xmlReaders, XmlReader reader, SimpleDataFieldInstance itemToRead, CancellationToken cancellationToken = default)
        {
            itemToRead.SimpleValue = reader.ReadInnerXml();
            return Task.CompletedTask;
        }
    }
}
