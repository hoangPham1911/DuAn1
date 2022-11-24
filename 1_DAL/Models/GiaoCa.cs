using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _1_DAL.Models
{
    [Table("GiaoCa")]
    [Index(nameof(Ma), Name = "UQ_GiaoCa", IsUnique = true)]
    public class GiaoCa
    {
        public GiaoCa()
        {

        }
        [Key]
        public Guid Id { get; set; }
        [StringLength(20)]
        public string Ma { get; set; }
        [StringLength(50)]
        public DateTime ThoiGianNhanCa { get; set; }
        public DateTime ThoiGianGiaoCa { get; set; }
        public Guid? IdNvNhanCaTiep { get; set; }
        public Guid? IdNvTrongCa { get; set; }
        public decimal? TienBanDau { get; set; }
        public decimal? TongTienTrongCa { get; set; }
        public decimal? TongTienMat { get; set; }
        public decimal? TongTienKhac { get; set; }
        public decimal? TienPhatSinh { get; set; }
        public string? GhiChuPhatSinh { get; set; }
        public decimal? TongTienCaTruoc { get; set; }
        public DateTime? Time { get; set; }
        public decimal? TongTienMatRut { get; set; }

        public int TrangThai { get; set; }
        [ForeignKey(nameof(IdNvNhanCaTiep))]
        [InverseProperty(nameof(NhanVien.GiaoCas))]
        public virtual NhanVien NhanVienNavigation { get; set; }
    }
}
