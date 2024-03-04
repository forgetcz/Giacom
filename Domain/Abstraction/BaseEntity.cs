using Domain.Interfaces;
using Domain.Enums;
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
    public abstract class BaseEntity<T> : IBaseEntity<T>
    {
        public T Id { get; set; }

        public BaseEntity(T id)
        {
            Id = id;
        }
    }
}
