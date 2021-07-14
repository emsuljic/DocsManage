using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ime = table.Column<string>(type: "TEXT", nullable: true),
                    Prezime = table.Column<string>(type: "TEXT", nullable: true),
                    DatumRodjenja = table.Column<string>(type: "TEXT", nullable: true),
                    MjestoStanovanja = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Docs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NaslovDokumenta = table.Column<string>(type: "TEXT", nullable: true),
                    DatumDokumenta = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DatumUnosaDokumenta = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FizickoLice = table.Column<string>(type: "TEXT", nullable: true),
                    Napomena = table.Column<string>(type: "TEXT", nullable: true),
                    Vrijednost = table.Column<int>(type: "INTEGER", nullable: true),
                    Posiljaoc = table.Column<string>(type: "TEXT", nullable: true),
                    Primaoc = table.Column<string>(type: "TEXT", nullable: true),
                    korisnikId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Docs_Users_korisnikId",
                        column: x => x.korisnikId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Docs_korisnikId",
                table: "Docs",
                column: "korisnikId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Docs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
