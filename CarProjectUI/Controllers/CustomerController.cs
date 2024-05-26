using Business.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarProjectUI.Controllers
{
    public class CustomerController : Controller
    {
        ICustomerService _customerService;
        Context c = new Context();
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            var customers = _customerService.GetAllCustomersWithCityAndTown();
            return View(customers);
        }

        public JsonResult GetTown(int p)
        {
            var towns = (from x in c.Towns
                         where x.CityId == p
                         select new
                         {
                             Text = x.Name,
                             Value = x.Id.ToString()
                         }).ToList();

            return Json(towns);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            List<SelectListItem> cityList = (from x in c.Cities.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.Id.ToString()
                                             }).ToList();
            ViewBag.City = cityList;


            List<SelectListItem> townList = (from x in c.Towns.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.Id.ToString()
                                             }).ToList();
            ViewBag.Town = townList;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer customer)
        {
            if (customer.File != null && customer.File.Count>0)
            {
                _customerService.Add(customer);
                foreach (var item in customer.File)
                {

                    var extend = Path.GetExtension(item.FileName);
                    var randomName = $"{Guid.NewGuid()}{extend}";
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\CustomerFiles", randomName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await item.CopyToAsync(stream);
                    }
                    CustomerFile customerFile = new CustomerFile();
                    customerFile.CustomerId = customer.Id;
                    customerFile.FileUrl = randomName;
                    c.CustomerFiles.Add(customerFile);
                    c.SaveChanges();
                    
                    
                }
                return RedirectToAction("Index", "Customer");

            }
            else
            {
                _customerService.Add(customer);
                return RedirectToAction("Index", "Customer");
            }  
        }

        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            var customer = _customerService.GetById(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult UpdateCustomer(Customer customer)
        {
            _customerService.Update(customer);
            return RedirectToAction("Index", "Customer");
        }

        public IActionResult DeleteCustomer(int id)
        {
            var customer = _customerService.GetById(id);
            _customerService.Delete(customer);
            return RedirectToAction("Index", "Customer");
        }
    }
}
