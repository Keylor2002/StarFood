using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StarFood.Models
{
    public class Platillo
    {
        [Key]
        public int IDPlatillo { get; set; }

        [Required]
        [MaxLength(60)]
        public string Nombre { get; set; }

        [ForeignKey("Categoria")]
        public int CategoriaID { get; set; }
        public Categoria Categoria { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Precio { get; set; }

        public string Descripcion { get; set; }

        public bool Suspendido { get; set; }

        [Required]
        public string ImagenUrl { get; set; }
    }
}
