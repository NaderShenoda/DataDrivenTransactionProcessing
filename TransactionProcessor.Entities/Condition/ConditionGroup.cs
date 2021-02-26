using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransactionProcessor.Entities.Condition
{
    public class ConditionGroup : IHaveId
    {
        public long Id { get; set; }

        public long ParentConditionGroupId { get; set; }

        public bool Or { get; set; }

        public bool Not { get; set; }

        public int Order { get; set; }

        public ICollection<ConditionGroup> ChildrenGroups { get; set; } = new HashSet<ConditionGroup>();

        public ICollection<Condition> Conditions { get; set; } = new HashSet<Condition>();
    }
}
