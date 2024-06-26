using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace StarFood.Models
{
    public class DetallePlatillo
    {
        /*
        @[Tags] this allows you to add constraints both in the model and in the database.
        */
        [Key]
        public int IDDetallePlatillo { get; set; }

        [ForeignKey("Platillo")]
        public int IDPlatillo { get; set; }

        [ValidateNever]
        public Platillo Platillo { get; set; }

        public int CantidadProducto { get; set; }

        public int IDProducto { get; set; }

        [ValidateNever]
        public Producto Producto { get; set; } 
    }
}
