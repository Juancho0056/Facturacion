using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VentasApp.Infrastructure.Persistence.Migrations
{
    public partial class ConsultaDatagrid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsultaDatagrid",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    Tipo = table.Column<string>(type: "varchar(50)", nullable: false),
                    Tabla = table.Column<string>(type: "varchar(50)", nullable: false),
                    Sentencia = table.Column<string>(type: "nvarchar(3000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultaDatagrid", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultaDatagrid");
        }
    }
}
