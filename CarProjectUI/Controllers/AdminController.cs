using Business.Abstract;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarProjectUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        Context c = new Context();
        ICategoryService _categoryService;

        public AdminController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        public IActionResult Index()
        {
            var categoryList = _categoryService.GetAll();

            ViewBag.Title = "Yazılım Geliştirici";
            TempData["NameAndSurname"] = "Çağrı Uğurel";
            return View(categoryList);
        }

    }
}
