using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EfRepository;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CarProjectUI.Controllers
{
    public class YearController : Controller
    {
        IYearService _yearService;

        public YearController(IYearService yearService)
        {
            _yearService = yearService;
        }

        public IActionResult Index()
        {
            var yearInfos = _yearService.GetAll();
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
            _yearService.Add(year);
            return RedirectToAction("Index","Year");
        }


        [HttpGet]
        public IActionResult UpdateYear(int id)
        {
            var year = _yearService.GetById(id);
            return View(year);
        }


        [HttpPost]
        public IActionResult UpdateYear(Year year)
        {
            _yearService.Update(year);
            return RedirectToAction("Index", "Year");
        }


        public IActionResult DeleteYear(int id)
        {
            var year = _yearService.GetById(id);
            _yearService.Delete(year);
            return RedirectToAction("Index", "Year");
        }
    }
}
