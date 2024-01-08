using Microsoft.AspNetCore.Mvc;

namespace FarmerCoopWebUI.Controllers
{
	public class SignalRDefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
