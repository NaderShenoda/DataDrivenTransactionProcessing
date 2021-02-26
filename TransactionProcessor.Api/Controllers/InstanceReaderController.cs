using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TransactionProcessor.Api.Data;
using TransactionProcessor.Entities;
using TransactionProcessor.Entities.Instance;
using TransactionProcessor.Entities.Xml;

namespace TransactionProcessor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstanceReaderController : ControllerBase
    {
        protected readonly IXmlInstanceReader InstanceReader;
        private readonly DataDefinitionContext Context;

        public InstanceReaderController(DataDefinitionContext context, IXmlInstanceReader instanceReader)
        {
            Context = context;
            InstanceReader = instanceReader;
        }

        [HttpPost("{id}")]
        public async Task<DataFieldInstanceBase> Post(long id, CancellationToken cancellationToken)
        {
            var tree = (await Context.Set<DataDefinition>().Where(item => item.MasterDataDefinitionId == id || item.Id == id).ToArrayAsync(cancellationToken)).BuildDataDefinitionTree().BuildDataInstance();
            return (await InstanceReader.Read(Request.Body, tree, cancellationToken)).StripChildren();
        }
    }
}
