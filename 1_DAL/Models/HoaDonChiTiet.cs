using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Models
{
    [Table("HoaDonChiTiet")]
    public partial class HoaDonChiTiet
    {
        public HoaDonChiTiet()
        {

        }
        [Key]
        [Required]
        public Guid IdHoaDon { get; set; }
        [Key]
        [Required]
        [Column("IdChiTietSP")]
        public Guid IdChiTietSp { get; set; }
        public int? SoLuong { get; set; }
        [Column(TypeName = "decimal(20, 0)")]
        public decimal? ThanhTien { get; set; }

        public decimal? DonGia { get; set; }

        [ForeignKey(nameof(IdChiTietSp))]
     //   [InverseProperty(nameof(ChiTietHangHoa.HoaDonChiTiets))]
        public virtual ChiTietHangHoa IdChiTietSpNavigation { get; set; }
        [ForeignKey(nameof(IdHoaDon))]
   //     [InverseProperty(nameof(HoaDon.HoaDonChiTiets))]
        public virtual HoaDon IdHoaDonNavigation { get; set; }
    }
}
