using StarFood.Models;

namespace StarFood.Repository.IRepository
{
    public interface IRepositorioPedido : IRepositorio<Pedido>
    {
        void Update(Pedido pedido);
    }
}
