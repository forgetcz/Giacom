using GiacomImportData.Business;

namespace GiacomImportData
{
    /// <summary>
    /// Main Data worker for data import, as data import can be long process API is not requsted here
    /// </summary>
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await CsvParser.Parse("path to file here...");
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
