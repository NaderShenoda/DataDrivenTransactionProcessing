using System.Collections.Generic;

namespace TransactionProcessor.Entities.ViewModel
{
    public class EntityTableModel
    {
        public ICollection<EntityTableHeaderFieldModel> TableHeaderFields { get; set; } 
            = new HashSet<EntityTableHeaderFieldModel>();

        public ICollection<EntityRowModel> Rows { get; set; }
            = new HashSet<EntityRowModel>();

        public EntityModel Entity { get; set; } 
    }
}
