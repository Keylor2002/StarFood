using StarFood.Data;
using StarFood.Models;
using StarFood.Repository.IRepository;

namespace StarFood.Repository
{
    public class RepositorioPlatilloProducto : Repositorio<PlatilloProducto>, IRepositorioPlatilloProducto
    {
        private StarfoodContext _db;

        public RepositorioPlatilloProducto(StarfoodContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PlatilloProducto platillo_producto)
        {
            _db.PlatillosProductos.Update(platillo_producto);
        }
    }
}