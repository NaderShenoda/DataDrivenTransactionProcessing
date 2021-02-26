using System.Collections.Generic;

namespace TransactionProcessor.Entities
{
    public partial class DataDefinitionTree
    {
        public string Path { get; set; }

        public DataDefinition Definition { get; set; }

        public IEnumerable<DataDefinitionTree> Fields { get; set; }
    }
}
