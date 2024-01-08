using EntityLayer.Concrete;
using FarmerCoopWebUI.Dtos.ProductDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FarmerCoopWebUI.Controllers
{
	public class ProductController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly UserManager<AppUser> _userManager;

		public ProductController(IHttpClientFactory httpClientFactory, UserManager<AppUser> userManager)
		{
			_httpClientFactory = httpClientFactory;
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7111/api/Product/ProductListWithAppUser/");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultProductWithAppUserDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		public async Task <IActionResult> ProductDetails(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7111/api/Product/ProductWithAppUser/"+id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ResultProductWithAppUserDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public IActionResult AddProduct()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddProduct(CreateProductDto createProductDto)
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			//UserManager _myUserManager = new UserManager(new EfUserDal(new FarmerCoopDbContext()));
			//var user = _myUserManager.GetEntity(x => x.UserName == User.Identity.Name);


			createProductDto.AppUserId = user.Id;
			createProductDto.StockStatus = true;
			var client = _httpClientFactory.CreateClient();	
			var jsonData = JsonConvert.SerializeObject(createProductDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7111/api/Product/", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet("/Product/ProductListByAppUser/")]
		public async Task<IActionResult> ProductListByAppUser()
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7111/api/Product/ProductListByAppUser/" + user.Id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
