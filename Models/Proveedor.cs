using System.ComponentModel.DataAnnotations;

namespace StarFood.Models
{
    public class Proveedor
    {
        [Key]
        public int IDProveedor { get; set; }

        [Required]
        [StringLength(50)]
        public string Empresa { get; set; }

        [Required]
        [StringLength(80)]
        public string Contacto { get; set; }

        [Required]
        [StringLength(60)]
        public string Nombre { get; set; }
    }
}
