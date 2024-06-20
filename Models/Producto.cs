using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace StarFood.Models
{
    public class Producto
    {
        [Key]
        public int IDProducto { get; set; }

        [Required]
        [MaxLength(60)]
        public string Nombre { get; set; }

        [ForeignKey("Categoria")]
        public int CategoriaID { get; set; }
        [ValidateNever]
        public Categoria Categoria { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal PrecioCosto { get; set; }

        [ValidateNever]
        public int CantidadExistente { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal PrecioVenta { get; set; }

        [MaxLength(50)]
        public string UnidadMedida { get; set; }

        public DateTime FechaCaducidad { get; set; }
        public DateTime FechaCompra { get; set; }

        [ForeignKey("Proveedor")]
        public int IDProveedor { get; set; }
        [ValidateNever]
        public Proveedor Proveedor { get; set; }

        public bool Suspendido { get; set; }
    }
}
