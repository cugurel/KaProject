using Business.Abstract;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarProjectUI.Controllers
{
    public class HomeController : Controller
    {
        ICategoryService _categoryService;

        public HomeController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        Context c = new Context();
        

        public IActionResult Index()
        {
            var categoryList = _categoryService.GetAll();

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
