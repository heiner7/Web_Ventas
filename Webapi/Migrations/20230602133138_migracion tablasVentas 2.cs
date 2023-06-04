using Microsoft.EntityFrameworkCore.Migrations;

namespace VentasBackend.Migrations
{
    public partial class migraciontablasVentas2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cedula",
                table: "EncabezadoOrdenVentas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cedula",
                table: "DetalleOrdenVenta",
                type: "nvarchar(max)",
                nullable: true);
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
