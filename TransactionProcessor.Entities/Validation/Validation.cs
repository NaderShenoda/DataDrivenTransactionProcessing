using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionProcessor.Entities.Validation
{
    public class Validation : IHaveId
    {
        public long Id { get; set; }

        public long ValidationChainId { get; set; }

        public bool IsValid { get; set; }

        public string TypeFullName { get; set; }
    }
}
