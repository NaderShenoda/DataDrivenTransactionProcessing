using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionProcessor.Entities.Validation
{
    public class ValidationParameter : IHaveId
    {
        public long Id { get; set; }

        public long ValidationId { get; set; }

        public long DataPointerId { get; set; }

        public string ParameterName { get; set; }
    }
}
