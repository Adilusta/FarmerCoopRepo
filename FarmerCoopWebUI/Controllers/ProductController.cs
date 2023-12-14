using Microsoft.AspNetCore.Mvc;

namespace FarmerCoopWebUI.Controllers
{
	public class ProductController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult ProductDetails()
		{
			return View();
		}
	}
}
