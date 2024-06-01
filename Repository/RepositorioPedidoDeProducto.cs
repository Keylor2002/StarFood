using StarFood.Data;
using StarFood.Models;
using StarFood.Repository.IRepository;

namespace StarFood.Repository
{
    public class RepositorioPedidoDeProducto : Repositorio<PedidoDeProducto>, IRepositorioPedidoDeProducto
    {
        private StarfoodContext _db;

        public RepositorioPedidoDeProducto(StarfoodContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PedidoDeProducto pedido_producto)
        {
            _db.PedidosDeProducto.Update(pedido_producto);
        }

        public PedidoDeProducto GetLast()
        {
            return _db.PedidosDeProducto.OrderByDescending(p => p.IDPedidoProducto).FirstOrDefault();
        }
    }
}
