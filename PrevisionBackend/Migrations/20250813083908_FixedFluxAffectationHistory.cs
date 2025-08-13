using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrevisionBackend.Migrations
{
    /// <inheritdoc />
    public partial class FixedFluxAffectationHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FluxId",
                table: "PrevisionFermes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PrevisionFermes_FluxId",
                table: "PrevisionFermes",
                column: "FluxId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrevisionFermes_Flux_FluxId",
                table: "PrevisionFermes",
                column: "FluxId",
                principalTable: "Flux",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrevisionFermes_Flux_FluxId",
                table: "PrevisionFermes");

            migrationBuilder.DropIndex(
                name: "IX_PrevisionFermes_FluxId",
                table: "PrevisionFermes");

            migrationBuilder.DropColumn(
                name: "FluxId",
                table: "PrevisionFermes");
        }
    }
}
