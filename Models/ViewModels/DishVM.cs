namespace StarFood.Models.ViewModels
{
    public class DishVM
    {
        public Platillo Dish { get; set; }

        public IEnumerable<Platillo> Dishes { get; set; }

        public IEnumerable<Categoria> Categorias { get; set; }

    
    }
}