using Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Configuration.JSON
{
    /// <summary>
    /// ConnectionStrings keys from config
    /// </summary>
    public class JsonlWebConfig : IConfigurationRepositoryJsonConfiguration
    {
        /// <summary>
        /// Memory storage for connection strings
        /// </summary>
        private readonly SortedList<string, string> keysValues = new SortedList<string, string>();

        /// <summary>
        /// Get requested connection string form storage
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetKeyValue(string key)
        {
            return keysValues[key];
        }

        /// <summary>
        /// Read all connection strings from appsettings.json by JSON configuration
        /// </summary>
        /// <returns></returns>
        public JsonlWebConfig()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile(AppDomain.CurrentDomain.BaseDirectory + "appsettings.json", optional: true).Build();
            var connectionStrings = configuration.GetSection("connectionStrings");

            foreach (var item in connectionStrings.GetChildren())
            {
                if (item?.Value?.GetType() ==  typeof(string))
                {
                    keysValues.Add(item.Key, item.Value);
                }
            }
        }
    }
}
