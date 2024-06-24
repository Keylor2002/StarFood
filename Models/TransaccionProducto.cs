using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarFood.Models
{
    public class TransaccionProducto
    {
        [Key]
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

        [Range(0, int.MaxValue, ErrorMessage = "La cantidad existente debe ser un valor positivo.")]
        public int cantidad { get; set; }

        [Required(ErrorMessage = "El precio de venta es obligatorio.")]
        [Column(TypeName = "decimal(10, 2)")]
        [Range(0, 9999999999.99, ErrorMessage = "El precio de venta debe estar entre 0 y 9999999999.99.")]
        public decimal PrecioVenta { get; set; }

        [Required(ErrorMessage = "La fecha de caducidad es obligatoria.")]
        public DateTime FechaCaducidad { get; set; }

        [Required(ErrorMessage = "La fecha de compra es obligatoria.")]
        public DateTime FechaCompra { get; set; }
    }
}
