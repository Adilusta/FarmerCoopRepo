using Microsoft.AspNetCore.Mvc;

namespace FarmerCoopWebUI.ViewComponents.Post
{
    public class LastThreePostsViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
