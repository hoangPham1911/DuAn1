using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1_DAL.Migrations
{
    public partial class V01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatLieu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Ma = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatLieu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChucVu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Ma = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMuc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Ma = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMuc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Ma = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoCCCD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamSinh = table.Column<DateTime>(type: "date", nullable: true),
                    Sdt = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TrangThai = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    DiemTichDiem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiGiay",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Ma = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiGiay", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NSX",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Ma = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NSX", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuocGia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Ma = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuocGia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SizeGiay",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Ma = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    SoSize = table.Column<int>(type: "int", maxLength: 30, nullable: false, defaultValueSql: "((0))"),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeGiay", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Ma = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NamSinh = table.Column<DateTime>(type: "date", nullable: true),
                    QueQuan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sdt = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CMND = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCV = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdGuiBC = table.Column<int>(type: "int", nullable: true),
                    img = table.Column<byte[]>(type: "image", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhanVien_ChucVu_IdCV",
                        column: x => x.IdCV,
                        principalTable: "ChucVu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Ma = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    img = table.Column<byte[]>(type: "image", nullable: false),
                    IdNsx = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPham_NSX_IdNsx",
                        column: x => x.IdNsx,
                        principalTable: "NSX",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IdKH = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdNV = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Ma = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    NgayTao = table.Column<DateTime>(type: "date", nullable: true),
                    NgayThanhToan = table.Column<DateTime>(type: "date", nullable: true),
                    NgayShip = table.Column<DateTime>(type: "date", nullable: true),
                    NgayNhan = table.Column<DateTime>(type: "date", nullable: true),
                    TinhTrang = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    Thue = table.Column<decimal>(type: "decimal(18,2)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoaDon_KhachHang_IdKH",
                        column: x => x.IdKH,
                        principalTable: "KhachHang",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HoaDon_NhanVien_IdNV",
                        column: x => x.IdNV,
                        principalTable: "NhanVien",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietSP",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IdSP = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdQuocGia = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdLoaiGiay = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdDongSP = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdChatLieu = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NamBH = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    MoTa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SoLuongTon = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    GiaNhap = table.Column<decimal>(type: "decimal(20,0)", nullable: true, defaultValueSql: "((0))"),
                    GiaBan = table.Column<decimal>(type: "decimal(20,0)", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietSP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietSP_ChatLieu_IdChatLieu",
                        column: x => x.IdChatLieu,
                        principalTable: "ChatLieu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChiTietSP_LoaiGiay_IdLoaiGiay",
                        column: x => x.IdLoaiGiay,
                        principalTable: "LoaiGiay",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChiTietSP_QuocGia_IdQuocGia",
                        column: x => x.IdQuocGia,
                        principalTable: "QuocGia",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChiTietSP_SanPham_IdSP",
                        column: x => x.IdSP,
                        principalTable: "SanPham",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChiTietSP_SizeGiay_IdDongSP",
                        column: x => x.IdDongSP,
                        principalTable: "SizeGiay",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KieuDanhMuc",
                columns: table => new
                {
                    IdDanhMuc = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdHangHoa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenKieuDanhMuc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KieuDanhMuc", x => new { x.IdDanhMuc, x.IdHangHoa });
                    table.ForeignKey(
                        name: "FK_KieuDanhMuc_DanhMuc_IdDanhMuc",
                        column: x => x.IdDanhMuc,
                        principalTable: "DanhMuc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KieuDanhMuc_SanPham_IdHangHoa",
                        column: x => x.IdHangHoa,
                        principalTable: "SanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDonChiTiet",
                columns: table => new
                {
                    IdHoaDon = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdChiTietSP = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    ThanhTien = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonChiTiet", x => new { x.IdChiTietSP, x.IdHoaDon });
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiet_ChiTietSP_IdChiTietSP",
                        column: x => x.IdChiTietSP,
                        principalTable: "ChiTietSP",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiet_HoaDon_IdHoaDon",
                        column: x => x.IdHoaDon,
                        principalTable: "HoaDon",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "UQ_ChatLieu",
                table: "ChatLieu",
                column: "Ma",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSP_IdChatLieu",
                table: "ChiTietSP",
                column: "IdChatLieu");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSP_IdDongSP",
                table: "ChiTietSP",
                column: "IdDongSP");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSP_IdLoaiGiay",
                table: "ChiTietSP",
                column: "IdLoaiGiay");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSP_IdQuocGia",
                table: "ChiTietSP",
                column: "IdQuocGia");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSP_IdSP",
                table: "ChiTietSP",
                column: "IdSP");

            migrationBuilder.CreateIndex(
                name: "UQ_ChucVu",
                table: "ChucVu",
                column: "Ma",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_DanhMuc",
                table: "DanhMuc",
                column: "Ma",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_IdKH",
                table: "HoaDon",
                column: "IdKH");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_IdNV",
                table: "HoaDon",
                column: "IdNV");

            migrationBuilder.CreateIndex(
                name: "UQ_HoaDon",
                table: "HoaDon",
                column: "Ma",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiet_IdHoaDon",
                table: "HoaDonChiTiet",
                column: "IdHoaDon");

            migrationBuilder.CreateIndex(
                name: "UQ_KhachHang",
                table: "KhachHang",
                column: "Ma",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KieuDanhMuc_IdHangHoa",
                table: "KieuDanhMuc",
                column: "IdHangHoa");

            migrationBuilder.CreateIndex(
                name: "UQ_LoaiGiay",
                table: "LoaiGiay",
                column: "Ma",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_IdCV",
                table: "NhanVien",
                column: "IdCV");

            migrationBuilder.CreateIndex(
                name: "UQ_NhanVien",
                table: "NhanVien",
                column: "Ma",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_NSX",
                table: "NSX",
                column: "Ma",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_QuocGia",
                table: "QuocGia",
                column: "Ma",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_IdNsx",
                table: "SanPham",
                column: "IdNsx");

            migrationBuilder.CreateIndex(
                name: "UQ_SanPham",
                table: "SanPham",
                column: "Ma",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_SizeGiay",
                table: "SizeGiay",
                column: "Ma",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HoaDonChiTiet");

            migrationBuilder.DropTable(
                name: "KieuDanhMuc");

            migrationBuilder.DropTable(
                name: "ChiTietSP");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "DanhMuc");

            migrationBuilder.DropTable(
                name: "ChatLieu");

            migrationBuilder.DropTable(
                name: "LoaiGiay");

            migrationBuilder.DropTable(
                name: "QuocGia");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "SizeGiay");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "NSX");

            migrationBuilder.DropTable(
                name: "ChucVu");
        }
    }
}
