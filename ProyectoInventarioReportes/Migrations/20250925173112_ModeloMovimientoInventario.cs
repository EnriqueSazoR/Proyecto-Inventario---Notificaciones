using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoInventarioReportes.Migrations
{
    /// <inheritdoc />
    public partial class ModeloMovimientoInventario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovimientoInventarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    Unidades = table.Column<int>(type: "int", nullable: false),
                    Movimiento = table.Column<int>(type: "int", nullable: false),
                    Venta = table.Column<int>(type: "int", nullable: true),
                    FechaMovimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientoInventarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimientoInventarios_Productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoInventarios_IdProducto",
                table: "MovimientoInventarios",
                column: "IdProducto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovimientoInventarios");
        }
    }
}
