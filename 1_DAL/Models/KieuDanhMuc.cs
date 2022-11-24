using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Models
{
    [Table("KieuDanhMuc")]
    public partial class KieuDanhMuc
    {
        public Guid? IdDanhMuc { get; set; }    
        public Guid? IdHangHoa { get; set; }
        public int TheLoaiGioiTinh { get; set; }

        public int TrangThai { get; set; }
        [ForeignKey(nameof(IdDanhMuc))]
        [InverseProperty(nameof(DanhMuc.KieuDanhMucs))]
        public virtual DanhMuc IdDanhMucNavigation { get; set; }

        [ForeignKey(nameof(IdHangHoa))]
        [InverseProperty(nameof(HangHoa.KieuDanhMucs))]
        public virtual HangHoa IdHangHoaNavigation { get; set; }
    }
}
