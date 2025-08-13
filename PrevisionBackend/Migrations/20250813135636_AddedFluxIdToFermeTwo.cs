using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrevisionBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddedFluxIdToFermeTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fermes_Flux_FluxId1",
                table: "Fermes");

            migrationBuilder.DropIndex(
                name: "IX_Fermes_FluxId1",
                table: "Fermes");

            migrationBuilder.DropColumn(
                name: "FluxId1",
                table: "Fermes");

            migrationBuilder.AddColumn<int>(
                name: "FluxId",
                table: "Fermes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fermes_FluxId",
                table: "Fermes",
                column: "FluxId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fermes_Flux_FluxId",
                table: "Fermes",
                column: "FluxId",
                principalTable: "Flux",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fermes_Flux_FluxId",
                table: "Fermes");

            migrationBuilder.DropIndex(
                name: "IX_Fermes_FluxId",
                table: "Fermes");

            migrationBuilder.DropColumn(
                name: "FluxId",
                table: "Fermes");

            migrationBuilder.AddColumn<int>(
                name: "FluxId1",
                table: "Fermes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Fermes_FluxId1",
                table: "Fermes",
                column: "FluxId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Fermes_Flux_FluxId1",
                table: "Fermes",
                column: "FluxId1",
                principalTable: "Flux",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
