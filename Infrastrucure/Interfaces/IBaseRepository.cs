using Domain.Abstraction;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Interfaces
{
    /// <summary>
    /// Base definition for each database repository action on database item
    /// </summary>
    /// <!-- Definition for K must be again defined in order to compile source code -->
    /// <typeparam name="T">Type of entity</typeparam>
    /// <typeparam name="K">Type of key in database</typeparam>
    public interface IBaseDbRepository<T, K> where T : IBaseEntity<K>
         where K : struct,
          IComparable,
          IComparable<K>,
          IEquatable<K>,
          IFormattable
    {
        Task<T?> GetById(K id);
        Task<IEnumerable<T>> TakeRange(int skip, int count);
        Task<T> Insert(T entity);
        Task<IEnumerable<T>> InsertMany(IEnumerable<T> entities);
        Task<T> Update(T entity);
        Task<IEnumerable<T>> UpdateMany(IEnumerable<T> entities);
        Task Delete(T entity);
        Task DeleteMany(IEnumerable<T> entities);
    }
}
