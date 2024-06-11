using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace StarFood.Models
{
    public class PedidoDeProducto
    {
        [Key]
        public int IDPedidoProducto { get; set; }

        [Required]
        public DateTime FechaPedido { get; set; }

        [ForeignKey("Producto")]
        
        public int IDProducto { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [ForeignKey("Proveedor")]
        public int IDProveedor { get; set; }

        [ValidateNever]
        public Producto Producto { get; set; }

        [ValidateNever]
        public Proveedor Proveedor { get; set; }
    }
}
