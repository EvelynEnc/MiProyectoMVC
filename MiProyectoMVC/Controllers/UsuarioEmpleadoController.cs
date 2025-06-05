using Microsoft.AspNetCore.Mvc;
using MiProyectoMVC.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace MiProyectoMVC.Controllers
{
    public class UsuarioEmpleadoController : Controller
    {
        private string connectionString = "Server=EVELYN;Database=programacionV;Trusted_Connection=True;TrustServerCertificate=True;";

        // GET: Lista de Empleados
        public IActionResult Index()
        {
            List<UsuarioEmpleadoModel> empleados = new List<UsuarioEmpleadoModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT id, username, name, fechanacimiento, email FROM Usuario";
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        empleados.Add(new UsuarioEmpleadoModel
                        {
                            id = Convert.ToInt32(reader["id"]),
                            username = reader["username"].ToString(),
                            name = reader["name"].ToString(),
                            fechanacimiento = Convert.ToDateTime(reader["fechanacimiento"]),
                            email = reader["email"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error al obtener empleados: {ex.Message}");
            }

            return View(empleados); // Vista: Index.cshtml
        }

        // GET: Formulario de Registro
        public IActionResult Registrar()
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole != "Empleado" && userRole != "Dueño")
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            // Si el usuario es Empleado o Dueño, mostramos la vista del formulario
            return View();
        }


        [HttpPost]
        public IActionResult Registrar(UsuarioEmpleadoModel empleado)
        {
            if (!ModelState.IsValid)
                return View(empleado);

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Usuario(username, name, fechanacimiento, email, password) " +
                                   "VALUES (@username, @name, @fechanacimiento, @email, @password)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", empleado.username);
                    command.Parameters.AddWithValue("@name", empleado.name);
                    command.Parameters.AddWithValue("@fechanacimiento", empleado.fechanacimiento);
                    command.Parameters.AddWithValue("@email", empleado.email);
                    command.Parameters.AddWithValue("@password", empleado.password);

                    connection.Open();
                    command.ExecuteNonQuery();

                    TempData["Mensaje"] = "Empleado registrado correctamente.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error al registrar empleado: {ex.Message}");
                return View(empleado);
            }

            // 👇 Esto evita el error, aunque en teoría no se debería llegar hasta acá.
            return View(empleado);
        }


    }
}
