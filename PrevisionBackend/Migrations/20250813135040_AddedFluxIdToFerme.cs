using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrevisionBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddedFluxIdToFerme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fermes_Flux_FluxId",
                table: "Fermes");

            migrationBuilder.RenameColumn(
                name: "FluxId",
                table: "Fermes",
                newName: "FluxId1");

            migrationBuilder.RenameIndex(
                name: "IX_Fermes_FluxId",
                table: "Fermes",
                newName: "IX_Fermes_FluxId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Fermes_Flux_FluxId1",
                table: "Fermes",
                column: "FluxId1",
                principalTable: "Flux",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fermes_Flux_FluxId1",
                table: "Fermes");

            migrationBuilder.RenameColumn(
                name: "FluxId1",
                table: "Fermes",
                newName: "FluxId");

            migrationBuilder.RenameIndex(
                name: "IX_Fermes_FluxId1",
                table: "Fermes",
                newName: "IX_Fermes_FluxId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fermes_Flux_FluxId",
                table: "Fermes",
                column: "FluxId",
                principalTable: "Flux",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
