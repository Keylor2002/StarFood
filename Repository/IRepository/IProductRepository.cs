using StarFood.Models;

namespace StarFood.Repository.IRepository
{
    public interface IProductRepository : IRepository<Producto>
    {
        void Update(Producto producto);
    }
}
