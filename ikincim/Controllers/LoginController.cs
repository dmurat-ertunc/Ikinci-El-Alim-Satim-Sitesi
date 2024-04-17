using EntityLayer.Concrete;
using ikincim.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ikincim.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel userLoginViewModel, string? returnbUrl=null)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            returnbUrl = returnbUrl ?? Url.Action("Index","HomePage");

            var userNameDeg = await _userManager.FindByEmailAsync(userLoginViewModel.Email);
            
            if (userNameDeg == null)
            {
                ViewBag.Mesaj = "E-Posta veya Şifre yanlış!";
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(userNameDeg, userLoginViewModel.Password, false, false);

            if (result.Succeeded)
            {
                return Redirect(returnbUrl!);
            }
            ViewBag.Mesaj = "E-Posta veya Şifre yanlış!";
            return View();

            
        }
    }
}
