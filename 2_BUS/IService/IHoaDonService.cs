using _1_DAL.Models;
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
        string XoaHoaDon(Guid Hoadonold);
        List<SuaHoaDonModels> GetAllHoaDonDB();
        public Guid GetIdHoaDon(ThemHoaDonModels IdHoaDon);
        public List<SuaHoaDonModels> Get();
        List<HoaDon> timkiemHoadonTheoMa(string MaHoaDon);
        public string UpdateSoTienNvTrongCa(SuaHoaDonModels Hoadonold);
    }
}
