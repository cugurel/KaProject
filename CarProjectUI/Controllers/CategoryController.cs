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
        EfCategoryRepository categoryRepository = new EfCategoryRepository();

        public IActionResult Index(int page =1)
        {
            ViewBag.Title = "Yazılım Geliştirici";
            TempData["NameAndSurname"] = "Çağrı Uğurel";

            var categoryList = categoryRepository.GetAll().ToPagedList(page,3);

            return View(categoryList);
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            ViewBag.Title = "Yazılım Geliştirici";
            TempData["NameAndSurname"] = "Çağrı Uğurel";

            var category = categoryRepository.GetById(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            categoryRepository.Update(category);
            
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
            categoryRepository.Add(category);
            return Redirect("Index");
        }

        
        public IActionResult DeleteCategory(int id)
        {
            var category = categoryRepository.GetById(id);
            categoryRepository.Delete(category);
            return RedirectToAction("Index","Category");
        }
    }
}
