using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class ExtendedUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Docs_Users_korisnikId",
                table: "Docs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Docs",
                table: "Docs");

            migrationBuilder.DropIndex(
                name: "IX_Docs_korisnikId",
                table: "Docs");

            migrationBuilder.DropColumn(
                name: "korisnikId",
                table: "Docs");

            migrationBuilder.RenameTable(
                name: "Docs",
                newName: "Documents");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatumRodjenja",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Kreiran",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PosljednjeAktivan",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Spol",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Documents",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Documents",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Documents",
                table: "Documents",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_AppUserId",
                table: "Documents",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Users_AppUserId",
                table: "Documents",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Users_AppUserId",
                table: "Documents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Documents",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_AppUserId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Kreiran",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PosljednjeAktivan",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Spol",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Documents");

            migrationBuilder.RenameTable(
                name: "Documents",
                newName: "Docs");

            migrationBuilder.AlterColumn<string>(
                name: "DatumRodjenja",
                table: "Users",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "korisnikId",
                table: "Docs",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Docs",
                table: "Docs",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Docs_korisnikId",
                table: "Docs",
                column: "korisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Docs_Users_korisnikId",
                table: "Docs",
                column: "korisnikId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
