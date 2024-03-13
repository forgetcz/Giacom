using ApplicationApplication.Interfaces;

namespace GiacomImportData
{
    /// <summary>
    /// Main Data worker for data import, as data import can be long process API is not requsted here
    /// </summary>
    public class Worker(ILogger<Worker> logger, IDataImport dataImportService, IConfiguration? appConfig) : BackgroundService
    {
        private readonly ILogger<Worker> _logger = logger;
        //private readonly ILog _logger4Net = logger4Net;
        private readonly IDataImport _dataImportService = dataImportService;
        private readonly IConfiguration? _appConfig = appConfig;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogDebug("LogDebug Start");
                _logger.LogInformation("LogInformation Start");
                _logger.LogWarning("LogWarning Start");
                _logger.LogError("LogError Start");
                _logger.LogCritical("LogCritical Start");
                //_logger4Net.Info(string.Format("Worker running at: {time}", DateTimeOffset.Now));

                var filePath = _appConfig!.GetSection("appSettings:filePath").Value;
                //await _dataImportService.ImportData(filePath!);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
