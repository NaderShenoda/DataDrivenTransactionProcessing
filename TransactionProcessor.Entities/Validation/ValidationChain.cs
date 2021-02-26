using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionProcessor.Entities.Validation
{
    public class ValidationChain : IHaveId
    {
        public long Id { get; set; }

        public long DataPointerId { get; set; }
    }
}
