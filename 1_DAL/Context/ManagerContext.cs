using _1_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Context
{
    public class ManagerContext : DbContext
    {
        public ManagerContext()
        {

        }
        public ManagerContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<ChiTietHangHoa> ChiTietSps { get; set; } // cái này dùng để tạo ra 1 cái bảng ChiTietHangHoa trong database
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiGiay> LoaiGiays { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<Nsx> Nsxes { get; set; }
        public virtual DbSet<HangHoa> SanPhams { get; set; }
        public virtual DbSet<SizeGiay> SizeGiays { get; set; }
        public virtual DbSet<QuocGia> QuocGias { get; set; }
        public virtual DbSet<KieuDanhMuc> KieuDanhMucs { get; set; }
        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<ChatLieu> ChatLieus { get; set; }
        public virtual DbSet<LichSuDiemTieuDung> LichSuDiemTieuDungs { get; set; }
        public virtual DbSet<SaleChiTiet> SaleChiTiets { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Anh> Anhs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-3S50L70\\SQLEXPRESS;" +
            "Initial Catalog=ManagerShoppingShose;Persist Security Info=True;User ID=hoangpham;Password=19112002");
            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-FOR2JQI\\SQLEXPRESS;" +
            //"Initial Catalog=ManagerShoppingShose;Persist Security Info=True;User ID=hello;Password=hello");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<SaleChiTiet>(entity =>
            {
                entity.HasKey(e => new { e.IdChiTietHangHoa, e.IdSale });

            });

            modelBuilder.Entity<HoaDonChiTiet>(entity =>
            {
                entity.HasKey(e => new { e.IdChiTietSp, e.IdHoaDon });   // de tranh cho cac cap gtri trung nhau
                entity.Property(e => e.GiamGia).HasDefaultValueSql("((0))");
                entity.Property(e => e.SoLuong).HasDefaultValueSql("((0))");
                entity.HasOne(d => d.IdHoaDonNavigation)
                      .WithMany(g => g.HoaDonChiTiets)
                      .OnDelete(DeleteBehavior.ClientSetNull); // phương thức OnDelete với tham số DeleteBehavior
                entity.HasOne(d => d.IdChiTietSpNavigation)
                      .WithMany(g => g.HoaDonChiTiets)
                      .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<KieuDanhMuc>(entity =>
            {
                entity.HasKey(e => new { e.IdDanhMuc, e.IdHangHoa });

            });
            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Ma).IsUnicode(false);
                entity.Property(e => e.Sdt).IsUnicode(false);
                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");
           


            });
            modelBuilder.Entity<ChucVu>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Ma).IsUnicode(false);
                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

            });
            modelBuilder.Entity<HangHoa>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Ma).IsUnicode(false);
                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");


            });
            modelBuilder.Entity<LoaiGiay>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Ma).IsUnicode(false);
                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

            });
            modelBuilder.Entity<Nsx>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Ma).IsUnicode(false);
                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

            });
            modelBuilder.Entity<Anh>(entity =>
            {
                entity.Property(e => e.ID).HasDefaultValueSql("(newid())");
                entity.Property(e => e.MaAnh).IsUnicode(false);
                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");
               
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Ma).IsUnicode(false);
                entity.Property(e => e.TinhTrang).HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<ChiTietHangHoa>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.SoLuongTon).HasDefaultValueSql("((0))");
                entity.Property(e => e.NamBh).HasDefaultValueSql("((0))");
                entity.Property(e => e.GiaBan).HasDefaultValueSql("((0))");
                entity.Property(e => e.GiaNhap).HasDefaultValueSql("((0))");
         

            });
            modelBuilder.Entity<DanhMuc>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Ma).IsUnicode(false);
                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");
                entity.Property(e => e.IdDanhMucKhac).IsRequired(false);

            });
            modelBuilder.Entity<SizeGiay>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Ma).IsUnicode(false);
                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.Property(e => e.SoSize).HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<ChatLieu>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Ma).IsUnicode(false);
                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");


            });
            modelBuilder.Entity<QuocGia>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Ma).IsUnicode(false);
                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");


            });
            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Ma).IsUnicode(false);
                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");
                entity.Property(e => e.MaOTP).IsRequired();


            });
            modelBuilder.Entity<LichSuDiemTieuDung>(entity =>
            {
                entity.Property(e => e.IdKhachHang).IsRequired();
                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

            });
        }
    }
}
