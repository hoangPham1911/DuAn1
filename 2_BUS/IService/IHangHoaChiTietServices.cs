using _1_DAL.Models;
using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IService
{
    public interface IHangHoaChiTietServices
    {
        bool ThemHangHoaChiTiet(HangHoaChiTietThemViewModels HangHoa);
        bool SuaHangHoaChiTiet(HangHoaChiTietUpdateViewModels HangHoa);
        bool XoaHangHoaChiTiet(Guid idHangHoa);
        public List<HangHoaChiTietViewModels> GetAllHoaDonDB();
    }
}
