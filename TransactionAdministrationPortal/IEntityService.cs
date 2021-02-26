using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionProcessor.Entities.ViewModel;

namespace TransactionAdministrationPortal
{
    public interface IEntityService
    {
        Task<IEnumerable<EntityModel>> GetEntities();

        Task<EntityModel> GetEntity(string entityName);

        Task<EntityTableModel> GetEntityTable(string entityName);
    }
}
