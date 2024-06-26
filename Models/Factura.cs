using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace StarFood.Models
{
    public class Factura
    {
        /*
        @[Tags] this allows you to add constraints both in the model and in the database.
        */
        [Key]
        public int IDFactura { get; set; }

        [ForeignKey("Orden")]
        public int IDOrden { get; set; }

        [ValidateNever]
        public Orden Orden { get; set; }

        public DateTime FechaVenta { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal TotalVenta { get; set; }

        [ForeignKey("MetodoPago")]
        public int IDMetodoPago { get; set; }

        [ValidateNever]
        public MetodoPago MetodoPago { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal CantidadPago { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal CantidadCambio { get; set; }
    }
}
