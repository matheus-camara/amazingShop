using amazingShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace amazingShop.Domain.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<IList<T>> GetAsync();

        Task<IList<TResult>> GetAsync<TResult>(Expression<Func<T, TResult>> selector);

        Task<IList<TResult>> GetAsync<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector);

        Task<IList<TResult>> GetAsync<TResult>(int skip, int take, Expression<Func<T, TResult>> selector);

        Task<IList<TResult>> GetAsync<TResult>(int skip, int take, Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector);


        Task<IList<T>> GetAsync(int skip, int take);

        Task<IList<T>> GetAsync(Expression<Func<T, bool>> predicate);

        Task<IList<T>> GetAsync(int skip, int take, Expression<Func<T, bool>> predicate);

        Task<T> FindAsync(Expression<Func<T, bool>> predicate);

        Task<T> FindAsync(long primaryKey);

        Task<TResult> FindAsync<TResult>(long primaryKey, Expression<Func<T, TResult>> selector);

        Task<TResult> FindAsync<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector);

        Task<long> CountAsync();

        Task<T> AddAsync(T entity);

        T Delete(T entity);

        T Edit(T entity);

        void SaveAsync();
    }
}
