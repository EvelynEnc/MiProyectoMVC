using Microsoft.AspNetCore.Mvc;

namespace MvcMovie.Controllers
{
    public class HomeController2 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
