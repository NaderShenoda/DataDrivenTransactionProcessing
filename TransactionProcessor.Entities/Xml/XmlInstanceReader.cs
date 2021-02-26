using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using TransactionProcessor.Entities.Instance;

namespace TransactionProcessor.Entities.Xml
{
    public class XmlInstanceReader : IXmlInstanceReader
    {
        protected readonly IEnumerable<IReadXml> XmlReaders;

        public XmlInstanceReader(IEnumerable<IReadXml> xmlReaders)
            => XmlReaders = xmlReaders;

        public async Task<ComplexDataFieldInstance> Read(Stream source, ComplexDataFieldInstance dataInstance, CancellationToken cancellationToken)
        {
            using (var streamReader = new StreamReader(source))
            {
                using (var xmlReader = XmlReader.Create(streamReader, new XmlReaderSettings { Async = true }))
                {
                    await XmlReaders.CanRead(dataInstance).Read(XmlReaders, xmlReader, dataInstance, cancellationToken);
                }
            }
            return dataInstance;
        }
    }
}
