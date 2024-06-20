using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarFood.Models
{
    public class TransaccionProducto
    {
        Key]
    public int IDTransacProducto { get; set; }

        [ForeignKey("Producto")]
        public int IDProducto { get; set; }

        [ValidateNever]
        public Producto Producto { get; set; }

        [ForeignKey("Proveedor")]
        public int IDProveedor { get; set; }

        [ValidateNever]
        public Proveedor Proveedor { get; set; }

        [Required(ErrorMessage = "El precio de costo es obligatorio.")]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal PrecioCosto { get; set; }

        [Required(ErrorMessage = "La fecha de caducidad es obligatoria.")]
        public DateTime FechaCaducidad { get; set; }

        [Required(ErrorMessage = "La fecha de compra es obligatoria.")]
        public DateTime FechaCompra { get; set; }
    }
}
