using Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    /// <summary>
    /// Definition of methods using for meta data attributes (JSON/XML & AppKeys/ConnectionStrings)
    /// </summary>
    public interface IAppConfigurationMefAttributes
    {
        /// <summary>
        /// Attributes definition for App config type (JOSN, XML)
        /// </summary>
        eApplicationConfigurationRepositoryType AppConfigType { get; }

        /// <summary>
        /// Attributes definition for App config section (AppKeys, ConnectionStrings)
        /// </summary>
        eApplicationConfigurationRepositorySection AppConfigSection { get; }
    }
}
