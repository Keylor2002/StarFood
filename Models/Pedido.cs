using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StarFood.Models
{
    public class Pedido
    {
        [Key]
        public int IDPedido { get; set; }

        [ForeignKey("Usuario")]
        public int IDUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
    }
}
