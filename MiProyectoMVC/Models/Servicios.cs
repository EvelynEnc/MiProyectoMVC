using System;
using System.ComponentModel.DataAnnotations;

namespace MiProyectoMVC.Models
{
    public class Servicio
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }  // Nombre del servicio (ej. Corte clásico)

        [Required]
        [Range(0, 99999)]
        public decimal Precio { get; set; } // Precio del servicio

        [Display(Name = "Duración Aproximada (minutos)")]
        public int DuracionAproximada { get; set; } // En minutos

        public string Categoria { get; set; } // (ej. Corte, Afeitado, Peinado)
    }
}
