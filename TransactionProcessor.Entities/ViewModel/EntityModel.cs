using System.Collections.Generic;

namespace TransactionProcessor.Entities.ViewModel
{
    public class EntityModel
    {
        public ICollection<EntityTableHeaderFieldModel> DefaultTableHeaderFields { get; set; }
            = new HashSet<EntityTableHeaderFieldModel>();

        public string EntityName { get; set; }

        public string DisplayName { get; set; }

        public string ContextName { get; set; }

        public bool ShowOnNav { get; set; }

        public int Order { get; set; }

        public string Icon { get; set; }
    }
}
