using Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Configuration.JSON
{
    /// <summary>
    /// Application Keys from config
    /// </summary>
    public class ApplicationKeysJson : IConfigurationRepositoryJsonAppKeys
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
        /// Read all application strings from appsettings.json by JSON configuration
        /// </summary>
        /// <returns></returns>
        public ApplicationKeysJson()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile(AppDomain.CurrentDomain.BaseDirectory + "appsettings.json", optional: true).Build();
            var appSettings = configuration.GetSection("appSettings");

            foreach (var item in appSettings.GetChildren())
            {
                if (item?.Value?.GetType() == typeof(string))
                {
                    keysValues.Add(item.Key, item.Value);
                }
            }
        }
    }
}
