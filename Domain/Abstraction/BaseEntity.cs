using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstraction
{
    /// <summary>
    /// Base (core) database entity definition
    /// </summary>
    public abstract class BaseEntity<T> : IBaseEntity<T> where T : struct,
          IComparable,
          IComparable<T>,
          IEquatable<T>,
          IFormattable
    {
        public T Id { get; set; }

        public BaseEntity(T id)
        {
            Id = id;
        }
    }
}
