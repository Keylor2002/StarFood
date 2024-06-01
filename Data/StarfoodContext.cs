using Microsoft.EntityFrameworkCore;
using StarFood.Models;

namespace StarFood.Data
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
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=SQL8010.site4now.net;Initial Catalog=db_aa9678_starfood;User Id=db_aa9678_starfood_admin;Password=StarFood!1812");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de relaciones con DeleteBehavior.Restrict para evitar ciclos
            modelBuilder.Entity<PedidoDeProducto>()
                .HasOne(p => p.Producto)
                .WithMany()
                .HasForeignKey(p => p.IDProducto)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PedidoDeProducto>()
                .HasOne(p => p.Proveedor)
                .WithMany()
                .HasForeignKey(p => p.IDProveedor)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Proveedor)
                .WithMany()
                .HasForeignKey(p => p.IDProveedor)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany()
                .HasForeignKey(p => p.CategoriaID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Platillo>()
                .HasOne(p => p.Categoria)
                .WithMany()
                .HasForeignKey(p => p.CategoriaID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Factura>()
                .HasOne(f => f.Pedido)
                .WithMany()
                .HasForeignKey(f => f.IDPedido)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Factura>()
                .HasOne(f => f.MetodoPago)
                .WithMany()
                .HasForeignKey(f => f.IDMetodoPago)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PlatilloProducto>()
                .HasOne(pp => pp.Platillo)
                .WithMany()
                .HasForeignKey(pp => pp.IDPlatillo)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PlatilloProducto>()
                .HasOne(pp => pp.Producto)
                .WithMany()
                .HasForeignKey(pp => pp.IDProducto)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
