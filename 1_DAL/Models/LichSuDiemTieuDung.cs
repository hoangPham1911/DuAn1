using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Models
{
    [Table("LichSuDiemTieuDung")]
    public partial class LichSuDiemTieuDung
    {
        public LichSuDiemTieuDung()
        {
            
        }
        [Key]
        public Guid IdLichSuDiem { get; set; }
        public DateTime? NgaySuDung { get; set; }
        public int? SoDiemTieuDung { get; set; }
        public int? SoDiemCong { get; set; }
        public int? TrangThai { get; set; }
        public Guid? IdViDiem { get; set; }
        public Guid? IdHoaDon { get; set; }
       

        [ForeignKey(nameof(IdViDiem))]
        [InverseProperty(nameof(ViDiem.LichSuDiemTieuDungs))]
        public virtual ViDiem IdViDiemNavigation { get; set; }

        [ForeignKey(nameof(IdHoaDon))]
        [InverseProperty(nameof(HoaDon.LichSuDiems))]
        public virtual HoaDon IdHoaDonNavigation { get; set; }
    }
}
