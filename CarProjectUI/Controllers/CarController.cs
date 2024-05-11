using DataAccess.Concrete.EfRepository;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CarProjectUI.Controllers
{
    public class CarController : Controller
    {
        EfCarRepository carRepository = new EfCarRepository();
        public IActionResult Index()
        {
            var values = carRepository.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCar(Car car)
        {
            carRepository.Add(car);
            return Redirect("Index");
        }
    }
}
