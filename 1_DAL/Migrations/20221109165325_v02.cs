using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1_DAL.Migrations
{
    public partial class v02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KieuDanhMuc_DanhMuc_IdDanhMuc",
                table: "KieuDanhMuc");

            migrationBuilder.DropForeignKey(
                name: "FK_KieuDanhMuc_SanPham_Id",
                table: "KieuDanhMuc");

            migrationBuilder.DropForeignKey(
                name: "FK_KieuDanhMuc_SanPham_IdHangHoa",
                table: "KieuDanhMuc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KieuDanhMuc",
                table: "KieuDanhMuc");

            migrationBuilder.DropIndex(
                name: "IX_KieuDanhMuc_IdDanhMuc",
                table: "KieuDanhMuc");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "KieuDanhMuc");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdHangHoa",
                table: "KieuDanhMuc",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdDanhMuc",
                table: "KieuDanhMuc",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_KieuDanhMuc",
                table: "KieuDanhMuc",
                columns: new[] { "IdDanhMuc", "IdHangHoa" });

            migrationBuilder.AddForeignKey(
                name: "FK_KieuDanhMuc_DanhMuc_IdDanhMuc",
                table: "KieuDanhMuc",
                column: "IdDanhMuc",
                principalTable: "DanhMuc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KieuDanhMuc_SanPham_IdHangHoa",
                table: "KieuDanhMuc",
                column: "IdHangHoa",
                principalTable: "SanPham",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KieuDanhMuc_DanhMuc_IdDanhMuc",
                table: "KieuDanhMuc");

            migrationBuilder.DropForeignKey(
                name: "FK_KieuDanhMuc_SanPham_IdHangHoa",
                table: "KieuDanhMuc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KieuDanhMuc",
                table: "KieuDanhMuc");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdHangHoa",
                table: "KieuDanhMuc",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdDanhMuc",
                table: "KieuDanhMuc",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "KieuDanhMuc",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_KieuDanhMuc",
                table: "KieuDanhMuc",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_KieuDanhMuc_IdDanhMuc",
                table: "KieuDanhMuc",
                column: "IdDanhMuc");

            migrationBuilder.AddForeignKey(
                name: "FK_KieuDanhMuc_DanhMuc_IdDanhMuc",
                table: "KieuDanhMuc",
                column: "IdDanhMuc",
                principalTable: "DanhMuc",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KieuDanhMuc_SanPham_Id",
                table: "KieuDanhMuc",
                column: "Id",
                principalTable: "SanPham",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KieuDanhMuc_SanPham_IdHangHoa",
                table: "KieuDanhMuc",
                column: "IdHangHoa",
                principalTable: "SanPham",
                principalColumn: "Id");
        }
    }
}
