using System;
using System.Collections.Generic;

namespace TransactionProcessor.Entities
{
    public partial class DataDefinition : IHaveId
    {
        public long Id { get; set; }

        public string Path { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsArray { get; set; }

        public long? MasterDataDefinitionId { get; set; }

        public long? ParentDataDefinitionId { get; set; }
    }
}
