namespace StarFood.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IRepositorioPlatilloProducto PlatilloProducto { get; }
        IRepositorioUsuario Usuario { get; }
        IRepositorioProveedor Proveedor { get; }
        IRepositorioProducto Producto { get; }
        IRepositorioPlatillo Platillo { get; }
        IRepositorioPedidoDeProducto PedidoDeProducto { get; }
        IRepositorioPedido Pedido { get; }
        IRepositorioMetodoPago MetodoPago { get; }
        IRepositorioFactura Factura { get; }
        IRepositorioCategoria Categoria { get; }
        IRepositorioDetallePedido DetallePedido { get; }

        void Save();
    }
}
