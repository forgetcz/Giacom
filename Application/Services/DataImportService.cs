using Application.Interfaces;
using ApplicationApplication.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;
using System.Globalization;

namespace Application.Services
{

    /// <summary>
    /// Data import managed
    /// </summary>
    public class DataImportService : IDataImport
    {
        private readonly IAppConfiguration _appConfiguration;
        private readonly IBaseDbRepository<CrdData, long> _crdRepositories;

        public DataImportService(IAppConfiguration appConfiguration, IBaseDbRepository<CrdData, long> crdRepositories)
        {
            _appConfiguration = appConfiguration;
            _crdRepositories = crdRepositories;
        }

        /// <summary>
        /// Parse CSV File and send it to repository
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public async Task ImportData(string filePath)
        {
            var connString = _appConfiguration.ConnectionStringsRepository.GetKeyValue("mainConn");
            _crdRepositories.setConnectionString(connString);

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

                        CrdData crdData = new CrdData(counter, caller_id, recipient, call_date, end_time, duration, cost, reference, currency);
                        await _crdRepositories.Insert(crdData);
                    }
                }
            }
        }
    }
}
