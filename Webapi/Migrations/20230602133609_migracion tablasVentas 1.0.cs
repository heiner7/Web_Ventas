using Microsoft.EntityFrameworkCore.Migrations;

namespace VentasBackend.Migrations
{
    public partial class migraciontablasVentas10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "EncabezadoOrdenVentas");

            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "DetalleOrdenVenta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
