using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace FarmerCoopWebUI.Controllers
{
    public class DenemeController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal(new FarmerCoopDbContext()) );
        [HttpGet]
        public IActionResult Index()
        {
          var values=  commentManager.GetAll(x=> x.CommentUserName=="adilusta");
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Comment comment)
        {
            commentManager.Insert(comment);
            return View(comment);
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(Comment comment)
        {
            commentManager.Delete(comment);
            return View(comment);
        }

    }
}
