using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.ViewModels
{
    public class SaleSuaViewModel
    {
        public Guid Id { get; set; }
        public string MaGiamGia { get; set; }
        public string TenChuongTrinh { get; set; }
        public int TrangThai { get; set; }
    }
}
