using System;
using System.Collections.Generic;

namespace TransactionProcessor.Entities
{
    public partial class ReferenceDataInstance : IHaveId
    {
        public long Id { get; set; }

        public long ReferenceDataDefinitionId { get; set; }

        public virtual ReferenceDataDefinition ReferenceDataDefinition { get; set; }

        public virtual ICollection<ReferenceDataFieldInstance> ReferenceDataFieldInstances { get; set; }
            = new HashSet<ReferenceDataFieldInstance>();
    }
}
