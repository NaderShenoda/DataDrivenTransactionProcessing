using AdminPortal.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AdminPortal.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DataDefinitionController : EntityFrameworkControllerBase<DataDefinition, DataContext>
    {
        public DataDefinitionController(DataContext context) : base(context) { }

        [HttpGet]
        [Route("api/datadefinition")]
        public async Task<IEnumerable<DataDefinition>> Get(CancellationToken cancellationToken)
            => await base.GetItems(cancellationToken);

        [HttpGet]
        [Route("api/datadefinition/{dataDefinitionId}")]
        public async Task<DataDefinition> Get(long dataDefinitionId, CancellationToken cancellationToken)
            => await base.GetItem(dataDefinitionId, cancellationToken);

        [HttpPost]
        [Route("api/datadefinition")]
        public async Task<DataDefinition> Post([FromBody] DataDefinition value, CancellationToken cancellationToken)
            => await base.Insert(value, cancellationToken);

        [HttpPut]
        [Route("api/datadefinition/{dataDefinitionId}")]
        public async Task<DataDefinition> Put(long dataDefinitionId, [FromBody] DataDefinition value, CancellationToken cancellationToken)
            => await base.Update(dataDefinitionId, value, cancellationToken);

        [HttpDelete]
        [Route("api/datadefinition/{dataDefinitionId}")]
        public async Task<DataDefinition> Delete(long dataDefinitionId, CancellationToken cancellationToken)
            => await base.Remove(dataDefinitionId, cancellationToken);
    }
}
