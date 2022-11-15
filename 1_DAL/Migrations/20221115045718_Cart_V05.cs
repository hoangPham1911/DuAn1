using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1_DAL.Migrations
{
    public partial class Cart_V05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "img",
                table: "SanPham");

            migrationBuilder.AddColumn<string>(
                name: "DuongDan",
                table: "Anh",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DuongDan",
                table: "Anh");

            migrationBuilder.AddColumn<byte[]>(
                name: "img",
                table: "SanPham",
                type: "image",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
