using ClassLibrary1.Entities;
using ClassLibrary1.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonsterController : ControllerBase
    {
        private readonly IMonsterService _monsterService;

        public MonsterController(IMonsterService monsterService)
        {
            _monsterService = monsterService;
        }

        // GET: api/Monster/
        [HttpGet]
        public async Task<PaginatedList<Monster>> Get(int pageIndex, int pageSize)
        {
            return await _monsterService.GetMonsterListAsync(pageIndex, pageSize);
        }

        // GET api/Monster/5
        [HttpGet("{id}")]
        public async Task<Monster> Get(int id)
        {
            return await _monsterService.GetMonsterByIdAsync(id);
        }

        // POST api/Monster/
        [HttpPost]
        public async Task<Monster> Post([FromBody] Monster monster)
        {
            return await _monsterService.AddMonsterAsync(monster);
        }

        // PUT api/Monster/5
        [HttpPut("{id}")]
        public async Task<Monster> Put(int id, [FromBody] Monster monster)
        {
            return await _monsterService.EditMonsterAsync(id, monster);
        }

        // DELETE api/Monster/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _monsterService.DeleteMonsterAsync(id);
        }
    }
}
