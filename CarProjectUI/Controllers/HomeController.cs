using Business.Abstract;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarProjectUI.Controllers
{
    public class HomeController : Controller
    {
        Context c = new Context();
        ICategoryService _categoryService;

        public HomeController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        
        

        public IActionResult Index()
        {
            ViewBag.CarCount = c.Cars.Count();
            ViewBag.CategoryCount = c.Categories.Count();
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
