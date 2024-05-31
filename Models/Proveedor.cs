using System.ComponentModel.DataAnnotations;

namespace StarFood.Models
{
    public class Proveedor
    {
        [Key]
        public int IDProveedor { get; set; }

        [Required]
        [MaxLength(50)]
        public string Empresa { get; set; }

        [Required]
        [MaxLength(80)]
        public string Contacto { get; set; }

        [Required]
        [MaxLength(60)]
        public string Nombre { get; set; }
    }
}
