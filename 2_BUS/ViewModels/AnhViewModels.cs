using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.ViewModels
{
    public class AnhViewModels
    {
        public Guid ID { get; set; }
        public string MaAnh { get; set; }
        public string? Ten { get; set; }
        public string? DuongDan { get; set; }
        public int TrangThai { get; set; }
    }
}
