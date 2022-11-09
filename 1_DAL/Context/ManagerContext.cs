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
            //public ManagerContext(DbContextOptions<ManagerContext> options) : base(options)
            //{

            //}

        public virtual DbSet<ChiTietHangHoa> ChiTietSps { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiGiay> MauSacs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<Nsx> Nsxes { get; set; }
        public virtual DbSet<HangHoa> SanPhams { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-3S50L70\\SQLEXPRESS;" +
            "Initial Catalog=ManagerShoppingShose;Persist Security Info=True;User ID=hoangpham;Password=19112002");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<HoaDonChiTiet>(entity =>
            {
                entity.HasKey(e => new { e.IdChiTietSp, e.IdHoaDon });
                entity.Property(e => e.DonGia).HasDefaultValueSql("((0))");
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
     
            });
            modelBuilder.Entity<ChucVu>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Ma).IsUnicode(false);
            });
            modelBuilder.Entity<HangHoa>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Ma).IsUnicode(false);
      
            });
            modelBuilder.Entity<LoaiGiay>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Ma).IsUnicode(false);
            });
            modelBuilder.Entity<Nsx>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Ma).IsUnicode(false);
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
        }

    }
}
