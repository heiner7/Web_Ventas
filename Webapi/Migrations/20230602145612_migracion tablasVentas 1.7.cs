using Microsoft.EntityFrameworkCore.Migrations;

namespace VentasBackend.Migrations
{
    public partial class migraciontablasVentas17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EncabezadoOrdenVentas_Personas_PersonaCedula",
                table: "EncabezadoOrdenVentas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personas",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_EncabezadoOrdenVentas_PersonaCedula",
                table: "EncabezadoOrdenVentas");

            migrationBuilder.AlterColumn<string>(
                name: "Cedula",
                table: "Personas",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Personas",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "PersonaCedula",
                table: "EncabezadoOrdenVentas",
                type: "nvarchar(max)",
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

            migrationBuilder.AddColumn<int>(
                name: "PersonaId",
                table: "EncabezadoOrdenVentas",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cedula",
                table: "DetalleOrdenVenta",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personas",
                table: "Personas",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_EncabezadoOrdenVentas_PersonaId",
                table: "EncabezadoOrdenVentas",
                column: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_EncabezadoOrdenVentas_Personas_PersonaId",
                table: "EncabezadoOrdenVentas",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EncabezadoOrdenVentas_Personas_PersonaId",
                table: "EncabezadoOrdenVentas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personas",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_EncabezadoOrdenVentas_PersonaId",
                table: "EncabezadoOrdenVentas");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "PersonaId",
                table: "EncabezadoOrdenVentas");

            migrationBuilder.AlterColumn<int>(
                name: "Cedula",
                table: "Personas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12,
                oldNullable: true)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "PersonaCedula",
                table: "EncabezadoOrdenVentas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personas",
                table: "Personas",
                column: "Cedula");

            migrationBuilder.CreateIndex(
                name: "IX_EncabezadoOrdenVentas_PersonaCedula",
                table: "EncabezadoOrdenVentas",
                column: "PersonaCedula");

            migrationBuilder.AddForeignKey(
                name: "FK_EncabezadoOrdenVentas_Personas_PersonaCedula",
                table: "EncabezadoOrdenVentas",
                column: "PersonaCedula",
                principalTable: "Personas",
                principalColumn: "Cedula",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
