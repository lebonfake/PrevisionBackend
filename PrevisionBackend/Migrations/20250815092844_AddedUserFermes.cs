using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrevisionBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserFermes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserFermes",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FermeId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFermes", x => new { x.UserId, x.FermeId });
                    table.ForeignKey(
                        name: "FK_UserFermes_Fermes_FermeId",
                        column: x => x.FermeId,
                        principalTable: "Fermes",
                        principalColumn: "cod_ferm",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFermes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFermes_FermeId",
                table: "UserFermes",
                column: "FermeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFermes");
        }
    }
}
