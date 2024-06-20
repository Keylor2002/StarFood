using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace StarFood.Models
{
    public class Usuario : IdentityUser
    {
        [Required]
        [StringLength(9)]
        public string IDUsuario { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "La longitud máxima es de 30 caracteres.")]
        [MinLength(4, ErrorMessage = "La longitud minima es de 4 caracteres.")]
        [RegularExpression(@"^[^0-9]*$", ErrorMessage = "El campo no puede contener números.")]
        public string NombreUsuario { get; set; }

        public bool Suspendido { get; set; }
    }
}
