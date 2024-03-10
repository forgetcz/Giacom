using Domain.Entities;
using Infrastructure.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    /// <summary>
    /// Definition of CrdData
    /// </summary>
    public interface IDataService
    {
        IBaseDbRepository<CrdData<ObjectId>, ObjectId> GetCrdDataRepository();
    }
}
