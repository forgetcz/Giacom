using Domain.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Repository.EntityFramework.Mongo;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;

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
            services.AddSingleton<IBaseDbRepository<CrdData<ObjectId>, ObjectId>, CrdDataRepository>();
            
            return services;
        }
    }
}
