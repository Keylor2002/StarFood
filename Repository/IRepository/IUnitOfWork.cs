namespace StarFood.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IDishProductRepository PlatilloProducto { get; }
        IUserRepository Usuario { get; }
        ISupplierRepository Proveedor { get; }
        IProductRepository Producto { get; }
        IDishRepository Platillo { get; }
        ITransactProductRepository TransaccionProducto { get; }
        IOrderRepository Orden { get; }
        IRepositoryPaymentMethod MetodoPago { get; }
        IBillRepository Factura { get; }
        ICategoryRepository Categoria { get; }
        IDetailOrderRepository DetalleOrden { get; }

        void Save();
    }
}
