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
    [Route("api/referencedata/instance")]
    [ApiController]
    public class ReferenceDataInstanceController : EntityFrameworkControllerBase<ReferenceDataInstance, DataDefinitionContext>
    {
        public ReferenceDataInstanceController(DataDefinitionContext context) : base(context) { }

        public override async Task<ReferenceDataInstance> Put(long itemId, [FromBody] ReferenceDataInstance value, CancellationToken cancellationToken)
        {
            foreach (var field in value.ReferenceDataFieldInstances)
            {
                Context.Entry(field).State = EntityState.Modified;
            }
            Context.Entry(value).State = EntityState.Modified;
            await Context.SaveChangesAsync(cancellationToken);
            return value;
        }

        public override async Task<ReferenceDataInstance> Delete(long itemId, CancellationToken cancellationToken)
        {
            Context.Set<ReferenceDataFieldInstance>().RemoveRange(Context.Set<ReferenceDataFieldInstance>().Where(field => field.ReferenceDataInstanceId == itemId));
            var item = await GetItem(itemId, cancellationToken);
            Context.Set<ReferenceDataInstance>().Remove(item);
            await Context.SaveChangesAsync(cancellationToken);
            return item;
        }
    }
}
