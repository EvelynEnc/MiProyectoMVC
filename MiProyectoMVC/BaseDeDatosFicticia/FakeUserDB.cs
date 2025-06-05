using MiProyectoMVC.Models;

namespace MiProyectoMVC.BaseDeDatosFicticia
{
    public class FakeUserDB
    {
        public static List<LoginModel> Users = new List<LoginModel>
        {
            new LoginModel
            {
                Id = 1,
                User = "admin",
                Password = "43736385",
                Roles = "Dueño" // 👈 rol agregado
            },
            new LoginModel
            {
                Id = 2,
                User = "empleado1",
                Password = "1234",
                Roles = "Empleado" // 👈 otro rol
            }
        };
    }
}
