using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace StarFood.Models
{
    public class Categoria
    {
        [Key]
        public int IDCategoria { get; set; }

        [Required(ErrorMessage = "Es necesario agregar el nombre")]
        [MaxLength(30, ErrorMessage = "La longitud máxima es de 30 caracteres.")]
        [MinLength(4, ErrorMessage = "La longitud minima es de 4 caracteres.")]
        [RegularExpression(@"^[^0-9]*$", ErrorMessage = "El campo no puede contener números.")]
        public string Nombre { get; set; }

        [ValidateNever]
        public bool Suspendido { get; set; }
    }
}
