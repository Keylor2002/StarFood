using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarFood.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallesPedido_Platillos_PlatilloIDPlatillo",
                table: "DetallesPedido");

            migrationBuilder.DropIndex(
                name: "IX_DetallesPedido_PlatilloIDPlatillo",
                table: "DetallesPedido");

            migrationBuilder.DropColumn(
                name: "PlatilloIDPlatillo",
                table: "DetallesPedido");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesPedido_IDPlatillo",
                table: "DetallesPedido",
                column: "IDPlatillo");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesPedido_Platillos_IDPlatillo",
                table: "DetallesPedido",
                column: "IDPlatillo",
                principalTable: "Platillos",
                principalColumn: "IDPlatillo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallesPedido_Platillos_IDPlatillo",
                table: "DetallesPedido");

            migrationBuilder.DropIndex(
                name: "IX_DetallesPedido_IDPlatillo",
                table: "DetallesPedido");

            migrationBuilder.AddColumn<int>(
                name: "PlatilloIDPlatillo",
                table: "DetallesPedido",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DetallesPedido_PlatilloIDPlatillo",
                table: "DetallesPedido",
                column: "PlatilloIDPlatillo");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesPedido_Platillos_PlatilloIDPlatillo",
                table: "DetallesPedido",
                column: "PlatilloIDPlatillo",
                principalTable: "Platillos",
                principalColumn: "IDPlatillo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
