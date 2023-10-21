using ClassLibrary1.Entities;
using System.Net.Http.Json;

namespace ClassLibrary1.Services
{
    public class ClientMonsterService : IMonsterService
    {
        private readonly HttpClient _httpClient;

        public ClientMonsterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Monster> AddMonsterAsync(Monster monster)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/Monster", monster);
            return await result.Content.ReadFromJsonAsync<Monster>();
        }

        public async Task<bool> DeleteMonsterAsync(int id)
        {
            var result = await _httpClient.DeleteAsync($"/api/Monster/{id}");
            return await result.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<Monster> EditMonsterAsync(int id, Monster monster)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/Monster/{id}", monster);
            return await result.Content.ReadFromJsonAsync<Monster>();
        }

        public async Task<Monster> GetMonsterByIdAsync(int id)
        {
            var result = await _httpClient.GetAsync($"/api/Monster/{id}");
            return await result.Content.ReadFromJsonAsync<Monster>();
        }

        public async Task<PaginatedList<Monster>> GetMonsterListAsync(int pageIndex, int pageSize)
        {
            var result = await _httpClient.GetAsync($"/api/Monster/?pageIndex={pageIndex}&pageSize={pageSize}");
            return await result.Content.ReadFromJsonAsync<PaginatedList<Monster>>();
        }
    }
}
