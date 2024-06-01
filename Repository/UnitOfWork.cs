using StarFood.Data;
using StarFood.Repository.IRepository;
using Microsoft.AspNetCore.Identity;

namespace StarFood.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private StarfoodContext _db;

        public IRepositorioCategoria Categoria { get; private set; }
        public IRepositorioPlatilloProducto PlatilloProducto { get; private set; }
        public IRepositorioUsuario Usuario { get; private set; }
        public IRepositorioProveedor Proveedor { get; private set; }
        public IRepositorioProducto Producto { get; private set; }
        public IRepositorioPlatillo Platillo { get; private set; }
        public IRepositorioPedidoDeProducto PedidoDeProducto { get; private set; }
        public IRepositorioPedido Pedido { get; private set; }
        public IRepositorioMetodoPago MetodoPago { get; private set; }
        public IRepositorioFactura Factura { get; private set; }

        public UnitOfWork(StarfoodContext db)
        {
            _db = db;
            Usuario = new RepositorioUsuario(_db);
            Categoria = new RepositorioCategoria(_db);
            Pedido = new RepositorioPedido(_db);
            Platillo = new RepositorioPlatillo(_db);
            PlatilloProducto = new RepositorioPlatilloProducto(_db);
            PedidoDeProducto = new RepositorioPedidoDeProducto(_db);
            Producto = new RepositorioProducto(_db);
            Proveedor = new RepositorioProveedor(_db);
            Factura = new RepositorioFactura(_db);
            MetodoPago = new RepositorioMetodoPago(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
        
}
