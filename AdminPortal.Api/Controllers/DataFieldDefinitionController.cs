using AdminPortal.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AdminPortal.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DataFieldDefinitionController : EntityFrameworkControllerBase<DataFieldDefinition, DataContext>
    {
        public DataFieldDefinitionController(DataContext context) : base(context) { }

        [HttpGet]
        [Route("api/datadefinition/{dataDefinitionId}/datafielddefinition")]
        public async Task<IEnumerable<DataFieldDefinition>> Get(long dataDefinitionId, CancellationToken cancellationToken)
            => await GetItems(dataDefinitionId, cancellationToken);

        [HttpGet]
        [Route("api/datadefinition/{dataDefinitionId}/datafielddefinition/{dataFieldDefinitionId}")]
        public async Task<DataFieldDefinition> Get(long dataDefinitionId, long dataFieldDefinitionId, CancellationToken cancellationToken)
            => await GetItem(dataDefinitionId, dataFieldDefinitionId, cancellationToken);

        [HttpPost]
        [Route("api/datadefinition/{dataDefinitionId}/datafielddefinition")]
        public async Task<DataFieldDefinition> Post(long dataDefinitionId, [FromBody] DataFieldDefinition value, CancellationToken cancellationToken)
        {
            await Context.Set<DataFieldDefinition>().AddAsync(value, cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);
            return value;
        }

        [HttpPut]
        [Route("api/datadefinition/{dataDefinitionId}/datafielddefinition/{dataFieldDefinitionId}")]
        public async Task<DataFieldDefinition> Put(long dataDefinitionId, long dataFieldDefinitionId, [FromBody] DataFieldDefinition value, CancellationToken cancellationToken)
        {
            Context.Entry(value).State = EntityState.Modified;
            await Context.SaveChangesAsync(cancellationToken);
            return value;
        }

        [HttpDelete]
        [Route("api/datadefinition/{dataDefinitionId}/datafieldDefinition/{dataFieldDefinitionId}")]
        public async Task<DataFieldDefinition> Delete(long dataDefinitionId, long dataFieldDefinitionId, CancellationToken cancellationToken)
        {
            var item = await GetItem(dataDefinitionId, dataFieldDefinitionId, cancellationToken);
            Context.Set<DataFieldDefinition>().Remove(item);
            await Context.SaveChangesAsync(cancellationToken);
            return item;
        }

        protected virtual async Task<DataFieldDefinition> GetItem(long dataDefinitionId, long dataFieldDefinitionId, CancellationToken cancellationToken)
            => await Context.Set<DataFieldDefinition>().SingleAsync(fieldDefinition => fieldDefinition.DataDefiniitionId == dataDefinitionId && fieldDefinition.Id == dataFieldDefinitionId, cancellationToken);

        protected virtual async Task<IEnumerable<DataFieldDefinition>> GetItems(long dataDefinitionId, CancellationToken cancellationToken)
            => await Context.Set<DataFieldDefinition>().Where(fieldDefinition => fieldDefinition.DataDefiniitionId == dataDefinitionId).ToArrayAsync(cancellationToken);
    }
}
