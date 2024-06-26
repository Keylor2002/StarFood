using StarFood.Data;
using StarFood.Models;
using StarFood.Repository.IRepository;

namespace StarFood.Repository
{
    public class DetailDishRepository : repository<DetallePlatillo>, IDetailDishRepository
    {
        private StarfoodContext _db;

        public DetailDishRepository(StarfoodContext db) : base(db)
        {
            _db = db;
        }

        public void Update(DetallePlatillo detalle_Platillo)
        {
            _db.DetallesPlatillos.Update(detalle_Platillo);
        }
    }
}