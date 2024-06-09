using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EfRepository;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using X.PagedList;

namespace CarProjectUI.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());

        string apiUrl = "https://localhost:7261/api/Category/";
        HttpClient client = new HttpClient();
        public async Task<IActionResult> Index(int page =1)
        {
            
            var result = await client.GetAsync
                (apiUrl + "GetAllCategories");

            var jsonString = result.Content.ReadAsStringAsync().Result;
            var categories = JsonConvert.DeserializeObject<List<Category>>(jsonString);

            //ViewBag.Title = "Yazılım Geliştirici";
            //TempData["NameAndSurname"] = "Çağrı Uğurel";

            var categoryList = categories.ToPagedList(page, 5);

            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            
            var result = await client.GetAsync
                (apiUrl + "GetById/"+id);

            if (result.IsSuccessStatusCode)
            {
                var jsonCategory = await result.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<Category>(jsonCategory);
                return View(value);
            }
            return View(null);
            //ViewBag.Title = "Yazılım Geliştirici";
            //TempData["NameAndSurname"] = "Çağrı Uğurel";

            //var category = categoryManager.GetById(id);
            //return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            var jsonCategory = JsonConvert.SerializeObject(category);
            StringContent content = new StringContent(jsonCategory, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync(apiUrl + "UpdateCategory", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category");
            }
            return View();

            //categoryManager.Update(category);
            //return Redirect("Index");
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            ViewBag.Title = "Yazılım Geliştirici";
            TempData["NameAndSurname"] = "Çağrı Uğurel";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(Category category)
        {
            var jsonCategory = JsonConvert.SerializeObject(category);
            StringContent content = new StringContent(jsonCategory,Encoding.UTF8,"application/json");

            var result = await client.PostAsync(apiUrl,content);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category");
            }

            return View();
        }

        
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await client.DeleteAsync
                (apiUrl + "DeleteById/" + id);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category");
            }
            return View(result);
        }
    }
}
