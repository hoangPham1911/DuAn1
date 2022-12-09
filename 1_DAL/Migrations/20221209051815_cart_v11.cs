using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1_DAL.Migrations
{
    public partial class cart_v11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TongTienNvTrongCa",
                table: "NhanVien",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TongTienNvTrongCa",
                table: "NhanVien");
        }
    }
}
