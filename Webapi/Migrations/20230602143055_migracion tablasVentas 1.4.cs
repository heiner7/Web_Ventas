using Microsoft.EntityFrameworkCore.Migrations;

namespace VentasBackend.Migrations
{
    public partial class migraciontablasVentas14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cedula",
                table: "EncabezadoOrdenVentas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Cedula",
                table: "DetalleOrdenVenta",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "EncabezadoOrdenVentas");

            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "DetalleOrdenVenta");
        }
    }
}
