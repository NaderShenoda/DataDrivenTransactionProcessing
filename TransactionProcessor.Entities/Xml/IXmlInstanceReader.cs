using System.IO;
using System.Threading;
using System.Threading.Tasks;
using TransactionProcessor.Entities.Instance;

namespace TransactionProcessor.Entities.Xml
{
    public interface IXmlInstanceReader
    {
        Task<ComplexDataFieldInstance> Read(Stream source, ComplexDataFieldInstance dataInstance, CancellationToken cancellationToken = default);
    }
}
