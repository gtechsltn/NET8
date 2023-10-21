using ClassLibrary1.Data;
using ClassLibrary1.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMonsterService _monsterService;
        private readonly MonsterContext _monsterContext;
        public HomeController(ILogger<HomeController> logger,
            IMonsterService monsterService,
            MonsterContext monsterContext)
        {
            _logger = logger;
            _monsterService = monsterService;
            _monsterContext = monsterContext;
        }

        public IActionResult Index()
        {
            var monsters = _monsterContext.Monsters.ToList();
            Debug.WriteLine(monsters.Count);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}