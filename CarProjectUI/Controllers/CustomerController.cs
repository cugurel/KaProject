using Microsoft.AspNetCore.Mvc;

namespace CarProjectUI.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
