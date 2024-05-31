using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StarFood.Models
{
    public class PlatilloProducto
    {
        [Key]
        public int IDPlatilloProducto { get; set; }

        [ForeignKey("Platillo")]
        public int IDPlatillo { get; set; }
        public Platillo Platillo { get; set; }

        [ForeignKey("Producto")]
        public int IDProducto { get; set; }
        public Producto Producto { get; set; }

        public int CantidadProducto { get; set; }
    }
}
