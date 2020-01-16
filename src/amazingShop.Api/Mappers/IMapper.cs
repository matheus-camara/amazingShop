using System;

namespace amazingShop.Api.Mappers
{
    public interface IMapper<T, TResult> where T : class where TResult : class
    {
        public TResult Map(T entity);
    }
}