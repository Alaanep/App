using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    public partial class token : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Token",
                schema: "AppDB",
                table: "Students",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Token",
                schema: "AppDB",
                table: "Lessons",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Token",
                schema: "AppDB",
                table: "Instructors",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Token",
                schema: "AppDB",
                table: "Currencies",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Token",
                schema: "AppDB",
                table: "CountryCurrencies",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Token",
                schema: "AppDB",
                table: "Countries",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                schema: "AppDB",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Token",
                schema: "AppDB",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "Token",
                schema: "AppDB",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "Token",
                schema: "AppDB",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "Token",
                schema: "AppDB",
                table: "CountryCurrencies");

            migrationBuilder.DropColumn(
                name: "Token",
                schema: "AppDB",
                table: "Countries");
        }
    }
}
