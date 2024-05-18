using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EfRepository;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace CarProjectUI.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());

        public IActionResult Index(int page =1)
        {
            ViewBag.Title = "Yazılım Geliştirici";
            TempData["NameAndSurname"] = "Çağrı Uğurel";

            var categoryList = categoryManager.GetAll().ToPagedList(page,5);

            return View(categoryList);
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            ViewBag.Title = "Yazılım Geliştirici";
            TempData["NameAndSurname"] = "Çağrı Uğurel";

            var category = categoryManager.GetById(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            categoryManager.Update(category);
            
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
            categoryManager.Add(category);
            return Redirect("Index");
        }

        
        public IActionResult DeleteCategory(int id)
        {
            var category = categoryManager.GetById(id);
            categoryManager.Delete(category);
            return RedirectToAction("Index","Category");
        }
    }
}
