using StarFood.Models;

namespace StarFood.Repository.IRepository
{
    public interface ITransactProductRepository : IRepository<TransaccionProducto>
    {
        void Update(TransaccionProducto transaccionProducto);
    }
}
