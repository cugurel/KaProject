using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EfRepository;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;

namespace CarProjectUI.Controllers
{
    public class CarController : Controller
    {
        ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        public IActionResult Index()
        {
            var values = _carService.GetAllCarsWithCategory();
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
        public async Task<IActionResult> AddCar(Car car)
        {
            if(car.File != null)
            {
                var item = car.File;
                var extend = Path.GetExtension(item.FileName);
                var randomName = ($"{Guid.NewGuid()}{extend}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\CarImages", randomName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await item.CopyToAsync(stream);
                }

                car.FileUrl = randomName;
                _carService.Add(car);
                return Redirect("Index");
            }

            _carService.Add(car);
            return Redirect("Index");
        }

        public IActionResult DeleteCar(int id)
        {
            var car = _carService.GetById(id);
            _carService.Delete(car);
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

            var car = _carService.GetById(id);
            return View(car);
        }

        [HttpPost]
        public IActionResult UpdateCar(Car car)
        {
            _carService.Update(car);
            return RedirectToAction("Index", "Car");
        }
    }
}
