using StarFood.Data;
using StarFood.Models;
using StarFood.Repository.IRepository;

namespace StarFood.Repository
{
    public class RepositorioMetodoPago : Repositorio<MetodoPago>, IRepositorioMetodoPago
    {
        private StarfoodContext _db;

        public RepositorioMetodoPago(StarfoodContext db) : base(db)
        {
            _db = db;
        }

        public void Update(MetodoPago metodo_pago)
        {
            _db.MetodosPago.Update(metodo_pago);
        }

        public MetodoPago GetLast()
        {
            return _db.MetodosPago.OrderByDescending(m => m.IDMetodoPago).FirstOrDefault();
        }
    }
}
