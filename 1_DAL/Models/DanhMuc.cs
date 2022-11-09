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
    [Table("DanhMuc")]
    [Index(nameof(Ma), Name = "UQ_DanhMuc", IsUnique = true)]
    public partial class DanhMuc
    {
        public DanhMuc()
        {
            KieuDanhMucs = new HashSet<KieuDanhMuc>();
        }
        [Key]
        [Required]
        public Guid Id { get; set; }
        [StringLength(30)]
        public string Ma { get; set; }
        [StringLength(30)]  

        public string Ten { get; set; }

        public virtual ICollection<KieuDanhMuc> KieuDanhMucs { get; set; }

    }
}
