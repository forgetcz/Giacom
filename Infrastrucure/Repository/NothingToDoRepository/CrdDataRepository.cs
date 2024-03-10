using Domain.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Repository.NothingToDoRepository
{

    public class CrdDataRepository : IBaseDbRepository<CrdData<long>, long>
    {
        public Task Delete(CrdData<long> entity)
        {
            return Task.FromResult(entity);
        }

        public Task DeleteMany(IEnumerable<CrdData<long>> entities)
        {
            return Task.CompletedTask;
        }

        public Task<CrdData<long>?> GetById(long id)
        {
            return Task.FromResult<CrdData<long>?>(new CrdData<long>(0, "", "", DateTime.MinValue, DateTime.MinValue, 0, 0, "", ""));
        }

        public Task<CrdData<long>> Insert(CrdData<long> entity)
        {
            return Task.FromResult(entity);
        }

        public Task<IEnumerable<CrdData<long>>> InsertMany(IEnumerable<CrdData<long>> entities)
        {
            return Task.FromResult(entities);
        }

        public Task<IEnumerable<CrdData<long>>> TakeRange(int skip, int count)
        {
            throw new NotImplementedException();
        }

        public Task<CrdData<long>> Update(CrdData<long> entity)
        {
            return Task.FromResult(entity);
        }

        public Task<IEnumerable<CrdData<long>>> UpdateMany(IEnumerable<CrdData<long>> entities)
        {
            return Task.FromResult(entities);
        }
    }
}