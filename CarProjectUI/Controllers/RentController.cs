using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarProjectUI.Controllers
{
    
    public class RentController : Controller
    {
        IRentService _rentService;

        public RentController(IRentService rentService)
        {
            _rentService = rentService;
        }
        [Authorize]
        public IActionResult Index()
        {
            var rents = _rentService.GetRentalInfo();
            return View(rents);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult RentCar(Rent rent)
        {
            _rentService.Add(rent);
            TempData["RentSuccess"] = "Kiralama talebi gerçekleşti.";
            return RedirectToAction("Index","Home");
        }
    }
}
