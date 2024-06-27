namespace StarFood.Models.ViewModels
{
    public class SupplierVM
    {
        public Proveedor Supplier { get; set; }

        public IEnumerable<Proveedor> Suppliers { get; set; }
    }
}
