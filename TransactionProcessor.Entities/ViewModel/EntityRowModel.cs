using System.Collections.Generic;

namespace TransactionProcessor.Entities.ViewModel
{
    public class EntityRowModel
    {
        public long Id { get; set; }

        public ICollection<EntityFieldModel> Fields { get; set; }
            = new HashSet<EntityFieldModel>();
    }
}
