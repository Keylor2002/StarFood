using StarFood.Data;
using StarFood.Models;
using StarFood.Repository.IRepository;

namespace StarFood.Repository
{
    public class DetailOrderRepository : repository<DetalleOrden>, IDetailOrderRepository
    {
        private StarfoodContext _db;

        public DetailOrderRepository(StarfoodContext db) : base(db)
        {
            _db = db;
        }

        public void Update(DetalleOrden detallePedido)
        {
            _db.DetallesOrdenes.Update(detallePedido);
        }
    }
}
