using ApplicationApplication.Interfaces;

namespace GiacomImportData
{
    /// <summary>
    /// Main Data worker for data import, as data import can be long process API is not requsted here
    /// </summary>
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IDataImport _dataImportService;
        private readonly IConfiguration? _appConfig;

        public Worker(ILogger<Worker> logger, IDataImport dataImportService, IConfiguration? appConfig)
        {
            _logger = logger;
            _dataImportService = dataImportService;
            _appConfig = appConfig;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                var filePath = _appConfig!.GetSection("appSettings:filePath").Value;
                await _dataImportService.ImportData(filePath!);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
