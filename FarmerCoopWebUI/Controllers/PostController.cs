using FarmerCoopWebUI.Dtos.PostDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FarmerCoopWebUI.Controllers
{
	public class PostController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public PostController(IHttpClientFactory httpClientFactory)
        {
			this._httpClientFactory = httpClientFactory;
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

		public IActionResult PostDetails()
		{
			return View();
		}
	}
}
