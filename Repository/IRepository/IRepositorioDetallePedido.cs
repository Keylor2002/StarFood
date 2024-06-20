using StarFood.Models;

namespace StarFood.Repository.IRepository
{
    public interface IRepositorioDetallePedido : IRepositorio<Detalleorden>
    {
        void Update(Detalleorden detallePedido);
    }
}
