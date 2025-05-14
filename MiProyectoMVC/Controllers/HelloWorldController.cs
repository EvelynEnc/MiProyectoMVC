using Microsoft.AspNetCore.Mvc;


namespace MvcBarberia.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Welcome", new { name = "Sofi", numTimes = 3 });
        }

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}
