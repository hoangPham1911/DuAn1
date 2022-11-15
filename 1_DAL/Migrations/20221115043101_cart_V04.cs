using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1_DAL.Migrations
{
    public partial class cart_V04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdAnh",
                table: "ChiTietSP",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Anh",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    MaAnh = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    TenAnh = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anh", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSP_IdAnh",
                table: "ChiTietSP",
                column: "IdAnh");

            migrationBuilder.CreateIndex(
                name: "UQ_Anh",
                table: "Anh",
                column: "MaAnh",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSP_Anh_IdAnh",
                table: "ChiTietSP",
                column: "IdAnh",
                principalTable: "Anh",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSP_Anh_IdAnh",
                table: "ChiTietSP");

            migrationBuilder.DropTable(
                name: "Anh");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietSP_IdAnh",
                table: "ChiTietSP");

            migrationBuilder.DropColumn(
                name: "IdAnh",
                table: "ChiTietSP");
        }
    }
}
