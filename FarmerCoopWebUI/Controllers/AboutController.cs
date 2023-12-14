using Microsoft.AspNetCore.Mvc;

namespace FarmerCoopWebUI.Controllers
{
	public class AboutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
