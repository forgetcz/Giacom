using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Infrastructure.Configuration.JSON;
using Infrastructure.Data.MemoryRepository;
using Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configuration
{
    public static class IServiceCollectionExtension
    {
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
