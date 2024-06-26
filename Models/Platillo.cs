using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace StarFood.Models
{
    public class Platillo
    {
        /*
        @[Tags] this allows you to add constraints both in the model and in the database.
        */
        [Key]
        public int IDPlatillo { get; set; }

        [Required(ErrorMessage = "El nombre del platillo es obligatorio.")]
        [MaxLength(60, ErrorMessage = "La longitud máxima para el nombre del platillo es de 60 caracteres.")]
        public string Nombre { get; set; }

        [ForeignKey("Categoria")]
        public int CategoriaID { get; set; }

        [ValidateNever]
        public Categoria Categoria { get; set; }

        [Required(ErrorMessage = "El precio del platillo es obligatorio.")]
        [Column(TypeName = "decimal(10, 2)")]
        [Range(0.01, 9999999999.99, ErrorMessage = "El precio del platillo debe estar entre 0.01 y 9999999999.99.")]
        public decimal Precio { get; set; }

        public string Descripcion { get; set; }

        public bool Suspendido { get; set; }
        [Required]
        public string ImagenUrl { get; set; }
        
        [ValidateNever]
        public ICollection<DetallePlatillo> DetallePlatillo { set; get; }
    }
}
