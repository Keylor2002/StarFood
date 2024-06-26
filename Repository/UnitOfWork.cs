using StarFood.Data;
using StarFood.Repository.IRepository;
using Microsoft.AspNetCore.Identity;

namespace StarFood.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private StarfoodContext _db;

        public ICategoryRepository Categoria { get; private set; }
        public IDishProductRepository PlatilloProducto { get; private set; }
        public IUserRepository Usuario { get; private set; }
        public ISupplierRepository Proveedor { get; private set; }
        public IProductRepository Producto { get; private set; }
        public IDishRepository Platillo { get; private set; }
        public ITransactProductRepository TransaccionProducto { get; private set; }
        public IOrderRepository Orden { get; private set; }
        public IRepositoryPaymentMethod MetodoPago { get; private set; }
        public IBillRepository Factura { get; private set; }
        public IDetailOrderRepository DetalleOrden { get; private set; }

        public UnitOfWork(StarfoodContext db)
        {
            _db = db;
            Usuario = new UserRepository(_db);
            Categoria = new CategoryRepository(_db);
            Orden = new OrderRepository(_db);
            Platillo = new DishRepository(_db);
            PlatilloProducto = new DishProductRepository(_db);
            TransaccionProducto = new TransactProductRepository(_db);

            Producto = new ProductRepository(_db);
            Proveedor = new SupplierRepository(_db);
            Factura = new BillRepository(_db);
            MetodoPago = new PaymentMethodRepository(_db);
            DetalleOrden = new DetailOrderRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
        
}
