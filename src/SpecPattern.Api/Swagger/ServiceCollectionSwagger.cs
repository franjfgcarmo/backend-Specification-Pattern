using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace SpecPattern.Api.Swagger
{
    public static class ServiceCollectionSwagger
    {
        private static IServiceCollection AddApiVersion(this IServiceCollection services)
        {
            services.AddApiVersioning(
              options =>
              {
                  // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
                  options.ReportApiVersions = true;
              });

            services.AddVersionedApiExplorer(
                options =>
                {
                    // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                    // note: the specified format code will format the version as "'v'major[.minor][-status]"
                    options.GroupNameFormat = "'v'VVV";

                    // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                    // can also be used to control the format of the API version in route templates
                    options.SubstituteApiVersionInUrl = true;
                });
            services.AddVersionedApiExplorer(options => options.GroupNameFormat = "'v'VVV");

            return services;
        }
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddApiVersion();
            //https://github.com/microsoft/aspnet-api-versioning/blob/master/samples/aspnetcore/SwaggerSample/Startup.cs
            //https://github.com/microsoft/aspnet-api-versioning/wiki/API-Documentation
            //https://dejanstojanovic.net/aspnet/2018/november/setting-up-swagger-to-support-versioned-api-endpoints-in-aspnet-core/  
            var openApiInfo = new OpenApiInfo
            {
                Title = "SpecPattern.Api",
                Description = "SpecPattern.Api",
            };
            // Resolve the temprary IApiVersionDescriptionProvider service  
            var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

            services.AddSwaggerGen(s =>
            {

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    openApiInfo.Version = description.ApiVersion.ToString();
                    s.SwaggerDoc(description.GroupName, openApiInfo);
                }
            });
            return services;
        }
    }
}
