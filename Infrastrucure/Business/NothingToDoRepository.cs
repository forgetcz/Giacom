using Domain.Interfaces;
using Infrastructure.Interfaces;

namespace Infrastructure.Business
{

    /// <summary>
    /// NothingToDoRepository just do nothing
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="K"></typeparam>
    public class NothingToDoRepository<T, K> : IBaseDbRepository<T, K>
        where T : IBaseEntity<K>
        where K : struct,
          IComparable,
          IComparable<K>,
          IEquatable<K>,
          IFormattable
    {
        public Task<K> Delete(K entity)
        {
            return Task.FromResult(entity);
        }

        public Task DeleteMany(IEnumerable<K> entities)
        {
            return Task.CompletedTask;
        }

        public Task<T> Insert(T entity)
        {
            return Task.FromResult(entity);
        }

        public Task<IEnumerable<T>> InsertMany(IEnumerable<T> entities)
        {
            return Task.FromResult(entities);
        }

        public Task<IEnumerable<T>> ReadAll()
        {
            List<T> entities = new();
            return Task.FromResult(entities.AsEnumerable());
        }

        public Task<T> GetById(K id)
        {
            return Task.FromResult(default(T));
        }

        public Task<T> Update(T entity)
        {
            return Task.FromResult(entity);
        }

        public async Task<IEnumerable<T>> UpdateMany(IEnumerable<T> entities)
        {
            return new List<T>();
        }

        public void setConnectionString(string connectionString)
        {
        }
    }
}
