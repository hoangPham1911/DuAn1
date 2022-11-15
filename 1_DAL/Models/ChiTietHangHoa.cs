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

    [Table("ChiTietSP")]
    public partial class ChiTietHangHoa
    {
        public ChiTietHangHoa()
        {
            HoaDonChiTiets = new HashSet<HoaDonChiTiet>();
            SaleChiTiets = new HashSet<SaleChiTiet>();
        }

        [Key]
        public Guid Id { get; set; }
        [Column("IdSP")]
        public Guid? IdSp { get; set; }
        public Guid? IdQuocGia { get; set; }
        public Guid? IdLoaiGiay { get; set; }
        [Column("IdDongSP")]
        public Guid? IdSizeGiay { get; set; }

        public Guid? IdAnh { get; set; }
        public Guid? IdChatLieu { get; set; }

        [Column("NamBH")]
        public int? NamBh { get; set; }
        [StringLength(50)]
        public string MoTa { get; set; }
        public int? SoLuongTon { get; set; }
        [Column(TypeName = "decimal(20, 0)")]
        public decimal? GiaNhap { get; set; }
        [Column(TypeName = "decimal(20, 0)")]
        public decimal? GiaBan { get; set; }

        [ForeignKey(nameof(IdSizeGiay))]
        //  [InverseProperty(nameof(SizeGiay.ChiTietHangHoas))]
        public virtual SizeGiay IdSizeNavigation { get; set; }

        [ForeignKey(nameof(IdLoaiGiay))]
        //  [InverseProperty(nameof(LoaiGiay.ChiTietHangHoas))]
        public virtual LoaiGiay IdMauSacNavigation { get; set; }

        [ForeignKey(nameof(IdChatLieu))]
        //   [InverseProperty(nameof(ChatLieu))]
        public virtual ChatLieu IdChatLieuNavigation { get; set; }

        [ForeignKey(nameof(IdAnh))]
        //   [InverseProperty(nameof(ChatLieu))]
        public virtual Anh IdAnhNavigation { get; set; }

        [ForeignKey(nameof(IdQuocGia))]
        public virtual QuocGia IdQuocGiaNavigation { get; set; }

        // tham chiếu tới bảng cha
        [ForeignKey(nameof(IdSp))]
        //   [InverseProperty(nameof(HangHoa.ChiTietSps))]
        public virtual HangHoa IdSpNavigation { get; set; } // Thuộc tính điều hướng tham chiếu

        public virtual ICollection<SaleChiTiet> SaleChiTiets { get; set; }
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }
    }
}
