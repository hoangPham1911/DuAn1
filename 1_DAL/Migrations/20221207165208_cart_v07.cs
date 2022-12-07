using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1_DAL.Migrations
{
    public partial class cart_v07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_Voucher_VoucherNavigrationId",
                table: "HoaDon");

            migrationBuilder.DropIndex(
                name: "IX_HoaDon_VoucherNavigrationId",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "VoucherNavigrationId",
                table: "HoaDon");

            migrationBuilder.AlterColumn<int>(
                name: "TrangThai",
                table: "Voucher",
                type: "int",
                nullable: false,
                defaultValueSql: "((0))",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "MaGiamGia",
                table: "Voucher",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Voucher",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "(newid())",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "IdVouCher",
                table: "HoaDon",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_IdVouCher",
                table: "HoaDon",
                column: "IdVouCher");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_Voucher_IdVouCher",
                table: "HoaDon",
                column: "IdVouCher",
                principalTable: "Voucher",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_Voucher_IdVouCher",
                table: "HoaDon");

            migrationBuilder.DropIndex(
                name: "IX_HoaDon_IdVouCher",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "IdVouCher",
                table: "HoaDon");

            migrationBuilder.AlterColumn<int>(
                name: "TrangThai",
                table: "Voucher",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "((0))");

            migrationBuilder.AlterColumn<string>(
                name: "MaGiamGia",
                table: "Voucher",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Voucher",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "(newid())");

            migrationBuilder.AddColumn<Guid>(
                name: "VoucherNavigrationId",
                table: "HoaDon",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_VoucherNavigrationId",
                table: "HoaDon",
                column: "VoucherNavigrationId");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_Voucher_VoucherNavigrationId",
                table: "HoaDon",
                column: "VoucherNavigrationId",
                principalTable: "Voucher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
