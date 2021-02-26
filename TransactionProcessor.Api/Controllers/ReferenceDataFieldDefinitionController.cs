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
    [Route("api/referencedata/definition/field")]
    [ApiController]
    public class ReferenceDataFieldDefinitionController : EntityFrameworkControllerBase<ReferenceDataFieldDefinition, DataDefinitionContext>
    {
        public ReferenceDataFieldDefinitionController(DataDefinitionContext context) : base(context) { }
    }
}
