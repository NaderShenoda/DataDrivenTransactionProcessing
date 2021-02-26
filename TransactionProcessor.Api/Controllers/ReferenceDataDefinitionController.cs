using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TransactionProcessor.Api.Data;
using TransactionProcessor.Entities;

namespace TransactionProcessor.Api.Controllers
{
    [Route("api/referencedata/definition")]
    [ApiController]
    public class ReferenceDataDefinitionController : EntityFrameworkControllerBase<ReferenceDataDefinition, DataDefinitionContext>
    {
        public ReferenceDataDefinitionController(DataDefinitionContext context) : base(context) { }

        [HttpGet("{id}/field")]
        public async Task<IEnumerable<ReferenceDataFieldDefinition>> GetField(long id, CancellationToken cancellationToken)
            => await Context.ReferenceDataFieldDefinitions.Where(definition => definition.ReferenceDataDefinitionId == id).ToArrayAsync(cancellationToken);

        [HttpGet("{id}/instance")]
        public async Task<IEnumerable<ReferenceDataInstance>> GetInstance(long id, CancellationToken cancellationToken)
            => await Context.ReferenceDataInstances.Where(definition => definition.ReferenceDataDefinitionId == id).ToArrayAsync(cancellationToken);

        [HttpGet("{masterId}/instance/{id}")]
        public async Task<ReferenceDataInstance> GetInstance(long masterId, long id, CancellationToken cancellationToken)
            => await Context.ReferenceDataInstances.FindAsync(id);

        [HttpGet("{id}/instance/field")]
        public async Task<IEnumerable<ReferenceDataFieldInstance>> GetFieldInstance(long id, CancellationToken cancellationToken)
            => await Context.ReferenceDataFieldInstances.Where(field => field.ReferenceDataInstance.ReferenceDataDefinitionId == id).ToArrayAsync(cancellationToken);

        [HttpGet("{masterId}/instance/{id}/field")]
        public async Task<IEnumerable<ReferenceDataFieldInstance>> GetFieldInstance(long masterId, long id, CancellationToken cancellationToken)
            => await Context.ReferenceDataFieldInstances.Where(field => field.ReferenceDataInstanceId == id).ToArrayAsync(cancellationToken);

        public override async Task<ReferenceDataDefinition> Delete(long itemId, CancellationToken cancellationToken)
        {
            Context.Set<ReferenceDataFieldInstance>().RemoveRange(Context.Set<ReferenceDataFieldInstance>().Where(field => field.ReferenceDataInstance.ReferenceDataDefinition.Id == itemId));
            Context.Set<ReferenceDataInstance>().RemoveRange(Context.Set<ReferenceDataInstance>().Where(field => field.ReferenceDataDefinition.Id == itemId));
            Context.Set<ReferenceDataFieldDefinition>().RemoveRange(Context.Set<ReferenceDataFieldDefinition>().Where(field => field.ReferenceDataDefinitionId == itemId));
            var item = await GetItem(itemId, cancellationToken);
            Context.Set<ReferenceDataDefinition>().Remove(item);
            await Context.SaveChangesAsync(cancellationToken);
            return item;
        }
    }
}
