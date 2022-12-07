using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Models
{
    [Table("SizeGiay")]
    [Index(nameof(Ma), Name = "UQ_SizeGiay", IsUnique = true)]
    public partial class SizeGiay
    {
        public SizeGiay()
        {
            ChiTietHangHoas = new HashSet<ChiTietHangHoa>();
        }
        [Key]
        public Guid Id { get; set; }
        [StringLength(20)]
        public string Ma { get; set; }
        [StringLength(30)]
        public int SoSize { get; set; }

        public int TrangThai { get; set; }
        public virtual ICollection<ChiTietHangHoa> ChiTietHangHoas { get; set; }
    }
}
