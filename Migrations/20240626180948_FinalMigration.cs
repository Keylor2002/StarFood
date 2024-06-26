using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarFood.Migrations
{
    /// <inheritdoc />
    public partial class FinalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    IDUsuario = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    NombreUsuario = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Suspendido = table.Column<bool>(type: "bit", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IDCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Suspendido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IDCategoria);
                });

            migrationBuilder.CreateTable(
                name: "MetodosPago",
                columns: table => new
                {
                    IDMetodoPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreMetodoPago = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodosPago", x => x.IDMetodoPago);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    IDProveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empresa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Contacto = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Suspendido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.IDProveedor);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    IDOrden = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaOrden = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Entregado = table.Column<bool>(type: "bit", nullable: false),
                    Cancelado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.IDOrden);
                    table.ForeignKey(
                        name: "FK_Ordenes_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallesOrdenes",
                columns: table => new
                {
                    IDDetalleOrden = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDOrden = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesOrdenes", x => x.IDDetalleOrden);
                    table.ForeignKey(
                        name: "FK_DetallesOrdenes_Ordenes_IDOrden",
                        column: x => x.IDOrden,
                        principalTable: "Ordenes",
                        principalColumn: "IDOrden",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    IDFactura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDOrden = table.Column<int>(type: "int", nullable: false),
                    FechaVenta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalVenta = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    IDMetodoPago = table.Column<int>(type: "int", nullable: false),
                    CantidadPago = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CantidadCambio = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.IDFactura);
                    table.ForeignKey(
                        name: "FK_Facturas_MetodosPago_IDMetodoPago",
                        column: x => x.IDMetodoPago,
                        principalTable: "MetodosPago",
                        principalColumn: "IDMetodoPago",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Facturas_Ordenes_IDOrden",
                        column: x => x.IDOrden,
                        principalTable: "Ordenes",
                        principalColumn: "IDOrden",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Platillos",
                columns: table => new
                {
                    IDPlatillo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CategoriaID = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Suspendido = table.Column<bool>(type: "bit", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetalleOrdenIDDetalleOrden = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platillos", x => x.IDPlatillo);
                    table.ForeignKey(
                        name: "FK_Platillos_Categorias_CategoriaID",
                        column: x => x.CategoriaID,
                        principalTable: "Categorias",
                        principalColumn: "IDCategoria",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Platillos_DetallesOrdenes_DetalleOrdenIDDetalleOrden",
                        column: x => x.DetalleOrdenIDDetalleOrden,
                        principalTable: "DetallesOrdenes",
                        principalColumn: "IDDetalleOrden");
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IDProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoriaID = table.Column<int>(type: "int", nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CantidadExistente = table.Column<int>(type: "int", nullable: false),
                    UnidadMedida = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Suspendido = table.Column<bool>(type: "bit", nullable: false),
                    DetalleOrdenIDDetalleOrden = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IDProducto);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_CategoriaID",
                        column: x => x.CategoriaID,
                        principalTable: "Categorias",
                        principalColumn: "IDCategoria",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_DetallesOrdenes_DetalleOrdenIDDetalleOrden",
                        column: x => x.DetalleOrdenIDDetalleOrden,
                        principalTable: "DetallesOrdenes",
                        principalColumn: "IDDetalleOrden");
                });

            migrationBuilder.CreateTable(
                name: "DetallesPlatillos",
                columns: table => new
                {
                    IDDetallePlatillo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPlatillo = table.Column<int>(type: "int", nullable: false),
                    CantidadProducto = table.Column<int>(type: "int", nullable: false),
                    IDProducto = table.Column<int>(type: "int", nullable: false),
                    ProductoIDProducto = table.Column<int>(type: "int", nullable: false),
                    PlatilloIDPlatillo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesPlatillos", x => x.IDDetallePlatillo);
                    table.ForeignKey(
                        name: "FK_DetallesPlatillos_Platillos_IDPlatillo",
                        column: x => x.IDPlatillo,
                        principalTable: "Platillos",
                        principalColumn: "IDPlatillo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetallesPlatillos_Platillos_PlatilloIDPlatillo",
                        column: x => x.PlatilloIDPlatillo,
                        principalTable: "Platillos",
                        principalColumn: "IDPlatillo");
                    table.ForeignKey(
                        name: "FK_DetallesPlatillos_Productos_ProductoIDProducto",
                        column: x => x.ProductoIDProducto,
                        principalTable: "Productos",
                        principalColumn: "IDProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransaccionProducto",
                columns: table => new
                {
                    IDTransacProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDProducto = table.Column<int>(type: "int", nullable: false),
                    IDProveedor = table.Column<int>(type: "int", nullable: false),
                    PrecioCosto = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    FechaCaducidad = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCompra = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransaccionProducto", x => x.IDTransacProducto);
                    table.ForeignKey(
                        name: "FK_TransaccionProducto_Productos_IDProducto",
                        column: x => x.IDProducto,
                        principalTable: "Productos",
                        principalColumn: "IDProducto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransaccionProducto_Proveedores_IDProveedor",
                        column: x => x.IDProveedor,
                        principalTable: "Proveedores",
                        principalColumn: "IDProveedor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesOrdenes_IDOrden",
                table: "DetallesOrdenes",
                column: "IDOrden");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesPlatillos_IDPlatillo",
                table: "DetallesPlatillos",
                column: "IDPlatillo");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesPlatillos_PlatilloIDPlatillo",
                table: "DetallesPlatillos",
                column: "PlatilloIDPlatillo");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesPlatillos_ProductoIDProducto",
                table: "DetallesPlatillos",
                column: "ProductoIDProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_IDMetodoPago",
                table: "Facturas",
                column: "IDMetodoPago");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_IDOrden",
                table: "Facturas",
                column: "IDOrden");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_UsuarioId",
                table: "Ordenes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Platillos_CategoriaID",
                table: "Platillos",
                column: "CategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Platillos_DetalleOrdenIDDetalleOrden",
                table: "Platillos",
                column: "DetalleOrdenIDDetalleOrden");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaID",
                table: "Productos",
                column: "CategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_DetalleOrdenIDDetalleOrden",
                table: "Productos",
                column: "DetalleOrdenIDDetalleOrden");

            migrationBuilder.CreateIndex(
                name: "IX_TransaccionProducto_IDProducto",
                table: "TransaccionProducto",
                column: "IDProducto");

            migrationBuilder.CreateIndex(
                name: "IX_TransaccionProducto_IDProveedor",
                table: "TransaccionProducto",
                column: "IDProveedor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DetallesPlatillos");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "TransaccionProducto");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Platillos");

            migrationBuilder.DropTable(
                name: "MetodosPago");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "DetallesOrdenes");

            migrationBuilder.DropTable(
                name: "Ordenes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
