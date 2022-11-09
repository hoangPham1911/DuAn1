using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Models
{

    [Table("QuocGia")]
    [Index(nameof(Ma), Name = "UQ_QuocGia", IsUnique = true)]
    public partial class QuocGia
    {
        public QuocGia()
        {
            HangHoaChiTiet = new HashSet<ChiTietHangHoa>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(20)]
        public string Ma { get; set; }
        [StringLength(30)]
        public string Ten { get; set; }

        public int TrangThai { get; set; }

   //     [InverseProperty(nameof(ChiTietHangHoa.IdQuocGiaNavigation))]
        public virtual ICollection<ChiTietHangHoa> HangHoaChiTiet { get; set; }
    }
}


