using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.ViewModels
{
    public class HoaDonChiTietViewModel
    {
        public Guid IdHoaDon { get; set; }
        public string Name { get; set; }
        public Guid IdChiTietSp { get; set; }
        public int? SoLuong { get; set; }
        public decimal? DonGia { get; set; }
        public decimal? ThanhTien { get; set; }
        public int TrangThai { get; set; }
        public decimal? GiamGia { get; set; }


    }
}
