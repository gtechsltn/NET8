using ClassLibrary1.Data;
using ClassLibrary1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace xUnitTestProject1
{
    public class SimpleIntegrationTest : IDisposable
    {
        MonsterContext _context;

        public SimpleIntegrationTest()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlServer()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<MonsterContext>();

            builder.UseSqlServer($"Server=(localdb)\\ProjectsV13;Database=monsters_db_{Guid.NewGuid()};Trusted_Connection=True;MultipleActiveResultSets=true")
                    .UseInternalServiceProvider(serviceProvider);

            _context = new MonsterContext(builder.Options);
            _context.Database.Migrate();

        }

        [Fact]
        public void QueryMonstersFromSqlTest()
        {
            //Add some monsters before querying
            _context.Monsters.Add(new Monster { Name = "Dave", Colour = "Orange", IsScary = false });
            _context.Monsters.Add(new Monster { Name = "Simon", Colour = "Blue", IsScary = false });
            _context.Monsters.Add(new Monster { Name = "James", Colour = "Green", IsScary = false });
            _context.Monsters.Add(new Monster { Name = "Imposter Monster", Colour = "Red", IsScary = true });
            _context.SaveChanges();

            //Execute the query
            ScaryMonstersQuery query = new ScaryMonstersQuery(_context);
            var scaryMonsters = query.Execute();

            //Verify the results
            Assert.Single(scaryMonsters);
            var scaryMonster = scaryMonsters.First();
            Assert.Equal("Imposter Monster", scaryMonster.Name);
            Assert.Equal("Red", scaryMonster.Colour);
            Assert.True(scaryMonster.IsScary);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
        }
    }
}