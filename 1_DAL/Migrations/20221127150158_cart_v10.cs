using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1_DAL.Migrations
{
    public partial class cart_v10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LichSuDiemTieuDung_KhachHang_IdKhachHang",
                table: "LichSuDiemTieuDung");

            migrationBuilder.DropIndex(
                name: "IX_LichSuDiemTieuDung_IdKhachHang",
                table: "LichSuDiemTieuDung");

            migrationBuilder.DropColumn(
                name: "IdKhachHang",
                table: "LichSuDiemTieuDung");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "BangQuyDoiDiem",
                newName: "Ten");

            migrationBuilder.RenameColumn(
                name: "GiaQuyDoi",
                table: "BangQuyDoiDiem",
                newName: "TyLeQuyDoi");

            migrationBuilder.AddColumn<Guid>(
                name: "IdHoaDon",
                table: "LichSuDiemTieuDung",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdViDiem",
                table: "LichSuDiemTieuDung",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "KhachHangId",
                table: "LichSuDiemTieuDung",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ViDiem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TyLeQuyDoi = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViDiem", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LichSuDiemTieuDung_IdHoaDon",
                table: "LichSuDiemTieuDung",
                column: "IdHoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuDiemTieuDung_IdViDiem",
                table: "LichSuDiemTieuDung",
                column: "IdViDiem");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuDiemTieuDung_KhachHangId",
                table: "LichSuDiemTieuDung",
                column: "KhachHangId");

            migrationBuilder.AddForeignKey(
                name: "FK_LichSuDiemTieuDung_HoaDon_IdHoaDon",
                table: "LichSuDiemTieuDung",
                column: "IdHoaDon",
                principalTable: "HoaDon",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LichSuDiemTieuDung_KhachHang_KhachHangId",
                table: "LichSuDiemTieuDung",
                column: "KhachHangId",
                principalTable: "KhachHang",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LichSuDiemTieuDung_ViDiem_IdViDiem",
                table: "LichSuDiemTieuDung",
                column: "IdViDiem",
                principalTable: "ViDiem",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LichSuDiemTieuDung_HoaDon_IdHoaDon",
                table: "LichSuDiemTieuDung");

            migrationBuilder.DropForeignKey(
                name: "FK_LichSuDiemTieuDung_KhachHang_KhachHangId",
                table: "LichSuDiemTieuDung");

            migrationBuilder.DropForeignKey(
                name: "FK_LichSuDiemTieuDung_ViDiem_IdViDiem",
                table: "LichSuDiemTieuDung");

            migrationBuilder.DropTable(
                name: "ViDiem");

            migrationBuilder.DropIndex(
                name: "IX_LichSuDiemTieuDung_IdHoaDon",
                table: "LichSuDiemTieuDung");

            migrationBuilder.DropIndex(
                name: "IX_LichSuDiemTieuDung_IdViDiem",
                table: "LichSuDiemTieuDung");

            migrationBuilder.DropIndex(
                name: "IX_LichSuDiemTieuDung_KhachHangId",
                table: "LichSuDiemTieuDung");

            migrationBuilder.DropColumn(
                name: "IdHoaDon",
                table: "LichSuDiemTieuDung");

            migrationBuilder.DropColumn(
                name: "IdViDiem",
                table: "LichSuDiemTieuDung");

            migrationBuilder.DropColumn(
                name: "KhachHangId",
                table: "LichSuDiemTieuDung");

            migrationBuilder.RenameColumn(
                name: "TyLeQuyDoi",
                table: "BangQuyDoiDiem",
                newName: "GiaQuyDoi");

            migrationBuilder.RenameColumn(
                name: "Ten",
                table: "BangQuyDoiDiem",
                newName: "Name");

            migrationBuilder.AddColumn<Guid>(
                name: "IdKhachHang",
                table: "LichSuDiemTieuDung",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_LichSuDiemTieuDung_IdKhachHang",
                table: "LichSuDiemTieuDung",
                column: "IdKhachHang");

            migrationBuilder.AddForeignKey(
                name: "FK_LichSuDiemTieuDung_KhachHang_IdKhachHang",
                table: "LichSuDiemTieuDung",
                column: "IdKhachHang",
                principalTable: "KhachHang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
