
using Microsoft.EntityFrameworkCore;
using SpecPattern.Domain;
using SpecPattern.Domain.Entities;
using SpecPattern.Domain.Spedifications;
using SpecPattern.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SpecPattern.Infrastructure.Repositories
{
    public class EFRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly IDbSpecPattern _dbContext;

        public EFRepository(IDbSpecPattern dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<IReadOnlyList<T>> AllAsync() => await _dbContext.Set<T>().AsNoTracking().ToListAsync();

        public async Task<int> CountAsync(Specification<T> specification) => await _dbContext.Set<T>().CountAsync(specification.ToExpresion());
        public async Task<int> CountAsync() => await _dbContext.Set<T>().CountAsync();
        public void DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);            
        }

        public async Task<IReadOnlyList<T>> FindAsync(Specification<T> specification) => await _dbContext.Set<T>()
            .AsQueryable()
            .Where(specification.ToExpresion())
            .ToListAsync();

        public async Task<T> GetAsNoTrackingAsync(int id) => await _dbContext.Set<T>()
            .AsNoTracking()
            .FirstOrDefaultAsync(w=>w.Id ==  id);

        public virtual async Task<T> GetAsync(int id) => await _dbContext.Set<T>().FindAsync(id);

        public T UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
