using EntityLayer.Concrete;
using ikincim.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ikincim.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        
        public RegisterController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserViewModel userRegisterViewModel)
        {                       
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser appUser = new AppUser()
            {
                Ad = userRegisterViewModel.Name,
                Soyad = userRegisterViewModel.Surname,
                Email = userRegisterViewModel.Email,
                UserName = userRegisterViewModel.UserName,
                Yas = userRegisterViewModel.Yas,
                PhoneNumber = userRegisterViewModel.PhoneNumber,
                
            };
            var result = await userManager.CreateAsync(appUser, userRegisterViewModel.Password);
            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Kayıt olma işlemi başarılı.";
            }
            foreach (IdentityError item in result.Errors)
            {
                ModelState.AddModelError(string.Empty, item.Description);
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index","HomePage");
        }
        
        
    }
}

        //public async Task<IActionResult> Register(UserViewModel userRegisterViewModel)
        //{

        //}

