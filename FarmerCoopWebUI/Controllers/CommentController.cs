using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using FarmerCoopWebUI.Dtos.CommentDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace FarmerCoopWebUI.Controllers
{
	public class CommentController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly UserManager<AppUser> _userManager;

		public CommentController(IHttpClientFactory httpClientFactory, UserManager<AppUser> userManager)
		{
			_httpClientFactory = httpClientFactory;
			_userManager = userManager;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> CommentListByAppUser()
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7111/api/Comment/GetCommentListByAppUser/"+user.Id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<GetCommentByAppUserDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
