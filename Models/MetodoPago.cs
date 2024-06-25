using System.ComponentModel.DataAnnotations;

namespace StarFood.Models
{
    public class MetodoPago
    {
        /*
        @[Tags] this allows you to add constraints both in the model and in the database.
        */
        [Key]
        public int IDMetodoPago { get; set; }

        [Required(ErrorMessage = "El nombre del método de pago es obligatorio.")]
        [MaxLength(60, ErrorMessage = "La longitud máxima para el nombre del método de pago es de 60 caracteres.")]
        public string NombreMetodoPago { get; set; }
    }
}
