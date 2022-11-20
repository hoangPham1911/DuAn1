using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1_DAL.Migrations
{
    public partial class Cart_V09 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenKieuDanhMuc",
                table: "KieuDanhMuc");

            migrationBuilder.AddColumn<int>(
                name: "TheLoaiGioiTinh",
                table: "KieuDanhMuc",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TheLoaiGioiTinh",
                table: "KieuDanhMuc");

            migrationBuilder.AddColumn<string>(
                name: "TenKieuDanhMuc",
                table: "KieuDanhMuc",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
