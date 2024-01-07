using EntityLayer.Concrete;
using FarmerCoopWebUI.Dtos.AppUserDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FarmerCoopWebUI.Controllers
{
	public class UserController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public UserController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> UserEditProfile()
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			UpdateAppUserDto model = new UpdateAppUserDto();
			model.Email = user.Email;
			model.PhoneNumber = user.PhoneNumber;
			model.UserName = user.UserName;
			model.Name= user.Name;
			model.Surname = user.Surname;
			model.ImageURL = user.ImageURL;
			
			return View(model);
			
		}
		[HttpPost]
		public async Task<IActionResult> UserEditProfile(UpdateAppUserDto model)
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			model.Email = user.Email;
			model.PhoneNumber = user.PhoneNumber;
			model.UserName = user.UserName;
			model.Name = user.Name;
			model.Surname = user.Surname;
			model.ImageURL = user.ImageURL;
			user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
			var result = await _userManager.UpdateAsync(user);
			if (result.Succeeded)
			{
				return RedirectToAction("PostListByAppUser", "Post");
			}
			else
			{
				return View();
			}
			
		}
	}
}
