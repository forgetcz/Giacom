using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Enums
{
    /// <summary>
    /// Attributes definition for App config type (JOSN, XML)
    /// </summary>
    public enum eApplicationConfigurationRepositoryType { JSON, XML }

    /// <summary>
    /// Attributes definition for App config section AppKeys, ConnectionStrings
    /// </summary>
    public enum eApplicationConfigurationRepositorySection { AppKeys, ConnectionStrings}

    /// <summary>
    /// Definition of database source repository (SQL, FireBird, FileSystem, Mongo,... 
    /// </summary>
    public enum eDomainSourceRepositoryType { SQL, FireBird, FileSystem, Mongo, Memory }

    public enum eMefAttribute { exportedTpe, repositoryType }
}
