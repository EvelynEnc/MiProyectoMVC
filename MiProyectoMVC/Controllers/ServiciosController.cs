using Microsoft.AspNetCore.Mvc;
using MiProyectoMVC.Models;
using System.Collections.Generic;

namespace MiProyectoMVC.Controllers
{
    public class MvcBarberiaController : Controller
    {
        // GET: MvcBarberia/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicio = new Servicio
            {
                Id = 1,
                Nombre = "Corte Clásico",
                Precio = 6000,
                DuracionAproximada = 40,
                Categoria = "Corte"
            };

            return View(servicio);
        }

        // GET: MvcBarberia/Index
        public IActionResult Index()
        {
            var listaServicios = new List<Servicio>
            {
                new Servicio
                {
                    Id = 1,
                    Nombre = "Corte Clásico",
                    Precio = 6000,
                    DuracionAproximada = 40,
                    Categoria = "Corte"
                },
                new Servicio
                {
                    Id = 2,
                    Nombre = "Afeitado con toalla caliente",
                    Precio = 1200,
                    DuracionAproximada = 20,
                    Categoria = "Afeitado"
                }
            };

            return View(listaServicios);
        }
    }
}