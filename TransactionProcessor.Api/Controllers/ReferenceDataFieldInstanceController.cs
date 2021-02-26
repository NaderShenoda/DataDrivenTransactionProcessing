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
    [Route("api/referencedata/instance/field")]
    [ApiController]
    public class ReferenceDataFieldInstanceController : EntityFrameworkControllerBase<ReferenceDataFieldInstance, DataDefinitionContext>
    {
        public ReferenceDataFieldInstanceController(DataDefinitionContext context) : base(context) { }
    }
}
