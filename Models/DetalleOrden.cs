using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace StarFood.Models
{
    public class Detalleorden
    {
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
        public int Cantidad { get; set; }

    }
}
