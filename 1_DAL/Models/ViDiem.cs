using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Models
{

    [Table("ViDiem")]
    public class ViDiem
    {
        public ViDiem()
        {
            QuyDoiDiems = new HashSet<QuyDoiDiem>();
            LichSuDiemTieuDungs = new HashSet<LichSuDiemTieuDung>();
        }
        [Key]
        public Guid Id { get; set; }
        public int? TongDiem { get; set; }
        public int? TrangThai { get; set; }
        public Guid? IdKhachHang { get; set; }
        [InverseProperty(nameof(QuyDoiDiem.IdQuyDoiDiemNavigation))]
        public virtual ICollection<QuyDoiDiem> QuyDoiDiems { get; set; }

        [InverseProperty(nameof(LichSuDiemTieuDung.IdViDiemNavigation))]
        public virtual ICollection<LichSuDiemTieuDung> LichSuDiemTieuDungs { get; set; }
        public virtual KhachHang KhachHangs { get; set; }
    }
}

