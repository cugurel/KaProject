using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CarProjectUI.Controllers
{
    public class OfficeController : Controller
    {
        IOfficeService _officeService;

        public OfficeController(IOfficeService officeService)
        {
            _officeService = officeService;
        }

        public IActionResult Index()
        {
            var values = _officeService.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddOffice()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddOffice(Office office)
        {
            _officeService.Add(office);
            return Redirect("index");
        }

        [HttpGet]
        public IActionResult UpdateOffice(int id)
        {
            var value = _officeService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateOffice(Office office)
        {
            _officeService.Update(office);
            return Redirect("index");
        }

        public IActionResult DeleteOffice(int id)
        {
            var value = _officeService.GetById(id);
            _officeService.Delete(value);
            return Redirect("index");
        }
    }
}
