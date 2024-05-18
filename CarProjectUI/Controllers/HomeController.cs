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

            ViewBag.Title = "Yaz�l�m Geli�tirici";
            TempData["NameAndSurname"] = "�a�r� U�urel";
            return View(categoryList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
