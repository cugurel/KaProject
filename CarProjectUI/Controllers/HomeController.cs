using Business.Abstract;
using CarProjectUI.CustomFilter;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarProjectUI.Controllers
{
    
    public class HomeController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            ViewBag.FavCars = c.Cars.OrderByDescending(e => e.Id).Take(6).ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
