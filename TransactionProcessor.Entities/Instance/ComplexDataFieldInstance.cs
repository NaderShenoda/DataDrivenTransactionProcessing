using System.Collections.Generic;

namespace TransactionProcessor.Entities.Instance
{
    public class ComplexDataFieldInstance : DataFieldInstanceBase
    {
        public ICollection<DataFieldInstanceBase> ComplexValue { get; set; } = new HashSet<DataFieldInstanceBase>();
    }
}
