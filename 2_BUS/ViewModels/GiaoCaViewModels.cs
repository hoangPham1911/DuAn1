using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.ViewModels
{
    public class GiaoCaViewModels
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
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
        public int? Time { get; set; }
        public decimal? TongTienMatRut { get; set; }
        public int TrangThai { get; set; }
        public string StrTrangThai { get; set; }
        public string NhanVienTrongCa { get; set; }
        public string NhanVienCaTiep { get; set; }
    }
}
