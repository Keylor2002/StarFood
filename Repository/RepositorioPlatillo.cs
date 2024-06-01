using StarFood.Data;
using StarFood.Models;
using StarFood.Repository.IRepository;

namespace StarFood.Repository
{
    public class RepositorioPlatillo : Repositorio<Platillo>, IRepositorioPlatillo
    {
        private StarfoodContext _db;

        public RepositorioPlatillo(StarfoodContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Platillo platillo)
        {
            _db.Platillos.Update(platillo);
        }

        public Platillo GetLast()
        {
            return _db.Platillos.OrderByDescending(p => p.IDPlatillo).FirstOrDefault();
        }
    }
}
