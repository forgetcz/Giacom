
using Application.Interfaces;
using Application.Services;
using ApplicationApplication.Interfaces;
using Domain.Entities;
using Infrastructure.Data.MemoryRepository;
using Infrastructure.Interfaces;

namespace GiacomImportData.Application.Composition
{
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Initial DI for Import data part, do not forget composition for other part as well !
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
