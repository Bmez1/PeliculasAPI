using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PeliculasCore.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore
{
    public static class ConfigurationService
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddMappingProfileServices();

            return services;
        }

        private static IServiceCollection AddMappingProfileServices(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new GenderMappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
