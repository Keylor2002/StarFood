using StarFood.Data;
using StarFood.Models;
using StarFood.Repository.IRepository;

namespace StarFood.Repository
{
    public class RepositorioPedido : Repositorio<Orden>, IRepositorioPedido
    {
        private StarfoodContext _db;

        public RepositorioPedido(StarfoodContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Orden pedido)
        {
            _db.Pedidos.Update(pedido);
        }

        public Orden GetLast()
        {
            return _db.Pedidos.OrderByDescending(p => p.IDPedido).FirstOrDefault();
        }
    }
}
