using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace StarFood.Models
{
    public class Usuario : IdentityUser
    {
        [Required]
        [StringLength(12)]
        public string Cedula { get; set; } //Numero de cedula

        [Required]
        [MaxLength(50)]
        public string NombreUsuario { get; set; }

        public bool Suspendido { get; set; }
    }
}
