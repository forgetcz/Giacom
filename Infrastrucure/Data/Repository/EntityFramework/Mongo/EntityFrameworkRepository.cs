using Domain.Entities;
using Infrastructure.Business.Extensions;
using Infrastructure.Configuration.JSON;
using Infrastructure.Enums;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Diagnostics;
using static System.Collections.Specialized.BitVector32;

namespace Infrastructure.Data.Repository.EntityFramework.Mongo
{
    /// <summary>
    /// Crd data repository
    /// </summary>
    public partial class EntityFrameworkRepository : DbContext
    {
        private readonly IConfiguration? _appConfig;
        private static readonly IMongoDatabase? _database;
        private static DbContextOptions<EntityFrameworkRepository> DbContextOptionsBuilder { get; set; }
        public virtual DbSet<CrdData<ObjectId>>? CrdDatas { get; set; }

        /// <summary>
        /// This is a hack how to create dbContextOptionsBuilder before initial constructor is created. We used it for base constructor latter.
        /// </summary>
        static EntityFrameworkRepository()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(AppDomain.CurrentDomain.BaseDirectory +
                    eConfigurationFile.json.ToDescriptionString(), optional: true, reloadOnChange: true)
                .Build();
            var mongoConnection = configuration.GetSection("mongoConnection");
            var client = new MongoClient(mongoConnection.GetSection("ConnectionString").Value);
            _database = client.GetDatabase(mongoConnection.GetSection("DatabaseName").Value);

            DbContextOptionsBuilder = new DbContextOptionsBuilder<EntityFrameworkRepository>()
                .UseMongoDB(_database.Client, _database.DatabaseNamespace.DatabaseName)
                .Options;

            //ApplicationKeysJson applicationKeysJson = new ApplicationKeysJson();
            //var mongo = applicationKeysJson.GetKeyValue("");
        }

        public EntityFrameworkRepository(IConfiguration? appConfig)
        {
            _appConfig = appConfig;

            //var section = _appConfig!.GetSection("");
            //var client = new MongoClient(section.GetSection("MongoSection").Value);
            //_database = client.GetDatabase(section.GetSection("DataBaseName").Value);
            //EntityFrameworkRepository(db);
        }

        public EntityFrameworkRepository(DbContextOptions options) : base(DbContextOptionsBuilder) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMongoDB(_database!.Client, _database.DatabaseNamespace.DatabaseName);
        }
        /*

        public EntityFrameworkRepository(DbContextOptions options): base(options)  {  }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var v = modelBuilder.Entity<CrdData>();
            Debug.WriteLine(v);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _appConfig!.GetConnectionString(nameof(eSqlConnectionStrings.mongoConn));
            var client = new MongoClient(connectionString);
            //var db = MflixDbContext.Create(client.GetDatabase("Test"));
            //optionsBuilder.UseMongoDb(connectionString);
        }*/
    }
}
