using Infrastructure.Enums;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Configuration.JSON
{
    /// <summary>
    /// Configuration keys from config
    /// </summary>
    /// 
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
        /// Read all connection strings from appsettings.json by configuration
        /// </summary>
        /// <returns></returns>
        public JsonlWebConfig()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile(AppDomain.CurrentDomain.BaseDirectory + "appsettings.json", optional: true).Build();
            var appSettings = configuration.GetSection("connectionStrings");

            string mainConn = appSettings.GetSection(nameof(eSqlConnectionStrings.mainConn)).Value;

            keysValues.Add(nameof(eSqlConnectionStrings.mainConn), mainConn);
        }
    }
}
