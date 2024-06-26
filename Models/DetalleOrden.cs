using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace StarFood.Models
{
    public class DetalleOrden
    {
        /*
        @[Tags] this allows you to add constraints both in the model and in the database.
        */
        [Key]
        public int IDDetalleOrden { get; set; }

        [ForeignKey("Orden")]
        public int IDOrden { get; set; }

        [ValidateNever]
        public Orden Orden { get; set; }
 
        [ValidateNever]
        public ICollection<Platillo> Platillo { get; set; }

        [ValidateNever]
        public ICollection<Producto> Producto { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que cero.")]
        public int Cantidad { get; set; }

    }
}
