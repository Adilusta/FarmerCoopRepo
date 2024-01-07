using EntityLayer.Concrete;
using FarmerCoopWebUI.Dtos.IdentityDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FarmerCoopWebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Index(RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                var appUser = new AppUser()
                {
                    Name = registerDto.Name,
                    Surname = registerDto.Surname,
                    Email = registerDto.Mail,
                    UserName = registerDto.Username
                };
                var result = await _userManager.CreateAsync(appUser, registerDto.Password);
                //BAşarılıysa tekrar bizi giriş sayfasına atacak
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                //Başarısızsa gelen hataları bize gösterecek
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(registerDto);
        }
    }
}
