using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Models
{
    [Table("BangQuyDoiDiem")]
    public class QuyDoiDiem
    {
        public QuyDoiDiem()
        {
            LichSuDiemTieuDungs = new HashSet<LichSuDiemTieuDung>();
        }
        [Key]
        public Guid Id { get; set; }
        public string? Ten { get; set; }
        public decimal? TyLeQuyDoi { get; set; }
        public string? TrangThai { get; set; }
        public virtual ICollection<LichSuDiemTieuDung> LichSuDiemTieuDungs { get; set; }
    }
}
