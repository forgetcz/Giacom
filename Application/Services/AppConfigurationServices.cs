using Application.Interfaces;
using Infrastructure.Enums;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace Application.Services
{
    /// <summary>
    /// Full application configuration, Current setting for Configuration is XML in .NET it will be JSON
    /// </summary>
    public class AppConfigurationServices : IAppConfiguration
    {
        public IConfigurationRepository ConfigurationRepository { get; set; }

        public IConfigurationRepository ApplicationKeysRepository { get; set; }

        public AppConfigurationServices(IConfigurationRepositoryJsonConfiguration configurationRepository, IConfigurationRepositoryJsonAppKeys applicationKeysRepository)
        {
            ConfigurationRepository = configurationRepository;
            ApplicationKeysRepository = applicationKeysRepository;
        }
    }
}
