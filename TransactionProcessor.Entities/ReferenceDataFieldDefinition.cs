using System.Collections.Generic;

namespace TransactionProcessor.Entities
{
    public partial class ReferenceDataFieldDefinition : IHaveId
    {
        public long Id { get; set; }

        public long ReferenceDataDefinitionId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ReferenceDataDefinition ReferenceDataDefinition { get; set; }

    }
}
