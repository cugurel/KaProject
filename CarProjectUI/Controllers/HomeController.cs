using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarProjectUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Yazýlým Geliþtirici";
            TempData["NameAndSurname"] = "Çaðrý Uðurel";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
