using Microsoft.AspNetCore.Mvc;
using MiProyectoMVC.Models;

namespace MiProyectoMVC.Controllers
{
    public class TurnosController : Controller
    {
        // GET: Turnos/Reservar
        public IActionResult Reservar()
        {
            return View();
        }

        // POST: Turnos/Reservar
        [HttpPost]
        public IActionResult Reservar(Turno turno)
        {
            if (ModelState.IsValid)
            {
                // Aquí deberías guardar el turno en base de datos o lista, pero para el ejemplo lo dejamos simple
                ViewBag.Mensaje = "Turno reservado con éxito para " + turno.Nombre + " el día " + turno.Fecha.ToShortDateString() + " a las " + turno.Hora;
                ModelState.Clear();  // Limpiar formulario
                return View();
            }
            return View(turno);
        }
    }
}
