using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VentasApp.Infrastructure.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(type: "varchar(20)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Description = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true),
                    Access = table.Column<string>(nullable: true),
                    EstadoRegistro = table.Column<bool>(nullable: true),
                    CreadoPor = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: true),
                    ModificadoPor = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(type: "varchar(15)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(50)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(60)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    IdentificationCard = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    FirstName = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: true),
                    LastName = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: true),
                    Lastlogin = table.Column<DateTime>(nullable: false),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cajas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    Detalle = table.Column<string>(type: "varchar(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cajas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "clases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    Detalle = table.Column<string>(type: "varchar(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceCodes",
                columns: table => new
                {
                    UserCode = table.Column<string>(maxLength: 200, nullable: false),
                    DeviceCode = table.Column<string>(maxLength: 200, nullable: false),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: false),
                    Data = table.Column<string>(maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceCodes", x => x.UserCode);
                });

            migrationBuilder.CreateTable(
                name: "documentosidentificacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    Sigla = table.Column<string>(type: "char(2)", nullable: false),
                    Detalle = table.Column<string>(type: "varchar(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documentosidentificacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "formapagos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(10)", nullable: false),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    Detalle = table.Column<string>(type: "varchar(80)", nullable: false),
                    MedioPago = table.Column<string>(type: "char(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_formapagos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "grupos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    Detalle = table.Column<string>(type: "varchar(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "impoconsumos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    Detalle = table.Column<string>(type: "varchar(80)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(28, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_impoconsumos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ivas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    Detalle = table.Column<string>(type: "varchar(80)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(28, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ivas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "listas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    Detalle = table.Column<string>(type: "varchar(80)", nullable: false),
                    ModificarPrecioSN = table.Column<string>(type: "char(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_listas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "marcas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    Detalle = table.Column<string>(type: "varchar(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mediospagos",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    Detalle = table.Column<string>(type: "varchar(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mediospagos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "paginas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    Nombre = table.Column<string>(type: "varchar(40)", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(70)", nullable: false),
                    Proyecto = table.Column<string>(type: "varchar(70)", nullable: false),
                    Url = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paginas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "paises",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    Detalle = table.Column<string>(type: "varchar(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersistedGrants",
                columns: table => new
                {
                    Key = table.Column<string>(maxLength: 200, nullable: false),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Data = table.Column<string>(maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedGrants", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "regimenes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    Detalle = table.Column<string>(type: "varchar(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regimenes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "retefuentes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    Detalle = table.Column<string>(type: "varchar(100)", nullable: false),
                    Porcentaje = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    CuentaV = table.Column<string>(type: "varchar(45)", nullable: false),
                    CuentaDV = table.Column<string>(type: "varchar(45)", nullable: false),
                    CuentaC = table.Column<string>(type: "varchar(45)", nullable: false),
                    CuentaDC = table.Column<string>(type: "varchar(45)", nullable: false),
                    TipoCatalogo = table.Column<string>(type: "char(1)", nullable: true),
                    DeclaranteSN = table.Column<string>(type: "varchar(1)", nullable: false),
                    Ano = table.Column<int>(nullable: false),
                    Tope = table.Column<decimal>(type: "decimal(28, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_retefuentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "reteicas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    Detalle = table.Column<string>(type: "varchar(100)", nullable: false),
                    Porcentaje = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    CuentaV = table.Column<string>(type: "varchar(45)", nullable: false),
                    CuentaDV = table.Column<string>(type: "varchar(45)", nullable: false),
                    CuentaC = table.Column<string>(type: "varchar(45)", nullable: false),
                    CuentaDC = table.Column<string>(type: "varchar(45)", nullable: false),
                    TipoCatalogo = table.Column<string>(type: "char(1)", nullable: true),
                    DeclaranteSN = table.Column<string>(type: "varchar(1)", nullable: false),
                    Ano = table.Column<int>(nullable: false),
                    Tope = table.Column<decimal>(type: "decimal(28, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reteicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tipocompradores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    Detalle = table.Column<string>(type: "varchar(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipocompradores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tipoproveedores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    Detalle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoproveedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tiposdocumentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    Detalle = table.Column<string>(type: "varchar(80)", nullable: false),
                    Identificador = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tiposdocumentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tipospersonas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    Detalle = table.Column<string>(type: "varchar(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipospersonas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "unidadesmedidas",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    Detalle = table.Column<string>(type: "varchar(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unidadesmedidas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "zonas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    Detalle = table.Column<string>(type: "varchar(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zonas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true),
                    EstadoRegistro = table.Column<bool>(nullable: true),
                    CreadoPor = table.Column<string>(nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: true),
                    ModificadoPor = table.Column<string>(nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId1",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    Detalle = table.Column<string>(type: "varchar(80)", nullable: false),
                    IvaVentaId = table.Column<int>(nullable: false),
                    IvaCompraId = table.Column<int>(nullable: false),
                    ImpoConsumoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contables_impoconsumos_ImpoConsumoId",
                        column: x => x.ImpoConsumoId,
                        principalTable: "impoconsumos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_contables_ivas_IvaCompraId",
                        column: x => x.IvaCompraId,
                        principalTable: "ivas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_contables_ivas_IvaVentaId",
                        column: x => x.IvaVentaId,
                        principalTable: "ivas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "menus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    Titulo = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: true),
                    Nombre = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true),
                    Url = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: true),
                    Padre = table.Column<int>(nullable: true),
                    PaginaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_menus_paginas_PaginaId",
                        column: x => x.PaginaId,
                        principalTable: "paginas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "departamentos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(2)", nullable: false),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    Detalle = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    PaisId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_departamentos_paises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "consecutivos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    NroResolucion = table.Column<string>(type: "varchar(250)", nullable: false),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: false),
                    Detalle = table.Column<string>(type: "varchar(80)", nullable: false),
                    Longitud = table.Column<int>(nullable: false),
                    NumeroInicio = table.Column<int>(nullable: false),
                    NumeroFin = table.Column<int>(nullable: false),
                    Prefijo = table.Column<string>(type: "varchar(45)", nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(250)", nullable: true),
                    NroActual = table.Column<int>(nullable: false),
                    TipoDocumentoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consecutivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_consecutivos_tiposdocumentos_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalTable: "tiposdocumentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "articulos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    Detalle = table.Column<string>(type: "varchar(80)", nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(250)", nullable: true),
                    Factor = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    Modelo = table.Column<string>(type: "varchar(45)", nullable: true),
                    Referencia = table.Column<string>(type: "varchar(250)", nullable: true),
                    Imagen = table.Column<string>(type: "varchar(250)", nullable: true),
                    Observacion = table.Column<string>(type: "varchar(250)", nullable: true),
                    TipoCatalogo = table.Column<string>(type: "char(1)", nullable: true),
                    ClaseId = table.Column<int>(nullable: false),
                    ContableId = table.Column<int>(nullable: false),
                    GrupoId = table.Column<int>(nullable: false),
                    MarcaId = table.Column<int>(nullable: false),
                    UnidadMedidaId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articulos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_articulos_clases_ClaseId",
                        column: x => x.ClaseId,
                        principalTable: "clases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_articulos_contables_ContableId",
                        column: x => x.ContableId,
                        principalTable: "contables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_articulos_grupos_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "grupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_articulos_marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_articulos_unidadesmedidas_UnidadMedidaId",
                        column: x => x.UnidadMedidaId,
                        principalTable: "unidadesmedidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "menusroles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    RoleId = table.Column<string>(nullable: true),
                    MenuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menusroles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_menusroles_menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_menusroles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ciudades",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(5)", nullable: false),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    DepartamentoId = table.Column<string>(nullable: false),
                    Detalle = table.Column<string>(type: "varchar(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ciudades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ciudades_departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "listaprecios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    ListaId = table.Column<int>(nullable: false),
                    ArticuloId = table.Column<int>(nullable: false),
                    UnidadMedidaId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_listaprecios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_listaprecios_articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "articulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_listaprecios_listas_ListaId",
                        column: x => x.ListaId,
                        principalTable: "listas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_listaprecios_unidadesmedidas_UnidadMedidaId",
                        column: x => x.UnidadMedidaId,
                        principalTable: "unidadesmedidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tercero",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    NroDocumento = table.Column<string>(type: "varchar(45)", nullable: false),
                    DigitoVerificacion = table.Column<string>(type: "char(2)", nullable: false),
                    PrimerNombre = table.Column<string>(type: "varchar(60)", nullable: false),
                    SegundoNombre = table.Column<string>(type: "varchar(60)", nullable: true),
                    PrimerApellido = table.Column<string>(type: "varchar(60)", nullable: false),
                    SegundoApellido = table.Column<string>(type: "varchar(60)", nullable: true),
                    RazonSocial = table.Column<string>(type: "varchar(200)", nullable: true),
                    NombreComercial = table.Column<string>(type: "varchar(200)", nullable: true),
                    Direccion = table.Column<string>(type: "varchar(200)", nullable: true),
                    Email = table.Column<string>(type: "varchar(200)", nullable: true),
                    Celular = table.Column<string>(type: "varchar(25)", nullable: true),
                    Telefono = table.Column<string>(type: "varchar(25)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: true),
                    DocumentoId = table.Column<int>(nullable: false),
                    RegimenId = table.Column<int>(nullable: false),
                    TipoPersonaId = table.Column<int>(nullable: false),
                    CiudadUbicacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tercero", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tercero_ciudades_CiudadUbicacion",
                        column: x => x.CiudadUbicacion,
                        principalTable: "ciudades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tercero_documentosidentificacion_DocumentoId",
                        column: x => x.DocumentoId,
                        principalTable: "documentosidentificacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tercero_regimenes_RegimenId",
                        column: x => x.RegimenId,
                        principalTable: "regimenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tercero_tipospersonas_TipoPersonaId",
                        column: x => x.TipoPersonaId,
                        principalTable: "tipospersonas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "compañias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    Autorretenedor = table.Column<bool>(nullable: false),
                    TerceroId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compañias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_compañias_tercero_TerceroId",
                        column: x => x.TerceroId,
                        principalTable: "tercero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "repventas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    MetaVenta = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    Comision = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    Notas = table.Column<string>(type: "varchar(90)", nullable: false),
                    TerceroId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_repventas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_repventas_tercero_TerceroId",
                        column: x => x.TerceroId,
                        principalTable: "tercero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    DescuentoComercial = table.Column<decimal>(type: "decimal(28,2)", nullable: false),
                    ReteIcaSN = table.Column<string>(type: "char(1)", nullable: false),
                    ReteIvaSN = table.Column<string>(type: "char(1)", nullable: false),
                    ReteFteSN = table.Column<string>(type: "char(1)", nullable: false),
                    AutoRetenedorSN = table.Column<string>(type: "char(1)", nullable: false),
                    DeclaranteSN = table.Column<string>(type: "char(1)", nullable: false),
                    Estado = table.Column<string>(nullable: true),
                    Cupo = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    TipoCompradorId = table.Column<int>(nullable: false),
                    ZonaId = table.Column<int>(nullable: false),
                    RepresentanteVentas = table.Column<int>(nullable: false),
                    ListaPrecioId = table.Column<int>(nullable: false),
                    ReteFuenteServiciosId = table.Column<int>(nullable: false),
                    ReteFuenteId = table.Column<int>(nullable: false),
                    ReteIcaServiciosId = table.Column<int>(nullable: false),
                    ReteIcaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_clientes_listas_ListaPrecioId",
                        column: x => x.ListaPrecioId,
                        principalTable: "listas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_clientes_repventas_RepresentanteVentas",
                        column: x => x.RepresentanteVentas,
                        principalTable: "repventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_clientes_retefuentes_ReteFuenteId",
                        column: x => x.ReteFuenteId,
                        principalTable: "retefuentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_clientes_retefuentes_ReteFuenteServiciosId",
                        column: x => x.ReteFuenteServiciosId,
                        principalTable: "retefuentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_clientes_reteicas_ReteIcaId",
                        column: x => x.ReteIcaId,
                        principalTable: "reteicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_clientes_reteicas_ReteIcaServiciosId",
                        column: x => x.ReteIcaServiciosId,
                        principalTable: "reteicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_clientes_tipocompradores_TipoCompradorId",
                        column: x => x.TipoCompradorId,
                        principalTable: "tipocompradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_clientes_zonas_ZonaId",
                        column: x => x.ZonaId,
                        principalTable: "zonas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "proveedores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    DescuentoComercial = table.Column<decimal>(type: "decimal(28,2)", nullable: false),
                    ReteIcaSN = table.Column<string>(type: "char(1)", nullable: false),
                    ReteIvaSN = table.Column<string>(type: "char(1)", nullable: false),
                    ReteFteSN = table.Column<string>(type: "char(1)", nullable: false),
                    AutoRetenedorSN = table.Column<string>(type: "char(1)", nullable: false),
                    DeclaranteSN = table.Column<string>(type: "char(1)", nullable: false),
                    Cupo = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    TipoProveedorId = table.Column<int>(nullable: false),
                    ZonaId = table.Column<int>(nullable: false),
                    RepresentanteVentaId = table.Column<int>(nullable: false),
                    ListaPrecioId = table.Column<int>(nullable: false),
                    ReteFuenteServiciosId = table.Column<int>(nullable: false),
                    ReteFuenteId = table.Column<int>(nullable: false),
                    ReteIcaServiciosId = table.Column<int>(nullable: false),
                    ReteIcaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_proveedores_listas_ListaPrecioId",
                        column: x => x.ListaPrecioId,
                        principalTable: "listas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_proveedores_repventas_RepresentanteVentaId",
                        column: x => x.RepresentanteVentaId,
                        principalTable: "repventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_proveedores_retefuentes_ReteFuenteId",
                        column: x => x.ReteFuenteId,
                        principalTable: "retefuentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_proveedores_retefuentes_ReteFuenteServiciosId",
                        column: x => x.ReteFuenteServiciosId,
                        principalTable: "retefuentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_proveedores_reteicas_ReteIcaId",
                        column: x => x.ReteIcaId,
                        principalTable: "reteicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_proveedores_reteicas_ReteIcaServiciosId",
                        column: x => x.ReteIcaServiciosId,
                        principalTable: "reteicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_proveedores_tipoproveedores_TipoProveedorId",
                        column: x => x.TipoProveedorId,
                        principalTable: "tipoproveedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_proveedores_zonas_ZonaId",
                        column: x => x.ZonaId,
                        principalTable: "zonas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ventas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    NroFactura = table.Column<string>(type: "varchar(45)", nullable: true),
                    TipoDocumentoId = table.Column<int>(nullable: false),
                    FechaVenta = table.Column<DateTime>(nullable: false),
                    FechaVencimiento = table.Column<DateTime>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    MunicipioId = table.Column<string>(nullable: true),
                    RepVentaId = table.Column<int>(nullable: false),
                    CajaId = table.Column<int>(nullable: true),
                    Observacion = table.Column<string>(nullable: true),
                    TotalBruto = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    DsctoProd = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    DsctoComer = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    BaseIva = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    ValorIva = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    ValorVenta = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    TotalRetefuenteC = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    TotalRetefuenteS = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    TotalReteIcaC = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    TotalReteIcaS = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    TotalReteIva = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    TotalOtrRetencion = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    TotalAutoRetencion = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    TotalPagar = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    Resolucion = table.Column<string>(type: "varchar(200)", nullable: true),
                    ValorImpConsumo = table.Column<decimal>(type: "decimal(28, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ventas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ventas_cajas_CajaId",
                        column: x => x.CajaId,
                        principalTable: "cajas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ventas_clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ventas_ciudades_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "ciudades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ventas_repventas_RepVentaId",
                        column: x => x.RepVentaId,
                        principalTable: "repventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ventas_tiposdocumentos_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalTable: "tiposdocumentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "detallesventas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(2)", nullable: false),
                    EstadoRegistro = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<string>(maxLength: 60, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    VentaId = table.Column<int>(nullable: false),
                    ArticuloId = table.Column<int>(nullable: false),
                    Detalle = table.Column<string>(type: "varchar(200)", nullable: false),
                    UnidadId = table.Column<string>(nullable: true),
                    Descuento = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    IvaId = table.Column<int>(nullable: false),
                    PorcentajeIva = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    ListaPrecioId = table.Column<int>(nullable: false),
                    ValorLista = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    ReteFuenteId = table.Column<int>(nullable: false),
                    PorcentajeRtfte = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    VlrRtfteC = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    VlrRtfteS = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    ReteIcaId = table.Column<int>(nullable: false),
                    PorcentajeReteIca = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    VlrRteIcaC = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    VlrRteIcaS = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    VlrDescuento = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    VentaBruta = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    VlrIva = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    DescComercial = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    ImpoConsumoId = table.Column<int>(nullable: false),
                    PorImpoConsumo = table.Column<decimal>(type: "decimal(28, 2)", nullable: false),
                    VlrImpoConsumo = table.Column<decimal>(type: "decimal(28, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detallesventas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detallesventas_articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "articulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_detallesventas_impoconsumos_ImpoConsumoId",
                        column: x => x.ImpoConsumoId,
                        principalTable: "impoconsumos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_detallesventas_ivas_IvaId",
                        column: x => x.IvaId,
                        principalTable: "ivas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_detallesventas_listaprecios_ListaPrecioId",
                        column: x => x.ListaPrecioId,
                        principalTable: "listaprecios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_detallesventas_retefuentes_ReteFuenteId",
                        column: x => x.ReteFuenteId,
                        principalTable: "retefuentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_detallesventas_reteicas_ReteIcaId",
                        column: x => x.ReteIcaId,
                        principalTable: "reteicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detallesventas_unidadesmedidas_UnidadId",
                        column: x => x.UnidadId,
                        principalTable: "unidadesmedidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_detallesventas_ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_articulos_ClaseId",
                table: "articulos",
                column: "ClaseId");

            migrationBuilder.CreateIndex(
                name: "IX_articulos_ContableId",
                table: "articulos",
                column: "ContableId");

            migrationBuilder.CreateIndex(
                name: "IX_articulos_GrupoId",
                table: "articulos",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_articulos_MarcaId",
                table: "articulos",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_articulos_UnidadMedidaId",
                table: "articulos",
                column: "UnidadMedidaId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId1",
                table: "AspNetUserRoles",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ciudades_DepartamentoId",
                table: "ciudades",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_clientes_ListaPrecioId",
                table: "clientes",
                column: "ListaPrecioId");

            migrationBuilder.CreateIndex(
                name: "IX_clientes_RepresentanteVentas",
                table: "clientes",
                column: "RepresentanteVentas");

            migrationBuilder.CreateIndex(
                name: "IX_clientes_ReteFuenteId",
                table: "clientes",
                column: "ReteFuenteId");

            migrationBuilder.CreateIndex(
                name: "IX_clientes_ReteFuenteServiciosId",
                table: "clientes",
                column: "ReteFuenteServiciosId");

            migrationBuilder.CreateIndex(
                name: "IX_clientes_ReteIcaId",
                table: "clientes",
                column: "ReteIcaId");

            migrationBuilder.CreateIndex(
                name: "IX_clientes_ReteIcaServiciosId",
                table: "clientes",
                column: "ReteIcaServiciosId");

            migrationBuilder.CreateIndex(
                name: "IX_clientes_TipoCompradorId",
                table: "clientes",
                column: "TipoCompradorId");

            migrationBuilder.CreateIndex(
                name: "IX_clientes_ZonaId",
                table: "clientes",
                column: "ZonaId");

            migrationBuilder.CreateIndex(
                name: "IX_compañias_TerceroId",
                table: "compañias",
                column: "TerceroId");

            migrationBuilder.CreateIndex(
                name: "IX_consecutivos_TipoDocumentoId",
                table: "consecutivos",
                column: "TipoDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_contables_ImpoConsumoId",
                table: "contables",
                column: "ImpoConsumoId");

            migrationBuilder.CreateIndex(
                name: "IX_contables_IvaCompraId",
                table: "contables",
                column: "IvaCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_contables_IvaVentaId",
                table: "contables",
                column: "IvaVentaId");

            migrationBuilder.CreateIndex(
                name: "IX_departamentos_PaisId",
                table: "departamentos",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_detallesventas_ArticuloId",
                table: "detallesventas",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_detallesventas_ImpoConsumoId",
                table: "detallesventas",
                column: "ImpoConsumoId");

            migrationBuilder.CreateIndex(
                name: "IX_detallesventas_IvaId",
                table: "detallesventas",
                column: "IvaId");

            migrationBuilder.CreateIndex(
                name: "IX_detallesventas_ListaPrecioId",
                table: "detallesventas",
                column: "ListaPrecioId");

            migrationBuilder.CreateIndex(
                name: "IX_detallesventas_ReteFuenteId",
                table: "detallesventas",
                column: "ReteFuenteId");

            migrationBuilder.CreateIndex(
                name: "IX_detallesventas_ReteIcaId",
                table: "detallesventas",
                column: "ReteIcaId");

            migrationBuilder.CreateIndex(
                name: "IX_detallesventas_UnidadId",
                table: "detallesventas",
                column: "UnidadId");

            migrationBuilder.CreateIndex(
                name: "IX_detallesventas_VentaId",
                table: "detallesventas",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_DeviceCode",
                table: "DeviceCodes",
                column: "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_Expiration",
                table: "DeviceCodes",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_listaprecios_ArticuloId",
                table: "listaprecios",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_listaprecios_ListaId",
                table: "listaprecios",
                column: "ListaId");

            migrationBuilder.CreateIndex(
                name: "IX_listaprecios_UnidadMedidaId",
                table: "listaprecios",
                column: "UnidadMedidaId");

            migrationBuilder.CreateIndex(
                name: "IX_menus_PaginaId",
                table: "menus",
                column: "PaginaId");

            migrationBuilder.CreateIndex(
                name: "IX_menusroles_MenuId",
                table: "menusroles",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_menusroles_RoleId",
                table: "menusroles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_Expiration",
                table: "PersistedGrants",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_ClientId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "ClientId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_proveedores_ListaPrecioId",
                table: "proveedores",
                column: "ListaPrecioId");

            migrationBuilder.CreateIndex(
                name: "IX_proveedores_RepresentanteVentaId",
                table: "proveedores",
                column: "RepresentanteVentaId");

            migrationBuilder.CreateIndex(
                name: "IX_proveedores_ReteFuenteId",
                table: "proveedores",
                column: "ReteFuenteId");

            migrationBuilder.CreateIndex(
                name: "IX_proveedores_ReteFuenteServiciosId",
                table: "proveedores",
                column: "ReteFuenteServiciosId");

            migrationBuilder.CreateIndex(
                name: "IX_proveedores_ReteIcaId",
                table: "proveedores",
                column: "ReteIcaId");

            migrationBuilder.CreateIndex(
                name: "IX_proveedores_ReteIcaServiciosId",
                table: "proveedores",
                column: "ReteIcaServiciosId");

            migrationBuilder.CreateIndex(
                name: "IX_proveedores_TipoProveedorId",
                table: "proveedores",
                column: "TipoProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_proveedores_ZonaId",
                table: "proveedores",
                column: "ZonaId");

            migrationBuilder.CreateIndex(
                name: "IX_repventas_TerceroId",
                table: "repventas",
                column: "TerceroId");

            migrationBuilder.CreateIndex(
                name: "IX_tercero_CiudadUbicacion",
                table: "tercero",
                column: "CiudadUbicacion");

            migrationBuilder.CreateIndex(
                name: "IX_tercero_DocumentoId",
                table: "tercero",
                column: "DocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_tercero_RegimenId",
                table: "tercero",
                column: "RegimenId");

            migrationBuilder.CreateIndex(
                name: "IX_tercero_TipoPersonaId",
                table: "tercero",
                column: "TipoPersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_CajaId",
                table: "ventas",
                column: "CajaId");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_ClienteId",
                table: "ventas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_MunicipioId",
                table: "ventas",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_RepVentaId",
                table: "ventas",
                column: "RepVentaId");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_TipoDocumentoId",
                table: "ventas",
                column: "TipoDocumentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "compañias");

            migrationBuilder.DropTable(
                name: "consecutivos");

            migrationBuilder.DropTable(
                name: "detallesventas");

            migrationBuilder.DropTable(
                name: "DeviceCodes");

            migrationBuilder.DropTable(
                name: "formapagos");

            migrationBuilder.DropTable(
                name: "mediospagos");

            migrationBuilder.DropTable(
                name: "menusroles");

            migrationBuilder.DropTable(
                name: "PersistedGrants");

            migrationBuilder.DropTable(
                name: "proveedores");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "listaprecios");

            migrationBuilder.DropTable(
                name: "ventas");

            migrationBuilder.DropTable(
                name: "menus");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "tipoproveedores");

            migrationBuilder.DropTable(
                name: "articulos");

            migrationBuilder.DropTable(
                name: "cajas");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "tiposdocumentos");

            migrationBuilder.DropTable(
                name: "paginas");

            migrationBuilder.DropTable(
                name: "clases");

            migrationBuilder.DropTable(
                name: "contables");

            migrationBuilder.DropTable(
                name: "grupos");

            migrationBuilder.DropTable(
                name: "marcas");

            migrationBuilder.DropTable(
                name: "unidadesmedidas");

            migrationBuilder.DropTable(
                name: "listas");

            migrationBuilder.DropTable(
                name: "repventas");

            migrationBuilder.DropTable(
                name: "retefuentes");

            migrationBuilder.DropTable(
                name: "reteicas");

            migrationBuilder.DropTable(
                name: "tipocompradores");

            migrationBuilder.DropTable(
                name: "zonas");

            migrationBuilder.DropTable(
                name: "impoconsumos");

            migrationBuilder.DropTable(
                name: "ivas");

            migrationBuilder.DropTable(
                name: "tercero");

            migrationBuilder.DropTable(
                name: "ciudades");

            migrationBuilder.DropTable(
                name: "documentosidentificacion");

            migrationBuilder.DropTable(
                name: "regimenes");

            migrationBuilder.DropTable(
                name: "tipospersonas");

            migrationBuilder.DropTable(
                name: "departamentos");

            migrationBuilder.DropTable(
                name: "paises");
        }
    }
}
