using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.ViewModels
{
    public class ThemKhachHangViewModels
    {
        

        public string Ma { get; set; }

        public string Ten { get; set; }
        public Guid? IdVi { get; set; }

        public string GioiTinh { get; set; }

        public string? Email { get; set; }
        public string? SoCCCD { get; set; }


        public DateTime? NamSinh { get; set; }

        public string Sdt { get; set; }

        public string DiaChi { get; set; }

        public int TrangThai { get; set; }

        public int DiemTichDiem { get; set; }
    }
}
