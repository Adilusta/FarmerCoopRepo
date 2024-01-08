using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FarmerCoopWebUI.Dtos.PostDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
		[HttpGet]

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
				return  RedirectToAction("PostListByAppUser");
			}
			return View();
		}

		[HttpGet("/Post/PostListByAppUser/")]
		public async Task<IActionResult> PostListByAppUser()
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7111/api/Post/PostListByAppUserID/" + user.Id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultPostDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpGet("/Post/DeletePost/{postID}")]
		public async Task<IActionResult> DeletePost(int postID)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync("https://localhost:7111/api/Post/" + postID);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return RedirectToAction("PostListByAppUser");
		}

		[HttpGet]
		public async Task<IActionResult> UpdatePost(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7111/api/Post/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdatePostDto>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdatePost(UpdatePostDto updatePostDto)
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			updatePostDto.AppUserId = user.Id;
			updatePostDto.PostStatus = true;
			updatePostDto.CreateDate = DateTime.Now;
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updatePostDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7111/api/Post/", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("PostListByAppUser");
			}
			return View();
		}
		//[HttpPost("/Post/PostListByAppUser/{userID}")]
		//public async Task<IActionResult> PostListByAppUser(int userID)
		//{
		//	var user = await _userManager.FindByNameAsync(User.Identity.Name);
		//	user.Id = userID;
		//	var client = _httpClientFactory.CreateClient();
		//	var responseMessage = await client.GetAsync("https://localhost:7111/api/Post/PostListByAppUserID/" + userID);
		//	if (responseMessage.IsSuccessStatusCode)
		//	{
		//		var jsonData = await responseMessage.Content.ReadAsStringAsync();
		//		var values = JsonConvert.DeserializeObject<List<ResultPostDto>>(jsonData);
		//		return View(values);
		//	}
		//	return View();

		//}
	}
}
