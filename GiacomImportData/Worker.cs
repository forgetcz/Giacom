using Application.Interfaces;
using GiacomImportData.Application.Services;

namespace GiacomImportData
{
    /// <summary>
    /// Main Data worker for data import, as data import can be long process API is not requsted here
    /// </summary>
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IDataImport _dataImportService;
        private readonly IAppConfiguration _appConfiguration;

        public Worker(ILogger<Worker> logger, IDataImport dataImportService, IAppConfiguration appConfiguration)
        {
            _logger = logger;
            _dataImportService = dataImportService;
            _appConfiguration = appConfiguration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                var filePath = _appConfiguration.AppKeysRepository.GetKeyValue("filePath");
                await _dataImportService.ImportData(filePath);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
