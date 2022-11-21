using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.ViewModels
{
    public class KieuDanhMucViewModels
    {
        public string TenDM { get; set; }
        public string TenHH { get; set; }
        public Guid? IdDanhMuc { get; set; }
        public Guid? IdHangHoa { get; set; }
        public int TheLoaiGioiTinh { get; set; }
    }
}
