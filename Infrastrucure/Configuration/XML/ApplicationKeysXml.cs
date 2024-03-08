using Infrastructure.Interfaces;
using System.Configuration;
using System.Diagnostics;

namespace Infrastructure.Configuration.XML
{
    /// <summary>
    /// Application Keys from config
    /// </summary>
    public class ApplicationKeysXml : IConfigurationRepository
    {
        /// <summary>
        /// Memory storage for connection strings
        /// </summary>
        private readonly SortedList<string, string> keysValues = new();

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
        /// Read all connection strings from web-config by XML configuration
        /// </summary>
        /// <returns></returns>
        public ApplicationKeysXml()
        {
            var keys = ConfigurationManager.AppSettings.AllKeys;

            if (keys != null)
            {
                foreach (var key in keys)
                {
                    if (key != null)
                    {
                        string? value = ConfigurationManager.AppSettings[key];
                        keysValues.Add(key, value ?? "");
                    }
                }
            }
        }
    }
}
