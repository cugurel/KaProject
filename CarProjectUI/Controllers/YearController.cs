using DataAccess.Concrete.EfRepository;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CarProjectUI.Controllers
{
    public class YearController : Controller
    {
        EfYearRepository yearRepository = new EfYearRepository();
        public IActionResult Index()
        {
            var yearInfos = yearRepository.GetAll();
            return View(yearInfos);
        }

        [HttpGet]
        public IActionResult AddYear()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddYear(Year year)
        {
            yearRepository.Add(year);
            return RedirectToAction("Index","Year");
        }


        [HttpGet]
        public IActionResult UpdateYear(int id)
        {
            var year = yearRepository.GetById(id);
            return View(year);
        }


        [HttpPost]
        public IActionResult UpdateYear(Year year)
        {
            yearRepository.Update(year);
            return RedirectToAction("Index", "Year");
        }


        public IActionResult DeleteYear(int id)
        {
            var year = yearRepository.GetById(id);
            yearRepository.Delete(year);
            return RedirectToAction("Index", "Year");
        }
    }
}
