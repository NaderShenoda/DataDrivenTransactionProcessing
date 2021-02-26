using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TransactionProcessor.Api.Data;
using TransactionProcessor.Entities;
using TransactionProcessor.Entities.ViewModel;

namespace TransactionProcessor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityController : ControllerBase
    {
        private DbContext Context;

        public EntityController(DataDefinitionContext context)
        {
            Context = context;
        }

        [HttpGet()]
        public virtual Task<IEnumerable<EntityModel>> Get(CancellationToken cancellationToken)
            => Task.FromResult(Entities);

        [HttpGet("{entityName}")]
        public virtual Task<EntityModel> Get(string entityName, CancellationToken cancellationToken)
            => Task.FromResult(Entities.FirstOrDefault(entity => string.Equals(entity.EntityName, entityName, System.StringComparison.CurrentCultureIgnoreCase)));

        [HttpGet("{entityName}/table")]
        public virtual async Task<EntityTableModel> GetTable(string entityName, CancellationToken cancellationToken)
        {
            var entity = await Get(entityName, cancellationToken);
            var model = new EntityTableModel { Entity = entity, TableHeaderFields = entity.DefaultTableHeaderFields };
            var type = Context.Model.FindEntityType(entity.ContextName).ClrType;
            IEnumerable items = typeof(DbContext).GetMethod(nameof(DbContext.Set)).MakeGenericMethod(new[] { type }).Invoke(Context, null) as IEnumerable;
            model.Rows = items.OfType<IHaveId>()
                .Select(item => new EntityRowModel
                {
                    Id = item.Id,
                    Fields = type.GetProperties()
                    .Where(prop => prop.GetMethod?.IsPublic == true)
                    .Select(prop => new EntityFieldModel
                    {
                        FieldName = prop.Name,
                        DisplayValue = prop.GetValue(item)?.ToString()
                    }).Concat(new[]
                    {
                        new EntityFieldModel
                        {
                            Icon = "oi oi-chevron-right"
                        }
                    }).ToList()
                }).ToList();
            return model;
        }

        private readonly IEnumerable<EntityModel> Entities = new[]
        {
            new EntityModel
            {
                DefaultTableHeaderFields = new[]
                {
                    new EntityTableHeaderFieldModel
                    {
                        CssClass = "col-3",
                        DisplayName = "Name",
                        FieldName = "Name",
                        Order = 0,
                        Show = true
                    },
                    new EntityTableHeaderFieldModel
                    {
                        CssClass = "col",
                        DisplayName = "Description",
                        FieldName = "Description",
                        Order = 1,
                        Show = true
                    },
                    new EntityTableHeaderFieldModel
                    {
                        CssClass = "col-1",
                        DisplayName = "",
                        FieldName = null,
                        Order = 2,
                        Show = true
                    },
                },
                DisplayName = "Data Definiition",
                EntityName = "DataDefinition",
                ContextName = "TransactionProcessor.Entities.DataDefinition",
                Order = 0,
                ShowOnNav = true,
                Icon = "oi oi-list-rich"
            },
            new EntityModel
            {
                DefaultTableHeaderFields = new[]
                {
                    new EntityTableHeaderFieldModel
                    {
                        CssClass = "col-3",
                        DisplayName = "Name",
                        FieldName = "Name",
                        Order = 0,
                        Show = true
                    },
                    new EntityTableHeaderFieldModel
                    {
                        CssClass = "col",
                        DisplayName = "Description",
                        FieldName = "Description",
                        Order = 1,
                        Show = true
                    },
                    new EntityTableHeaderFieldModel
                    {
                        CssClass = "col-1",
                        DisplayName = "",
                        FieldName = null,
                        Order = 2,
                        Show = true
                    },
                },
                DisplayName = "Reference Data",
                EntityName = "ReferenceDataDefinition",
                ContextName = "TransactionProcessor.Entities.ReferenceDataDefinition",
                Order = 1,
                ShowOnNav = true,
                Icon = "oi oi-spreadsheet"
            }
        };
    }
}
