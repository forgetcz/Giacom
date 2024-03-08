using Domain.Entities;
using Infrastructure.Business;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Configuration;
using System.Diagnostics;

namespace Infrastructure.Repository.EntityFramework.Mongo
{
    public class CrdDataRepository : IBaseDbRepository<CrdData, long>
    {
        private ILogger _logger { get; } = CreateLogger.GetLogger<CrdDataRepository>();
        
        private readonly IConfiguration? appConfig;
        private EntityFrameworkRepository Context { get; }

        private DbSet<CrdData> CrdDataDb
        {
            get
            {
                return Context.CrdData!;
            }
        }

        public CrdDataRepository(IConfiguration? appConfig)
        {
            Context = new EntityFrameworkRepository(appConfig);
            int count = CrdDataDb.Count();
            _logger.LogError(count.ToString());

            /*if (count == 0) 
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

        public async Task Delete(CrdData entity)
        {
            var r = CrdDataDb.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteMany(IEnumerable<CrdData> entities)
        {
            foreach (var entity in entities)
            {
                await Delete(entity);
            }
        }

        public async Task<CrdData?> GetById(long id)
        {
            var result = await CrdDataDb.FirstOrDefaultAsync(f => f.Id == id);
            return result;
        }

        public async Task<CrdData> Insert(CrdData entity)
        {
            await CrdDataDb.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<CrdData>> InsertMany(IEnumerable<CrdData> entities)
        {
            List<CrdData> result = new();
            foreach (var entity in entities)
            {
                var newItem = await Insert(entity);
                result.Add(newItem);
            }
            return result;
        }

        public async Task<IEnumerable<CrdData>> TakeRange(int skip, int count)
        {
            var result = await CrdDataDb.Skip(skip).Take(count).ToListAsync();
            return result!;
        }

        public async Task<CrdData> Update(CrdData entity)
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

        public async Task<IEnumerable<CrdData>> UpdateMany(IEnumerable<CrdData> entities)
        {
            List<CrdData> result = new();
            foreach (var entity in entities)
            {
                var newItem = await Update(entity);
                result.Add(newItem);
            }
            return result;
        }
    }
}
