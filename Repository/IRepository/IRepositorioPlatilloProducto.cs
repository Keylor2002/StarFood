using StarFood.Models;

namespace StarFood.Repository.IRepository
{
    public interface IRepositorioPlatilloProducto : IRepositorio<PlatilloProducto>
    {
        void Update(PlatilloProducto platillo_producto);
    }
}
