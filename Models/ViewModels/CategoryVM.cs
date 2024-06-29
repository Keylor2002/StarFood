namespace StarFood.Models.ViewModels
{
    public class CategoryVM
    {
        public Categoria Category { get; set; }
        public IEnumerable<Categoria> Categories { get; set; }
    }
}
