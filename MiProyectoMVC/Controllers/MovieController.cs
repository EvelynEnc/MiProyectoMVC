using Microsoft.AspNetCore.Mvc;
using MiProyectoMVC.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiProyectoMVC.Controllers
{
    public class MoviesCrudController : Controller
    {
        // GET: Movies/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Simulación de creación de un objeto (model)
            var movie = new Movie
            {
                Genre = "Terror",
                Id = 1,
                Price = 1,
                ReleaseDate = DateTime.Now,
                Title = "La noche del terror"
            };

            return View(movie);
        }

        // GET: Movies/Index
        public IActionResult Index()
        {
            var listMovies = new List<Movie>();

            var movie1 = new Movie
            {
                Genre = "Terror",
                Id = 1,
                Price = 1,
                ReleaseDate = DateTime.Now,
                Title = "La noche del terror"
            };
            listMovies.Add(movie1);

            var movie2 = new Movie
            {
                Genre = "Terror",
                Id = 2,
                Price = 1,
                ReleaseDate = DateTime.Now,
                Title = "La noche del terror II"
            };
            listMovies.Add(movie2);

            return View(listMovies);
        }
    }
}