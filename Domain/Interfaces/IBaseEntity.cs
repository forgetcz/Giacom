using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    /// <summary>
    /// Base definition for each Entity from database (only Id must by defined be any type)
    /// </summary>
    public interface IBaseEntity<T> 
        where T : struct, IComparable<T>, IEquatable<T>
        //IComparable,
        //IComparable<T>,
        //IEquatable<T>
        //IFormattable
    {
        T Id { get; set; }
    }
}
