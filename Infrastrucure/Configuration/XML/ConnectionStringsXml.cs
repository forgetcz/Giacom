using Infrastructure.Enums;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Configuration;

namespace Infrastructure.Configuration.XML
{
    /// <summary>
    /// Configuration keys from config
    /// </summary>
    /// 
    ///[ConfigurationRepositoryExportAttributes(eApplicationConfigurationRepositoryType.XML, eApplicationConfigurationRepositorySection.ConnectionStrings)]
    public class XmlWebConfig : IConfigurationRepository
    {
        /// <summary>
        /// Memory storage for connection strings
        /// </summary>
        private SortedList<string, string> keysValues = new SortedList<string, string>();

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
        public void LoadApplicationSection() 
        {
            /*string mainConn = ConfigurationManager.ConnectionStrings[nameof(eSqlConnectionStrings.mainConn)].ConnectionString;
            string secondConn = ConfigurationManager.ConnectionStrings[nameof(eSqlConnectionStrings.secondConn)].ConnectionString;

            keysValues.Add(nameof(eSqlConnectionStrings.mainConn), mainConn);
            keysValues.Add(nameof(eSqlConnectionStrings.secondConn), secondConn);*/
        }
    }
}
