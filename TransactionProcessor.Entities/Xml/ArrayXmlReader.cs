using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using TransactionProcessor.Entities.Instance;

namespace TransactionProcessor.Entities.Xml
{
    public class ArrayXmlReader : XmlReaderBase<ArrayDataFieldInstance>
    {

        protected override async Task Read(IEnumerable<IReadXml> xmlReaders, XmlReader reader, ArrayDataFieldInstance itemToRead, CancellationToken cancellationToken = default)
        {
            if (reader.NodeType == XmlNodeType.Element && reader.Name == itemToRead.DataDefinition.Definition.Name)
            {
                await XmlNodeTypeElement(xmlReaders, reader, itemToRead, cancellationToken);
            }
        }

        protected override async Task XmlNodeTypeElement(IEnumerable<IReadXml> xmlReaders, XmlReader reader, ArrayDataFieldInstance itemToRead, CancellationToken cancellationToken = default)
        {
            await base.XmlNodeTypeElement(xmlReaders, reader, itemToRead, cancellationToken);
            var fieldInstance = itemToRead.DataDefinition.BuildDataInstance();
            await xmlReaders.CanRead(fieldInstance).Read(xmlReaders, reader, fieldInstance, cancellationToken);
            itemToRead.ArrayValue.Add(fieldInstance);
        }
    }
}
