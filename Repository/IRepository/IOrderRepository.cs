using StarFood.Models;

namespace StarFood.Repository.IRepository
{
    public interface IOrderRepository : IRepository<Orden>
    {
        void Update(Orden pedido);
    }
}
