using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace StarFood.Models
{
    public class Orden
    {
        /*
        @[Tags] this allows you to add constraints both in the model and in the database.
        */
        [Key]
        public int IDOrden { get; set; }

        public string IDUsuario { get; set; }
        
        [ValidateNever]
        public Usuario Usuario { get; set; }

        [Required(ErrorMessage = "La fecha del pedido es obligatoria.")]
        public DateTime FechaOrden { get; set; }

        [ValidateNever]
        public DateTime FechaEntrega { get; set; }

        [ValidateNever]
        public ICollection<DetalleOrden> DetalleOrden { get; set; }

        [ValidateNever]
        public bool Entregado {  get; set; }

        [ValidateNever]
        public bool Cancelado { get; set; }
    }
}
