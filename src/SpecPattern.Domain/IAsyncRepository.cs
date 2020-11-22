using SpecPattern.Domain.Spedifications;
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
        Task<T> GetAsNoTrackingAsync(int id);
        Task<IReadOnlyList<T>> AllAsync();
        Task<IReadOnlyList<T>> FindAsync(Specification<T> specification);
        Task<int> CountAsync(Specification<T> specification);
        Task<int> CountAsync();
    }
}
