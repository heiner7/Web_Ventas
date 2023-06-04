using Microsoft.EntityFrameworkCore.Migrations;

namespace VentasBackend.Migrations
{
    public partial class migraciontablasVentas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleOrdenVenta_EncabezadoOrdenVentas_OrdenVentaId",
                table: "DetalleOrdenVenta");

            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "EncabezadoOrdenVentas");

            migrationBuilder.DropColumn(
                name: "IdOrdenVenta",
                table: "DetalleOrdenVenta");

            migrationBuilder.AlterColumn<decimal>(
                name: "TipoCambio",
                table: "EncabezadoOrdenVentas",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecioUnitario",
                table: "DetalleOrdenVenta",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecioTotalImpuestos",
                table: "DetalleOrdenVenta",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecioImpuestoUnitario",
                table: "DetalleOrdenVenta",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PorcentajeImpuesto",
                table: "DetalleOrdenVenta",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "OrdenVentaId",
                table: "DetalleOrdenVenta",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleOrdenVenta_EncabezadoOrdenVentas_OrdenVentaId",
                table: "DetalleOrdenVenta",
                column: "OrdenVentaId",
                principalTable: "EncabezadoOrdenVentas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleOrdenVenta_EncabezadoOrdenVentas_OrdenVentaId",
                table: "DetalleOrdenVenta");

            migrationBuilder.AlterColumn<decimal>(
                name: "TipoCambio",
                table: "EncabezadoOrdenVentas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AddColumn<string>(
                name: "Cedula",
                table: "EncabezadoOrdenVentas",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecioUnitario",
                table: "DetalleOrdenVenta",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecioTotalImpuestos",
                table: "DetalleOrdenVenta",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecioImpuestoUnitario",
                table: "DetalleOrdenVenta",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PorcentajeImpuesto",
                table: "DetalleOrdenVenta",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<int>(
                name: "OrdenVentaId",
                table: "DetalleOrdenVenta",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdOrdenVenta",
                table: "DetalleOrdenVenta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleOrdenVenta_EncabezadoOrdenVentas_OrdenVentaId",
                table: "DetalleOrdenVenta",
                column: "OrdenVentaId",
                principalTable: "EncabezadoOrdenVentas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
