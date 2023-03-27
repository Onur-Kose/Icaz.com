using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Icaz.com.Migrations
{
    /// <inheritdoc />
    public partial class v6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KonuUsers_AspNetUsers_MemberId1",
                table: "KonuUsers");

            migrationBuilder.DropIndex(
                name: "IX_KonuUsers_MemberId1",
                table: "KonuUsers");

            migrationBuilder.DropColumn(
                name: "MemberId1",
                table: "KonuUsers");

            migrationBuilder.AlterColumn<string>(
                name: "MemberId",
                table: "KonuUsers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KonuUsers_MemberId",
                table: "KonuUsers",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_KonuUsers_AspNetUsers_MemberId",
                table: "KonuUsers",
                column: "MemberId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KonuUsers_AspNetUsers_MemberId",
                table: "KonuUsers");

            migrationBuilder.DropIndex(
                name: "IX_KonuUsers_MemberId",
                table: "KonuUsers");

            migrationBuilder.AlterColumn<int>(
                name: "MemberId",
                table: "KonuUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MemberId1",
                table: "KonuUsers",
                type: "nvarchar(450)",
                nullable: true);

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
        }
    }
}
