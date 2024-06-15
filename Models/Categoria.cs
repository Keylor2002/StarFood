using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace StarFood.Models
{
    public class Categoria
    {
        [Key]
        public int IDCategoria { get; set; }

        [Required]
        [MaxLength(80)]
        public string Nombre { get; set; }

        [ValidateNever]
        public bool Suspendido { get; set; }
    }
}
