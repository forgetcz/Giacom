using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Infrastructure.Configuration.JSON;
using Infrastructure.Data.MemoryRepository;
using Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Composition
{
    public static class IServiceCollectionExtension
    {
        /// <summary>
        /// Initial DI for Application part
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IAppConfiguration, AppConfigurationServices>();
            services.AddSingleton<IConfigurationRepositoryJsonConfiguration, JsonlWebConfig>();
            services.AddSingleton<IConfigurationRepositoryJsonAppKeys, ApplicationKeysJson>();
            services.AddSingleton<IBaseDbRepository<CrdData, long>, CrdDataRepository>();
            
            return services;
        }
    }
}
