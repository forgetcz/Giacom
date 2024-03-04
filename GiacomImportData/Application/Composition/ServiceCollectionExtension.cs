
using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using GiacomImportData.Application.Services;
using Infrastructure.Data.MemoryRepository;
using Infrastructure.Interfaces;

namespace GiacomImportData.Application.Composition
{
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Initial DI for Application part
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddImportDataServices(this IServiceCollection services)
        {
            services.AddSingleton<IAppConfiguration, AppConfigurationServices>();
            services.AddSingleton<IBaseDbRepository<CrdData, long>, CrdDataRepository>();
            services.AddSingleton<IDataImport, DataImportService>();


            return services;
        }
    }
}
