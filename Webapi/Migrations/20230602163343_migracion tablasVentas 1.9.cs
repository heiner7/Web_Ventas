using Microsoft.EntityFrameworkCore.Migrations;

namespace VentasBackend.Migrations
{
    public partial class migraciontablasVentas19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "PersonaId",
                table: "EncabezadoOrdenVentas",
                type: "int",
                nullable: true);

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
    }
}
