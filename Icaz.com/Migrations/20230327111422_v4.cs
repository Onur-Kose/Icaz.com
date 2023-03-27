using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Icaz.com.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KonuId",
                table: "KonuUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "KonuUsers",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KonuId",
                table: "KonuUsers");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "KonuUsers");
        }
    }
}
