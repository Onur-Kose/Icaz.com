using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Icaz.com.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rols",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rols", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cinsiyet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kullaniciadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAdresi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeleteUser = table.Column<bool>(type: "bit", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Rols_RolId",
                        column: x => x.RolId,
                        principalTable: "Rols",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Konus",
                columns: table => new
                {
                    KonuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KonuAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konus", x => x.KonuId);
                    table.ForeignKey(
                        name: "FK_Konus_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Makales",
                columns: table => new
                {
                    MakaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakleAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MakleOzet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MakleMetni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KacOkundu = table.Column<int>(type: "int", nullable: false),
                    Puan = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KonuId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makales", x => x.MakaleId);
                    table.ForeignKey(
                        name: "FK_Makales_Konus_KonuId",
                        column: x => x.KonuId,
                        principalTable: "Konus",
                        principalColumn: "KonuId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Makales_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Konus_UserId",
                table: "Konus",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Makales_KonuId",
                table: "Makales",
                column: "KonuId");

            migrationBuilder.CreateIndex(
                name: "IX_Makales_UserId",
                table: "Makales",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RolId",
                table: "Users",
                column: "RolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Makales");

            migrationBuilder.DropTable(
                name: "Konus");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Rols");
        }
    }
}
