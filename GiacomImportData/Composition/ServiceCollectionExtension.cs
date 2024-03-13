
using Application.Services;
using ApplicationApplication.Interfaces;
using log4net;
using log4net.Config;

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
            //XmlConfigurator.Configure(new FileInfo("log4net.config"));
            //services.AddSingleton(LogManager.GetLogger(typeof(Program)));

            services.AddSingleton<IDataImport, DataImportService>();

            return services;
        }
    }
}
