using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrevisionBackend.Migrations
{
    /// <inheritdoc />
    public partial class RemovedNumberOfVersionsInSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreVersion",
                table: "SystemVersions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NombreVersion",
                table: "SystemVersions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
