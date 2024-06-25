using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace StarFood.Models
{
    /*
    The Usuario class acts as a model and inherits properties from IdentityUser for login.
    @IDUsuario it is a user DNI.
    @NombreUsuario it is a short name or nickname with which the user wants to be recognized in the system.
    @Suspendido this is what allows you to block or unblock a user.
    */
    public class Usuario : IdentityUser
    {
        /*
        @[Tags] this allows you to add constraints both in the model and in the database.
        */
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
