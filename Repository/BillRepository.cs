using StarFood.Data;
using StarFood.Models;
using StarFood.Repository.IRepository;

namespace StarFood.Repository
{
    public class BillRepository : repository<Factura>, IBillRepository
    {
        private StarfoodContext _db;

        public BillRepository(StarfoodContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Factura factura)
        {
            _db.Facturas.Update(factura);
        }

        public Factura GetLast()
        {
            return _db.Facturas.OrderByDescending(f => f.IDFactura).FirstOrDefault();
        }
    }
}
