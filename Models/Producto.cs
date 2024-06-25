using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace StarFood.Models
{
    /*
    The Producto class acts as a model and data master in the system.
    @IDProducto it is a product identifier.
    @Nombre it is a name with which the product wants to be recognized in the system.
    @CategoriaID it is a foreign key to identify the category to which the product belongs.
    @Categoria it is a category object to use the attributes of the category to which the product belongs.
    @Precioventa it is a price to sell product.
    @CantidadExistente it is existing quantity of product.
    @UnidadMedida it is the measurement of units or weight that the product will have.
    @Suspendido this is what allows you to block or unblock a product.
    */
    public class Producto
    {

        /*
        @[Tags] this allows you to add constraints both in the model and in the database.
        */
        [Key]
        public int IDProducto { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(50, ErrorMessage = "La longitud máxima es de 50 caracteres.")]
        [MinLength(4, ErrorMessage = "La longitud mínima es de 4 caracteres.")]
        [RegularExpression(@"^[^0-9]*$", ErrorMessage = "El nombre no puede contener números.")]
        public string Nombre { get; set; }

        [ForeignKey("Categoria")]
        [Required(ErrorMessage = "La categoría es obligatoria.")]
        public int CategoriaID { get; set; }

        [ValidateNever]
        public Categoria Categoria { get; set; }

        [ValidateNever]
        [Required(ErrorMessage = "El precio de venta es obligatorio.")]
        [Column(TypeName = "decimal(10, 2)")]
        [Range(0, 9999999999.99, ErrorMessage = "El precio de venta debe estar entre 0 y 9999999999.99.")]
        public decimal PrecioVenta { get; set; }

        [ValidateNever]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad existente debe ser un valor positivo.")]
        public int CantidadExistente { get; set; }

        [MaxLength(50, ErrorMessage = "La longitud máxima es de 50 caracteres.")]
        public string UnidadMedida { get; set; }

        public bool Suspendido { get; set; }
    }
}
