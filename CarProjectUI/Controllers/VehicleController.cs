using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace CarProjectUI.Controllers
{
    public class VehicleController : Controller
    {
        Context c = new Context();
        public IActionResult Index(int page = 1)
        {
            var cars = c.Cars.ToList().ToPagedList(page, 2); ;
            return View(cars);
        }
    }
}
