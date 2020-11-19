
using Microsoft.EntityFrameworkCore;
using SpecPattern.Domain;
using SpecPattern.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SpecPattern.Infrastructure.Repositories
{
    public class EFRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly IDbSpecPattern _dbContext;

        public EFRepository(IDbSpecPattern dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> TableNoTracking => _dbContext.Set<T>().AsQueryable<T>().AsNoTracking();

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> AllAsync() => await _dbContext.Set<T>().AsNoTracking().ToListAsync();

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate) => await _dbContext.Set<T>().CountAsync(predicate);
        public async Task<int> CountAsync() => await _dbContext.Set<T>().CountAsync();
        public void DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);            
        }

        public async Task<IEnumerable<T>> FindAsync(GenericSpecification<T> genericSpecification) => await _dbContext.Set<T>()
            .AsQueryable()
            .Where(genericSpecification.Expression)
            .ToListAsync();

        public virtual async Task<T> GetAsync(int id) => await _dbContext.Set<T>().FindAsync(id);

        public T UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
