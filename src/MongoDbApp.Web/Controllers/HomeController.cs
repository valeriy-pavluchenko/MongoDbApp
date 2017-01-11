using Microsoft.AspNetCore.Mvc;

namespace MongoDbApp.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
