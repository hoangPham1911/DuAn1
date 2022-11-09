using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _1_DAL.Models
{
    [Table("LoaiGiay")]
    [Index(nameof(Ma), Name = "UQ_LoaiGiay", IsUnique = true)]
    public class LoaiGiay
    {
        public LoaiGiay()
        {
            ChiTietHangHoas = new HashSet<ChiTietHangHoa>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(20)]
        public string Ma { get; set; }
        [StringLength(30)]
        public string Ten { get; set; }

      //  [InverseProperty(nameof(ChiTietHangHoa.IdMauSacNavigation))]
        public virtual ICollection<ChiTietHangHoa> ChiTietHangHoas { get; set; }
    }
}
