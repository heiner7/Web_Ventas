using Microsoft.EntityFrameworkCore.Migrations;

namespace VentasBackend.Migrations
{
    public partial class migraciontablasVentas110 : Migration
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

            migrationBuilder.DropColumn(
                name: "PersonaCedula",
                table: "EncabezadoOrdenVentas");

            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "DetalleOrdenVenta");

            migrationBuilder.AlterColumn<long>(
                name: "Cedula",
                table: "Personas",
                type: "bigint",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 12)
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Personas",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personas",
                table: "Personas",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Personas",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Personas");

            migrationBuilder.AlterColumn<long>(
                name: "Cedula",
                table: "Personas",
                type: "bigint",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 12)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "PersonaCedula",
                table: "EncabezadoOrdenVentas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Cedula",
                table: "DetalleOrdenVenta",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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
