using System.ComponentModel.DataAnnotations;

namespace MiProyectoMVC.Models
{
    public class ClienteModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [Phone(ErrorMessage = "Ingrese un teléfono válido")]
        public string telefono { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "Ingrese un email válido")]
        public string email { get; set; }
    }
}

