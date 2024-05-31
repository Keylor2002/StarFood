using System.ComponentModel.DataAnnotations;

namespace StarFood.Models
{
    public class MetodoPago
    {
        [Key]
        public int IDMetodoPago { get; set; }

        [Required]
        [MaxLength(60)]
        public string NombreMetodoPago { get; set; }
    }
}
