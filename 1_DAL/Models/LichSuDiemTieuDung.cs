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
        public DateTime NgaySuDung { get; set; }
        public int SoDiemTieuDung { get; set; }
        public int TrangThai { get; set; }
        public Guid IdKhachHang { get; set; }

        [ForeignKey(nameof(IdKhachHang))]
        public virtual KhachHang IdKhachHangNavigation { get; set; }
    }
}
