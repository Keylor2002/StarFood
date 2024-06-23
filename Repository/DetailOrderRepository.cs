using StarFood.Data;
using StarFood.Models;
using StarFood.Repository.IRepository;

namespace StarFood.Repository
{
    public class DetailOrderRepository : repository<Detalleorden>, IDetailOrderRepository
    {
        private StarfoodContext _db;

        public DetailOrderRepository(StarfoodContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Detalleorden detallePedido)
        {
            _db.DetallesPedido.Update(detallePedido);
        }
    }
}
