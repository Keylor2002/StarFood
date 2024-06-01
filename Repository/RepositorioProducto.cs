using StarFood.Data;
using StarFood.Models;
using StarFood.Repository.IRepository;

namespace StarFood.Repository
{
    public class RepositorioProducto : Repositorio<Producto>, IRepositorioProducto
    {
        private StarfoodContext _db;

        public RepositorioProducto(StarfoodContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Producto producto)
        {
            _db.Productos.Update(producto);
        }

        public Producto GetLast()
        {
            return _db.Productos.OrderByDescending(p => p.IDProducto).FirstOrDefault();
        }
    }
}
