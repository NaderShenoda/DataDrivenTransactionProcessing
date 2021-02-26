using System.Collections.Generic;

namespace TransactionProcessor.Entities.Instance
{
    public class ArrayDataFieldInstance : DataFieldInstanceBase
    {
        public ICollection<DataFieldInstanceBase> ArrayValue { get; set; } = new HashSet<DataFieldInstanceBase>();
    }
}
