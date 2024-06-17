using StarFood.Data;
using StarFood.Models;
using StarFood.Repository.IRepository;

namespace StarFood.Repository
{
    public class RepositorioProveedor : Repositorio<Proveedor>, IRepositorioProveedor
    {
        private StarfoodContext _db;

        public RepositorioProveedor(StarfoodContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Proveedor proveedor)
        {
            _db.Proveedores.Update(proveedor);
        }

        //public Proveedor GetLast() 
        //{ 
        //    return _db.Proveedores.OrderByDescending(p => p.IDProveedor).FirstOrDefault();
        //}

    }
}
