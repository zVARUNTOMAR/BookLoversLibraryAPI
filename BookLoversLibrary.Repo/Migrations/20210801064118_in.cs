using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookLoversLibrary.Repo.Migrations
{
    public partial class @in : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Pack",
                table: "users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResponseTime",
                table: "users",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Slot",
                table: "users",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pack",
                table: "users");

            migrationBuilder.DropColumn(
                name: "ResponseTime",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Slot",
                table: "users");
        }
    }
}
