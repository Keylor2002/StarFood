using System.ComponentModel.DataAnnotations;

namespace StarFood.Models
{
    public class Proveedor
    {
        /*
        @[Tags] this allows you to add constraints both in the model and in the database.
        */
        [Key]
        public int IDProveedor { get; set; }

        [Required(ErrorMessage = "El nombre de la empresa es obligatorio.")]
        [MaxLength(50, ErrorMessage = "La longitud máxima para el nombre de la empresa es de 50 caracteres.")]
        public string Empresa { get; set; }

        [Required(ErrorMessage = "El contacto es obligatorio.")]
        [MaxLength(80, ErrorMessage = "La longitud máxima para el contacto es de 80 caracteres.")]
        public string Contacto { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(60, ErrorMessage = "La longitud máxima para el nombre es de 60 caracteres.")]
        public string Nombre { get; set; }

        public bool Suspendido { get; set; }
    }
}
