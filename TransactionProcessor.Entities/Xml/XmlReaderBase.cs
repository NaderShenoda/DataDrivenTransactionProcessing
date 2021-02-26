using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace TransactionProcessor.Entities.Xml
{
    public abstract class XmlReaderBase<T> : IReadXml
        where T : class
    {
        protected readonly IReadOnlyDictionary<XmlNodeType, Func<IEnumerable<IReadXml>, XmlReader, T, CancellationToken, Task>> TokenActions;

        protected XmlReaderBase()
        {
            TokenActions = new Dictionary<XmlNodeType, Func<IEnumerable<IReadXml>, XmlReader, T, CancellationToken, Task>>
            {
                { XmlNodeType.None, XmlNodeTypeNone },
                { XmlNodeType.Element, XmlNodeTypeElement },
                { XmlNodeType.Attribute, XmlNodeTypeAttribute },
                { XmlNodeType.Text, XmlNodeTypeText },
                { XmlNodeType.CDATA, XmlNodeTypeCDATA },
                { XmlNodeType.EntityReference, XmlNodeTypeEntityReference },
                { XmlNodeType.Entity, XmlNodeTypeEntity },
                { XmlNodeType.ProcessingInstruction, XmlNodeTypeProcessingInstruction },
                { XmlNodeType.Comment, XmlNodeTypeComment },
                { XmlNodeType.Document, XmlNodeTypeDocument },
                { XmlNodeType.DocumentType, XmlNodeTypeDocumentType },
                { XmlNodeType.DocumentFragment, XmlNodeTypeDocumentFragment },
                { XmlNodeType.Notation, XmlNodeTypeNotation },
                { XmlNodeType.Whitespace, XmlNodeTypeWhitespace },
                { XmlNodeType.SignificantWhitespace, XmlNodeTypeSignificantWhitespace },
                { XmlNodeType.EndElement, XmlNodeTypeEndElement },
                { XmlNodeType.EndEntity, XmlNodeTypeEndEntity },
                { XmlNodeType.XmlDeclaration, XmlNodeTypeXmlDeclaration },
            };
        }

        protected virtual bool CanRead(T itemToRead)
            => itemToRead != null;

        bool IReadXml.CanRead<T1>(T1 itemToRead)
            => CanRead(itemToRead as T);

        protected virtual async Task Read(IEnumerable<IReadXml> xmlReaders, XmlReader reader, T itemToRead, CancellationToken cancellationToken = default)
        {
            var depth = reader.Depth;
            while (await reader.ReadAsync())
            {
                Debug.WriteLine($"{this.GetType().Name}: {reader.Name} - {reader.NodeType}");
                await TokenActions[reader.NodeType](xmlReaders, reader, itemToRead, cancellationToken);

                if (reader.NodeType == XmlNodeType.EndElement && reader.Depth == depth)
                {
                    break;
                }
            }
        }

        protected virtual Task XmlNodeTypeNone(IEnumerable<IReadXml> xmlReaders, XmlReader reader, T itemToRead, CancellationToken cancellationToken = default)
            => Process(nameof(XmlNodeTypeNone), reader);

        protected virtual async Task XmlNodeTypeElement(IEnumerable<IReadXml> xmlReaders, XmlReader reader, T itemToRead, CancellationToken cancellationToken = default)
        {
            await Process(nameof(XmlNodeTypeElement), reader);
            if (reader.HasAttributes)
            {
                while (reader.MoveToNextAttribute())
                {
                    await TokenActions[reader.NodeType](xmlReaders, reader, itemToRead, cancellationToken);
                }
                reader.MoveToElement();
            }
        }

        protected virtual Task XmlNodeTypeAttribute(IEnumerable<IReadXml> xmlReaders, XmlReader reader, T itemToRead, CancellationToken cancellationToken = default)
            => Process(nameof(XmlNodeTypeAttribute), reader);

        protected virtual Task XmlNodeTypeText(IEnumerable<IReadXml> xmlReaders, XmlReader reader, T itemToRead, CancellationToken cancellationToken = default)
            => Process(nameof(XmlNodeTypeText), reader);

        protected virtual Task XmlNodeTypeCDATA(IEnumerable<IReadXml> xmlReaders, XmlReader reader, T itemToRead, CancellationToken cancellationToken = default)
            => Process(nameof(XmlNodeTypeCDATA), reader);

        protected virtual Task XmlNodeTypeEntityReference(IEnumerable<IReadXml> xmlReaders, XmlReader reader, T itemToRead, CancellationToken cancellationToken = default)
            => Process(nameof(XmlNodeTypeEntityReference), reader);

        protected virtual Task XmlNodeTypeEntity(IEnumerable<IReadXml> xmlReaders, XmlReader reader, T itemToRead, CancellationToken cancellationToken = default)
            => Process(nameof(XmlNodeTypeEntity), reader);

        protected virtual Task XmlNodeTypeProcessingInstruction(IEnumerable<IReadXml> xmlReaders, XmlReader reader, T itemToRead, CancellationToken cancellationToken = default)
            => Process(nameof(XmlNodeTypeProcessingInstruction), reader);

        protected virtual Task XmlNodeTypeComment(IEnumerable<IReadXml> xmlReaders, XmlReader reader, T itemToRead, CancellationToken cancellationToken = default)
            => Process(nameof(XmlNodeTypeComment), reader);

        protected virtual Task XmlNodeTypeDocument(IEnumerable<IReadXml> xmlReaders, XmlReader reader, T itemToRead, CancellationToken cancellationToken = default)
            => Process(nameof(XmlNodeTypeDocument), reader);

        protected virtual Task XmlNodeTypeDocumentType(IEnumerable<IReadXml> xmlReaders, XmlReader reader, T itemToRead, CancellationToken cancellationToken = default)
            => Process(nameof(XmlNodeTypeDocumentType), reader);

        protected virtual Task XmlNodeTypeDocumentFragment(IEnumerable<IReadXml> xmlReaders, XmlReader reader, T itemToRead, CancellationToken cancellationToken = default)
            => Process(nameof(XmlNodeTypeDocumentFragment), reader);

        protected virtual Task XmlNodeTypeNotation(IEnumerable<IReadXml> xmlReaders, XmlReader reader, T itemToRead, CancellationToken cancellationToken = default)
            => Process(nameof(XmlNodeTypeNotation), reader);

        protected virtual Task XmlNodeTypeWhitespace(IEnumerable<IReadXml> xmlReaders, XmlReader reader, T itemToRead, CancellationToken cancellationToken = default)
            => Process(nameof(XmlNodeTypeWhitespace), reader);

        protected virtual Task XmlNodeTypeSignificantWhitespace(IEnumerable<IReadXml> xmlReaders, XmlReader reader, T itemToRead, CancellationToken cancellationToken = default)
            => Process(nameof(XmlNodeTypeSignificantWhitespace), reader);

        protected virtual Task XmlNodeTypeEndElement(IEnumerable<IReadXml> xmlReaders, XmlReader reader, T itemToRead, CancellationToken cancellationToken = default)
            => Process(nameof(XmlNodeTypeEndElement), reader);

        protected virtual Task XmlNodeTypeEndEntity(IEnumerable<IReadXml> xmlReaders, XmlReader reader, T itemToRead, CancellationToken cancellationToken = default)
            => Process(nameof(XmlNodeTypeEndEntity), reader);

        protected virtual Task XmlNodeTypeXmlDeclaration(IEnumerable<IReadXml> xmlReaders, XmlReader reader, T itemToRead, CancellationToken cancellationToken = default)
            => Process(nameof(XmlNodeTypeXmlDeclaration), reader);

        protected virtual Task Process(string method, XmlReader reader)
        {
            return Task.CompletedTask;
        }

        async Task IReadXml.Read<T1>(IEnumerable<IReadXml> xmlReaders, XmlReader reader, T1 itemToRead, CancellationToken cancellationToken)
            => await Read(xmlReaders, reader, itemToRead as T, cancellationToken);
    }
}
