using ClassLibrary1;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MonsterContext _monsterContext;
        public HomeController(ILogger<HomeController> logger, MonsterContext monsterContext)
        {
            _logger = logger;
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