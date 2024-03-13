using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data.Repository.EntityFramework.InMemory
{
    /// <summary>
    /// Crd data repository
    /// </summary>
    public partial class EntityFrameworkRepository : DbContext
    {
        private readonly IConfiguration? appConfig;

        public virtual DbSet<CrdData<long>>? CrdData { get; set; }

        public EntityFrameworkRepository(IConfiguration? config)
        {
            appConfig = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ApplicationDb");
        }

    }
}
