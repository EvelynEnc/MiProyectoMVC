using Microsoft.EntityFrameworkCore;
using MiProyectoMVC.Models; // Importa los modelos, no los controladores

namespace MiProyectoMVC.Models
{
    public class MvcBarberiaContext : DbContext
    {
        public MvcBarberiaContext(DbContextOptions<MvcBarberiaContext> options)
            : base(options)
        {
        }

        public DbSet<Servicio> Servicios { get; set; }
    }
}