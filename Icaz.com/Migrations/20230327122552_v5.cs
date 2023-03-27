using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Icaz.com.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_KonuUsers_KonuUserId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Konus_KonuUsers_KonuUserId",
                table: "Konus");

            migrationBuilder.DropIndex(
                name: "IX_Konus_KonuUserId",
                table: "Konus");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_KonuUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "KonuUserId",
                table: "Konus");

            migrationBuilder.DropColumn(
                name: "KonuUserId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "MemberId1",
                table: "KonuUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KonuUsers_KonuId",
                table: "KonuUsers",
                column: "KonuId");

            migrationBuilder.CreateIndex(
                name: "IX_KonuUsers_MemberId1",
                table: "KonuUsers",
                column: "MemberId1");

            migrationBuilder.AddForeignKey(
                name: "FK_KonuUsers_AspNetUsers_MemberId1",
                table: "KonuUsers",
                column: "MemberId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KonuUsers_Konus_KonuId",
                table: "KonuUsers",
                column: "KonuId",
                principalTable: "Konus",
                principalColumn: "KonuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KonuUsers_AspNetUsers_MemberId1",
                table: "KonuUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_KonuUsers_Konus_KonuId",
                table: "KonuUsers");

            migrationBuilder.DropIndex(
                name: "IX_KonuUsers_KonuId",
                table: "KonuUsers");

            migrationBuilder.DropIndex(
                name: "IX_KonuUsers_MemberId1",
                table: "KonuUsers");

            migrationBuilder.DropColumn(
                name: "MemberId1",
                table: "KonuUsers");

            migrationBuilder.AddColumn<int>(
                name: "KonuUserId",
                table: "Konus",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KonuUserId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Konus_KonuUserId",
                table: "Konus",
                column: "KonuUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_KonuUserId",
                table: "AspNetUsers",
                column: "KonuUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_KonuUsers_KonuUserId",
                table: "AspNetUsers",
                column: "KonuUserId",
                principalTable: "KonuUsers",
                principalColumn: "KonuUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Konus_KonuUsers_KonuUserId",
                table: "Konus",
                column: "KonuUserId",
                principalTable: "KonuUsers",
                principalColumn: "KonuUserId");
        }
    }
}
