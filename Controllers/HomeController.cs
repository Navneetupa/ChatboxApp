using Microsoft.AspNetCore.Mvc;

namespace ChatboxApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Landing()
        {
            return View();
        }
    }
}
