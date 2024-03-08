using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    /// <summary>
    /// Repository definition for Configuration (GetKeyValue)
    /// </summary>
    public interface IConfigurationRepository
    {
        /// <summary>
        /// Return value from config section 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetKeyValue(string key);
    }

    public interface IConfigurationRepositoryJsonAppKeys : IConfigurationRepository { }
    public interface IConfigurationRepositoryJsonConfiguration : IConfigurationRepository  { }
}
