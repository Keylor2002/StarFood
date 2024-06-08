using System.ComponentModel.DataAnnotations;

namespace StarFood.Models
{
    public class Categoria
    {
        [Key]
        public int IDCategoria { get; set; }

        [Required]
        [StringLength(80)]
        public string Nombre { get; set; }
    }
}
