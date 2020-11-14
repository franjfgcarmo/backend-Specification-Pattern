using Microsoft.EntityFrameworkCore;
using SpecPattern.Domain.Entities;
using SpecPattern.Infrastructure.Extensions;

namespace SpecPattern.Infrastructure.Data
{
    public class DbSpecPattern: DbContext, IDbSpecPattern
    {
        public DbSpecPattern(DbContextOptions<DbSpecPattern> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigurationBuilder();
            base.OnModelCreating(modelBuilder);
        }
    }
}
