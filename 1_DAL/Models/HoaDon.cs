using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _1_DAL.Models
{
    [Table("HoaDon")]
    [Index(nameof(Ma), Name = "UQ_HoaDon", IsUnique = true)]
    public partial class HoaDon
    {
        public HoaDon()
        {
            HoaDonChiTiets = new HashSet<HoaDonChiTiet>();
            LichSuDiems = new HashSet<LichSuDiemTieuDung>();

        }

        [Key]
        public Guid Id { get; set; }
        [Column("IdKH")]
        public Guid? IdKh { get; set; }
        [Column("IdNV")]
        public Guid? IdNv { get; set; }
        [StringLength(20)]
        public string Ma { get; set; }
        [Column(TypeName = "date")]
        public DateTime? NgayTao { get; set; }
        [Column(TypeName = "date")]
        public DateTime? NgayThanhToan { get; set; }
        [Column(TypeName = "date")]
        public DateTime? NgayShip { get; set; }
        [Column(TypeName = "date")]
        public DateTime? NgayNhan { get; set; }
        public int? TinhTrang { get; set; }
        [StringLength(50)]
        public decimal Thue { get; set; }
        [StringLength(100)]
        public string? SDTShip { get; set; }
        public string? TenShip { get; set; }
        public decimal ? SoTienQuyDoi { get; set; }
        public int? SoDiemSuDung { get; set; }
        public decimal? PhanTramGiamGia { get; set; }

        [ForeignKey(nameof(IdNv))]
        [InverseProperty(nameof(NhanVien.HoaDons))]
        public virtual NhanVien IdNvNavigation { get; set; }

        [ForeignKey(nameof(IdKh))]
        [InverseProperty(nameof(KhachHang.HoaDons))]
        public virtual KhachHang IdKhNavigation { get; set; }

        [InverseProperty(nameof(HoaDonChiTiet.IdHoaDonNavigation))]
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        [InverseProperty(nameof(LichSuDiemTieuDung.IdHoaDonNavigation))]
        public virtual ICollection<LichSuDiemTieuDung> LichSuDiems { get; set; }    

    }
}
