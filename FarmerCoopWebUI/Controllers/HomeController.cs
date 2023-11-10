using FarmerCoopWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FarmerCoopWebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}