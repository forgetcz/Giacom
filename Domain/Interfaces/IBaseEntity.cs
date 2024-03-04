using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    /// <summary>
    /// Base definition for each Entity from database
    /// </summary>
    interface IBaseEntity<T>
    {
        T Id { get; set; }
    }
}
