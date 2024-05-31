using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StarFood.Models
{
    public class PedidoDeProducto
    {
        [Key]
        public int IDPedidoProducto { get; set; }

        public DateTime FechaPedido { get; set; }

        [ForeignKey("Producto")]
        public int IDProducto { get; set; }
        public Producto Producto { get; set; }

        public int Cantidad { get; set; }

        [ForeignKey("Proveedor")]
        public int IDProveedor { get; set; }
        public Proveedor Proveedor { get; set; }
    }
}
