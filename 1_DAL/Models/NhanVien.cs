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
    [Table("NhanVien")]
    [Index(nameof(Ma), Name = "UQ_NhanVien", IsUnique = true)]
    public partial class NhanVien
    {
        public NhanVien()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(20)]
        public string Ma { get; set; }
        [StringLength(30)]
        public string Ho { get; set; }
        [StringLength(30)]
        public string TenDem { get; set; }
        [StringLength(30)]
        public string Ten { get; set; }
        [StringLength(30)]
        public string GioiTinh { get; set; }
        [Column(TypeName = "date")]
        public DateTime? NamSinh { get; set; }
        [StringLength(100)]
        public string QueQuan { get; set; }
        [StringLength(30)]
        public string Sdt { get; set; }
        public string MatKhau { get; set; }

        public string Email { get; set; }

        public string CMND { get; set; }

        [Column("IdCV")]
        public Guid? IdCv { get; set; }
        [Column("IdGuiBC")]
        public int? TrangThai { get; set; }

        [Column("img", TypeName = "image")]
        public byte[]? Anh { get; set; }
        public string? MaOTP { get; set; }

        [ForeignKey(nameof(IdCv))]
        [InverseProperty(nameof(ChucVu.NhanViens))]
        public virtual ChucVu IdCvNavigation { get; set; }
        //   [InverseProperty(nameof(HoaDon.IdNvNavigation))]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

    }
}
