using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace StarFood.Models
{
    public class Pedido
    {
        [Key]
        public int IDPedido { get; set; }

        //LLave foranea sobre Id del usuario
        [ForeignKey("Usuario")]
        public string Id { get; set; } //Identificador de usuario por identityUser
        
        [ValidateNever]
        public Usuario Usuario { get; set; }

        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }

        [ValidateNever]
        public ICollection<DetallePedido> DetallePedido { get; set; } 
        public bool Cancelado { get; set; }
        public bool EnProceso { get; set; }
        public bool Entregado {  get; set; }
    }
}
