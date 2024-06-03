using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace StarFood.Models
{
    public class Usuario : IdentityUser
    {
        [Key]
        public string IDUsuario { get; set; }

        [Required]
        [MaxLength(50)]
        public string NombreUsuario { get; set; }
    }
}
