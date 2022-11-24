using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1_DAL.Migrations
{
    public partial class Cart_V06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "img",
                table: "Anh");

            migrationBuilder.RenameColumn(
                name: "SaleTheoPhanTram",
                table: "SaleChiTiet",
                newName: "SoTienSauKhiGiam");

            migrationBuilder.RenameColumn(
                name: "SaleTheoKhoangTien",
                table: "SaleChiTiet",
                newName: "DonGia");

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "SaleChiTiet",
                type: "int",
                nullable: true,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<decimal>(
                name: "DieuKienGiamGia",
                table: "Sale",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SaleTheoKhoangTien",
                table: "Sale",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SaleTheoPhanTram",
                table: "Sale",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "KieuDanhMuc",
                type: "int",
                nullable: false,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "HoaDonChiTiet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PhanTramGiamGia",
                table: "HoaDon",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SDTShip",
                table: "HoaDon",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoDiemSuDung",
                table: "HoaDon",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SoTienQuyDoi",
                table: "HoaDon",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenNguoiShip",
                table: "HoaDon",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TenShip",
                table: "HoaDon",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TrangThai",
                table: "DanhMuc",
                type: "int",
                nullable: true,
                defaultValueSql: "((0))",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "((0))");

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "ChiTietSP",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Ten",
                table: "Anh",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GiaoCa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ThoiGianNhanCa = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    ThoiGianGiaoCa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdNvNhanCaTiep = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdNvTrongCa = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TienBanDau = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TongTienTrongCa = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TongTienMat = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TongTienKhac = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TienPhatSinh = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GhiChuPhatSinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TongTienCaTruoc = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TongTienMatRut = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaoCa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiaoCa_NhanVien_IdNvNhanCaTiep",
                        column: x => x.IdNvNhanCaTiep,
                        principalTable: "NhanVien",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GiaoCa_IdNvNhanCaTiep",
                table: "GiaoCa",
                column: "IdNvNhanCaTiep");

            migrationBuilder.CreateIndex(
                name: "UQ_GiaoCa",
                table: "GiaoCa",
                column: "Ma",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GiaoCa");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "SaleChiTiet");

            migrationBuilder.DropColumn(
                name: "DieuKienGiamGia",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "SaleTheoKhoangTien",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "SaleTheoPhanTram",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "KieuDanhMuc");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "HoaDonChiTiet");

            migrationBuilder.DropColumn(
                name: "PhanTramGiamGia",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "SDTShip",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "SoDiemSuDung",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "SoTienQuyDoi",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "TenNguoiShip",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "TenShip",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "ChiTietSP");

            migrationBuilder.DropColumn(
                name: "Ten",
                table: "Anh");

            migrationBuilder.RenameColumn(
                name: "SoTienSauKhiGiam",
                table: "SaleChiTiet",
                newName: "SaleTheoPhanTram");

            migrationBuilder.RenameColumn(
                name: "DonGia",
                table: "SaleChiTiet",
                newName: "SaleTheoKhoangTien");

            migrationBuilder.AlterColumn<int>(
                name: "TrangThai",
                table: "DanhMuc",
                type: "int",
                nullable: false,
                defaultValueSql: "((0))",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValueSql: "((0))");

            migrationBuilder.AddColumn<byte[]>(
                name: "img",
                table: "Anh",
                type: "image",
                nullable: true);
        }
    }
}
