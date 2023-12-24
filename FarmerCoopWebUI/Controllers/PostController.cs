using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FarmerCoopWebUI.Dtos.PostDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FarmerCoopWebUI.Controllers
{
	public class PostController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly UserManager<AppUser> _userManager;

		public PostController(IHttpClientFactory httpClientFactory, UserManager<AppUser> userManager)
		{
			_httpClientFactory = httpClientFactory;
			_userManager = userManager;
		}

		public async Task <IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7111/api/Post/PostListWithAppUser/");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultPostWithAppUserDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet("/Post/PostDetails/{postID}")]
		public async Task <IActionResult> PostDetails(int postID)
		{
			
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7111/api/Post/PostWithAppUserAndComments/"+ postID);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ResultPostWithAppUserAndCommentsDto>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public IActionResult AddPost()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddPost(CreatePostDto createPostDto)
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			//UserManager _myUserManager = new UserManager(new EfUserDal(new FarmerCoopDbContext()));
			//var user = _myUserManager.GetEntity(x => x.UserName == User.Identity.Name);
			
			createPostDto.AppUserId = user.Id;
			createPostDto.CreateDate = DateTime.Now;
			createPostDto.PostStatus = true;
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createPostDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7111/api/Post/", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View("Gönderi başarıyla eklendi");
		}
	}
}
