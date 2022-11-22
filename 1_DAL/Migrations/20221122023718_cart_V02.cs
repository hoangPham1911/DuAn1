using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1_DAL.Migrations
{
    public partial class cart_V02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdGuiBC",
                table: "NhanVien",
                newName: "TrangThai");

            migrationBuilder.AlterColumn<byte[]>(
                name: "img",
                table: "Anh",
                type: "image",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "image(30)",
                oldMaxLength: 30,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrangThai",
                table: "NhanVien",
                newName: "IdGuiBC");

            migrationBuilder.AlterColumn<byte[]>(
                name: "img",
                table: "Anh",
                type: "image(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "image",
                oldNullable: true);
        }
    }
}
