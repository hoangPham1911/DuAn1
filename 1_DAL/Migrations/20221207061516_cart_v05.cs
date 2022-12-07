using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1_DAL.Migrations
{
    public partial class cart_v05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleChiTiet_ChiTietSP_IdChiTietHangHoa",
                table: "SaleChiTiet");

            migrationBuilder.RenameColumn(
                name: "IdChiTietHangHoa",
                table: "SaleChiTiet",
                newName: "IdHoaDon");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleChiTiet_HoaDon_IdHoaDon",
                table: "SaleChiTiet",
                column: "IdHoaDon",
                principalTable: "HoaDon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleChiTiet_HoaDon_IdHoaDon",
                table: "SaleChiTiet");

            migrationBuilder.RenameColumn(
                name: "IdHoaDon",
                table: "SaleChiTiet",
                newName: "IdChiTietHangHoa");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleChiTiet_ChiTietSP_IdChiTietHangHoa",
                table: "SaleChiTiet",
                column: "IdChiTietHangHoa",
                principalTable: "ChiTietSP",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
