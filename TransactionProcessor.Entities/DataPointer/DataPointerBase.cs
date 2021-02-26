using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionProcessor.Entities.DataPointer
{
    public abstract class DataPointerBase : IHaveId
    {
        public long Id { get; set; }
    }
}
