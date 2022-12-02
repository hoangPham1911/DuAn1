using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1_DAL.Migrations
{
    public partial class Cart_V17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TenNguoiShip",
                table: "HoaDon",
                newName: "TenKhachHang");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TenKhachHang",
                table: "HoaDon",
                newName: "TenNguoiShip");
        }
    }
}
