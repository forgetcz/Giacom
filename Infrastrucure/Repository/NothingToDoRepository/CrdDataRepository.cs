using Domain.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Data.NothingToDoRepository
{

    public class CrdDataRepository : IBaseDbRepository<CrdData, long>
    {
        public Task<long> Delete(long entity)
        {
            return Task.FromResult(entity);
        }

        public Task DeleteMany(IEnumerable<long> entities)
        {
            return Task.CompletedTask;
        }

        public Task<CrdData> GetById(long id)
        {
            return Task.FromResult(new CrdData(0, "", "", DateTime.MinValue, DateTime.MinValue, 0, 0, "", ""));
        }
        public Task<CrdData> Insert(CrdData entity)
        {
            return Task.FromResult(entity);
        }

        public Task<IEnumerable<CrdData>> InsertMany(IEnumerable<CrdData> entities)
        {
            return Task.FromResult(entities);
        }

        public Task<IEnumerable<CrdData>> ReadAll()
        {
            List<CrdData> entities = new();
            return Task.FromResult(entities.AsEnumerable());
        }

        public void setConnectionString(string connectionString)
        {
        }

        public Task<CrdData> Update(CrdData entity)
        {
            return Task.FromResult(entity);
        }

        public Task<IEnumerable<CrdData>> UpdateMany(IEnumerable<CrdData> entities)
        {
            return Task.FromResult(entities);
        }
    }
}