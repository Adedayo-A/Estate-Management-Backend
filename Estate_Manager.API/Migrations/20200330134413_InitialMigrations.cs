using Microsoft.EntityFrameworkCore.Migrations;

namespace Estate_Manager.API.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estates",
                columns: table => new
                {
                    EstateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estates", x => x.EstateId);
                });

            migrationBuilder.CreateTable(
                name: "Roads",
                columns: table => new
                {
                    RoadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    EstateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roads", x => x.RoadId);
                    table.ForeignKey(
                        name: "FK_Roads_Estates_EstateId",
                        column: x => x.EstateId,
                        principalTable: "Estates",
                        principalColumn: "EstateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Homes",
                columns: table => new
                {
                    HomeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoadId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homes", x => x.HomeId);
                    table.ForeignKey(
                        name: "FK_Homes_Roads_RoadId",
                        column: x => x.RoadId,
                        principalTable: "Roads",
                        principalColumn: "RoadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Homes_RoadId",
                table: "Homes",
                column: "RoadId");

            migrationBuilder.CreateIndex(
                name: "IX_Roads_EstateId",
                table: "Roads",
                column: "EstateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Homes");

            migrationBuilder.DropTable(
                name: "Roads");

            migrationBuilder.DropTable(
                name: "Estates");
        }
    }
}
