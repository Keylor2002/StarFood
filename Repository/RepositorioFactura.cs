using StarFood.Data;
using StarFood.Models;
using StarFood.Repository.IRepository;

namespace StarFood.Repository
{
    public class RepositorioFactura : Repositorio<Factura>, IRepositorioFactura
    {
        private StarfoodContext _db;

        public RepositorioFactura(StarfoodContext db) : base(db)
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
