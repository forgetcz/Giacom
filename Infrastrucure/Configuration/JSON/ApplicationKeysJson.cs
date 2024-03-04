using Infrastructure.Enums;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;

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
        /// Read all connection strings from appsettings.json by XML configuration
        /// </summary>
        /// <returns></returns>
        public ApplicationKeysJson()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile(AppDomain.CurrentDomain.BaseDirectory + "appsettings.json", optional: true).Build();
            var appSettings = configuration.GetSection("appSettings");

            string myPrivateSettings1 = appSettings.GetSection(nameof(eApplicationKeys.myPrivateSettings1)).Value;
            string myPrivateSettings2 = appSettings.GetSection(nameof(eApplicationKeys.myPrivateSettings2)).Value;

            keysValues.Add(nameof(eApplicationKeys.myPrivateSettings1), myPrivateSettings1);
            keysValues.Add(nameof(eApplicationKeys.myPrivateSettings2), myPrivateSettings2);
        }
    }
}
