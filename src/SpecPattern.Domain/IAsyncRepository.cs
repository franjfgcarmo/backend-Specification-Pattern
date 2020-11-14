using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SpecPattern.Domain
{
    public interface IAsyncRepository<T>
    {
        Task<T> AddAsync(T entity);
        T UpdateAsync(T entity);
        void DeleteAsync(T entity);
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> AllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync();
        IQueryable<T> TableNoTracking { get; }
    }
}
