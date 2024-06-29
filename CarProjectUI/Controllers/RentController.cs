using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarProjectUI.Controllers
{
    [Authorize]
    public class RentController : Controller
    {
        IRentService _rentService;

        public RentController(IRentService rentService)
        {
            _rentService = rentService;
        }

        public IActionResult Index()
        {
            var rents = _rentService.GetAll();
            return View(rents);
        }
    }
}
