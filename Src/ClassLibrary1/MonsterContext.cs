using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

//Microsoft.Extensions.Configuration
//Microsoft.Extensions.Configuration.FileExtensions     <- .SetBasePath(Directory.GetCurrentDirectory())
//Microsoft.Extensions.Configuration.Json               <- .AddJsonFile("appsettings.json")

namespace ClassLibrary1
{
    public class MonsterContext : DbContext
    {
        public MonsterContext(DbContextOptions<MonsterContext> options) : base(options)
        {
        }

        public DbSet<Monster> Monsters { get; set; }
    }

    public class MonsterContextFactory : IDesignTimeDbContextFactory<MonsterContext>
    {
        public MonsterContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<MonsterContext>();
            var connectionString = configuration.GetConnectionString(nameof(MonsterContext));
            dbContextOptionsBuilder.UseSqlServer(connectionString);

            return new MonsterContext(dbContextOptionsBuilder.Options);
        }
    }

    public class ScaryMonstersQuery
    {
        private MonsterContext _context;

        public ScaryMonstersQuery(MonsterContext context)
        {
            _context = context;
        }

        public IEnumerable<Monster> Execute()
        {
            return _context.Monsters.FromSqlRaw("SELECT Id, Name, IsScary, Colour FROM Monsters WHERE IsScary = {0}", true);
        }

    }

    public class Monster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsScary { get; set; }
        public string Colour { get; set; }
    }
}
