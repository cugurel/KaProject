using Business.Abstract;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace CarProjectUI.Controllers
{
    public class VehicleController : Controller
    {
        Context c = new Context();
        ICarService _carService;

        public VehicleController(ICarService carService)
        {
            _carService = carService;
        }

        public IActionResult Index(int page = 1)
        {
            var cars = c.Cars.ToList().ToPagedList(page, 2); ;
            return View(cars);
        }

        public IActionResult VehicleDetail(int id)
        {
            var car = _carService.GetAllCarsWithCategory().SingleOrDefault(x=>x.Id == id);
            return View(car);
        }
    }
}
