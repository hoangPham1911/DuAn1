using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.ViewModels
{
    public class SuaHoaDonModels
    {
        public Guid IdHoaDon { get; set; }

        public Guid? IdKh { get; set; }
        //public string TenKhachHang { get; set; }
        public Guid? IdNv { get; set; }
        //public string TenNhanVien { get; set; }
        public string? Ma { get; set; }
        public DateTime? NgayTao { get; set; }

        public DateTime? NgayThanhToan { get; set; }

        public DateTime? NgayShip { get; set; }

        public DateTime? NgayNhan { get; set; }

        public int? TinhTrang { get; set; }

        //public decimal Thue { get; set; }
        public string? SDTShip { get; set; }
        public string? TenShip { get; set; }
        public decimal? SoTienQuyDoi { get; set; }
        public int? SoDiemSuDung { get; set; }
        public string TenKhachHang { get; set; }

        public decimal TongSoTienTrongCa { get; set; }

    }
}

