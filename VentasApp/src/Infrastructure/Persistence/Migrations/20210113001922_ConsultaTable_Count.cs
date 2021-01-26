using Microsoft.EntityFrameworkCore.Migrations;

namespace VentasApp.Infrastructure.Persistence.Migrations
{
    public partial class ConsultaTable_Count : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tabla",
                table: "ConsultaDatagrid",
                newName: "Pagina");

            migrationBuilder.RenameColumn(
                name: "Sentencia",
                table: "ConsultaDatagrid",
                newName: "SentenciaTable");

            migrationBuilder.AddColumn<string>(
                name: "SentenciaCount",
                table: "ConsultaDatagrid",
                type: "nvarchar(3000)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SentenciaCount",
                table: "ConsultaDatagrid");

            migrationBuilder.RenameColumn(
                name: "SentenciaTable",
                table: "ConsultaDatagrid",
                newName: "Sentencia");

            migrationBuilder.RenameColumn(
                name: "Pagina",
                table: "ConsultaDatagrid",
                newName: "Tabla");
        }
    }
}
