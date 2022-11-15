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

    [Table("SanPham")]
    [Index(nameof(Ma), Name = "UQ_SanPham", IsUnique = true)]
    public partial class HangHoa
    {
        public HangHoa()
        {
            ChiTietSps = new HashSet<ChiTietHangHoa>();
            KieuDanhMucs = new HashSet<KieuDanhMuc>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(20)]
        public string Ma { get; set; }
        [StringLength(30)]  
        public string Ten { get; set; }
        public int TrangThai { get; set; }

        public Guid? IdNsx { get; set; }

 //       [InverseProperty(nameof(ChiTietHangHoa.IdSpNavigation))]
        public virtual ICollection<ChiTietHangHoa> ChiTietSps { get; set; }

        [ForeignKey(nameof(IdNsx))]
    //    [InverseProperty(nameof(Nsx.HangHoas))]
        public virtual Nsx IdNsxNavigation { get; set; }

    //    [InverseProperty(nameof(KieuDanhMuc.IdDanhMucNavigation))]
        public virtual ICollection<KieuDanhMuc> KieuDanhMucs { get; set; }

    }
}
