using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1_DAL.Migrations
{
    public partial class cart_v01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anh",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    MaAnh = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DuongDan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anh", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BangQuyDoiDiem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TyLeQuyDoi = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BangQuyDoiDiem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatLieu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Ma = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))")
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
                    Ten = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))")
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
                    IdDanhMucKhac = table.Column<Guid>(type: "uniqueidentifier", maxLength: 30, nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMuc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhMuc_DanhMuc_IdDanhMucKhac",
                        column: x => x.IdDanhMucKhac,
                        principalTable: "DanhMuc",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LoaiGiay",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Ma = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))")
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
                    Ten = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))")
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
                    TrangThai = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuocGia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaGiamGia = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenChuongTrinh = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    SaleTheoPhanTram = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SaleTheoKhoangTien = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DieuKienGiamGia = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SizeGiay",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Ma = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    SoSize = table.Column<int>(type: "int", maxLength: 30, nullable: false, defaultValueSql: "((0))"),
                    TrangThai = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeGiay", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ViDiem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    TongDiem = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    IdKhachHang = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdQuyDoiDiem = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViDiem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ViDiem_BangQuyDoiDiem_IdQuyDoiDiem",
                        column: x => x.IdQuyDoiDiem,
                        principalTable: "BangQuyDoiDiem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Ma = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Ho = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TenDem = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NamSinh = table.Column<DateTime>(type: "date", nullable: true),
                    QueQuan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sdt = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CMND = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCV = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    img = table.Column<byte[]>(type: "image", nullable: true),
                    MaOTP = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    TrangThai = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))"),
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
                name: "KhachHang",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IdVi = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Ma = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoCCCD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamSinh = table.Column<DateTime>(type: "date", nullable: true),
                    Sdt = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TrangThai = table.Column<int>(type: "int", maxLength: 50, nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhachHang_ViDiem_IdVi",
                        column: x => x.IdVi,
                        principalTable: "ViDiem",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateTable(
                name: "ChiTietSP",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IdSP = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdQuocGia = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdLoaiGiay = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdSizeGiay = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdAnh = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdChatLieu = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NamBH = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    MoTa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoLuongTon = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    GiaNhap = table.Column<decimal>(type: "decimal(20,0)", nullable: true, defaultValueSql: "((0))"),
                    GiaBan = table.Column<decimal>(type: "decimal(20,0)", nullable: true, defaultValueSql: "((0))"),
                    MaQRCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietSP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietSP_Anh_IdAnh",
                        column: x => x.IdAnh,
                        principalTable: "Anh",
                        principalColumn: "ID");
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
                        name: "FK_ChiTietSP_SizeGiay_IdSizeGiay",
                        column: x => x.IdSizeGiay,
                        principalTable: "SizeGiay",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KieuDanhMuc",
                columns: table => new
                {
                    IdDanhMuc = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdHangHoa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TheLoaiGioiTinh = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))")
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
                    Thue = table.Column<decimal>(type: "decimal(18,2)", maxLength: 50, nullable: false),
                    SDTShip = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TenShip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoTienQuyDoi = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValueSql: "((0))"),
                    SoDiemSuDung = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    PhanTramGiamGia = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
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
                name: "SaleChiTiet",
                columns: table => new
                {
                    IdSale = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdChiTietHangHoa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SoTienSauKhiGiam = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleChiTiet", x => new { x.IdChiTietHangHoa, x.IdSale });
                    table.ForeignKey(
                        name: "FK_SaleChiTiet_ChiTietSP_IdChiTietHangHoa",
                        column: x => x.IdChiTietHangHoa,
                        principalTable: "ChiTietSP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleChiTiet_Sale_IdSale",
                        column: x => x.IdSale,
                        principalTable: "Sale",
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
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    GiamGia = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValueSql: "((0))")
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

            migrationBuilder.CreateTable(
                name: "LichSuDiemTieuDung",
                columns: table => new
                {
                    IdLichSuDiem = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgaySuDung = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoDiemTieuDung = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    SoDiemCong = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    TrangThai = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    IdViDiem = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdHoaDon = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichSuDiemTieuDung", x => x.IdLichSuDiem);
                    table.ForeignKey(
                        name: "FK_LichSuDiemTieuDung_HoaDon_IdHoaDon",
                        column: x => x.IdHoaDon,
                        principalTable: "HoaDon",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LichSuDiemTieuDung_ViDiem_IdViDiem",
                        column: x => x.IdViDiem,
                        principalTable: "ViDiem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "UQ_Anh",
                table: "Anh",
                column: "MaAnh",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_ChatLieu",
                table: "ChatLieu",
                column: "Ma",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSP_IdAnh",
                table: "ChiTietSP",
                column: "IdAnh");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSP_IdChatLieu",
                table: "ChiTietSP",
                column: "IdChatLieu");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSP_IdLoaiGiay",
                table: "ChiTietSP",
                column: "IdLoaiGiay");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSP_IdQuocGia",
                table: "ChiTietSP",
                column: "IdQuocGia");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSP_IdSizeGiay",
                table: "ChiTietSP",
                column: "IdSizeGiay");

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
                name: "IX_DanhMuc_IdDanhMucKhac",
                table: "DanhMuc",
                column: "IdDanhMucKhac");

            migrationBuilder.CreateIndex(
                name: "UQ_DanhMuc",
                table: "DanhMuc",
                column: "Ma",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GiaoCa_IdNvNhanCaTiep",
                table: "GiaoCa",
                column: "IdNvNhanCaTiep");

            migrationBuilder.CreateIndex(
                name: "UQ_GiaoCa",
                table: "GiaoCa",
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
                name: "IX_KhachHang_IdVi",
                table: "KhachHang",
                column: "IdVi",
                unique: true,
                filter: "[IdVi] IS NOT NULL");

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
                name: "IX_LichSuDiemTieuDung_IdHoaDon",
                table: "LichSuDiemTieuDung",
                column: "IdHoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuDiemTieuDung_IdViDiem",
                table: "LichSuDiemTieuDung",
                column: "IdViDiem");

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
                name: "UQ_MaGiamGia",
                table: "Sale",
                column: "MaGiamGia",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SaleChiTiet_IdSale",
                table: "SaleChiTiet",
                column: "IdSale");

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

            migrationBuilder.CreateIndex(
                name: "IX_ViDiem_IdQuyDoiDiem",
                table: "ViDiem",
                column: "IdQuyDoiDiem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GiaoCa");

            migrationBuilder.DropTable(
                name: "HoaDonChiTiet");

            migrationBuilder.DropTable(
                name: "KieuDanhMuc");

            migrationBuilder.DropTable(
                name: "LichSuDiemTieuDung");

            migrationBuilder.DropTable(
                name: "SaleChiTiet");

            migrationBuilder.DropTable(
                name: "DanhMuc");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "ChiTietSP");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "Anh");

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
                name: "ViDiem");

            migrationBuilder.DropTable(
                name: "ChucVu");

            migrationBuilder.DropTable(
                name: "NSX");

            migrationBuilder.DropTable(
                name: "BangQuyDoiDiem");
        }
    }
}
