using Domain.Entities;
using Infrastructure.Business;

namespace Infrastructure.Data.Repository.MemoryRepository
{

    public class CrdDataRepository<T> : MemoryRepository<CrdData<T>, T> where T : struct,
          IComparable<T>,
          IEquatable<T>
    {

    }
}