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
            ViewBag.Title = "Yaz�l�m Geli�tirici";
            TempData["NameAndSurname"] = "�a�r� U�urel";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
