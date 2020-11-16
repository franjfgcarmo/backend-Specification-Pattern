using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecPattern.Infrastructure.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DbSpecPattern>
    {
        public DbSpecPattern CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DbSpecPattern>();
            builder.UseNpgsql("Server=127.0.0.1;port=5432;Database=spect_pattern;User Id=spect_pattern_user;Password=spect_pattern_user!;Persist Security Info=true;").UseSnakeCaseNamingConvention();
            return new DbSpecPattern(builder.Options);
        }
    }
}
