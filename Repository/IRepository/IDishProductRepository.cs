using StarFood.Models;

namespace StarFood.Repository.IRepository
{
    public interface IDishProductRepository : IRepository<PlatilloProducto>
    {
        void Update(PlatilloProducto platillo_producto);
    }
}
