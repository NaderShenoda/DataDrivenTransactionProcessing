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
    [Route("api/[controller]")]
    [ApiController]
    public class DataDefinitionController : EntityFrameworkControllerBase<DataDefinition, DataDefinitionContext>
    {
        public DataDefinitionController(DataDefinitionContext context) : base(context) { }

        [HttpGet("master")]
        public virtual async Task<IEnumerable<DataDefinition>> GetMaster(CancellationToken cancellationToken)
            => await Context.Set<DataDefinition>().Where(item => item.MasterDataDefinitionId == null).ToArrayAsync(cancellationToken);

        [HttpGet("{id}/master")]
        public virtual async Task<IEnumerable<DataDefinition>> GetMaster(long id, CancellationToken cancellationToken)
            => await Context.Set<DataDefinition>().Where(item => item.MasterDataDefinitionId == id || item.Id == id).ToArrayAsync(cancellationToken);

        [HttpGet("{id}/tree")]
        public virtual async Task<DataDefinitionTree> GetTree(long id, CancellationToken cancellationToken)
            => (await Context.Set<DataDefinition>().Where(item => item.MasterDataDefinitionId == id || item.Id == id).ToArrayAsync(cancellationToken)).BuildDataDefinitionTree();

        [HttpGet("{masterId}/tree/{id}")]
        public virtual async Task<DataDefinitionTree> GetTree(long masterId, long id, CancellationToken cancellationToken)
            => (await Context.Set<DataDefinition>().Where(item => item.MasterDataDefinitionId == masterId || item.Id == masterId).ToArrayAsync(cancellationToken)).BuildDataDefinitionTree().FindDataDefinitionTree(id);
    }
}
