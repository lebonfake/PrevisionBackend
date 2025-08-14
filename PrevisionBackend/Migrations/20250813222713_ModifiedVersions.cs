using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrevisionBackend.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedVersions : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartDay",
                table: "Versions");

            migrationBuilder.DropColumn(
                name: "EndDay",
                table: "Versions");

            migrationBuilder.AddColumn<int>(
                name: "StartDay",
                table: "Versions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EndDay",
                table: "Versions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
        
        

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "StartDay",
                table: "Versions",
                type: "date",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "EndDay",
                table: "Versions",
                type: "date",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
