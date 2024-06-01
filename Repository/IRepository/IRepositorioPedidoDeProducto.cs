using StarFood.Models;

namespace StarFood.Repository.IRepository
{
    public interface IRepositorioPedidoDeProducto : IRepositorio<PedidoDeProducto>
    {
        void Update(PedidoDeProducto pedido_de_producto);
    }
}
