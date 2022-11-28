using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1_DAL.Migrations
{
    public partial class cart_V16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_IdKH",
                table: "HoaDon",
                column: "IdKH");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_KhachHang_IdKH",
                table: "HoaDon",
                column: "IdKH",
                principalTable: "KhachHang",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_KhachHang_IdKH",
                table: "HoaDon");

            migrationBuilder.DropIndex(
                name: "IX_HoaDon_IdKH",
                table: "HoaDon");
        }
    }
}
