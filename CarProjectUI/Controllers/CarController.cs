using Microsoft.AspNetCore.Mvc;

namespace CarProjectUI.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddCar()
        {
            return View();
        }
    }
}
