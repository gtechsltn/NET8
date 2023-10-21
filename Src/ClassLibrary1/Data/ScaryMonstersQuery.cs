using ClassLibrary1.Entities;
using Microsoft.EntityFrameworkCore;

//Microsoft.Extensions.Configuration
//Microsoft.Extensions.Configuration.FileExtensions     <- .SetBasePath(Directory.GetCurrentDirectory())
//Microsoft.Extensions.Configuration.Json               <- .AddJsonFile("appsettings.json")

namespace ClassLibrary1.Data
{
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
}
