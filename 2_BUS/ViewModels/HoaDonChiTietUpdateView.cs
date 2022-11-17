using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.ViewModels
{
    public class HoaDonChiTietUpdateView
    {
        public Guid IdHoaDon { get; set; }

        public Guid IdChiTietSp { get; set; }
        public int? SoLuong { get; set; }

        public decimal? ThanhTien { get; set; }

        public decimal? GiamGia { get; set; }
    }
}
