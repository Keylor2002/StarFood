using System.ComponentModel.DataAnnotations;

namespace StarFood.Models
{
    public class Categoria
    {
        [Key]
        public int IDCategoria { get; set; }

        [Required]
        [MaxLength(80)]
        public string Nombre { get; set; }

        public bool Suspendido { get; set; }
    }
}
