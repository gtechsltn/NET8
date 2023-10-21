using ClassLibrary1.Entities;

namespace ClassLibrary1.Services
{
    public interface IMonsterService
    {
        Task<PaginatedList<Monster>> GetMonsterListAsync(int pageIndex, int pageSize);
        Task<Monster> GetMonsterByIdAsync(int id);
        Task<Monster> AddMonsterAsync(Monster monster);
        Task<Monster> EditMonsterAsync(int id, Monster monster);
        Task<bool> DeleteMonsterAsync(int id);
    }
}
