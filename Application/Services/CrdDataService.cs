using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Enums;
using Infrastructure.Interfaces;
using System.Diagnostics;

namespace Application.Services
{
    /// <summary>
    /// Compose Data repository at this moment CrdData service
    /// </summary>
    /// 
    public class CrdDataService : IDataService
    {
        private readonly IAppConfiguration _appConfiguration;
        private readonly IBaseDbRepository<CrdData, long> _crdRepositories;

        public IBaseDbRepository<CrdData, long> GetCrdDataRepository()
        {
            var mainConnectionString = _appConfiguration.ConfigurationRepository.GetKeyValue(nameof(eSqlConnectionStrings.mainConn));
            _crdRepositories.setConnectionString(mainConnectionString);

            return _crdRepositories;
        }

        public CrdDataService(IAppConfiguration appConfiguration, IBaseDbRepository<CrdData, long> cdrRepositories)
        {
            _appConfiguration = appConfiguration;
            _crdRepositories = cdrRepositories;
        }

    }
}
