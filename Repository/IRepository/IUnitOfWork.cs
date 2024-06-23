namespace StarFood.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IDishProductRepository PlatilloProducto { get; }
        IUserRepository Usuario { get; }
        ISupplierRepository Proveedor { get; }
        IProductRepository Producto { get; }
        IDishRepository Platillo { get; }
        
        IOrderRepository Pedido { get; }
        IRepositoryPaymentMethod MetodoPago { get; }
        IBillRepository Factura { get; }
        ICategoryRepository Categoria { get; }
        IDetailOrderRepository DetallePedido { get; }

        void Save();
    }
}
