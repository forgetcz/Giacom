using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiacomImportData.Application.Services
{
    /// <summary>
    /// Import data managed for file
    /// </summary>
    public interface IDataImport
    {
        Task ImportData(string filePath);
    }
}
