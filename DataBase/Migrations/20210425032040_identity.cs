using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
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
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Edificio",
                columns: table => new
                {
                    id_Edificio = table.Column<int>(name: "id _Edificio", type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    numero_Edificio = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_Edificio);
                });

            migrationBuilder.CreateTable(
                name: "Habitacion",
                columns: table => new
                {
                    id_Habitacion = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_tipo_habitacion = table.Column<int>(type: "int(11)", nullable: false),
                    id_edificio = table.Column<int>(type: "int(11)", nullable: false),
                    no_habitacion = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_Habitacion);
                });

            migrationBuilder.CreateTable(
                name: "img_habitaciones",
                columns: table => new
                {
                    id_img_habitaciones = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    path = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    id_tipo_habitacion = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_img_habitaciones);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    id_pago = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    numero = table.Column<string>(type: "varchar(20)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    titular = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    cantidadpagar = table.Column<decimal>(type: "decimal(19,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_pago);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    id_Reserva = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    Cedula = table.Column<string>(type: "varchar(16)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    Fecha_Llegada = table.Column<DateTime>(type: "date", nullable: true),
                    Fecha_Salida = table.Column<DateTime>(type: "date", nullable: true),
                    Adultos = table.Column<int>(type: "int(11)", nullable: true),
                    Niños = table.Column<int>(type: "int(11)", nullable: true),
                    Id_tipo_Habitacion = table.Column<int>(type: "int(11)", nullable: true),
                    Id_Habitacion = table.Column<int>(type: "int(11)", nullable: true),
                    Fecha_pago = table.Column<DateTime>(type: "date", nullable: true),
                    Apellido = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    Email = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    Telefono = table.Column<string>(type: "varchar(11)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    id_pago = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_Reserva);
                });

            migrationBuilder.CreateTable(
                name: "tipo_habitaciones",
                columns: table => new
                {
                    id_tipo_habitacion = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    descripcion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    cant_camas = table.Column<int>(type: "int(11)", nullable: true),
                    precio_noche = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    max_huespedes = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_tipo_habitacion);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id_User = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    correo = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    password = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_User);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
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
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

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
                unique: true);
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
                name: "Edificio");

            migrationBuilder.DropTable(
                name: "Habitacion");

            migrationBuilder.DropTable(
                name: "img_habitaciones");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "tipo_habitaciones");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
