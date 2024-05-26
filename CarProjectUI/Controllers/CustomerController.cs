using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CarProjectUI.Controllers
{
    public class CustomerController : Controller
    {
        ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            var customers = _customerService.GetAll();
            return View(customers);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer customer)
        {
            if (customer.File != null)
            {
                var extend = Path.GetExtension(customer.File.FileName);
                var randomName = $"{Guid.NewGuid()}{extend}";
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\CustomerFiles", randomName);

                using(var stream = new FileStream(path, FileMode.Create))
                {
                    await customer.File.CopyToAsync(stream);
                }
                customer.FileUrl = randomName;
                _customerService.Add(customer);
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
