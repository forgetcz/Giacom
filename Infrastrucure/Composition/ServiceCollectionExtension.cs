using Domain.Entities;
using Infrastructure.Business;
using Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Composition
{
    public static class IServiceCollectionExtension
    {
        /// <summary>
        /// Initial DI for Application part
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            //services.AddSingleton<IMongoConnectionSettings, MongoConnectionSettings>();
            return services;
        }
    }
}
