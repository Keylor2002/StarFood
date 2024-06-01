using StarFood.Data;
using StarFood.Models;
using StarFood.Repository.IRepository;

namespace StarFood.Repository
{
    public class RepositorioPedido : Repositorio<Pedido>, IRepositorioPedido
    {
        private StarfoodContext _db;

        public RepositorioPedido(StarfoodContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Pedido pedido)
        {
            _db.Pedidos.Update(pedido);
        }

        public Pedido GetLast()
        {
            return _db.Pedidos.OrderByDescending(p => p.IDPedido).FirstOrDefault();
        }
    }
}
