using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VentasApp.Infrastructure.Persistence.Migrations
{
    public partial class Permission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationPermission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    Detalle = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Slug = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    MenuRoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationPermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationPermission_menusroles_MenuRoleId",
                        column: x => x.MenuRoleId,
                        principalTable: "menusroles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationPermission_MenuRoleId",
                table: "ApplicationPermission",
                column: "MenuRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationPermission");
        }
    }
}
