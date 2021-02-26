using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using TransactionProcessor.Entities.Instance;

namespace TransactionProcessor.Entities.Xml
{
    public class DataInstanceXmlReader : XmlReaderBase<ComplexDataFieldInstance>
    {
        protected override async Task XmlNodeTypeAttribute(IEnumerable<IReadXml> xmlReaders, XmlReader reader, ComplexDataFieldInstance itemToRead, CancellationToken cancellationToken = default)
        {
            await base.XmlNodeTypeAttribute(xmlReaders, reader, itemToRead, cancellationToken);
            await ProcessField(xmlReaders, reader, itemToRead, cancellationToken);
        }

        protected override async Task XmlNodeTypeElement(IEnumerable<IReadXml> xmlReaders, XmlReader reader, ComplexDataFieldInstance itemToRead, CancellationToken cancellationToken = default)
        {
            await base.XmlNodeTypeElement(xmlReaders, reader, itemToRead, cancellationToken);
            await ProcessField(xmlReaders, reader, itemToRead, cancellationToken);
        }

        protected virtual async Task ProcessField(IEnumerable<IReadXml> xmlReaders, XmlReader reader, ComplexDataFieldInstance itemToRead, CancellationToken cancellationToken = default)
        {
            var field = FindEntityFieldInstance(itemToRead, reader.Name);
            if (field != null)
            {
                await xmlReaders.CanRead(field).Read(xmlReaders, reader, field, cancellationToken);
            }
        }

        protected virtual DataFieldInstanceBase FindEntityFieldInstance(ComplexDataFieldInstance itemToRead, string fieldName)
        {
            var findEntityFieldInstance = itemToRead.ComplexValue.SingleOrDefault(field => field.DataDefinition.Definition.Name == fieldName);
            return findEntityFieldInstance;
        }
    }
}
