using Microsoft.EntityFrameworkCore.Migrations;

namespace VentasBackend.Migrations
{
    public partial class NombreDeLaMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleOrdenVenta_EncabezadoOrdenVentas_OrdenVentaId",
                table: "DetalleOrdenVenta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EncabezadoOrdenVentas",
                table: "EncabezadoOrdenVentas");

            migrationBuilder.DropIndex(
                name: "IX_DetalleOrdenVenta_OrdenVentaId",
                table: "DetalleOrdenVenta");

            migrationBuilder.AlterColumn<long>(
                name: "Cedula",
                table: "EncabezadoOrdenVentas",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "EncabezadoOrdenVentas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "OrdenVentaCedula",
                table: "DetalleOrdenVenta",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EncabezadoOrdenVentas",
                table: "EncabezadoOrdenVentas",
                column: "Cedula");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrdenVenta_OrdenVentaCedula",
                table: "DetalleOrdenVenta",
                column: "OrdenVentaCedula");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleOrdenVenta_EncabezadoOrdenVentas_OrdenVentaCedula",
                table: "DetalleOrdenVenta",
                column: "OrdenVentaCedula",
                principalTable: "EncabezadoOrdenVentas",
                principalColumn: "Cedula",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleOrdenVenta_EncabezadoOrdenVentas_OrdenVentaCedula",
                table: "DetalleOrdenVenta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EncabezadoOrdenVentas",
                table: "EncabezadoOrdenVentas");

            migrationBuilder.DropIndex(
                name: "IX_DetalleOrdenVenta_OrdenVentaCedula",
                table: "DetalleOrdenVenta");

            migrationBuilder.DropColumn(
                name: "OrdenVentaCedula",
                table: "DetalleOrdenVenta");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "EncabezadoOrdenVentas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<long>(
                name: "Cedula",
                table: "EncabezadoOrdenVentas",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EncabezadoOrdenVentas",
                table: "EncabezadoOrdenVentas",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrdenVenta_OrdenVentaId",
                table: "DetalleOrdenVenta",
                column: "OrdenVentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleOrdenVenta_EncabezadoOrdenVentas_OrdenVentaId",
                table: "DetalleOrdenVenta",
                column: "OrdenVentaId",
                principalTable: "EncabezadoOrdenVentas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
