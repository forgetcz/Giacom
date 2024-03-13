using Domain.Entities;
using Infrastructure.Business;
using Infrastructure.Interfaces;
using log4net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using System.Configuration;
using System.Diagnostics;

namespace Infrastructure.Data.Repository.EntityFramework.Mongo
{
    public class CrdDataRepository : IBaseDbRepository<CrdData<ObjectId>, ObjectId>
    {
        private ILogger<CrdDataRepository> _logger;
        private readonly ILog? _logger4Net;
        //private ILogger _logger { get; } = CreateLogger.GetLogger<CrdDataRepository>();

        private readonly IConfiguration? appConfig;
        private EntityFrameworkRepository Context { get; }

        private DbSet<CrdData<ObjectId>> CrdDataDb
        {
            get
            {
                return Context.CrdDatas!;
            }
        }

        public CrdDataRepository(IConfiguration? appConfig)
        {
            //_logger = logger;
            //_logger4Net = logger4Net;
            Context = new EntityFrameworkRepository(appConfig);

            /*
             *             int count = CrdDataDb.Count();
            _logger4Net.Debug(count.ToString());

             * 
             * if (count == 0) 
            {
                for (int x = 1; x < 11; x++)
                {
                    var data = new CrdData(x, x.ToString(), x.ToString(), DateTime.Now, DateTime.Now, x, x, "", "");
                    var newData = CrdDataDb.Add(data);
                    Debug.WriteLine(newData);
                }
                Context.SaveChanges();
            }*/
        }

        public async Task Delete(CrdData<ObjectId> entity)
        {
            var r = CrdDataDb.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteMany(IEnumerable<CrdData<ObjectId>> entities)
        {
            foreach (var entity in entities)
            {
                await Delete(entity);
            }
        }

        public async Task<CrdData<ObjectId>?> GetById(ObjectId id)
        {
            var result = await CrdDataDb.FirstOrDefaultAsync(f => f.Id.Equals(id));
            return result;
        }

        public async Task<CrdData<ObjectId>> Insert(CrdData<ObjectId> entity)
        {
            await CrdDataDb.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<CrdData<ObjectId>>> InsertMany(IEnumerable<CrdData<ObjectId>> entities)
        {
            List<CrdData<ObjectId>> result = new();
            foreach (var entity in entities)
            {
                var newItem = await Insert(entity);
                result.Add(newItem);
            }
            return result;
        }

        public async Task<IEnumerable<CrdData<ObjectId>>> TakeRange(int skip, int count)
        {
            var result = await CrdDataDb.Skip(skip).Take(count).ToListAsync();
            return result!;
        }

        public async Task<CrdData<ObjectId>> Update(CrdData<ObjectId> entity)
        {
            var result = await GetById(entity.Id);
            if (result != null)
            {
                var entry = Context.Entry(result);
                entry.CurrentValues.SetValues(entity);
                entry.State = EntityState.Modified;
                CrdDataDb.Update(entity);
                await Context.SaveChangesAsync();
            }
            return entity;
        }

        public async Task<IEnumerable<CrdData<ObjectId>>> UpdateMany(IEnumerable<CrdData<ObjectId>> entities)
        {
            List<CrdData<ObjectId>> result = new();
            foreach (var entity in entities)
            {
                var newItem = await Update(entity);
                result.Add(newItem);
            }
            return result;
        }
    }
}
