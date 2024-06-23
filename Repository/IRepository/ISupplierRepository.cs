using StarFood.Models;

namespace StarFood.Repository.IRepository
{
    public interface ISupplierRepository : IRepository<Proveedor>
    {
        void Update(Proveedor proveedor);

        //Proveedor GetLast();
    }
}
