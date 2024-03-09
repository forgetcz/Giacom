
using Application.Services;
using ApplicationApplication.Interfaces;

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
            services.AddSingleton<IDataImport, DataImportService>();

            return services;
        }
    }
}
