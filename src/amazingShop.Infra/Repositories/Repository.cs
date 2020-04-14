using amazingShop.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace amazingShop.Infra.Repositories
{
    public abstract class Repository<Db, T> : IRepository<T>
        where T : class
    where Db : DbContext
    {
        protected DbContext Context { get; set; }

        protected virtual IQueryable<T> RawGet() => Context.Set<T>().AsNoTracking();

        public virtual async Task<IList<T>> GetAsync() => await RawGet().ToListAsync();

        public virtual async Task<IList<TResult>> GetAsync<TResult>(Expression<Func<T, TResult>> selector)
            => await RawGet().Select(selector).ToListAsync();

        public virtual async Task<IList<TResult>> GetAsync<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector)
            => await RawGet().Where(predicate).Select(selector).ToListAsync();

        public virtual async Task<IList<TResult>> GetAsync<TResult>(int skip, int take, Expression<Func<T, TResult>> selector)
            => await RawGet().Skip(skip).Take(take).Select(selector).ToListAsync();

        public virtual async Task<IList<TResult>> GetAsync<TResult>(int skip, int take, Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector)
            => await RawGet().Where(predicate).Skip(skip).Take(take).Select(selector).ToListAsync();

        public virtual async Task<IList<T>> GetAsync(int skip, int take)
            => await RawGet().Skip(skip).Take(take).ToListAsync();

        public virtual async Task<IList<T>> GetAsync(int skip, int take, Expression<Func<T, bool>> predicate)
            => await RawGet().Where(predicate).Skip(skip).Take(take).ToListAsync();

        public virtual async Task<IList<T>> GetAsync(Expression<Func<T, bool>> predicate)
            => await RawGet().Where(predicate).ToListAsync();

        public virtual async Task<T?> FindAsync(Expression<Func<T, bool>> predicate)
            => await RawGet().SingleOrDefaultAsync(predicate);

        public virtual async Task<T?> FindAsync(long primaryKey)
            => await Context.FindAsync<T>(primaryKey);

        public virtual async Task<TResult?> FindAsync<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector) where TResult : class
            => await RawGet().Where(predicate).Select(selector).SingleOrDefaultAsync(null);

        public virtual async Task<long> CountAsync() => await Context.Set<T>().LongCountAsync(u => 1 == 1);

        public virtual async Task<T> AddAsync(T Entity)
        {
            await Context.Set<T>().AddAsync(Entity);
            return Entity;
        }

        public virtual T Delete(T Entity)
        {
            Context.Set<T>().Remove(Entity);
            return Entity;
        }

        public virtual T Edit(T Entity)
        {
            Context.Entry(Entity).State = EntityState.Modified;
            return Entity;
        }

        public virtual async Task SaveAsync() => await Context.SaveChangesAsync();

        protected Repository(DbContext context)
        {
            Context = context;
        }
    }
}
