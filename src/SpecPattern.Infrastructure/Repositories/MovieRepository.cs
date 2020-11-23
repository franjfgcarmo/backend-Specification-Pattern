using Microsoft.EntityFrameworkCore;
using SpecPattern.Domain.Entities;
using SpecPattern.Domain.Spedifications;
using SpecPattern.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecPattern.Infrastructure.Repositories
{
    public class MovieRepository : EFRepository<Movie>
    {
        public MovieRepository(IDbSpecPattern dbContext) : base(dbContext)
        {
        }
        /*
         * You don´t have to represent all your search or validation capabilities as specifications.
         */
        public async Task<IReadOnlyList<Movie>> FindAsync(
            Specification<Movie> specification,
            double minimunRating,
            int page = 0,
            int pageSize = 4) => await _dbContext.Set<Movie>()
            .AsQueryable()
            .AsNoTracking()
            .Include(i=>i.Director)
            .Where(specification.ToExpression())
            .Where(w=> w.Rating >= minimunRating)
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToListAsync();

    }
}
