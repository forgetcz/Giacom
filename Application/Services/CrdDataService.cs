using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Application.Services
{
    /// <summary>
    /// Compose Data repository at this moment CrdData service
    /// </summary>
    /// 
    public class CrdDataService : IDataService
    {
        private readonly IConfiguration? _appConfig;
        private readonly IBaseDbRepository<CrdData, long>? _crdRepositories;

        public IBaseDbRepository<CrdData, long> GetCrdDataRepository()
        {
            //var mainConnectionString = _appConfig!.GetConnectionString(nameof(eSqlConnectionStrings.sqlConnString));
            //_crdRepositories!.setConnectionString(mainConnectionString!);

            return _crdRepositories!;
        }

        public CrdDataService(IConfiguration? appConfig, IBaseDbRepository<CrdData, long>? cdrRepositories)
        {
            _appConfig = appConfig;
            _crdRepositories = cdrRepositories;
        }

    }
}
