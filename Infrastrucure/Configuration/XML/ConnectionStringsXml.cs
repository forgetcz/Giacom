using Infrastructure.Interfaces;
using System.Configuration;

namespace Infrastructure.Configuration.XML
{
    /// <summary>
    /// Configuration keys from config
    /// </summary>
    public class XmlWebConfig : IConfigurationRepository
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
        public XmlWebConfig() 
        {
            var connectionStrings = ConfigurationManager.ConnectionStrings;

            if (connectionStrings != null)
            {
                foreach (var connectionString in connectionStrings)
                {
                    if ((connectionString != null) && (connectionString is ConnectionStringSettings))
                    {
                        var connectionStringValue = connectionString as ConnectionStringSettings;
                        if (connectionStringValue != null)
                        {
                            keysValues.Add(connectionStringValue.Name, connectionStringValue.ConnectionString);
                        }
                    }
                }
            }
        }
    }
}
