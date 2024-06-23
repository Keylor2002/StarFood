using StarFood.Data;
using StarFood.Models;
using StarFood.Repository.IRepository;

namespace StarFood.Repository
{
    public class PaymentMethodRepository : repository<MetodoPago>, IRepositoryPaymentMethod
    {
        private StarfoodContext _db;

        public PaymentMethodRepository(StarfoodContext db) : base(db)
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
