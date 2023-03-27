using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Icaz.com.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KonuUserId",
                table: "Konus",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fotograf",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KonuUserId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MemberDetail",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "KonuUsers",
                columns: table => new
                {
                    KonuUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KonuUsers", x => x.KonuUserId);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_KonuUsers_KonuUserId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Konus_KonuUsers_KonuUserId",
                table: "Konus");

            migrationBuilder.DropTable(
                name: "KonuUsers");

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
                name: "Fotograf",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "KonuUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MemberDetail",
                table: "AspNetUsers");
        }
    }
}
