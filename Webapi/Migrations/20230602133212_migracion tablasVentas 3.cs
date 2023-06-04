using Microsoft.EntityFrameworkCore.Migrations;

namespace VentasBackend.Migrations
{
    public partial class migraciontablasVentas3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EncabezadoOrdenVentas_Personas_PersonaCedula",
                table: "EncabezadoOrdenVentas");

            migrationBuilder.AlterColumn<int>(
                name: "Cedula",
                table: "Personas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "PersonaCedula",
                table: "EncabezadoOrdenVentas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Cedula",
                table: "EncabezadoOrdenVentas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Cedula",
                table: "DetalleOrdenVenta",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EncabezadoOrdenVentas_Personas_PersonaCedula",
                table: "EncabezadoOrdenVentas",
                column: "PersonaCedula",
                principalTable: "Personas",
                principalColumn: "Cedula",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EncabezadoOrdenVentas_Personas_PersonaCedula",
                table: "EncabezadoOrdenVentas");

            migrationBuilder.AlterColumn<string>(
                name: "Cedula",
                table: "Personas",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "PersonaCedula",
                table: "EncabezadoOrdenVentas",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Cedula",
                table: "EncabezadoOrdenVentas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Cedula",
                table: "DetalleOrdenVenta",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_EncabezadoOrdenVentas_Personas_PersonaCedula",
                table: "EncabezadoOrdenVentas",
                column: "PersonaCedula",
                principalTable: "Personas",
                principalColumn: "Cedula",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
