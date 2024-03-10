using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;

namespace Application.Services
{
    /// <summary>
    /// Compose Data repository at this moment CrdData service
    /// </summary>
    /// 
    public class CrdDataService : IDataService
    {
        private readonly IConfiguration? _appConfig;
        private readonly IBaseDbRepository<CrdData<ObjectId>, ObjectId>? _crdRepositories;

        public IBaseDbRepository<CrdData<ObjectId>, ObjectId> GetCrdDataRepository()
        {
            //var mainConnectionString = _appConfig!.GetConnectionString(nameof(eSqlConnectionStrings.sqlConnString));
            //_crdRepositories!.setConnectionString(mainConnectionString!);

            return _crdRepositories!;
        }

        public CrdDataService(IConfiguration? appConfig, IBaseDbRepository<CrdData<ObjectId>, ObjectId>? cdrRepositories)
        {
            _appConfig = appConfig;
            _crdRepositories = cdrRepositories;
        }

    }
}
