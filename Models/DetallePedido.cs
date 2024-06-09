using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StarFood.Models
{
    public class DetallePedido
    {
        [Key]
        public int IDDetallePedido { get; set; }

        [ForeignKey("Pedido")]
        public int IDPedido { get; set; }
        public Pedido Pedido { get; set; }

        [ForeignKey("Platillo")]
        public int IDPlatillo { get; set; }
        public Platillo Platillo { get; set; }

        public int Cantidad { get; set; }

        [NotMapped]
        public ICollection<Platillo> Platillos { get; set; } = new List<Platillo>();
    }
}
