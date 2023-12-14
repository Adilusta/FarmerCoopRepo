using Microsoft.AspNetCore.Mvc;

namespace FarmerCoopWebUI.Controllers
{
	public class ContactController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
