using Microsoft.EntityFrameworkCore.Migrations;

namespace GuzelSozlerim.Data.Migrations
{
    public partial class KullaniciSozIliski : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KullaniciSozler",
                columns: table => new
                {
                    KullaniciId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GuzelSozId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciSozler", x => new { x.GuzelSozId, x.KullaniciId });
                    table.ForeignKey(
                        name: "FK_KullaniciSozler_AspNetUsers_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KullaniciSozler_GuzelSozler_GuzelSozId",
                        column: x => x.GuzelSozId,
                        principalTable: "GuzelSozler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciSozler_KullaniciId",
                table: "KullaniciSozler",
                column: "KullaniciId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KullaniciSozler");
        }
    }
}
