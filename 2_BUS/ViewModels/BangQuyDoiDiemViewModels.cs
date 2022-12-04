using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.ViewModels
{
    public class BangQuyDoiDiemViewModels
    {
        public Guid Id { get; set; }
        public string? Ten { get; set; }
        public decimal? TyLeQuyDoi { get; set; }
        public string? TrangThai { get; set; }
        public Guid? IdKH { get; set; }
        public string? STD { get; set; }
        public int? Tong { get; set; }

    }
}
