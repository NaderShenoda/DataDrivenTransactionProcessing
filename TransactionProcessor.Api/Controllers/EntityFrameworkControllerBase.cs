using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TransactionProcessor.Entities;

namespace TransactionProcessor.Api.Controllers
{
    public abstract class EntityFrameworkControllerBase<TEntity, TContext>
        where TEntity : class, IHaveId
        where TContext : DbContext
    {
        protected readonly TContext Context;

        protected EntityFrameworkControllerBase(TContext context)
            => Context = context;

        [HttpGet]
        public virtual async Task<IEnumerable<TEntity>> Get(CancellationToken cancellationToken)
            => await GetItems(cancellationToken);

        // GET api/values/5
        [HttpGet("{itemId}")]
        public virtual async Task<TEntity> Get(long itemId, CancellationToken cancellationToken)
            => await GetItem(itemId, cancellationToken);

        // POST api/values
        [HttpPost]
        public virtual async Task<TEntity> Post([FromBody] TEntity value, CancellationToken cancellationToken)
        {
            await Context.Set<TEntity>().AddAsync(value, cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);
            return value;
        }

        // PUT api/values/5
        [HttpPut("{itemId}")]
        public virtual async Task<TEntity> Put(long itemId, [FromBody] TEntity value, CancellationToken cancellationToken)
        {
            Context.Entry(value).State = EntityState.Modified;
            await Context.SaveChangesAsync(cancellationToken);
            return value;
        }

        // DELETE api/values/5
        [HttpDelete("{itemId}")]
        public virtual async Task<TEntity> Delete(long itemId, CancellationToken cancellationToken)
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
