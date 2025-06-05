using MiProyectoMVC.BaseDeDatosFicticia;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace MiProyectoMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = FakeUserDB.Users.FirstOrDefault(u => u.User == username && u.Password == password);

            if (user != null)
            {
                // Creamos los claims, incluyendo el rol
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.User),
                    new Claim(ClaimTypes.Role, user.Roles!) // ← Agregado claim de rol
                };

                var identity = new ClaimsIdentity(claims, "Cookies");
                var principal = new ClaimsPrincipal(identity);

                HttpContext.Session.SetString("User", user.User);

                await HttpContext.SignInAsync("Cookies", principal);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Credenciales inválidas";
                return View();
            }
        }

        // GET: Logout
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Cookies");
            return RedirectToAction("Login");
        }
    }
}