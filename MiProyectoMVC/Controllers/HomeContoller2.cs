using Microsoft.AspNetCore.Mvc;

namespace MvcBarberia.Controllers
{
    
    public class HomeController2 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
