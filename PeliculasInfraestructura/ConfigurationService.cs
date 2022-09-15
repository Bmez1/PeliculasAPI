using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PeliculasCore.Interfaces.Repositories;
using PeliculasInfraestructura.Context;
using PeliculasInfraestructura.Repositories;

namespace PeliculasAPI
{
    public static class ConfigurationService
    {
        private const string stringConnection = "ConnectionDefault";
        public static IServiceCollection AddServicesInfraestructure(this IServiceCollection services)
        {
            services.AddDatabaseContexts();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<IActorRepository, ActorRepository>();
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
