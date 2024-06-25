using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace StarFood.Models
{
    public class Detalleorden
    {
        /*
        @[Tags] this allows you to add constraints both in the model and in the database.
        */
        [Key]
        public int IDDetallePedido { get; set; }

        [ForeignKey("Pedido")]
        public int IDPedido { get; set; }

        [ValidateNever]
        public Orden Pedido { get; set; }
 
        [ForeignKey("Platillo")]
        public int IDPlatillo { get; set; }

        [ValidateNever]
        public Platillo Platillo { get; set; } 

        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que cero.")]
        public int Cantidad { get; set; }

    }
}
