using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1_DAL.Migrations
{
    public partial class cart_v06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleChiTiet");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropColumn(
                name: "PhanTramGiamGia",
                table: "HoaDon");

            migrationBuilder.AddColumn<string>(
                name: "MaGiamGia",
                table: "HoaDon",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VoucherNavigrationId",
                table: "HoaDon",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Voucher",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaGiamGia = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenChuongTrinh = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    SoTienGiamGia = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voucher", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_VoucherNavigrationId",
                table: "HoaDon",
                column: "VoucherNavigrationId");

            migrationBuilder.CreateIndex(
                name: "UQ_MaGiamGia",
                table: "Voucher",
                column: "MaGiamGia",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_Voucher_VoucherNavigrationId",
                table: "HoaDon",
                column: "VoucherNavigrationId",
                principalTable: "Voucher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_Voucher_VoucherNavigrationId",
                table: "HoaDon");

            migrationBuilder.DropTable(
                name: "Voucher");

            migrationBuilder.DropIndex(
                name: "IX_HoaDon_VoucherNavigrationId",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "MaGiamGia",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "VoucherNavigrationId",
                table: "HoaDon");

            migrationBuilder.AddColumn<decimal>(
                name: "PhanTramGiamGia",
                table: "HoaDon",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DieuKienGiamGia = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaGiamGia = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SaleTheoKhoangTien = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SaleTheoPhanTram = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TenChuongTrinh = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleChiTiet",
                columns: table => new
                {
                    IdHoaDon = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSale = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SoTienSauKhiGiam = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleChiTiet", x => new { x.IdHoaDon, x.IdSale });
                    table.ForeignKey(
                        name: "FK_SaleChiTiet_HoaDon_IdHoaDon",
                        column: x => x.IdHoaDon,
                        principalTable: "HoaDon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleChiTiet_Sale_IdSale",
                        column: x => x.IdSale,
                        principalTable: "Sale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "UQ_MaGiamGia",
                table: "Sale",
                column: "MaGiamGia",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SaleChiTiet_IdSale",
                table: "SaleChiTiet",
                column: "IdSale");
        }
    }
}
