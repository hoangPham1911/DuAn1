using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.ViewModels
{
    public class HoaDonChiTietThemViewModel
    {
        public Guid IdHoaDon { get; set; }

        public Guid IdChiTietSp { get; set; }
        public int? SoLuong { get; set; }

        public decimal? ThanhTien { get; set; }

        public decimal? GiamGia { get; set; }

     //   public Guid? IdKh { get; set; }

   //     public Guid? IdNv { get; set; }

        public string? Ma { get; set; }

        public int? TinhTrang { get; set; }

    }
}
