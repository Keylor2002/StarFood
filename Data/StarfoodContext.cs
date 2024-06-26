using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using StarFood.Models;
using System.Collections.Generic;

namespace StarFood.Data
{

    /*
    The StarFoodContext class contains the data of the models that you want to have in 
    the database, it also allows you to migrate the code to the database.
    */
    public class StarfoodContext : IdentityDbContext
    {

        /*
        This constructor is responsible for receiving the configuration 
        options for the database context and passing them along, ensuring 
        that the context is properly initialized to interact with the database.
        */
        public StarfoodContext(DbContextOptions<StarfoodContext> options)
            : base(options)
        {
        }

        /*
        This methods they allow the context to manage and query models in 
        a simple and structured way.
        */
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<TransaccionProducto> TransaccionProducto { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Platillo> Platillos { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<DetalleOrden> DetallesOrdenes { get; set; }
        public DbSet<MetodoPago> MetodosPago { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<PlatilloProducto> PlatillosProductos { get; set; }

        /*
        The OnConfiguring method configures the context to use SQL Server with 
        a specific connection string. 
        */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=SQL8010.site4now.net;Initial Catalog=db_aa9682_starfood;User Id=db_aa9682_starfood_admin;Password=StarFood01.");
            }
        }

        /*
        The OnModelCreating method sets up relationships and delete constraints 
        (DeleteBehavior.Restrict) between entities in the model to avoid cycles in the database. 
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /* Setting up relationships with DeleteBehavior.Restrict to avoid cycles */
            modelBuilder.Entity<TransaccionProducto>()
                .HasOne(p => p.Producto)
                .WithMany()
                .HasForeignKey(p => p.IDProducto)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TransaccionProducto>()
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
                .HasOne(f => f.Orden)
                .WithMany()
                .HasForeignKey(f => f.IDOrden)
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
        }
    }
}
