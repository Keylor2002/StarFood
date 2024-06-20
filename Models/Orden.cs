using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace StarFood.Models
{
    public class Orden
    {
        [Key]
        public int IDPedido { get; set; }

        public string IDUsuario { get; set; }
        
        [ValidateNever]
        public Usuario Usuario { get; set; }

        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }

        public ICollection<Detalleorden> DetallePedido { get; set; } 
        public bool Cancelado { get; set; }
    }
}
