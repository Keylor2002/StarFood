using StarFood.Models;

namespace StarFood.Repository.IRepository
{
    public interface IRepositorioProducto : IRepositorio<Producto>
    {
        void Update(Producto producto);
    }
}
