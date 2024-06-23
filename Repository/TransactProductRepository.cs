using Microsoft.EntityFrameworkCore;
using StarFood.Data;
using StarFood.Models;
using StarFood.Repository.IRepository;

namespace StarFood.Repository
{
    public class TransactProductRepository : repository<TransaccionProducto>, ITransactProductRepository
    {
        private StarfoodContext _db;

        public TransactProductRepository(StarfoodContext db) : base(db)
        {
            _db = db;
        }

        public void Update(TransaccionProducto transaccionProducto)
        {
            _db.TransaccionProducto.Update(transaccionProducto);
        }
    }
}
