using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EfRepository;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarProjectUI.Controllers
{
    public class CarController : Controller
    {
        CarManager carManager = new CarManager(new EfCarRepository());
        public IActionResult Index()
        {
            var values = carManager.GetAllCarsWithCategory();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCar()
        {
            Context c = new Context();
            List<SelectListItem> categoryList = (from x in c.Categories.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.Id.ToString()
                                                    }).ToList();


            
            var categories = c.Categories.ToList();
            ViewBag.Category = categoryList;

            List<SelectListItem> yearList = (from x in c.Years.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.YearInfo,
                                                     Value = x.Id.ToString()
                                                 }).ToList();
            ViewBag.Year = yearList;
            return View();
        }

        [HttpPost]
        public IActionResult AddCar(Car car)
        {
            carManager.Add(car);
            return Redirect("Index");
        }

        public IActionResult DeleteCar(int id)
        {
            var car = carManager.GetById(id);
            carManager.Delete(car);
            return RedirectToAction("Index","Car");
        }

        [HttpGet]
        public IActionResult UpdateCar(int id)
        {
            Context c = new Context();
            List<SelectListItem> categoryList = (from x in c.Categories.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.Id.ToString()
                                                 }).ToList();
            ViewBag.Category = categoryList;
            var car = carManager.GetById(id);
            return View(car);
        }

        [HttpPost]
        public IActionResult UpdateCar(Car car)
        {
            carManager.Update(car);
            return RedirectToAction("Index", "Car");
        }
    }
}
