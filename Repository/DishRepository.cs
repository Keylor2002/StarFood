using StarFood.Data;
using StarFood.Models;
using StarFood.Repository.IRepository;

namespace StarFood.Repository
{
    public class DishRepository : repository<Platillo>, IDishRepository
    {
        private StarfoodContext _db;

        public DishRepository(StarfoodContext db) : base(db)
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
