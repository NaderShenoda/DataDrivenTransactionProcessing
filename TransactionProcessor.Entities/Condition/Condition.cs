using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionProcessor.Entities.Condition
{
    public class Condition : IHaveId
    {
        public long Id { get; set; }

        public long ConditionGroupId { get; set; }

        public int Order { get; set; }

        public long OperatorId { get; set; }

        public long RightDataPointerId { get; set; }

        public long LeftDataPointerId { get; set; }

        public bool Or { get; set; }

        public bool Not { get; set; }

        public string DataType { get; set; }

        public string OperatorType { get; set; }

        public string LeftFormatInformation { get; set; }

        public string RightFormatInformation { get; set; }
    }
}
