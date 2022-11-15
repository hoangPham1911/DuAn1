using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IServices
{
    public interface IHoaDonService
    {
        string ThemHoaDon(ThemHoaDonModels Hoadonnew);
        string SuaHoaDon(SuaHoaDonModels Hoadonold);
        string XoaHoaDon(SuaHoaDonModels Hoadonold);
        List<ThemHoaDonModels> GetAllHoaDonDB();
        List<ThemHoaDonModels> TimKiem(string MaHoaDon);

    }
}
