using Business.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CarProjectUI.Controllers
{
    public class PlaceController : Controller
    {
        IOfficeService _officeService;

        public PlaceController(IOfficeService officeService)
        {
            _officeService = officeService;
        }

        public IActionResult Index()
        {
            ViewBag.Offices = _officeService.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Contact contact)
        {
            Context context = new Context();
            context.Contacts.Add(contact);  
            context.SaveChanges();
            return View();
        }
    }
}
