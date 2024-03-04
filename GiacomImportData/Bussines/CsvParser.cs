using Domain.Entities;
using Infrastructure.Data.SqlRepository;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GiacomImportData.Business
{
    internal class CsvParser
    {
        public static async Task Parse(string path)
        {
            CrdDataRepository crdDataRepository = new();
            crdDataRepository.setConnectionString("sql conn string here ");
            using (TextFieldParser parser = new TextFieldParser(path))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string[]? fields = parser.ReadFields();
                    if (fields != null)
                    {
                        CrdData crdData = new CrdData(Convert.ToInt32(fields[0]), Convert.ToString(fields[1])
                            , Convert.ToString(fields[2]), Convert.ToDateTime(fields[3]), Convert.ToDateTime(fields[4])
                            , Convert.ToInt32(fields[5]), Convert.ToInt32(fields[6]), Convert.ToString(fields[7]), Convert.ToString(fields[8]));
                        await crdDataRepository.Insert(crdData);
                    }
                }
            }
        }
    }
}
