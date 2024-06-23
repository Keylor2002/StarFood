using StarFood.Data;
using StarFood.Models;
using StarFood.Repository.IRepository;

namespace StarFood.Repository
{
    public class SupplierRepository : repository<Proveedor>, ISupplierRepository
    {
        private StarfoodContext _db;

        public SupplierRepository(StarfoodContext db) : base(db)
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
