using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.ViewModels
{
    public class LichSuDiemViewModels
    {
        public Guid IdLichSuDiem { get; set; }
        public DateTime NgaySuDung { get; set; }
        public int SoDiemTieuDung { get; set; }
        public int SoDiemCong { get; set; }

        public int TrangThai { get; set; }
        public Guid? IdQuyDoiDiem { get; set; }
        public Guid? IdViDiem { get; set; }
        public Guid? IdHoaDon { get; set; }
    }
}
