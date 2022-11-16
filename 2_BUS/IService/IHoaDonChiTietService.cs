using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IService
{
    public interface IHoaDonChiTietService
    {
        bool ThemHoaDonChiTiet(HoaDonChiTietViewModel Hoadonnew);
        bool SuaHoaDonChiTiet(HoaDonChiTietUpdateView Hoadonold);
        bool XoaHoaDonChiTiet(Guid Hoadonold);
        List<HoaDonChiTietViewModel> GetAllHoaDonDB();
    }
}
