using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1_DAL.Migrations
{
    public partial class cart_v11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ten",
                table: "ViDiem");

            migrationBuilder.DropColumn(
                name: "TyLeQuyDoi",
                table: "ViDiem");

            migrationBuilder.DropColumn(
                name: "DiemTichDiem",
                table: "KhachHang");

            migrationBuilder.AddColumn<Guid>(
                name: "IdKhachHang",
                table: "ViDiem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "TongDiem",
                table: "ViDiem",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoDiemCong",
                table: "LichSuDiemTieuDung",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "IdVi",
                table: "KhachHang",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_IdVi",
                table: "KhachHang",
                column: "IdVi",
                unique: true,
                filter: "[IdVi] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_KhachHang_ViDiem_IdVi",
                table: "KhachHang",
                column: "IdVi",
                principalTable: "ViDiem",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KhachHang_ViDiem_IdVi",
                table: "KhachHang");

            migrationBuilder.DropIndex(
                name: "IX_KhachHang_IdVi",
                table: "KhachHang");

            migrationBuilder.DropColumn(
                name: "IdKhachHang",
                table: "ViDiem");

            migrationBuilder.DropColumn(
                name: "TongDiem",
                table: "ViDiem");

            migrationBuilder.DropColumn(
                name: "SoDiemCong",
                table: "LichSuDiemTieuDung");

            migrationBuilder.DropColumn(
                name: "IdVi",
                table: "KhachHang");

            migrationBuilder.AddColumn<string>(
                name: "Ten",
                table: "ViDiem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TyLeQuyDoi",
                table: "ViDiem",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiemTichDiem",
                table: "KhachHang",
                type: "int",
                nullable: true);
        }
    }
}
