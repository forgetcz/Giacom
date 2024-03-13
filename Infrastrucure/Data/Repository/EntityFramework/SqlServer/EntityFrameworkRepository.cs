using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data.Repository.EntityFramework.SqlServer
{
    /// <summary>
    /// Crd data repository
    /// </summary>
    public partial class EntityFrameworkRepository : DbContext
    {
        private readonly IConfiguration? _appConfig;
        public virtual DbSet<CrdData<long>>? CrdData { get; set; }

        public EntityFrameworkRepository(IConfiguration? appConfig)
        {
            _appConfig = appConfig;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//sqlConnString
        {
            var sqlConnectionString = _appConfig!.GetConnectionString("mainConn") as string;
            optionsBuilder.UseSqlServer(sqlConnectionString!);
        }
    }
}
