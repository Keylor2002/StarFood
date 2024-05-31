using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StarFood.Models
{
    public class Factura
    {
        [Key]
        public int IDFactura { get; set; }

        [ForeignKey("Pedido")]
        public int IDPedido { get; set; }
        public Pedido Pedido { get; set; }

        public DateTime FechaVenta { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal TotalVenta { get; set; }

        [ForeignKey("MetodoPago")]
        public int IDMetodoPago { get; set; }
        public MetodoPago MetodoPago { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal CantidadPago { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal CantidadCambio { get; set; }
    }
}
