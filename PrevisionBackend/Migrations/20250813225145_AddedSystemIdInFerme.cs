using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrevisionBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddedSystemIdInFerme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fermes_SystemVersions_SystemVersionId",
                table: "Fermes");

            migrationBuilder.AlterColumn<int>(
                name: "SystemVersionId",
                table: "Fermes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Fermes_SystemVersions_SystemVersionId",
                table: "Fermes",
                column: "SystemVersionId",
                principalTable: "SystemVersions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fermes_SystemVersions_SystemVersionId",
                table: "Fermes");

            migrationBuilder.AlterColumn<int>(
                name: "SystemVersionId",
                table: "Fermes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fermes_SystemVersions_SystemVersionId",
                table: "Fermes",
                column: "SystemVersionId",
                principalTable: "SystemVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
