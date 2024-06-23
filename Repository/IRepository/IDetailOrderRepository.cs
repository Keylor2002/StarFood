using StarFood.Models;

namespace StarFood.Repository.IRepository
{
    public interface IDetailOrderRepository : IRepository<Detalleorden>
    {
        void Update(Detalleorden detallePedido);
    }
}
