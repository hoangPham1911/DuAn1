using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _1_DAL.Models
{
    [Table("KhachHang")]
    [Index(nameof(Ma), Name = "UQ_KhachHang", IsUnique = true)]
    public partial class KhachHang
    {
        public KhachHang()
        {
        }

        [Key]
        public Guid Id { get; set; }
        public Guid? IdVi { get; set; }
        [StringLength(20)]
        public string Ma { get; set; }
        [StringLength(30)]
        public string Ten { get; set; }
        [StringLength(30)]
        
        public string GioiTinh { get; set; }    

        public string? Email { get; set; }
        public string? SoCCCD { get; set; }    
        
        [Column(TypeName = "date")]
        public DateTime? NamSinh { get; set; }
        [StringLength(30)]
        public string Sdt { get; set; }
        [StringLength(100)]
        public string? DiaChi { get; set; }
        [StringLength(50)]
        public int TrangThai { get; set; }
     
        [ForeignKey(nameof(IdVi))]
        public virtual ViDiem ViDiems { get; set; }

    }
}
