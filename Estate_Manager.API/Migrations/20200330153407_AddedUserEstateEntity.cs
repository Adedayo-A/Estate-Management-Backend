using Microsoft.EntityFrameworkCore.Migrations;

namespace Estate_Manager.API.Migrations
{
    public partial class AddedUserEstateEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estates_AspNetUsers_UserId",
                table: "Estates");

            migrationBuilder.DropIndex(
                name: "IX_Estates_UserId",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Estates");

            migrationBuilder.CreateTable(
                name: "UserEstate",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    EstateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEstate", x => new { x.EstateId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserEstate_Estates_EstateId",
                        column: x => x.EstateId,
                        principalTable: "Estates",
                        principalColumn: "EstateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserEstate_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserEstate_UserId",
                table: "UserEstate",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEstate");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Estates",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estates_UserId",
                table: "Estates",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estates_AspNetUsers_UserId",
                table: "Estates",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
