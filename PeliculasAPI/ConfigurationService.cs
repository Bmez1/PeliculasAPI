namespace PeliculasAPI
{
    public static class ConfigurationService
    {
        private const string _typologicSamsungConnectionString = "TypologicSamsungDatabase";
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddDatabaseContexts();
            return services;
        }
        private static IServiceCollection AddDatabaseContexts(this IServiceCollection services)
        {
            IConfiguration configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            return services;
        }
    }
}
