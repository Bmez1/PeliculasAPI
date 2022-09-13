using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PeliculasInfraestructura.Context;

namespace PeliculasAPI
{
    public static class ConfigurationService
    {
        private const string stringConnection = "ConnectionDefault";
        public static IServiceCollection AddServicesInfraestructure(this IServiceCollection services)
        {
            services.AddDatabaseContexts();
            return services;
        }
        private static IServiceCollection AddDatabaseContexts(this IServiceCollection services)
        {
            IConfiguration configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(configuration.GetConnectionString(stringConnection)));
            return services;
        }
    }
}
