using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpecPattern.Domain;
using SpecPattern.Infrastructure.Data;
using SpecPattern.Infrastructure.Repositories;
using SpecPattern.Infrastructure.UnitOfWork;

namespace SpecPattern.Api.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<DbSpecPattern>(c =>
                c.UseNpgsql(configuration.GetValue<string>("Settings:ConnectionString")).UseSnakeCaseNamingConvention());
            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EFRepository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            return services;
        }
    }
}
