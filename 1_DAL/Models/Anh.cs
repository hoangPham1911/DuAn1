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
    [Table("Anh")]
    [Index(nameof(MaAnh), Name = "UQ_Anh", IsUnique = true)]
    public partial class Anh
    {
        public Anh()
        {
            ChiTietHangHoas = new HashSet<ChiTietHangHoa>();
        }


        [Key]
        public Guid ID { get; set; }


        [StringLength(20)]
        public string MaAnh { get; set; }
        [StringLength(30)]
        public string TenAnh { get; set; }

        public int TrangThai { get; set; }

        //   [InverseProperty(nameof(ChiTietHangHoa.IdChatLieuNavigation))]
        public virtual ICollection<ChiTietHangHoa> ChiTietHangHoas { get; set; }  // tham chieu tap hop doi tuong phan nhieu
    }
}
