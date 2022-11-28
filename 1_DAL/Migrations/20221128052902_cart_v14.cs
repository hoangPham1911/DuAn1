using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1_DAL.Migrations
{
    public partial class cart_v14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LichSuDiemTieuDung_KhachHang_KhachHangId",
                table: "LichSuDiemTieuDung");

            migrationBuilder.DropIndex(
                name: "IX_LichSuDiemTieuDung_KhachHangId",
                table: "LichSuDiemTieuDung");

            migrationBuilder.DropColumn(
                name: "KhachHangId",
                table: "LichSuDiemTieuDung");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "KhachHangId",
                table: "LichSuDiemTieuDung",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LichSuDiemTieuDung_KhachHangId",
                table: "LichSuDiemTieuDung",
                column: "KhachHangId");

            migrationBuilder.AddForeignKey(
                name: "FK_LichSuDiemTieuDung_KhachHang_KhachHangId",
                table: "LichSuDiemTieuDung",
                column: "KhachHangId",
                principalTable: "KhachHang",
                principalColumn: "Id");
        }
    }
}
