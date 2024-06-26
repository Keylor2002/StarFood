using StarFood.Models;

namespace StarFood.Repository.IRepository
{
    public interface IDetailOrderRepository : IRepository<DetalleOrden>
    {
        void Update(DetalleOrden detallePedido);
    }
}
