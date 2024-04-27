using DataAccess.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CarProjectUI.Controllers
{
    public class CategoryController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            ViewBag.Title = "Yazılım Geliştirici";
            TempData["NameAndSurname"] = "Çağrı Uğurel";

            var categoryList = c.Categories.ToList();

            ViewBag.Title = "Yazılım Geliştirici";
            TempData["NameAndSurname"] = "Çağrı Uğurel";
            return View(categoryList);
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            ViewBag.Title = "Yazılım Geliştirici";
            TempData["NameAndSurname"] = "Çağrı Uğurel";

            var category = c.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            c.Categories.Update(category);
            c.SaveChanges();
            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            ViewBag.Title = "Yazılım Geliştirici";
            TempData["NameAndSurname"] = "Çağrı Uğurel";

            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            c.Categories.Add(category);
            c.SaveChanges();
            return Redirect("Index");
        }

        
        public IActionResult DeleteCategory(int id)
        {
            var category = c.Categories.Find(id);
            c.Categories.Remove(category);
            c.SaveChanges();
            return RedirectToAction("Index","Category");
        }
    }
}
