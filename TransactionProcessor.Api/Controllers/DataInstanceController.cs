using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TransactionProcessor.Api.Data;
using TransactionProcessor.Entities;
using TransactionProcessor.Entities.Instance;

namespace TransactionProcessor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataInstanceController
    {
        private readonly DataDefinitionContext Context;

        public DataInstanceController(DataDefinitionContext context) => Context = context;

        [HttpGet("{id}")]
        public virtual async Task<ComplexDataFieldInstance> Get(long id, CancellationToken cancellationToken)
            => (await Context.Set<DataDefinition>().Where(item => item.MasterDataDefinitionId == id || item.Id == id).ToArrayAsync(cancellationToken)).BuildDataDefinitionTree().BuildDataInstance();
    }
}
