using ClassLibrary1.Data;
using ClassLibrary1.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1.Services
{
    public class MonsterService : IMonsterService
    {
        private readonly MonsterContext _context;

        public MonsterService(MonsterContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Monster> AddMonsterAsync(Monster monster)
        {
            await _context.SaveChangesAsync();
            return monster;
        }

        public async Task<bool> DeleteMonsterAsync(int id)
        {
            var monsterDb = await _context.Monsters.FindAsync(id);
            if (monsterDb != null)
            {
                _context.Remove(monsterDb);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Monster> EditMonsterAsync(int id, Monster monster)
        {
            if (id <= 0) { throw new Exception($"Monster was not supplied"); }
            if (monster == null) { throw new Exception($"Monster was not supplied"); }
            var monsterDb = await _context.Monsters.FindAsync(id);
            if (monsterDb == null) { throw new Exception($"Monster was not found"); }
            else
            {
                monsterDb.Name = monster.Name;
                monsterDb.IsScary = monster.IsScary;
                monsterDb.Colour = monster.Colour;
                await _context.SaveChangesAsync();
                return monsterDb;
            }
        }

        public async Task<Monster> GetMonsterByIdAsync(int id)
        {
            var monsterDb = await _context.Monsters.FindAsync(id);
            if (monsterDb == null) { throw new Exception($"Monster was not found"); }
            return monsterDb;
        }

        public async Task<PaginatedList<Monster>> GetMonsterListAsync(int pageIndex, int pageSize)
        {
            var source = _context.Monsters;
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<Monster>(items, count, pageIndex, pageSize);
        }
    }
}
