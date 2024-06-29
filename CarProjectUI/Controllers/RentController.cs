using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarProjectUI.Controllers
{
    [Authorize]
    public class RentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
