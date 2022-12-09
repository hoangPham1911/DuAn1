using _1_DAL.Models;
using Microsoft.EntityFrameworkCore;

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
        public virtual DbSet<Voucher> Sales { get; set; }
        public virtual DbSet<Anh> Anhs { get; set; }
        public virtual DbSet<GiaoCa> GiaoCas { get; set; }
        public virtual DbSet<ViDiem> ViDiems { get; set; }
        public virtual DbSet<QuyDoiDiem> QuyDoiDiems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-I97RAVI\\SQLEXPRESS02;" +
            //"Initial Catalog=ManagerShoppingShose;Persist Security Info=True;User ID=linh123;Password=12345");
<<<<<<< HEAD
            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-FOR2JQI\\SQLEXPRESS;" +
            //"Initial Catalog=ManagerShoppingShose;Persist Security Info=True;User ID=hello;Password=hello");
=======
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-FOR2JQI\\SQLEXPRESS;" +
            "Initial Catalog=ManagerShoppingShose;Persist Security Info=True;User ID=hello;Password=hello");
>>>>>>> e352cc0be406909facdff49f39dd6463445d2f04
            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-3S50L70\\SQLEXPRESS;" +
            //"Initial Catalog=ManagerShoppingShose;Persist Security Info=True;User ID=hoangpham;Password=19112002");
            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-FOR2JQI\\SQLEXPRESS;" +
            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-I97RAVI\\SQLEXPRESS02;" +
            //"Initial Catalog=ManagerShoppingShose;Persist Security Info=True;User ID=linh123;Password=12345");
            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-3S50L70\\SQLEXPRESS;" +
            //"Initial Catalog=ManagerShoppingShose;Persist Security Info=True;User ID=hoangpham;Password=19112002");
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-PJLRIKK\\SQLEXPRESS;" +
            "Initial Catalog=ManagerShoppingShose;Persist Security Info=True;User ID=ph28227;Password=ph28227");
            //optionsBuilder.UseSqlServer("Data Source=KIRO\\SQLEXPRESS;" +
            //"Initial Catalog=ManagerShoppingShose;Persist Security Info=True;User ID=quannh;Password=123456");
            //optionsBuilder.UseSqlServer("Data Source=ADMIN-PC\\SQLEXPRESS;" +
            //"Initial Catalog=ManagerShoppingShose;Persist Security Info=True;User ID=quytv;Password=0123456789");
            //optionsBuilder.UseSqlServer("Data Source=SADBOY\\SQLEXPRESS;" +
            // "Initial Catalog=ManagerShoppingShose;Persist Security Info=True;User ID=ph27584;Password=123456");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

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
                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Ma).IsUnicode(false);
                entity.Property(e => e.Sdt).IsUnicode(false);
                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");
                entity.Property(e => e.Sdt).IsRequired(false);


            });
            modelBuilder.Entity<ChucVu>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Ma).IsUnicode(false);
                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

            });
            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.MaGiamGia).IsUnicode(false);
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
            modelBuilder.Entity<ViDiem>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
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
                entity.Property(e => e.SoTienQuyDoi).HasDefaultValueSql("((0))");
                entity.Property(e => e.SoDiemSuDung).HasDefaultValueSql("((0))");
                entity.Property(e => e.TongTienNvTrongCa).HasDefaultValueSql("((0))");

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

            });
            modelBuilder.Entity<LichSuDiemTieuDung>(entity =>
            {
                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");
                entity.Property(e => e.SoDiemCong).HasDefaultValueSql("((0))");
                entity.Property(e => e.SoDiemTieuDung).HasDefaultValueSql("((0))");

            });
        }
    }
}
