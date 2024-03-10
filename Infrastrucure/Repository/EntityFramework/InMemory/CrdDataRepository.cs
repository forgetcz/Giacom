using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace Infrastructure.Repository.EntityFramework.InMemory
{
    public class CrdDataRepository : IBaseDbRepository<CrdData<long>, long>
    {
        private EntityFrameworkRepository Context { get; } = new EntityFrameworkRepository(null);

        private DbSet<CrdData<long>> CrdDataDb
        {
            get
            {
                return Context.CrdData!;
            }
        }

        public CrdDataRepository(IConfiguration? appConfig)
        {
            for (int x = 1; x < 11; x++)
            {
                var data = new CrdData<long>(x, x.ToString(), x.ToString(), DateTime.Now, DateTime.Now, x, x, "", "");
                var newData = CrdDataDb.Add(data);
                Debug.WriteLine(newData);
            }
            Context.SaveChanges();
        }

        public async Task Delete(CrdData<long> entity)
        {
            var r = CrdDataDb.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteMany(IEnumerable<CrdData<long>> entities)
        {
            foreach (var entity in entities)
            {
                await Delete(entity);
            }
        }

        public async Task<CrdData<long>?> GetById(long id)
        {
            var result = await CrdDataDb.FirstOrDefaultAsync(f => f.Id == id);
            return result;
        }

        public async Task<CrdData<long>> Insert(CrdData<long> entity)
        {
            await CrdDataDb.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<CrdData<long>>> InsertMany(IEnumerable<CrdData<long>> entities)
        {
            List<CrdData<long>> result = new();
            foreach (var entity in entities)
            {
                var newItem = await Insert(entity);
                result.Add(newItem);
            }
            return result;
        }

        public async Task<IEnumerable<CrdData<long>>> TakeRange(int skip, int count)
        {
            var result = await CrdDataDb.Skip(skip).Take(count).ToListAsync();
            return result!;
        }

        public async Task<CrdData<long>> Update(CrdData<long> entity)
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

        public async Task<IEnumerable<CrdData<long>>> UpdateMany(IEnumerable<CrdData<long>> entities)
        {
            List<CrdData<long>> result = new();
            foreach (var entity in entities)
            {
                var newItem = await Update(entity);
                result.Add(newItem);
            }
            return result;
        }
    }
}
