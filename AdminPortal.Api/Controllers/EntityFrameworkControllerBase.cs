using AdminPortal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace AdminPortal.Api.Controllers
{
    public abstract class EntityFrameworkControllerBase<TEntity, TContext> : ApiController
        where TEntity : class, IHaveId
        where TContext : DbContext
    {
        protected readonly TContext Context;

        protected EntityFrameworkControllerBase(TContext context)
            => Context = context;

        public virtual async Task<TEntity> Insert([FromBody] TEntity value, CancellationToken cancellationToken)
        {
            await Context.Set<TEntity>().AddAsync(value, cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);
            return value;
        }

        public virtual async Task<TEntity> Update(long id, [FromBody] TEntity value, CancellationToken cancellationToken)
        {
            Context.Entry(value).State = EntityState.Modified;
            await Context.SaveChangesAsync(cancellationToken);
            return value;
        }

        public virtual async Task<TEntity> Remove(long itemId, CancellationToken cancellationToken)
        {
            var item = await GetItem(itemId, cancellationToken);
            Context.Set<TEntity>().Remove(item);
            await Context.SaveChangesAsync(cancellationToken);
            return item;
        }

        protected virtual async Task<TEntity> GetItem(long itemId, CancellationToken cancellationToken)
            => await Context.Set<TEntity>().SingleAsync(definition => definition.Id == itemId, cancellationToken);

        protected virtual async Task<IEnumerable<TEntity>> GetItems(CancellationToken cancellationToken)
            => await Context.Set<TEntity>().ToArrayAsync(cancellationToken);
    }
}