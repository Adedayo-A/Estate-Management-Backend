using Microsoft.EntityFrameworkCore.Migrations;

namespace Estate_Manager.API.Migrations
{
    public partial class Homeowner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeOwners_Homes_HomeId",
                table: "HomeOwners");

            migrationBuilder.DropIndex(
                name: "IX_HomeOwners_HomeId",
                table: "HomeOwners");

            migrationBuilder.AddColumn<int>(
                name: "HomeNo",
                table: "Homes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeOwnerId",
                table: "Homes",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "d9b849b1-da5e-4e02-9dc7-bbd1e2654f6f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "b5236b7f-29d3-4be4-8048-36d815b6453c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "6cdd539b-a8ad-4a6e-abe5-207ce644ff98");

            migrationBuilder.CreateIndex(
                name: "IX_HomeOwners_HomeId",
                table: "HomeOwners",
                column: "HomeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeOwners_Homes_HomeId",
                table: "HomeOwners",
                column: "HomeId",
                principalTable: "Homes",
                principalColumn: "HomeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeOwners_Homes_HomeId",
                table: "HomeOwners");

            migrationBuilder.DropIndex(
                name: "IX_HomeOwners_HomeId",
                table: "HomeOwners");

            migrationBuilder.DropColumn(
                name: "HomeNo",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "HomeOwnerId",
                table: "Homes");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "d34f3926-d950-4ffc-aaae-b5f606493f85");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "ca05f225-3b83-4606-8896-c83c97a76165");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "6e22f8e0-44c7-4e34-b7da-efe865b30c19");

            migrationBuilder.CreateIndex(
                name: "IX_HomeOwners_HomeId",
                table: "HomeOwners",
                column: "HomeId");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeOwners_Homes_HomeId",
                table: "HomeOwners",
                column: "HomeId",
                principalTable: "Homes",
                principalColumn: "HomeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
