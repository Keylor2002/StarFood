using StarFood.Models;

namespace StarFood.Repository.IRepository
{
    public interface IRepositorioPedido : IRepositorio<Orden>
    {
        void Update(Orden pedido);
    }
}
