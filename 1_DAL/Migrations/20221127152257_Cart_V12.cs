using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1_DAL.Migrations
{
    public partial class Cart_V12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_KhachHang_IdKH",
                table: "HoaDon");

            migrationBuilder.DropIndex(
                name: "IX_HoaDon_IdKH",
                table: "HoaDon");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdKhachHang",
                table: "ViDiem",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "IdKhachHang",
                table: "ViDiem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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
    }
}
