using ApplicationApplication.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic.FileIO;
using MongoDB.Bson;
using System.Diagnostics;
using System.Globalization;

namespace Application.Services
{

    /// <summary>
    /// Data import managed
    /// </summary>
    public class DataImportService : IDataImport
    {
        private readonly ILogger<DataImportService> _logger;
        private readonly IConfiguration? _appConfig;
        private readonly IBaseDbRepository<CrdData<ObjectId>, ObjectId>? _crdRepositories;

        public DataImportService(ILogger<DataImportService> logger, IConfiguration? appConfig, IBaseDbRepository<CrdData<ObjectId>, ObjectId>? crdRepositories)
        {
            this._logger = logger;
            _appConfig = appConfig;
            _crdRepositories = crdRepositories;
        }

        /// <summary>
        /// Parse CSV File and send it to repository
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public async Task ImportData(string filePath)
        {
            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                int counter = -1;
                while (!parser.EndOfData)
                {
                    counter++;
                    string[]? fields = parser.ReadFields();

                    Debug.WriteLine(counter.ToString());
                    if (counter == 0)
                    {
                        continue;
                    }


                    if (fields != null)
                    {
                        var caller_id = Convert.ToString(fields[0]);
                        var recipient = Convert.ToString(fields[1]);
                        var call_date = Convert.ToDateTime(fields[2]);
                        var end_time = Convert.ToDateTime(fields[3]);
                        var duration = Convert.ToInt32(fields[4]);
                        var cost = Convert.ToDecimal(fields[5], CultureInfo.InvariantCulture);
                        var reference = Convert.ToString(fields[6]);
                        var currency = Convert.ToString(fields[7]);

                        CrdData<ObjectId> crdData = new CrdData<ObjectId>(ObjectId.GenerateNewId(), caller_id, recipient, call_date, end_time, duration, cost, reference, currency);
                        _logger.LogDebug(counter.ToString());
                        await _crdRepositories!.Insert(crdData);
                    }
                }
            }
        }
    }
}
