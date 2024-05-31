using Microsoft.EntityFrameworkCore;

namespace StarFood.Models
{
    public class StarfoodContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<PedidoDeProducto> PedidosDeProducto { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Platillo> Platillos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetallePedido> DetallesPedido { get; set; }
        public DbSet<MetodoPago> MetodosPago { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<PlatilloProducto> PlatillosProductos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=SQL8010.site4now.net;Initial Catalog=db_aa9678_starfood;User Id=db_aa9678_starfood_admin;Password=StarFood!1812;Trusted_Connection=True;");
        }
    }
}
