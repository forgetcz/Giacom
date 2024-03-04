using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    /// <summary>
    /// Definition of application configuration
    /// </summary>
    public interface IAppConfiguration
    {
        IConfigurationRepository ConfigurationRepository { get; }
        IConfigurationRepository ApplicationKeysRepository { get; }
    }
}
