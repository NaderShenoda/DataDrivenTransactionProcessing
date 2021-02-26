using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionProcessor.Entities.DataPointer
{
    public class UtilityDataPointerParameter : IHaveId
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long DataPointerId { get; set; }
    }
}
