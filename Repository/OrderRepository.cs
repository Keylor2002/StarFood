using StarFood.Data;
using StarFood.Models;
using StarFood.Repository.IRepository;

namespace StarFood.Repository
{
    public class OrderRepository : repository<Orden>, IOrderRepository
    {
        private StarfoodContext _db;

        public OrderRepository(StarfoodContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Orden pedido)
        {
            _db.Ordenes.Update(pedido);
        }

        public Orden GetLast()
        {
            return _db.Ordenes.OrderByDescending(p => p.IDOrden).FirstOrDefault();
        }
    }
}
