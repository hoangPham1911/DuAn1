using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.ViewModels
{
    public class SaleViewModel
    {
        public Guid Id { get; set; }
        public string MaGiamGia { get; set; }
        public string TenChuongTrinh { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public decimal SoTienGiamGia { get; set; }
        public int TrangThai { get; set; }
    }
}
