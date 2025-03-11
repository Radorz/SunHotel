using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class CambioASQLServer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Edificio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroEdificio = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edificio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Habitacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoHabitacion = table.Column<int>(nullable: false),
                    IdEdificio = table.Column<int>(nullable: false),
                    NoHabitacion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Cedula = table.Column<string>(nullable: true),
                    FechaLlegada = table.Column<DateTime>(nullable: true),
                    FechaSalida = table.Column<DateTime>(nullable: true),
                    Adultos = table.Column<int>(nullable: true),
                    Niños = table.Column<int>(nullable: true),
                    IdTipoHabitacion = table.Column<int>(nullable: true),
                    IdHabitacion = table.Column<int>(nullable: true),
                    FechaPago = table.Column<DateTime>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    IdPago = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoHabitaciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    CantCamas = table.Column<int>(nullable: true),
                    PrecioNoche = table.Column<decimal>(nullable: true),
                    MaxHuespedes = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoHabitaciones", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Edificio");

            migrationBuilder.DropTable(
                name: "Habitacion");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "TipoHabitaciones");
        }
    }
}
