using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.ViewModels
{
    public class ViDiemViewModel
    {
        public Guid Id { get; set; }
        public int? TongDiem { get; set; }
        public string? TrangThai { get; set; }
        public Guid? IdKhachHang { get; set; }
    }
}
