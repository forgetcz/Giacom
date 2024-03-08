using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Business
{
    public class CreateLogger
    {
        /// <summary>
        /// Create logger where ever it is possible
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static ILogger GetLogger<T>()
        {
            var serviceProvider = new ServiceCollection()
            .AddLogging(cfg => cfg.AddConsole())
            .BuildServiceProvider();

            ILogger logger = serviceProvider!.GetService<ILogger<T>>();
            return logger;
        }
    }
}
