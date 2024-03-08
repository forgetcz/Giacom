using Domain.Interfaces;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Business
{

    /// <summary>
    /// Memory repository, don't use IConvertible as GUID can't be used as 'K'
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="K"></typeparam>
    public class MemoryRepository<T, K> : IBaseDbRepository<T, K>
        where T : IBaseEntity<K>
        where K : struct,
          IComparable,
          IComparable<K>,
          IEquatable<K>,
          IFormattable
    {
        private readonly SortedList<K, T> storage = new();

        public Task<K> Delete(K entity)
        {
            if (storage.Remove(entity))
            {
                entity = default;
            }
            return Task.FromResult(entity);
        }

        public async Task DeleteMany(IEnumerable<K> entities)
        {
            foreach (var entity in entities)
            {
                await Delete(entity);
            }
        }

        public Task<T> Insert(T entity)
        {
            storage.Add(entity.Id, entity);
            return Task.FromResult(entity);
        }

        public async Task<IEnumerable<T>> InsertMany(IEnumerable<T> entities)
        {
            List<T> result = new List<T>();
            foreach (var entity in entities)
            {
                var updatedEntity = await Insert(entity);
                result.Add(updatedEntity);
            }
            return result;
        }

        public Task<IEnumerable<T>> ReadAll()
        {
            return Task.FromResult(storage.Values.AsEnumerable());
        }

        public Task<T?> GetById(K id)
        {
            if (storage.ContainsKey(id))
            {
                var entity = storage[id];
                return Task.FromResult<T?>(entity);
            }
            return Task.FromResult(default(T));
        }

        public Task<T> Update(T entity)
        {
            if (storage.ContainsKey(entity.Id))
            {
                storage[entity.Id] = entity;
            }
            return Task.FromResult(entity);
        }

        public async Task<IEnumerable<T>> UpdateMany(IEnumerable<T> entities)
        {
            List<T> result = new List<T>();
            foreach (var entity in entities)
            {
                var res = await Update(entity);
                result.Add(res);
            }
            return result;
        }

        public Task<IEnumerable<T>> TakeRange(int skip, int count)
        {
            var items = storage.Skip(skip).Take(count).ToList();
            var result = new List<T>();
            items.ForEach(f => result.Add(f.Value));
            return Task.FromResult(result.AsEnumerable());
        }

        public Task Delete(T entity)
        {
            storage.Remove(entity.Id);
            return Task.FromResult(entity);
        }

        public async Task DeleteMany(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                await Delete(entity);
            }
        }
    }
}
