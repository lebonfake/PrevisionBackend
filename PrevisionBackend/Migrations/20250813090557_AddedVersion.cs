using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrevisionBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddedVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "PrevisionFermes");

            migrationBuilder.AddColumn<int>(
                name: "VersionId",
                table: "PrevisionFermes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SystemVersionId",
                table: "Fermes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SystemVersions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreVersion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Versions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDay = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDay = table.Column<DateOnly>(type: "date", nullable: false),
                    SystemVersionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Versions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Versions_SystemVersions_SystemVersionId",
                        column: x => x.SystemVersionId,
                        principalTable: "SystemVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrevisionFermes_VersionId",
                table: "PrevisionFermes",
                column: "VersionId");

            migrationBuilder.CreateIndex(
                name: "IX_Fermes_SystemVersionId",
                table: "Fermes",
                column: "SystemVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_Versions_SystemVersionId",
                table: "Versions",
                column: "SystemVersionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fermes_SystemVersions_SystemVersionId",
                table: "Fermes",
                column: "SystemVersionId",
                principalTable: "SystemVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrevisionFermes_Versions_VersionId",
                table: "PrevisionFermes",
                column: "VersionId",
                principalTable: "Versions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fermes_SystemVersions_SystemVersionId",
                table: "Fermes");

            migrationBuilder.DropForeignKey(
                name: "FK_PrevisionFermes_Versions_VersionId",
                table: "PrevisionFermes");

            migrationBuilder.DropTable(
                name: "Versions");

            migrationBuilder.DropTable(
                name: "SystemVersions");

            migrationBuilder.DropIndex(
                name: "IX_PrevisionFermes_VersionId",
                table: "PrevisionFermes");

            migrationBuilder.DropIndex(
                name: "IX_Fermes_SystemVersionId",
                table: "Fermes");

            migrationBuilder.DropColumn(
                name: "VersionId",
                table: "PrevisionFermes");

            migrationBuilder.DropColumn(
                name: "SystemVersionId",
                table: "Fermes");

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "PrevisionFermes",
                type: "int",
                nullable: true);
        }
    }
}
