using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1_DAL.Migrations
{
    public partial class Cart_V07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DonGia",
                table: "HoaDonChiTiet",
                newName: "GiamGia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GiamGia",
                table: "HoaDonChiTiet",
                newName: "DonGia");
        }
    }
}
