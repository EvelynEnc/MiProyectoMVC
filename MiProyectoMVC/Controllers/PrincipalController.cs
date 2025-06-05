using Microsoft.AspNetCore.Mvc;
using MiProyectoMVC.Models;


namespace MiProyectoMVC.Controllers
{
    public class PrincipalController : Controller
    {
        public IActionResult Principal()
        {
            var modelo = new PrincipalModel
            {
                Mensaje = "Bienvenidos al Panel Principal",
                FechaIngreso = DateTime.Now
            };

            ViewBag.Saludo = "Este saludo viene desde ViewBag también.";

            return View("Principal", modelo);

        }

    }
}
