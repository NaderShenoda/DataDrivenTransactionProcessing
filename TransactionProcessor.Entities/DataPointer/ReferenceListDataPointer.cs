using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionProcessor.Entities.DataPointer
{
    public class ReferenceListDataPointer : DataPointerBase
    {
        public long ReferenceDataDefinitionId { get; set; }

        public long ReferenceDataFieldDefinitionId { get; set; }
    }
}
