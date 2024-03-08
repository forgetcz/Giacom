using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Enums
{
    /// <summary>
    /// Enum defined names fpr sql connection strings
    /// </summary>
    public enum eDbConnectionStrings
    {
        sqlConnString, mongoConn
    }

    /// <summary>
    /// Application configuration files
    /// </summary>
    public enum eConfigurationFile
    {
        [Description("appsettings.json")]
        json,
        [Description("App.config")]
        xml
    }
}
