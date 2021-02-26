using System.Collections.Generic;

namespace TransactionProcessor.Entities
{
    public partial class ReferenceDataDefinition : IHaveId
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<ReferenceDataFieldDefinition> ReferenceDataFieldDefinitions { get; set; } 
            = new HashSet<ReferenceDataFieldDefinition>();
    }
}
