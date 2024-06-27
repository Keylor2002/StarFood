using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarFood.Migrations
{
    /// <inheritdoc />
    public partial class fixOrdersAndDetailsOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallesPedido_Pedidos_IDPedido",
                table: "DetallesPedido");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallesPedido_Platillos_IDPlatillo",
                table: "DetallesPedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Pedidos_IDPedido",
                table: "Facturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_AspNetUsers_UsuarioId",
                table: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pedidos",
                table: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetallesPedido",
                table: "DetallesPedido");

            migrationBuilder.DropIndex(
                name: "IX_DetallesPedido_IDPedido",
                table: "DetallesPedido");

            migrationBuilder.DropColumn(
                name: "IDDetallePedido",
                table: "DetallesPedido");

            migrationBuilder.RenameTable(
                name: "Pedidos",
                newName: "Ordenes");

            migrationBuilder.RenameTable(
                name: "DetallesPedido",
                newName: "DetallesOrdenes");

            migrationBuilder.RenameColumn(
                name: "IDPedido",
                table: "Facturas",
                newName: "IDOrden");

            migrationBuilder.RenameIndex(
                name: "IX_Facturas_IDPedido",
                table: "Facturas",
                newName: "IX_Facturas_IDOrden");

            migrationBuilder.RenameColumn(
                name: "FechaPedido",
                table: "Ordenes",
                newName: "FechaOrden");

            migrationBuilder.RenameColumn(
                name: "IDPedido",
                table: "Ordenes",
                newName: "IDOrden");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_UsuarioId",
                table: "Ordenes",
                newName: "IX_Ordenes_UsuarioId");

            migrationBuilder.RenameColumn(
                name: "IDPlatillo",
                table: "DetallesOrdenes",
                newName: "IDOrden");

            migrationBuilder.RenameColumn(
                name: "IDPedido",
                table: "DetallesOrdenes",
                newName: "IDDetalleOrden");

            migrationBuilder.RenameIndex(
                name: "IX_DetallesPedido_IDPlatillo",
                table: "DetallesOrdenes",
                newName: "IX_DetallesOrdenes_IDOrden");

            migrationBuilder.AddColumn<int>(
                name: "DetalleOrdenIDDetalleOrden",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DetalleOrdenIDDetalleOrden",
                table: "Platillos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Entregado",
                table: "Ordenes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "IDDetalleOrden",
                table: "DetallesOrdenes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ordenes",
                table: "Ordenes",
                column: "IDOrden");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetallesOrdenes",
                table: "DetallesOrdenes",
                column: "IDDetalleOrden");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_DetalleOrdenIDDetalleOrden",
                table: "Productos",
                column: "DetalleOrdenIDDetalleOrden");

            migrationBuilder.CreateIndex(
                name: "IX_Platillos_DetalleOrdenIDDetalleOrden",
                table: "Platillos",
                column: "DetalleOrdenIDDetalleOrden");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesOrdenes_Ordenes_IDOrden",
                table: "DetallesOrdenes",
                column: "IDOrden",
                principalTable: "Ordenes",
                principalColumn: "IDOrden",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Ordenes_IDOrden",
                table: "Facturas",
                column: "IDOrden",
                principalTable: "Ordenes",
                principalColumn: "IDOrden",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_AspNetUsers_UsuarioId",
                table: "Ordenes",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Platillos_DetallesOrdenes_DetalleOrdenIDDetalleOrden",
                table: "Platillos",
                column: "DetalleOrdenIDDetalleOrden",
                principalTable: "DetallesOrdenes",
                principalColumn: "IDDetalleOrden");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_DetallesOrdenes_DetalleOrdenIDDetalleOrden",
                table: "Productos",
                column: "DetalleOrdenIDDetalleOrden",
                principalTable: "DetallesOrdenes",
                principalColumn: "IDDetalleOrden");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallesOrdenes_Ordenes_IDOrden",
                table: "DetallesOrdenes");

            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Ordenes_IDOrden",
                table: "Facturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_AspNetUsers_UsuarioId",
                table: "Ordenes");

            migrationBuilder.DropForeignKey(
                name: "FK_Platillos_DetallesOrdenes_DetalleOrdenIDDetalleOrden",
                table: "Platillos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_DetallesOrdenes_DetalleOrdenIDDetalleOrden",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_DetalleOrdenIDDetalleOrden",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Platillos_DetalleOrdenIDDetalleOrden",
                table: "Platillos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ordenes",
                table: "Ordenes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetallesOrdenes",
                table: "DetallesOrdenes");

            migrationBuilder.DropColumn(
                name: "DetalleOrdenIDDetalleOrden",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "DetalleOrdenIDDetalleOrden",
                table: "Platillos");

            migrationBuilder.DropColumn(
                name: "Entregado",
                table: "Ordenes");

            migrationBuilder.RenameTable(
                name: "Ordenes",
                newName: "Pedidos");

            migrationBuilder.RenameTable(
                name: "DetallesOrdenes",
                newName: "DetallesPedido");

            migrationBuilder.RenameColumn(
                name: "IDOrden",
                table: "Facturas",
                newName: "IDPedido");

            migrationBuilder.RenameIndex(
                name: "IX_Facturas_IDOrden",
                table: "Facturas",
                newName: "IX_Facturas_IDPedido");

            migrationBuilder.RenameColumn(
                name: "FechaOrden",
                table: "Pedidos",
                newName: "FechaPedido");

            migrationBuilder.RenameColumn(
                name: "IDOrden",
                table: "Pedidos",
                newName: "IDPedido");

            migrationBuilder.RenameIndex(
                name: "IX_Ordenes_UsuarioId",
                table: "Pedidos",
                newName: "IX_Pedidos_UsuarioId");

            migrationBuilder.RenameColumn(
                name: "IDOrden",
                table: "DetallesPedido",
                newName: "IDPlatillo");

            migrationBuilder.RenameColumn(
                name: "IDDetalleOrden",
                table: "DetallesPedido",
                newName: "IDPedido");

            migrationBuilder.RenameIndex(
                name: "IX_DetallesOrdenes_IDOrden",
                table: "DetallesPedido",
                newName: "IX_DetallesPedido_IDPlatillo");

            migrationBuilder.AlterColumn<int>(
                name: "IDPedido",
                table: "DetallesPedido",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IDDetallePedido",
                table: "DetallesPedido",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pedidos",
                table: "Pedidos",
                column: "IDPedido");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetallesPedido",
                table: "DetallesPedido",
                column: "IDDetallePedido");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesPedido_IDPedido",
                table: "DetallesPedido",
                column: "IDPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesPedido_Pedidos_IDPedido",
                table: "DetallesPedido",
                column: "IDPedido",
                principalTable: "Pedidos",
                principalColumn: "IDPedido",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesPedido_Platillos_IDPlatillo",
                table: "DetallesPedido",
                column: "IDPlatillo",
                principalTable: "Platillos",
                principalColumn: "IDPlatillo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Pedidos_IDPedido",
                table: "Facturas",
                column: "IDPedido",
                principalTable: "Pedidos",
                principalColumn: "IDPedido",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_AspNetUsers_UsuarioId",
                table: "Pedidos",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
