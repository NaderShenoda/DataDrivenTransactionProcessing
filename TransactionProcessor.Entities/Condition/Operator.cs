using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionProcessor.Entities.Condition
{
    public class Operator : IHaveId
    {
        public long Id { get; set; }

        public string Name { get; set; }


    }
}
