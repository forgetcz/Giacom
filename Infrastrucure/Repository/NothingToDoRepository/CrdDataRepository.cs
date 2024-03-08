using Domain.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Repository.NothingToDoRepository
{

    public class CrdDataRepository : IBaseDbRepository<CrdData, long>
    {
        public Task Delete(CrdData entity)
        {
            return Task.FromResult(entity);
        }

        public Task DeleteMany(IEnumerable<CrdData> entities)
        {
            return Task.CompletedTask;
        }

        public Task<CrdData?> GetById(long id)
        {
            return Task.FromResult<CrdData?>(new CrdData(0, "", "", DateTime.MinValue, DateTime.MinValue, 0, 0, "", ""));
        }

        public Task<CrdData> Insert(CrdData entity)
        {
            return Task.FromResult(entity);
        }

        public Task<IEnumerable<CrdData>> InsertMany(IEnumerable<CrdData> entities)
        {
            return Task.FromResult(entities);
        }

        public Task<IEnumerable<CrdData>> TakeRange(int skip, int count)
        {
            throw new NotImplementedException();
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