using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarProjectUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        Context c = new Context();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var categoryList = c.Categories.ToList();

            ViewBag.Title = "Yazýlým Geliþtirici";
            TempData["NameAndSurname"] = "Çaðrý Uðurel";
            return View(categoryList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
