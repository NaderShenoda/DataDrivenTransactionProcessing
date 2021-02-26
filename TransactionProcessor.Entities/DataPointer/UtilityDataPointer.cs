using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionProcessor.Entities.DataPointer
{
    public class UtilityDataPointer : DataPointerBase
    {
        public string TypeName { get; set; }

        public long DataPointerId { get; set; }
    }
}
