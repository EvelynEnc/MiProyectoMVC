using Microsoft.AspNetCore.Mvc;
using MiProyectoMVC.Models;
using System.Collections.Generic;


namespace MiProyectoMVC.Controllers
{
    public class ClienteController : Controller
    {
        // Simulamos una "base de datos" en memoria para probar
        static List<ClienteModel> clientes = new List<ClienteModel>();

        // GET: Cliente
        public ActionResult Index()
        {
            return View(clientes);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(ClienteModel cliente)
        {
            if (ModelState.IsValid)
            {
                // En un proyecto real, acá guardarías en la base de datos
                cliente.id = clientes.Count + 1;
                clientes.Add(cliente);

                return RedirectToAction("Index");
            }
            // Si hay errores, vuelve a mostrar el formulario con mensajes
            return View(cliente);
        }
    }
}
