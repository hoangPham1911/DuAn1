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
    [Table("ChatLieu")]
    [Index(nameof(Ma), Name = "UQ_ChatLieu", IsUnique = true)]  
    public partial class ChatLieu
    {
        public ChatLieu()
        {
            ChiTietHangHoas = new HashSet<ChiTietHangHoa>();
        }
       

        [Key]
        public Guid Id { get; set; }


        [StringLength(20)]
        public string Ma { get; set; }
        [StringLength(30)]
        public string Ten { get; set; }

        public int TrangThai { get; set; }

        [InverseProperty(nameof(ChiTietHangHoa.IdChatLieuNavigation))]
        public virtual ICollection<ChiTietHangHoa> ChiTietHangHoas { get; set; }  // tham chieu tap hop doi tuong phan nhieu
    }
}
