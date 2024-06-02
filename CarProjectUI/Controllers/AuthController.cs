using CarProjectUI.Identity;
using CarProjectUI.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CarProjectUI.Controllers
{
    public class AuthController : Controller
    {
        UserManager<User> _userManager;
        SignInManager<User> _signinManager;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signinManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            if (user == null)
            {
                TempData["LoginError"] = "Bu email ile kayıtlı kullanıcı bulunamadı!";
                return View();
            }

            var result = await _signinManager.PasswordSignInAsync(user, loginModel.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = new User
            {
                Firstname = registerModel.Firstname,
                Lastname = registerModel.Surname,
                Email = registerModel.Email,
                PhoneNumber = registerModel.Phone,
                UserName = registerModel.Username
            };

            var userWithEmail = await _userManager.FindByEmailAsync(user.Email);
            if (userWithEmail != null)
            {
                TempData["EmailError"] = "Bu email ile bir kullanıcı zaten var.";
                return View();
            }

            var result = await _userManager.CreateAsync(user, registerModel.Password);

            if (result.Succeeded)
            {
                TempData["EmailError"] = "Kayıt başarılı!";
                return RedirectToAction("Login", "Auth");
            }
            return View();
        }
    }
}
