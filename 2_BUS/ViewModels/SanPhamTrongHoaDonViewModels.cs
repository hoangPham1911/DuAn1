using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.ViewModels
{
    public class SanPhamTrongHoaDonViewModels
    {
        public Guid IdHoaDon { get; set; }
        public Guid IdSpCt { get; set; }
        public decimal? DonGia { get; set; }
        public int? SoLuong { get; set; }
        public decimal? ThanhTien { get; set; }
        public string MaSP { get; set; }
        public string TenSp { get; set; }
    }
}
