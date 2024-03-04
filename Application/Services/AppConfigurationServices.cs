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
        public IConfigurationRepository ConnectionStringsRepository { get; set; }

        public IConfigurationRepository AppKeysRepository { get; set; }

        public AppConfigurationServices(IConfigurationRepositoryJsonConfiguration configurationRepository, IConfigurationRepositoryJsonAppKeys applicationKeysRepository)
        {
            ConnectionStringsRepository = configurationRepository;
            AppKeysRepository = applicationKeysRepository;
        }
    }
}
