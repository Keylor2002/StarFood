using StarFood.Models;

namespace StarFood.Repository.IRepository
{
    public interface IRepositorioDetallePedido : IRepositorio<DetallePedido>
    {
        void Update(DetallePedido detallePedido);
    }
}
