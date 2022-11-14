using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Models
{
    [Table("SaleChiTiet")]

    public partial class SaleChiTiet
    {
        public SaleChiTiet()
        {

        }
        [Key]
        [Required]
        public Guid IdSale { get; set; }
        [Key]
        [Required]
        public Guid IdChiTietHangHoa { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }

        [ForeignKey(nameof(IdSale))]
        public virtual Sale SaleNavigation { get; set; }

        [ForeignKey(nameof(IdChiTietHangHoa))]
        public virtual ChiTietHangHoa ChiTietHangHoaNavigation { get; set; }
    }
}